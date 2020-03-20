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
    }
}
