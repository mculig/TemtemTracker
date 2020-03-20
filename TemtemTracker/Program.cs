using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemtemTracker.Controllers;

namespace TemtemTracker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Load configs
            ConfigLoader configLoader = new ConfigLoader();
            if (configLoader.LoadFailed())
            {
                return;
            }
            //Create the Luma Calculator
            LumaChanceCalculator lumaCalculator = new LumaChanceCalculator(configLoader.GetUserSettings(), configLoader.GetConfig());
            //Create the main window and controller
            TemtemTrackerUI trackerUI = new TemtemTrackerUI();
            //Create the SettingsController
            SettingsController settingsController = new SettingsController(configLoader.GetSpeciesList(), configLoader.GetUserSettings(), trackerUI);
            trackerUI.SetSettingsController(settingsController);
            //Create the TemtemTableController
            TemtemTableController tableController = new TemtemTableController(trackerUI, lumaCalculator);
            trackerUI.SetTableController(tableController);
            OCRController ocr = new OCRController(configLoader.GetConfig(), configLoader.GetSpeciesList());
            DetectorLoop loop = new DetectorLoop(configLoader.GetConfig(), tableController, ocr);
            if (loop.LoadFailed())
            {
                return;
            }
            //The timer responsible for the detection loop
            System.Timers.Timer detectionLoopTimer = new System.Timers.Timer(10);
            detectionLoopTimer.Elapsed += (Object source, System.Timers.ElapsedEventArgs e) => {
                loop.Detect();
            };
            detectionLoopTimer.AutoReset = true;
            detectionLoopTimer.Enabled = true;
            //The timer responsible for the timer in the UI
            System.Timers.Timer timeTrackerTimer = new System.Timers.Timer(1000);
            timeTrackerTimer.Elapsed += (Object source, System.Timers.ElapsedEventArgs e) =>
            {
                tableController.IncrementTimer();
            };
            timeTrackerTimer.AutoReset = true;
            timeTrackerTimer.Enabled = true;
            //Add listeners to application exit
            Application.ApplicationExit += new EventHandler((Object source, EventArgs args) => {
                //Remove timers after run is over
                detectionLoopTimer.Stop();
                detectionLoopTimer.Dispose();
                timeTrackerTimer.Stop();
                timeTrackerTimer.Dispose();
                //Save Config and stuff
                tableController.SaveTable();
                settingsController.SaveSettings();
            });

            //Run the app
            Application.Run(trackerUI);
          
        }
    }
}
