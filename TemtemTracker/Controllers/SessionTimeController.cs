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

        public SessionTimeController(TemtemTrackerUI trackerUI)
        {
            this.trackerUI = trackerUI;

            LoadSessionTimeFromFile(Paths.SESSION_TIME_FILE);
        }

        public void LoadSessionTimeFromFile(string filename)
        {
            lock (saveLock)
            {
                if (File.Exists(filename))
                {
                    string json = File.ReadAllText(filename);
                    try
                    {
                        sessionTime = JsonConvert.DeserializeObject<PlayingSessionTime>(json);
                        //If it's a new day, set the new datetime
                        if(sessionTime.dayPlaying.Date != DateTime.Today.Date)
                        {
                            sessionTime.dayDuration = 0;
                            sessionTime.dayPlaying = DateTime.Today;
                        }
                        //Session duration is always 0 and it always starts on the running day
                        sessionTime.sessionDuration = 0;
                        sessionTime.sessionStartDay = DateTime.Today; 
                    }
                    catch
                    {
                        CreateNewSession();
                    }
                }
                else
                {
                    CreateNewSession();
                }
            }
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
            lock (saveLock)
            {
                //Save table to a provided location
                String jsonSessionTimers = JsonConvert.SerializeObject(sessionTime);
                File.WriteAllText(Paths.SESSION_TIME_FILE, jsonSessionTimers);
                DatabaseController.Instance.LogSession(sessionTime.sessionStartDay, sessionTime.sessionDuration);
            }
        }

        private void CreateNewSession()
        {
            sessionTime = new PlayingSessionTime()
            {
                dayPlaying = DateTime.Today,
                dayDuration = 0,
                sessionStartDay = DateTime.Today,
                sessionDuration = 0
            };
        }
    }
}
