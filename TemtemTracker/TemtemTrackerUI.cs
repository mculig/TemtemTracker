using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemtemTracker;
using TemtemTracker.Controllers;
using TemtemTracker.Data;

namespace TemtemTracker
{
    public partial class TemtemTrackerUI : UserControl
    {
        private delegate void AddRowDelegate(TemtemTableRowUI row);
        private delegate void StyleChangeDelegate(object sender, Style windowStyle);
        private SettingsController settingsController;
        private TemtemTableController tableController;
        private Style style;

        public TemtemTrackerUI(SettingsController settingsController)
        {
            InitializeComponent();
            this.Width = settingsController.GetUserSettings().mainWindowWidth;
            this.Height = settingsController.GetUserSettings().mainWindowHeight;
            this.settingsController = settingsController;
            settingsController.StyleChanged += SetWindowStyle;
            
            SetWindowStyle(null, settingsController.GetWindowStyle());
        }

        public void SetTableController(TemtemTableController tableController)
        {
            this.tableController = tableController;
        }

        public void AddRowToTable(TemtemTableRowUI row)
        {
            if (this.InvokeRequired)
            {
                AddRowDelegate d = new AddRowDelegate(AddRowToTable);
                this.Invoke(d, new object[] { row });
            }
            else
            {
                trackerTable.Controls.Add(row);
                RecolorTableRows();
            } 
        }

        public void RemoveRowFromTable(TemtemTableRowUI row)
        {
            trackerTable.Controls.Remove(row);
            RecolorTableRows();  
        }

        private void RecolorTableRows()
        {
            int i = 1;
            foreach (TemtemTableRowUI r in trackerTable.Controls)
            {
                if (i % 2 == 0)
                {
                    r.SetLight(style);
                }
                else
                {
                    r.SetDark(style);
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

        public void UpdateSessionTime(long sessionTimeMilis, long dayTimeMilis)
        {
            timeTrackerUI1.UpdateSessionTime(sessionTimeMilis, dayTimeMilis);
        }

        public void UpdateTemtemH(double temtemH)
        {
            timeTrackerUI1.UpdateTemtemH(temtemH);
        }

        public void TogglePauseTimerUIIndication(object sender, bool timerState)
        {
            timeTrackerUI1.SetPausedVisualIndication(timerState);
        }

        private void SetWindowStyle(object sender, Style style)
        {
            if (this.InvokeRequired)
            {
                StyleChangeDelegate d = new StyleChangeDelegate(SetWindowStyle);
                this.Invoke(d, new object[] { sender, style });
            }
            else
            {
                //Set the style
                this.style = style;
                //Set the foreground and background colors
                this.BackColor = ColorTranslator.FromHtml(style.trackerBackground);
                this.ForeColor = ColorTranslator.FromHtml(style.trackerForeground);
                //Create a custom color table for the menu and set the colors
                CustomMenuColorTable colorTable = new CustomMenuColorTable(style);
                //Recolor the table rows
                RecolorTableRows();
                //Set the time tracker UI style
                timeTrackerUI1.SetStyle(style);
            }          
        }

        public void ResetTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableController.ResetTable();
        }

        public void PauseTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsController.ToggleTimerPaused();
            tableController.SetLastChangeTime(); //On unpause we want to reset the inactivity timer
        }

        private void TemtemTrackerUI_ResizeEnd(object sender, EventArgs e)
        {
            settingsController.SetMainWindowSize(this.Size);
        }

        public void LoadTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Filter = "json files (*.json)|*.json",
                FilterIndex = 0,
                RestoreDirectory = true
            };
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                //Reset the table. This is necessary because loading adds elements to the UI
                //so we need to clear the UI first
                tableController.ResetTable();
                //Load the table from the provided file
                tableController.LoadTableFromFile(openFile.FileName);
            }
        }

        public void SaveTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "json files (*.json)|*.json",
                FilterIndex = 0,
                RestoreDirectory = true
            };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                tableController.SaveTableAs(saveDialog.FileName);
            }
        }

        public void ExportCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog exportDialog = new SaveFileDialog
            {
                Filter = "csv files (*.csv)|*.csv",
                FilterIndex = 0,
                RestoreDirectory = true
            };
            if (exportDialog.ShowDialog() == DialogResult.OK)
            {
                tableController.ExportCSV(exportDialog.FileName);
            }
        }
    }
}
