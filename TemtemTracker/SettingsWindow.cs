using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemtemTracker.Controllers;
using TemtemTracker.Data;

namespace TemtemTracker
{
    public partial class SettingsWindow : Form
    {

        private readonly SettingsController settingsController;
        private bool disableEventHandlers = false;

        public SettingsWindow(SettingsController settingsController)
        {
            InitializeComponent();
            this.settingsController = settingsController;
        }

        private void SettingsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        public void DisableEventHandlers()
        {
            this.disableEventHandlers = true;
        }

        public void EnableEventHandlers()
        {
            this.disableEventHandlers = false;
        }

        public void PopulateHotkeySettings(string resetTableHotkeyString, string pauseTimerHotkeyString)
        {
            labelResetTableHotkey.Text = resetTableHotkeyString;
            labelPauseTimerHotkey.Text = pauseTimerHotkeyString;
        }

        public void PopulateSaiparkSettings(List<string> temtemNames, bool saiparkMode, string temtem1Name, string temtem2Name, double temtem1Multiplier, double temtem2Multiplier)
        {
            
            checkBoxSaiparkMode.Checked = saiparkMode;
            temtem1NameSelect.DataSource = temtemNames.OrderBy(x => x).ToList();
            temtem2NameSelect.DataSource = temtemNames.OrderBy(x => x).ToList();
            temtem1NameSelect.SelectedItem = temtem1Name;
            temtem2NameSelect.SelectedItem = temtem2Name;
            this.temtem1Multiplier.Value = Convert.ToDecimal(temtem1Multiplier);
            this.temtem2Multiplier.Value = Convert.ToDecimal(temtem2Multiplier);
        }

        public void PopulateWindowSettings(double opacity)
        {
            opacityTrackBar.Value = (int) (opacity * 100);
        }

        public void SetTimeToLumaRadioButton(double probability)
        {
            if (probability == 0.9999)
            {
                radioButtonLuma9999Percent.Checked = true;
            }
            else if (probability == 0.75)
            {
                radioButtonLuma75Percent.Checked = true;
            }
            else if (probability == 0.5)
            {
                radioButtonLuma50Percent.Checked = true;
            }
            else
            {
                //Fallback default is 50%
                radioButtonLuma50Percent.Checked = true;
                //Also set this to 50% in the settings
                settingsController.SetTimeToLumaProbability(0.5);
            }
        }

        public void PopulateStyleComboBox(List<Style> styles, string selectedStyleName)
        {
            comboBoxStyleSelect.DataSource = styles.Select(style=> style.styleName).ToList();
            comboBoxStyleSelect.SelectedIndex = styles.IndexOf(HelperMethods.GetStyleByName(styles, selectedStyleName));
        }

        public void SetDisableDetectionCheckboxChecked(bool isChecked)
        {
            checkBoxDisableWhileTimer.Checked = isChecked;
        }

        public void SetAutosaveInterval(int intervalMinutes)
        {
            autosaveInterval.Value = intervalMinutes;
        }

        public void PopulateInactivitySettings(bool inactivityTimerEnabled, int intervalMinutes)
        {
            checkboxInactivity.Checked = inactivityTimerEnabled;
            inactivityTreshold.Value = intervalMinutes;
        }

        private void CheckBoxSaiparkMode_CheckedChanged(object sender, EventArgs e)
        {
            if(!disableEventHandlers)
            {
                settingsController.SetSaiparkMode(checkBoxSaiparkMode.Checked);
            }               
        }

