using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemtemTracker;
using TemtemTracker.Controllers;
using TemtemTracker.Data;

namespace TemtemTracker
{
    public partial class TemtemTrackerUI : Form
    {
        private delegate void SafeCallDelegate(TemtemTableRowUI row);
        private SettingsController settingsController;
        private TemtemTableController tableController;
        private TimerController timerController;

        public TemtemTrackerUI()
        {
            InitializeComponent();
        }

        public void SetSettingsController(SettingsController settingsController)
        {
            this.settingsController = settingsController;
        }

        public void SetTableController(TemtemTableController tableController)
        {
            this.tableController = tableController;
        }

        public void SetTimerController(TimerController timerController)
        {
            this.timerController = timerController;
        }

        public void AddRowToTable(TemtemTableRowUI row)
        {
            if (this.InvokeRequired)
            {
                SafeCallDelegate d = new SafeCallDelegate(AddRowToTable);
                this.Invoke(d, new object[] { row });
            }
            else
            {
                trackerTable.Controls.Add(row);
                if(trackerTable.Controls.Count%2 == 0)
                {
                    row.BackColor = SystemColors.ControlLight;
                }
            } 
        }

        public void RemoveRowFromTable(TemtemTableRowUI row)
        {
            trackerTable.Controls.Remove(row);
            //Recolor all the controls to fit the intertwined colors scheme
            int i = 1;
            foreach(Control c in trackerTable.Controls)
            {
                if (i % 2 == 0)
                {
                    c.BackColor = SystemColors.ControlLight;
                }
                else
                {
                    c.BackColor = SystemColors.Control;
                }
                i++;
            }
        }

        public void RemoveAllTableRows()
        {
            trackerTable.Controls.Clear();
        }

        public void SetTotal(TemtemDataRow totalRow)
        {
            temtemTableTotalUI.SetTotal(totalRow);
        }

        public void UpdateTotal()
        {
            temtemTableTotalUI.UpdateRow();
        }

        public void UpdateTime(long timeMilis)
        {
            timeTrackerUI1.UpdateTime(timeMilis);
        }

        public void UpdateTemtemH(double temtemH)
        {
            timeTrackerUI1.UpdateTemtemH(temtemH);
        }

        public void SetMenuStripHotkeyStrings(string resetTableHotkey, string pauseTimerHotkey)
        {
            resetTableToolStripMenuItem.ShortcutKeyDisplayString = resetTableHotkey;
            pauseTimerToolStripMenuItem.ShortcutKeyDisplayString = pauseTimerHotkey;
        }

        public void TogglePauseTimerUIIndication(bool timerState)
        {
            if (timerState)
            {
                pauseTimerToolStripMenuItem.Text = "Pause timer";               
            }
            else
            {
                pauseTimerToolStripMenuItem.Text = "Unpause timer";
            }
            timeTrackerUI1.TogglePausedVisualIndication(timerState);
        }

        public void SetDarkMode()
        {
            
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsController.ShowSettingsWindow();
        }

        private void resetTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableController.ResetTable();
        }

        private void pauseTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool timerState = timerController.ToggleTimeTrackerTimerPaused();
            TogglePauseTimerUIIndication(timerState);
        }

        private void TemtemTrackerUI_ResizeEnd(object sender, EventArgs e)
        {
            settingsController.SetMainWindowSize(this.Size);
        }

    }
}
