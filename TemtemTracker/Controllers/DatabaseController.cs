using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Text;
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

        //Strings used for database work

        private static readonly string CREATE_SESSION_TABLE = @"CREATE TABLE IF NOT EXISTS 
                                                        sessions(
                                                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                date TEXT,
                                                                length INTEGER
                                                        )"; //Date as text is ISO8601

        private static readonly string CREATE_ENCOUNTER_TABLE = @"CREATE TABLE IF NOT EXISTS
                                                                  encounters(
                                                                              id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                              date TEXT,
                                                                              temtem1 TEXT,
                                                                              temtem2 TEXT
                                                                  )"; //Date as text is ISO8601

        private static readonly string INSERT_SESSION = @"INSERT INTO sessions (date, length) VALUES (@date, @length)";

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

        private static readonly string GET_DAILY_SESSION_TOTALS = @"SELECT strftime('%w', date), SUM(length)
                                                                 FROM sessions
                                                                 WHERE date >=@weekStart
                                                                 AND date <=@weekEnd
                                                                 GROUP BY strftime('%w', date)";

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

            Thread dbThread = new Thread(()=> {
                //Create the table
                lock (dblock)
                {
                    using (SQLiteConnection con = new SQLiteConnection(dbPath))
                    {
                        con.Open();

                        using (SQLiteCommand cmd = new SQLiteCommand(CREATE_SESSION_TABLE, con))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        using(SQLiteCommand cmd = new SQLiteCommand(CREATE_ENCOUNTER_TABLE, con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }      
            });

            dbThread.Start();
        }

        public void LogEncounter(List<string> TemtemNames)
        {
            Thread dbThread = new Thread(() => {
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

            dbThread.Start();
        }

        public Task<TrackingStatistics> GetEncounterStatistics(Tuple<DateTime, DateTime> week)
        {
            Task<TrackingStatistics> dbTask = Task.Factory.StartNew<TrackingStatistics>(() => {
                lock (dblock)
                {
                    TrackingStatistics ts = new TrackingStatistics();
                    ts.dailyEncounters = new List<DailyEncounterStatistics>();
                    ts.dailyPlaytime = new List<DailyPlaytimeStatistics>();
                    for(int i = 0; i < 7; i++)
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
                        using(SQLiteCommand cmd = new SQLiteCommand(GET_DAILY_SESSION_TOTALS, con))
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

        public void LogSession(DateTime sessionBegin, long length)
        {
            Thread dbThread = new Thread(() => {
                lock (dblock)
                {
                    using (SQLiteConnection con = new SQLiteConnection(dbPath))
                    {
                        con.Open();

                        using (SQLiteCommand cmd = new SQLiteCommand(INSERT_SESSION, con))
                        {
                            cmd.Parameters.AddWithValue("@date", GetTimeISO8601(sessionBegin));
                            cmd.Parameters.AddWithValue("@length", length);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            });

            dbThread.Start();
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
