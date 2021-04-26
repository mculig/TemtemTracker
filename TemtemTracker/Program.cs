﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemtemTracker.Controllers;
using TemtemTracker.Data;

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
            Application.ThreadException += new ThreadExceptionEventHandler(UnhandledExceptionHandler.HandleUnhandledThreadException);
            //Load configs
            ConfigLoader configLoader = new ConfigLoader();
            if (configLoader.LoadFailed())
            {
                return;
            }
            //Create the SettingsController
            SettingsController settingsController = new SettingsController(configLoader.GetSpeciesList(), configLoader.GetStyles(), configLoader.GetUserSettings());
            //Create the main window and controller
            TemtemTrackerUI trackerUI = new TemtemTrackerUI(settingsController);
            TemtemTrackerMasterUI masterUI = new TemtemTrackerMasterUI(settingsController, trackerUI);
            //Create the Luma Calculator
            LumaChanceCalculator lumaCalculator = new LumaChanceCalculator(settingsController, configLoader.GetConfig());
            //Create the TemtemTableController
            TemtemTableController tableController = new TemtemTableController(trackerUI, lumaCalculator, settingsController);
            //Create the SessionTimeController
            SessionTimeController sessionTimeController = new SessionTimeController(trackerUI);

            OCRController ocr = new OCRController(configLoader.GetConfig(), configLoader.GetSpeciesList());

            //Database controller
            DatabaseController dbcon = DatabaseController.Instance;

            DetectorLoop loop = new DetectorLoop(configLoader.GetConfig(), tableController, ocr, settingsController);
            //The timer controller
            TimerController timerController = new TimerController(tableController, sessionTimeController, loop, configLoader.GetConfig(), configLoader.GetUserSettings(), settingsController);
            timerController.StartTimers();
            //The hotkey controller
            HotkeyController hotkeyController = new HotkeyController(settingsController, masterUI, tableController);
            //Add listeners to application exit
            masterUI.FormClosing += new FormClosingEventHandler((object source, FormClosingEventArgs e) =>
            {
                //Prevent shutdown during close
                User32.ShutdownBlockReasonCreate(trackerUI.Handle, "Saving! Please wait!");
                //Remove timers after run is over
                timerController.DisposeTimers();
                //Unregister hotkeys
                hotkeyController.UnregisterHotkeys();
                //Save Config and stuff
                tableController.SaveTable();
                settingsController.SaveSettings();
                sessionTimeController.SaveOnAppClose();
                //Allow shutdown again
                User32.ShutdownBlockReasonDestroy(trackerUI.Handle);

            });
            //Run the app
            Application.Run(masterUI);      
            

        }
    }
}