        private void Temtem1NameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!disableEventHandlers)
            {
                settingsController.SetTemtem1Name((string)temtem1NameSelect.SelectedItem);
            }       
        }

        private void Temtem2NameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!disableEventHandlers)
            {
                settingsController.SetTemtem2Name((string)temtem2NameSelect.SelectedItem);
            }
        }

        private void Temtem1Multiplier_ValueChanged(object sender, EventArgs e)
        {
            if (!disableEventHandlers)
            {
                settingsController.SetTemtem1Multiplier(Convert.ToDouble(temtem1Multiplier.Value));
            }
        }

        private void Temtem2Multiplier_ValueChanged(object sender, EventArgs e)
        {
            if (!disableEventHandlers)
            {
                settingsController.SetTemtem2Multiplier(Convert.ToDouble(temtem2Multiplier.Value));
            }
        }

        private void OpacityTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!disableEventHandlers)
            {
                settingsController.SetMainWindowOpacity(opacityTrackBar.Value);
            }
        }

        private void ButtonRemapResetTableHotkey_Click(object sender, EventArgs e)
        {
            //Temporarily disable hotkeys
            settingsController.DisableHotkeys();
            //Enable key preview
            KeyPreview = true;
            //Create temporary event handler to handle key preview
            void disableKeyPreview(object s, EventArgs eA)
            {
                settingsTabControl.SelectedIndexChanged -= disableKeyPreview;
                VisibleChanged -= disableKeyPreview;
                KeyPreview = false;
                //Enable hotkeys again
                settingsController.EnableHotkeys();
            }
            //Set it so key preview gets disabled when the tab is changed
            settingsTabControl.SelectedIndexChanged += disableKeyPreview;
            //Set it so key preview gets disabled when the window is made invisible
            VisibleChanged += disableKeyPreview;
            //Create temporary event handler to handle the actual key
            void getPressedKey(object s, KeyEventArgs eA)
            {
                switch (eA.KeyCode)
                {
                    case Keys.ControlKey:
                    case Keys.ShiftKey:
                    case Keys.Menu:
                    case Keys.LWin:
                    case Keys.RWin:
                        //We ignore controls other than to combine them with others
                        return;
                }
                //Remove the event handlers
                KeyDown -= getPressedKey;
                settingsTabControl.SelectedIndexChanged -= disableKeyPreview;
                VisibleChanged -= disableKeyPreview;
                KeyPreview = false;
                settingsController.RemapResetTableHotkey(eA.Modifiers, eA.KeyCode);
                //Enable hotkeys again
                settingsController.EnableHotkeys();
            }

            KeyDown += getPressedKey;
        }

        private void ButtonRemapPauseTimerHotkey_Click(object sender, EventArgs e)
        {
            //Temporarily disable hotkeys
            settingsController.DisableHotkeys();
            //Enable key preview
            KeyPreview = true;
            //Create temporary event handler to handle key preview
            void disableKeyPreview(object s, EventArgs eA)
            {
                settingsTabControl.SelectedIndexChanged -= disableKeyPreview;
                VisibleChanged -= disableKeyPreview;
                KeyPreview = false;
                //Enable hotkeys again
                settingsController.EnableHotkeys();
            }
            //Set it so key preview gets disabled when the tab is changed
            settingsTabControl.SelectedIndexChanged += disableKeyPreview;
            //Set it so key preview gets disabled when the window is made invisible
            VisibleChanged += disableKeyPreview;
            //Create temporary event handler to handle the actual key
            void getPressedKey(object s, KeyEventArgs eA)
            {
                switch (eA.KeyCode)
                {
                    case Keys.ControlKey:
                    case Keys.ShiftKey:
                    case Keys.Menu:
                    case Keys.LWin:
                    case Keys.RWin:
                        //We ignore controls other than to combine them with others
                        return;
                }
                //Remove the event handlers
                KeyDown -= getPressedKey;
                settingsTabControl.SelectedIndexChanged -= disableKeyPreview;
                VisibleChanged -= disableKeyPreview;
                KeyPreview = false;
                settingsController.RemapPauseTimerHotkey(eA.Modifiers, eA.KeyCode);
                //Enable hotkeys again
                settingsController.EnableHotkeys();
            }

            KeyDown += getPressedKey;
        }

        private void RadioButtonLuma50Percent_CheckedChanged(object sender, EventArgs e)
        {
            if (!disableEventHandlers)
            {
                if (radioButtonLuma50Percent.Checked)
                {
                    settingsController.SetTimeToLumaProbability(0.5);
                }
            }
        }

        private void RadioButtonLuma75Percent_CheckedChanged(object sender, EventArgs e)
        {
            if (!disableEventHandlers)
            {
                if (radioButtonLuma75Percent.Checked)
                {
                    settingsController.SetTimeToLumaProbability(0.75);
                }
            }
        }

        private void RadioButtonLuma9999Percent_CheckedChanged(object sender, EventArgs e)
        {
            if (!disableEventHandlers)
            {
                if (radioButtonLuma9999Percent.Checked)
                {
                    settingsController.SetTimeToLumaProbability(0.9999);
                }
            }
        }

        private void ComboBoxStyleSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!disableEventHandlers)
            {
                settingsController.SetWindowStyle(comboBoxStyleSelect.SelectedIndex);
            }           
        }

        private void CheckBoxDisableWhileTimer_CheckedChanged(object sender, EventArgs e)
        {
            if (!disableEventHandlers)
            {
                settingsController.SetDetectionDisabled(checkBoxDisableWhileTimer.Checked);
            }

        }

        private void AutosaveInterval_ValueChanged(object sender, EventArgs e)
        {
            if (!disableEventHandlers)
            {
                settingsController.SetAutosaveInterval((int)autosaveInterval.Value);
            }
        }

        private void CheckboxInactivity_CheckedChanged(object sender, EventArgs e)
        {
            if (!disableEventHandlers)
            {
                settingsController.SetPauseWhenInactive(checkboxInactivity.Checked);
            }
        }

        private void InactivityTreshold_ValueChanged(object sender, EventArgs e)
        {
            if (!disableEventHandlers)
            {
                settingsController.SetPauseWhenInactiveInterval((int)inactivityTreshold.Value);
            }
        }
    }
}
