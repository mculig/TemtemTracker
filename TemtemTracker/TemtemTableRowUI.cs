using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemtemTracker.Data;
using TemtemTracker.Controllers;

namespace TemtemTracker
{
    public partial class TemtemTableRowUI : UserControl
    {

        private delegate void SafeCallDelegate();
        private TemtemDataRow row;
        private TemtemTableController controller;

        public TemtemTableRowUI(TemtemDataRow row, TemtemTableController controller)
        {
            InitializeComponent();
            this.row = row;
            this.controller = controller;
            UpdateRow();
            this.Dock = DockStyle.Top;
        }

        public void UpdateRow()
        {
            if (this.InvokeRequired)
            {
                SafeCallDelegate d = new SafeCallDelegate(UpdateRow);
                this.Invoke(d, new object[] { });
            }
            else
            {
                labelTemtemName.Text = row.name;
                labelEncounters.Text = row.encountered.ToString();
                labelChanceLuma.Text = doubleToPercent(row.lumaChance);
                labelEncounteredPercent.Text = doubleToPercent(row.encounteredPercent);
                labelTimeToLuma.Text = milisToHMS(row.timeToLuma);
            }
            
        }

        private String doubleToPercent(double number)
        {
            return number.ToString("P");
        }

        private String milisToHMS(long milis)
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(milis);
            return ((int) ts.TotalHours).ToString("00") + ts.ToString(@"\:mm\:ss");
        }

        private void deleteButtonClick(object sender, EventArgs e)
        {
            controller.RemoveRow(row);
        }
    }
}
