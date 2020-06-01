using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemtemTracker.Data;

namespace TemtemTracker.Controllers
{
    class DatabaseController
    {

        private static DatabaseController instance = null;
        private static readonly string dbPath;
        //When updating the days database we want to check if the current date here
        //Matches the date of the playtime being provided
        //If it does not we either haven't inserted this day already
        //Or the day ticked over at midnight and we're inserting a new day
        private static DateTime currentPlaytimeDate=DateTime.MinValue;
        

        //Strings used for database work

        private static readonly string CREATE_ENCOUNTER_TABLE = @"CREATE TABLE IF NOT EXISTS
                                                                  encounters(
                                                                              id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                              date TEXT,
                                                                              temtem1 TEXT,
                                                                              temtem2 TEXT
                                                                  )"; //Date as text is ISO8601

        private static readonly string CREATE_DAY_TABLE = @"CREATE TABLE IF NOT EXISTS
                                                            days(
                                                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                date TEXT,
                                                                time INTEGER
                                                            )"; //Date as text is ISO8601

        private static readonly string CHECK_DAY = @"SELECT id FROM days WHERE date=@date";

        private static readonly string GET_PLAYTIME_DAY = @"SELECT time FROM days WHERE date=@date";

        private static readonly string INSERT_DAY = @"INSERT INTO days (date, time) VALUES (@date, @time)";

        private static readonly string UPDATE_DAY = @"UPDATE days SET time=@time WHERE date==@date";

        private static readonly string INSERT_ENCOUNTER = @"INSERT INTO encounters (date, temtem1, temtem2) VALUES (@date, @temtem1, @temtem2)";

        private static readonly string GET_SINGLE_ENCOUNTERS = @"SELECT strftime('%w', date), COUNT(*)
                                                                 FROM encounters
                                                                 WHERE temtem2 == ''
                                                                 AND date >=@weekStart
                                                                 AND date <=@weekEnd
                                                                 GROUP BY strftime('%w', date)";

        private static readonly string GET_DOUBLE_ENCOUNTERS = @"SELECT strftime('%w', date), COUNT(*)
                                                                 FROM encounters
                                                                 WHERE temtem2 != ''
                                                                 AND date >=@weekStart
                                                                 AND date <=@weekEnd
                                                                 GROUP BY strftime('%w', date)";

        private static readonly string GET_DAILY_TOTALS = @"SELECT strftime('%w', date), time
                                                                 FROM days
                                                                 WHERE date >=@weekStart
                                                                 AND date <=@weekEnd";

        //Lock for thread-safety
        private static readonly object padlock = new object();
        private static readonly object dblock = new object();

