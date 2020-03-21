using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemtemTracker.Data;

namespace TemtemTracker.Controllers
{
    public class HotkeyController : Form
    {
        //This is an empty bodiless form that is never shown and inherits form purely
        //so it can override WndProc and get the hotkeys it registered

        private SettingsController settingsController;
        private TemtemTrackerUI trackerUI;
        private TimerController timerController;
        private TemtemTableController tableController;
        private Keys resetTableHotkey;
        private Keys pauseTimerHotkey;

        private readonly int KEY_MESSAGE = 0x0312;
        private readonly int RESET_TABLE_HOTKEY_ID = 0;
        private readonly int PAUSE_TIMER_HOTKEY_ID = 1;

        public HotkeyController(SettingsController settingsController, TemtemTrackerUI trackerUI, TimerController timerController, TemtemTableController tableController)
        {
            this.settingsController = settingsController;
            this.trackerUI = trackerUI;
            this.timerController = timerController;
            this.tableController = tableController;

            //Get the hotkeys from settings
            this.resetTableHotkey = (Keys) settingsController.GetSettings().resetTableHotkey;
            this.pauseTimerHotkey = (Keys) settingsController.GetSettings().pauseTimerHotkey;

            //Set the hotkeys in the menu
            KeysConverter kc = new KeysConverter();
            trackerUI.SetMenuStripHotkeyStrings(kc.ConvertToString(resetTableHotkey), kc.ConvertToString(pauseTimerHotkey));

            //Bind the hotkeys 
            User32.RegisterHotKey(this.Handle, RESET_TABLE_HOTKEY_ID, User32.KeyModifiers.None, resetTableHotkey);
            User32.RegisterHotKey(this.Handle, PAUSE_TIMER_HOTKEY_ID, User32.KeyModifiers.None, pauseTimerHotkey);

        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if(m.Msg == KEY_MESSAGE)
            {
                Keys key = (Keys)(((int) m.LParam >> 16) & 0xFFFF);

                //Reset table key was pressed
                if (key == resetTableHotkey)
                {
                    tableController.ResetTable();
                }
                //Pause timer key was pressed
                if ( key== pauseTimerHotkey)
                {
                    //Toggle the tracker time
                    bool timerState = timerController.ToggleTimeTrackerTimerPaused();
                    trackerUI.TogglePauseTimerUIIndication(timerState);
                }
            }
        }

        public void RemapResetTableHotkey()
        {

        }

        public void RemapPauseTimerHotkey()
        {

        }

        //Finalizer (destructor) to unregister hotkeys when this class is garbage collected
        ~HotkeyController()
        {
            User32.UnregisterHotKey(this.Handle, RESET_TABLE_HOTKEY_ID);
            User32.UnregisterHotKey(this.Handle, PAUSE_TIMER_HOTKEY_ID);
        }



    }
}
