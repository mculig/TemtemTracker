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
        private readonly TemtemDataRow row;
        private readonly TemtemTableController controller;

        public TemtemTableRowUI(TemtemDataRow row, TemtemTableController controller)
        {
            InitializeComponent();
            this.row = row;
            this.controller = controller;
            UpdateRow();
            this.Dock = DockStyle.Top;
            //Set delete button hover
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
                labelChanceLuma.Text = DoubleToPercent(row.lumaChance);
                labelEncounteredPercent.Text = DoubleToPercent(row.encounteredPercent);
                labelTimeToLuma.Text = MilisToHMS(row.timeToLuma);
            }
            
        }

        public void SetDark(Style style)
        {
            BackColor = ColorTranslator.FromHtml(style.tableRowBackground1);
            ForeColor = ColorTranslator.FromHtml(style.tableRowForeground1);
            deleteButton.BackColor = ColorTranslator.FromHtml(style.tableRowButtonBackground);
            deleteButton.ForeColor = ColorTranslator.FromHtml(style.tableRowButtonForeground);
            deleteButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(style.tableRowButtonHoverColor);
            deleteButton.FlatAppearance.BorderColor = ColorTranslator.FromHtml(style.tableRowButtonBorderColor);
            buttonShowIndividualWindow.BackColor = ColorTranslator.FromHtml(style.tableRowButtonBackground);
            buttonShowIndividualWindow.ForeColor = ColorTranslator.FromHtml(style.tableRowButtonForeground);
            buttonShowIndividualWindow.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(style.tableRowButtonHoverColor);
            buttonShowIndividualWindow.FlatAppearance.BorderColor = ColorTranslator.FromHtml(style.tableRowButtonBorderColor);
        }

        public void SetLight(Style style)
        {
            BackColor = ColorTranslator.FromHtml(style.tableRowBackground2);
            ForeColor = ColorTranslator.FromHtml(style.tableRowForeground2);
            deleteButton.BackColor = ColorTranslator.FromHtml(style.tableRowButtonBackground);
            deleteButton.ForeColor = ColorTranslator.FromHtml(style.tableRowButtonForeground);
            deleteButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(style.tableRowButtonHoverColor);
            deleteButton.FlatAppearance.BorderColor = ColorTranslator.FromHtml(style.tableRowButtonBorderColor);
            buttonShowIndividualWindow.BackColor = ColorTranslator.FromHtml(style.tableRowButtonBackground);
            buttonShowIndividualWindow.ForeColor = ColorTranslator.FromHtml(style.tableRowButtonForeground);
            buttonShowIndividualWindow.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(style.tableRowButtonHoverColor);
            buttonShowIndividualWindow.FlatAppearance.BorderColor = ColorTranslator.FromHtml(style.tableRowButtonBorderColor);
        }

        private String DoubleToPercent(double number)
        {
            return number.ToString("P");
        }

        private String MilisToHMS(long milis)
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(milis);
            return ((int) ts.TotalHours).ToString("00") + ts.ToString(@"\:mm\:ss");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            controller.RemoveRow(row);
        }

        private void ButtonShowIndividualWindow_Click(object sender, EventArgs e)
        {
            controller.ShowIndividualWindow(row);
        }
    }
}