        public static DatabaseController Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DatabaseController();
                    }
                    return instance;
                }
            }
        }

        static DatabaseController()
        {
            dbPath = @"URI=file:" + Application.StartupPath + @"\" + Paths.DATABASE_PATH;

            Task dbTask = Task.Factory.StartNew(() =>
            {
                //Create the table
                lock (dblock)
                {
                    using (SQLiteConnection con = new SQLiteConnection(dbPath))
                    {
                        con.Open();

                        using (SQLiteCommand cmd = new SQLiteCommand(CREATE_ENCOUNTER_TABLE, con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SQLiteCommand cmd = new SQLiteCommand(CREATE_DAY_TABLE, con))
                        {
                            cmd.ExecuteNonQuery();
                        }

                    }
                }
            });
        }

        public void LogEncounter(List<string> TemtemNames)
        {
            Task dbTask = Task.Factory.StartNew(() => {
                lock (dblock)
                {
                    using (SQLiteConnection con = new SQLiteConnection(dbPath))
                    {
                        con.Open();

                        using (SQLiteCommand cmd = new SQLiteCommand(INSERT_ENCOUNTER, con))
                        {
                            cmd.Parameters.AddWithValue("@date", GetCurrentTimeISO8601());
                            cmd.Parameters.AddWithValue("@temtem1", TemtemNames[0]);
                            if (TemtemNames.Count == 2)
                            {
                                cmd.Parameters.AddWithValue("@temtem2", TemtemNames[1]);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@temtem2", "");
                            }
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            });
        }

        public Task<long> GetPlaytimeDay(DateTime day)
        {
            Task<long> dbTask = Task.Factory.StartNew<long>(() => {
                lock (dblock)
                {
                    using(SQLiteConnection con = new SQLiteConnection(dbPath))
                    {
                        con.Open();

                        using(SQLiteCommand cmd = new SQLiteCommand(GET_PLAYTIME_DAY, con))
                        {
                            cmd.Parameters.AddWithValue("@date", GetTimeISO8601(day));
                            try
                            {
                                object result = cmd.ExecuteScalar();
                                result = (result == DBNull.Value) ? null : result;
                                if (result == null)
                                {
                                    return 0;
                                }
                                else
                                {
                                    return (long)result;
                                }
                            }
                            catch
                            {
                                //This happens if the table doesn't exist yet
                                //Should only happen here because this is called on initialization
                                //Everything else should already be executed by the time it is called
                                return 0;
                            }
                        }
                    }
                } 
            });

            return dbTask;
        }

        public Task<TrackingStatistics> GetEncounterStatistics(Tuple<DateTime, DateTime> week)
        {
            Task<TrackingStatistics> dbTask = Task.Factory.StartNew<TrackingStatistics>(() => {
                lock (dblock)
                {
                    TrackingStatistics ts = new TrackingStatistics
                    {
                        dailyEncounters = new List<DailyEncounterStatistics>(),
                        dailyPlaytime = new List<DailyPlaytimeStatistics>()
                    };
                    for (int i = 0; i < 7; i++)
                    {
                        ts.dailyEncounters.Add(new DailyEncounterStatistics() {
                            date = week.Item1.AddDays(i),
                            totalTemtemEncountered = 0
                        });
                        ts.dailyPlaytime.Add(new DailyPlaytimeStatistics()
                        {
                            date = week.Item1.AddDays(i),
                            totalPlaytimeMinutes = 0
                        });
                    }
                    using (SQLiteConnection con = new SQLiteConnection(dbPath))
                    {
                        con.Open();
                        //Get double encounters
                        using (SQLiteCommand cmd = new SQLiteCommand(GET_DOUBLE_ENCOUNTERS, con))
                        {
                            cmd.Parameters.AddWithValue("@weekStart", GetTimeISO8601(week.Item1));
                            cmd.Parameters.AddWithValue("@weekEnd", GetTimeISO8601(week.Item2));
                            using (SQLiteDataReader rdr = cmd.ExecuteReader())
                            {
                                while (rdr.Read())
                                {
                                    int.TryParse(rdr.GetString(0), out int dayOfWeek);
                                    dayOfWeek = dayOfWeek == 0 ? 6 : dayOfWeek - 1; //Move everything back by 1, set Sunday last day
                                    int doubleBattles = rdr.GetInt32(1);
                                    ts.dailyEncounters[dayOfWeek].totalTemtemEncountered += doubleBattles*2;
                                    ts.doubleBattlesTotal += doubleBattles;
                                }
                            }
                        }
                        //Get single encounters
                        using (SQLiteCommand cmd = new SQLiteCommand(GET_SINGLE_ENCOUNTERS, con))
                        {
                            cmd.Parameters.AddWithValue("@weekStart", GetTimeISO8601(week.Item1));
                            cmd.Parameters.AddWithValue("@weekEnd", GetTimeISO8601(week.Item2));
                            using (SQLiteDataReader rdr = cmd.ExecuteReader())
                            {
                                while (rdr.Read())
                                {
                                    int.TryParse(rdr.GetString(0), out int dayOfWeek);
                                    dayOfWeek = dayOfWeek == 0 ? 6 : dayOfWeek - 1; //Move everything back by 1, set Sunday last day
                                    int singleBattles = rdr.GetInt32(1);
                                    ts.dailyEncounters[dayOfWeek].totalTemtemEncountered += singleBattles;
                                    ts.singleBattlesTotal += singleBattles;
                                }
                            }
                        }

                        //Get session totaly
                        using(SQLiteCommand cmd = new SQLiteCommand(GET_DAILY_TOTALS, con))
                        {
                            cmd.Parameters.AddWithValue("@weekStart", GetTimeISO8601(week.Item1));
                            cmd.Parameters.AddWithValue("@weekEnd", GetTimeISO8601(week.Item2));
                            using(SQLiteDataReader rdr = cmd.ExecuteReader())
                            {
                                while (rdr.Read())
                                {
                                    int.TryParse(rdr.GetString(0), out int dayOfWeek);
                                    dayOfWeek = dayOfWeek == 0 ? 6 : dayOfWeek - 1; //Move everything back by 1, set Sunday last day
                                    int sessionTime = rdr.GetInt32(1);
                                    ts.dailyPlaytime[dayOfWeek].totalPlaytimeMinutes = sessionTime/60000;
                                }
                            }
                        }
                    }
                    return ts;
                }
            });
            return dbTask;
        }

        public void UpdatePlaytimeLog(DateTime date, long timePlayed)
        {
            Task dbTask = Task.Factory.StartNew(() => {
                lock (dblock)
                {
                    using (SQLiteConnection con = new SQLiteConnection(dbPath))
                    {
                        con.Open();

                        if (currentPlaytimeDate != date)
                        {
                            //Check if the current date is in the database
                            using(SQLiteCommand cmd = new SQLiteCommand(CHECK_DAY, con))
                            {
                                cmd.Parameters.AddWithValue("@date", GetTimeISO8601(date));
                                object result = cmd.ExecuteScalar();
                                result = (result == DBNull.Value) ? null : result;
                                if (result == null)
                                {
                                    //If the result is null this day isn't in the database, insert it
                                    InsertNewDay(con, date, timePlayed);
                                }
                                else
                                {
                                    //Otherwise the day is in the database, set up our variables
                                    currentPlaytimeDate = date;
                                    UpdateCurrentDay(con, date, timePlayed);
                                }
                            }
                        }
                        else
                        {
                            UpdateCurrentDay(con, date, timePlayed);
                        }
                        
                    }
                }
            });
        }

        private void InsertNewDay(SQLiteConnection con, DateTime date, long timePlayed)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(INSERT_DAY, con))
            {
                cmd.Parameters.AddWithValue("@date", GetTimeISO8601(date));
                cmd.Parameters.AddWithValue("@time", timePlayed);
                cmd.ExecuteNonQuery();
                currentPlaytimeDate = date;
            }
        }

        private void UpdateCurrentDay(SQLiteConnection con, DateTime date, long timePlayed)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(UPDATE_DAY, con))
            {
                cmd.Parameters.AddWithValue("@time", timePlayed);
                cmd.Parameters.AddWithValue("@date", GetTimeISO8601(date));
                cmd.ExecuteNonQuery();
            }
        }

        private string GetCurrentTimeISO8601()
        {
            return DateTime.UtcNow.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
        }

        private string GetTimeISO8601(DateTime time)
        {
            return time.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
