using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TemtemTracker.Data;

namespace TemtemTracker.Controllers
{
    public class TimerController
    {

        
        private static readonly int TIME_TRACKER_INTERVAL = 1000;
        private readonly int detectionLoopInterval;

        private readonly System.Timers.Timer detectionLoopTimer;
        private readonly System.Timers.Timer timeTrackerTimer;
        private readonly System.Timers.Timer autosaveTimer;

        private readonly TemtemTableController tableController;
        private readonly DetectorLoop detectorLoop;

        private bool disableDetectionOnTimerPause;

        //To prevent reentrancy 
        int _TimerLock = 0;
        int _AutosaveLock = 0;

        public TimerController(TemtemTrackerUI trackerUI, TemtemTableController tableController, DetectorLoop detectorLoop, Config config, UserSettings userSettings, SettingsController settingsController)
        {
            this.tableController = tableController;
            this.detectorLoop = detectorLoop;
            this.detectionLoopInterval = config.detectionLoopInterval;
            this.disableDetectionOnTimerPause = userSettings.disableDetectionWhileTimerPaused;

            settingsController.SetTimerController(this);

            detectionLoopTimer = new System.Timers.Timer(detectionLoopInterval);
            timeTrackerTimer = new System.Timers.Timer(TIME_TRACKER_INTERVAL);
            autosaveTimer = new System.Timers.Timer();

            //Set the interval for the autosave timer from the user settings
            //The interval is in minutes, the timer accepts miliseconds, the function converts
            SetAutosaveTimeInterval(userSettings.autosaveInterval);

            detectionLoopTimer.Elapsed += DetectionLoopListener;
            timeTrackerTimer.Elapsed += TimeTrackerListener;
            autosaveTimer.Elapsed += AutosaveListener;

            detectionLoopTimer.AutoReset = true;
            timeTrackerTimer.AutoReset = true;
            autosaveTimer.AutoReset = true;

            //Set this as the timer controller in the UI
            trackerUI.SetTimerController(this);
        }

        public void StartTimers()
        {
            detectionLoopTimer.Start();
            timeTrackerTimer.Start();
            autosaveTimer.Start();
        }

        public bool ToggleTimeTrackerTimerPaused()
        {
            timeTrackerTimer.Enabled = !timeTrackerTimer.Enabled;
            if (disableDetectionOnTimerPause)
            {
                //If we want to disable detection when the timer is paused
                if (timeTrackerTimer.Enabled)
                {
                    //If the timer was unpaused
                    detectionLoopTimer.Start();
                }
                else
                {
                    //The timer was paused
                    detectionLoopTimer.Stop();
                }
            }
            return timeTrackerTimer.Enabled;
        }

        public void DisposeTimers()
        {
            detectionLoopTimer.Stop();
            detectionLoopTimer.Dispose();
            timeTrackerTimer.Stop();
            timeTrackerTimer.Dispose();
            autosaveTimer.Stop();
            autosaveTimer.Dispose();
        }

        public void SetAutosaveTimeInterval(int intervalMinutes)
        {
            autosaveTimer.Interval = intervalMinutes * 60000;
        }

        public void SetDisableDetectionOnTimerPause(bool detectionDisabled)
        {
            disableDetectionOnTimerPause = detectionDisabled;
            if(!detectionDisabled && !detectionLoopTimer.Enabled)
            {
                //Detection isn't disabled anymore, but the timer is still stopped. Restart it
                detectionLoopTimer.Start();
            }
            if(detectionDisabled && !timeTrackerTimer.Enabled)
            {
                //We've disabled detection while the timer is stopped
                //and the timer IS stopped. Stop the detection loop
                detectionLoopTimer.Stop();
            }
        }

        private void DetectionLoopListener(Object source, System.Timers.ElapsedEventArgs e)
        {

            if (Interlocked.CompareExchange(ref _TimerLock, 1, 0) != 0) return;
            try
            {
                Console.WriteLine("I'm detecting!");
                detectorLoop.Detect();
            }
            finally
            {
                Interlocked.Exchange(ref _TimerLock, 0);
            }

        }

        private void TimeTrackerListener(Object source, System.Timers.ElapsedEventArgs e)
        {
            tableController.IncrementTimer();
        }

        private void AutosaveListener(object source, System.Timers.ElapsedEventArgs e)
        {
            if (Interlocked.CompareExchange(ref _AutosaveLock, 1, 0) != 0) return;
            try
            {
                Console.WriteLine("Autosaving...");
                tableController.SaveTable();
            }
            finally
            {
                Interlocked.Exchange(ref _AutosaveLock, 0);
            }
        }

    }
}
