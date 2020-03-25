using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TemtemTracker.Data;

namespace TemtemTracker.Controllers
{
    public class TimerController
    {

        
        private static readonly int TIME_TRACKER_INTERVAL = 1000;
        private readonly int detectionLoopInterval;

        private readonly Timer detectionLoopTimer;
        private readonly Timer timeTrackerTimer;

        private readonly TemtemTableController tableController;
        private readonly DetectorLoop detectorLoop;

        public TimerController(TemtemTrackerUI trackerUI, TemtemTableController tableController, DetectorLoop detectorLoop, Config config)
        {
            this.tableController = tableController;
            this.detectorLoop = detectorLoop;
            this.detectionLoopInterval = config.detectionLoopInterval;

            detectionLoopTimer = new Timer(detectionLoopInterval);
            timeTrackerTimer = new Timer(TIME_TRACKER_INTERVAL);

            detectionLoopTimer.Elapsed += DetectionLoopListener;
            timeTrackerTimer.Elapsed += TimeTrackerListener;

            detectionLoopTimer.AutoReset = true;
            timeTrackerTimer.AutoReset = true;

            //Set this as the timer controller in the UI
            trackerUI.SetTimerController(this);
        }

        public void StartTimers()
        {
            detectionLoopTimer.Enabled = true;
            timeTrackerTimer.Enabled = true;
        }

        public bool ToggleTimeTrackerTimerPaused()
        {
            timeTrackerTimer.Enabled = !timeTrackerTimer.Enabled;
            return timeTrackerTimer.Enabled;
        }

        public void DisposeTimers()
        {
            detectionLoopTimer.Stop();
            detectionLoopTimer.Dispose();
            timeTrackerTimer.Stop();
            timeTrackerTimer.Dispose();
        }

        private void DetectionLoopListener(Object source, System.Timers.ElapsedEventArgs e)
        {
            detectorLoop.Detect();
        }

        private void TimeTrackerListener(Object source, System.Timers.ElapsedEventArgs e)
        {
            tableController.IncrementTimer();
        }

    }
}
