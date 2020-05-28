using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemtemTracker.Data;

namespace TemtemTracker.Controllers
{
    public class SessionTimeController
    {

        //An object to be used as a lock for the auto-save feature
        private static readonly object saveLock = new object();

        private PlayingSessionTime sessionTime;

        private readonly TemtemTrackerUI trackerUI;

        private readonly DatabaseController dbcon;

        public SessionTimeController(TemtemTrackerUI trackerUI)
        {
            this.trackerUI = trackerUI;

            this.dbcon = DatabaseController.Instance;

            //Get the current playtime from the database
            LoadSessionTimeFromDatabase();

            //Set the timers in the tracker
            trackerUI.UpdateSessionTime(sessionTime.sessionDuration, sessionTime.dayDuration);
        }

        private void LoadSessionTimeFromDatabase()
        {
            Task<long> getPlaytimeToday = dbcon.GetPlaytimeDay(DateTime.Today.Date);
            Task.WaitAll(getPlaytimeToday);
            sessionTime = new PlayingSessionTime()
            {
                dayDuration = getPlaytimeToday.Result, //Returns 0 if day isn't find, allowing this to double as initialization
                dayPlaying = DateTime.Today.Date,
                sessionDuration = 0
            };
        }

        public void IncrementTimer()
        {
            lock (saveLock)
            {
                //Check if it's still the same day
                if(sessionTime.dayPlaying.Date != DateTime.Today.Date)
                {
                    sessionTime.dayDuration = 0;
                    sessionTime.dayPlaying = DateTime.Today;
                }
                //Increment timers
                sessionTime.dayDuration+=1000;
                sessionTime.sessionDuration+=1000;

                trackerUI.UpdateSessionTime(sessionTime.sessionDuration, sessionTime.dayDuration);
            }
        }

        public void SaveSessionTimers()
        {        
              dbcon.UpdatePlaytimeLog(sessionTime.dayPlaying, sessionTime.dayDuration);
        }

    }
}
