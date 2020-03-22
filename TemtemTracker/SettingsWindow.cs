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

namespace TemtemTracker
{
    public partial class SettingsWindow : Form
    {

        private SettingsController settingsController;

        public SettingsWindow(SettingsController settingsController)
        {
            InitializeComponent();
            this.settingsController = settingsController;
        }

        private void darkModeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void SettingsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        public void PopulateHotkeySettings(string resetTableHotkeyString, string pauseTimerHotkeyString)
        {
            labelResetTableHotkey.Text = resetTableHotkeyString;
            labelPauseTimerHotkey.Text = pauseTimerHotkeyString;
        }

        public void PopulateSaiparkSettings(List<string> temtemNames, bool saiparkMode, string temtem1Name, string temtem2Name, double temtem1Multiplier, double temtem2Multiplier)
        {
            
            checkBoxSaiparkMode.Checked = true;
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

        private void checkBoxSaiparkMode_CheckedChanged(object sender, EventArgs e)
        {
            settingsController.SetSaiparkMode(checkBoxSaiparkMode.Checked);
        }

        private void temtem1NameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            settingsController.SetTemtem1Name((string) temtem1NameSelect.SelectedItem);
        }

        private void temtem2NameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            settingsController.SetTemtem2Name((string) temtem2NameSelect.SelectedItem);
        }

        private void temtem1Multiplier_ValueChanged(object sender, EventArgs e)
        {
            settingsController.SetTemtem1Multiplier(Convert.ToDouble(temtem1Multiplier.Value));
        }

        private void temtem2Multiplier_ValueChanged(object sender, EventArgs e)
        {
            settingsController.SetTemtem2Multiplier(Convert.ToDouble(temtem2Multiplier.Value));
        }

        private void opacityTrackBar_Scroll(object sender, EventArgs e)
        {
            settingsController.SetMainWindowOpacity(opacityTrackBar.Value);
        }

        private void buttonRemapResetTableHotkey_Click(object sender, EventArgs e)
        {
            //Temporarily disable hotkeys
            settingsController.DisableHotkeys();
            //Enable key preview
            KeyPreview = true;
            //Create temporary event handler to handle key preview
            EventHandler disableKeyPreview = null;
            disableKeyPreview = (s, eA) =>
            {
                settingsTabControl.SelectedIndexChanged -= disableKeyPreview;
                VisibleChanged -= disableKeyPreview;
                KeyPreview = false;
                //Enable hotkeys again
                settingsController.EnableHotkeys();
            };
            //Set it so key preview gets disabled when the tab is changed
            settingsTabControl.SelectedIndexChanged += disableKeyPreview;
            //Set it so key preview gets disabled when the window is made invisible
            VisibleChanged += disableKeyPreview;
            //Create temporary event handler to handle the actual key
            KeyEventHandler getPressedKey = null;
            getPressedKey = (s, eA) =>
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
            };
            KeyDown += getPressedKey;
        }

        private void buttonRemapPauseTimerHotkey_Click(object sender, EventArgs e)
        {
            //Temporarily disable hotkeys
            settingsController.DisableHotkeys();
            //Enable key preview
            KeyPreview = true;
            //Create temporary event handler to handle key preview
            EventHandler disableKeyPreview = null;
            disableKeyPreview = (s, eA) =>
            {
                settingsTabControl.SelectedIndexChanged -= disableKeyPreview;
                VisibleChanged -= disableKeyPreview;
                KeyPreview = false;
                //Enable hotkeys again
                settingsController.EnableHotkeys();
            };
            //Set it so key preview gets disabled when the tab is changed
            settingsTabControl.SelectedIndexChanged += disableKeyPreview;
            //Set it so key preview gets disabled when the window is made invisible
            VisibleChanged += disableKeyPreview;
            //Create temporary event handler to handle the actual key
            KeyEventHandler getPressedKey = null;
            getPressedKey = (s, eA) =>
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
            };
            KeyDown += getPressedKey;
        }

        private void radioButtonLuma50Percent_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLuma50Percent.Checked)
            {
                settingsController.SetTimeToLumaProbability(0.5);
            }
        }

        private void radioButtonLuma75Percent_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLuma75Percent.Checked)
            {
                settingsController.SetTimeToLumaProbability(0.75);
            }
        }

        private void radioButtonLuma9999Percent_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLuma9999Percent.Checked)
            {
                settingsController.SetTimeToLumaProbability(0.9999);
            }
        }
    }
}
