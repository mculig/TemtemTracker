using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TemtemTracker.Controllers
{
    public class TimerController
    {

        private static readonly int DETECTION_TIME_INTERVAL = 10;
        private static readonly int TIME_TRACKER_INTERVAL = 1000;

        Timer detectionLoopTimer;
        Timer timeTrackerTimer;

        TemtemTableController tableController;
        DetectorLoop detectorLoop;

        public TimerController(TemtemTrackerUI trackerUI, TemtemTableController tableController, DetectorLoop detectorLoop)
        {
            this.tableController = tableController;
            this.detectorLoop = detectorLoop;

            detectionLoopTimer = new Timer(DETECTION_TIME_INTERVAL);
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
