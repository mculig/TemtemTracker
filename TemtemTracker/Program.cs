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
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler.HandleUnhandledException);
            //Load configs
            ConfigLoader configLoader = new ConfigLoader();
            if (configLoader.LoadFailed())
            {
                return;
            }
            //Create the main window and controller
            TemtemTrackerUI trackerUI = new TemtemTrackerUI();
            //Create the SettingsController
            SettingsController settingsController = new SettingsController(configLoader.GetSpeciesList(), configLoader.GetUserSettings(), configLoader.GetStyles(), trackerUI);
            //Create the Luma Calculator
            LumaChanceCalculator lumaCalculator = new LumaChanceCalculator(settingsController, configLoader.GetConfig());
            //Create the TemtemTableController
            TemtemTableController tableController = new TemtemTableController(trackerUI, lumaCalculator, settingsController);
            OCRController ocr = new OCRController(configLoader.GetConfig(), configLoader.GetSpeciesList());
            DetectorLoop loop = new DetectorLoop(configLoader.GetConfig(), tableController, ocr);
            if (loop.LoadFailed())
            {
                return;
            }
            //The timer controller
            TimerController timerController = new TimerController(trackerUI, tableController, loop, configLoader.GetConfig(), configLoader.GetUserSettings(), settingsController);
            timerController.StartTimers();
            //The hotkey controller
            HotkeyController hotkeyController = new HotkeyController(settingsController, trackerUI, timerController, tableController);
            //Add listeners to application exit
            Application.ApplicationExit += new EventHandler((Object source, EventArgs args) => {
                //Remove timers after run is over
                timerController.DisposeTimers();
                //Unregister hotkeys
                hotkeyController.UnregisterHotkeys();
                //Save Config and stuff
                tableController.SaveTable();
                settingsController.SaveSettings();
            });

            //Run the app
            Application.Run(trackerUI);       
        }
    }
}
