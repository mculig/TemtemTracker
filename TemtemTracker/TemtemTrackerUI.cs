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
            } 
        }

        public void RemoveRowFromTable(TemtemTableRowUI row)
        {
            trackerTable.Controls.Remove(row);
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

        }

        private void TemtemTrackerUI_ResizeEnd(object sender, EventArgs e)
        {
            settingsController.SetMainWindowSize(this.Size);
        }
    }
}
