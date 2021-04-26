﻿using System;
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

        private readonly SettingsController settingsController;
        private readonly TemtemTrackerMasterUI masterUI;
        private readonly TemtemTableController tableController;
        private Keys resetTableHotkey;
        private Keys pauseTimerHotkey;
        private Keys resetTableHotkeyModifiers;
        private Keys pauseTimerHotkeyModifiers;
        private User32.KeyModifiers resetTableKeyModifiers;
        private User32.KeyModifiers pauseTimerKeyModifiers;

        private readonly int KEY_MESSAGE = 0x0312;
        private readonly int RESET_TABLE_HOTKEY_ID = 0;
        private readonly int PAUSE_TIMER_HOTKEY_ID = 1;

        public HotkeyController(SettingsController settingsController, TemtemTrackerMasterUI trackerUI, TemtemTableController tableController)
        {
            this.settingsController = settingsController;
            this.masterUI = trackerUI;
            this.tableController = tableController;

            //Get the hotkeys from settings
            this.resetTableHotkey = (Keys) settingsController.GetUserSettings().resetTableHotkey;
            this.resetTableHotkeyModifiers = (Keys)settingsController.GetUserSettings().resetTableHotkeyModifier;
            this.resetTableKeyModifiers = User32.KeysToKeyModifiers(resetTableHotkeyModifiers);
            this.pauseTimerHotkey = (Keys) settingsController.GetUserSettings().pauseTimerHotkey;
            this.pauseTimerHotkeyModifiers = (Keys)settingsController.GetUserSettings().pauseTimerHotkeyModifier;
            this.pauseTimerKeyModifiers = User32.KeysToKeyModifiers(pauseTimerHotkeyModifiers);

            //Subscribe to relevant events from settingsController
            settingsController.ToggleHotkeysEnabled += ToggleHotkeysEnabled;
            settingsController.ResetTableHotkeyChanged += ReloadResetTableHotkey;
            settingsController.PauseTimerHotkeyChanged += ReloadPauseTimerHotkey;

            //Set tracker UI hotkey strings
            PopulateTrackerUIHotkeyLabels();

            //Bind the hotkeys 
            User32.RegisterHotKey(this.Handle, RESET_TABLE_HOTKEY_ID, resetTableKeyModifiers, resetTableHotkey);
            User32.RegisterHotKey(this.Handle, PAUSE_TIMER_HOTKEY_ID, pauseTimerKeyModifiers, pauseTimerHotkey);

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
                    settingsController.ToggleTimerPaused();
                    tableController.SetLastChangeTime(); //On unpause we want to reset the inactivity timer
                }
            }
        }

        public void ReloadResetTableHotkey(object sender, EventArgs e)
        {
            //Get the hotkeys from settings
            this.resetTableHotkey = (Keys)settingsController.GetUserSettings().resetTableHotkey;
            this.resetTableHotkeyModifiers = (Keys)settingsController.GetUserSettings().resetTableHotkeyModifier;
            this.resetTableKeyModifiers = User32.KeysToKeyModifiers(resetTableHotkeyModifiers);
            //Set the hotkey labels in the tracker UI
            PopulateTrackerUIHotkeyLabels();
        }

        public void ReloadPauseTimerHotkey(object sender, EventArgs e)
        {
            //Get the hotkeys from settings
            this.pauseTimerHotkey = (Keys)settingsController.GetUserSettings().pauseTimerHotkey;
            this.pauseTimerHotkeyModifiers = (Keys)settingsController.GetUserSettings().pauseTimerHotkeyModifier;
            this.pauseTimerKeyModifiers = User32.KeysToKeyModifiers(pauseTimerHotkeyModifiers);
            //Set the hotkey labels in the tracker UI
            PopulateTrackerUIHotkeyLabels();
        }

        private void ToggleHotkeysEnabled(object sender, bool hotkeysEnabled)
        {
            if (hotkeysEnabled)
            {
                User32.RegisterHotKey(this.Handle, RESET_TABLE_HOTKEY_ID, resetTableKeyModifiers, resetTableHotkey);
                User32.RegisterHotKey(this.Handle, PAUSE_TIMER_HOTKEY_ID, pauseTimerKeyModifiers, pauseTimerHotkey);
            }
            else
            {
                UnregisterHotkeys();
            }
        }

        //Unregister the hotkeys
        public void UnregisterHotkeys()
        {
            User32.UnregisterHotKey(this.Handle, RESET_TABLE_HOTKEY_ID);
            User32.UnregisterHotKey(this.Handle, PAUSE_TIMER_HOTKEY_ID);
        }

        private void PopulateTrackerUIHotkeyLabels()
        {
            //Set the hotkeys in the menu
            KeysConverter kc = new KeysConverter();
            string resetTableHotkeyModifiersString = HelperMethods.ModifierKeysToString(resetTableHotkeyModifiers);
            string pauseTimerHotkeyModifiersString = HelperMethods.ModifierKeysToString(pauseTimerHotkeyModifiers);
            masterUI.SetMenuStripHotkeyStrings(resetTableHotkeyModifiersString + kc.ConvertToString(resetTableHotkey),
                pauseTimerHotkeyModifiersString + kc.ConvertToString(pauseTimerHotkey));
            
        }


    }
}
