using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemtemTracker.Controllers;
using TemtemTracker.Data;

namespace TemtemTracker
{
    public partial class IndividualTrackerWindow : Form
    {
        private readonly TemtemDataRow temtemRow;
        private delegate void TimeUpdateDelegate(long timeMilis);
        private delegate void TemtemHUpdateDelegate(double temtemH);
        private delegate void StyleChangeDelegate(object sender, Style style);
        private delegate void OpacityChangeDelegate(object sender, double opacity);
        private delegate void WindowUpdateDelegate();

        public IndividualTrackerWindow(TemtemDataRow temtemRow)
        {
            InitializeComponent();
            this.temtemRow = temtemRow;
            UpdateWindow();
            ApplicationStateController.Instance.StyleChanged += SetWindowStyle;
            ApplicationStateController.Instance.MainWindowOpacityChanged += OpacityChanged;
            SetWindowStyle(null, ApplicationStateController.Instance.GetWindowStyle());
            OpacityChanged(null, ApplicationStateController.Instance.GetUserSettings().mainWindowOpacity);
        }

        private void OpacityChanged(object sender, double opacity)
        {
            if (this.InvokeRequired)
            {
                OpacityChangeDelegate d = new OpacityChangeDelegate(OpacityChanged);
                this.Invoke(d, new object[] { sender, opacity });
            }
            else
            {
                this.Opacity = opacity;
            }
        }

        public void SetWindowStyle(object sender, Style style)
        {
            if (this.InvokeRequired)
            {
                StyleChangeDelegate d = new StyleChangeDelegate(SetWindowStyle);
                this.Invoke(d, new object[] { sender, style });
            }
            else
            {
                //Set the foreground and background colors
                this.BackColor = ColorTranslator.FromHtml(style.trackerBackground);
                this.ForeColor = ColorTranslator.FromHtml(style.trackerForeground);
            }         
        }

        public void UpdateTime(long timeMilis)
        {
            if (this.InvokeRequired)
            {
                TimeUpdateDelegate d = new TimeUpdateDelegate(UpdateTime);
                this.Invoke(d, new object[] { timeMilis });
            }
            else
            {
                labelTimer.Text = HelperMethods.MilisToHMS(timeMilis);
            }
        }

        public void UpdateTemtemH(double temtemH)
        {
            if (this.InvokeRequired)
            {
                TemtemHUpdateDelegate d = new TemtemHUpdateDelegate(UpdateTemtemH);
                this.Invoke(d, new object[] { temtemH });
            }
            else
            {
                labelTemtemPerHour.Text = Math.Round(temtemH, 2).ToString();
            }
        }

        public void UpdateWindow()
        {
            if (this.InvokeRequired)
            {
                WindowUpdateDelegate d = new WindowUpdateDelegate(UpdateWindow);
                this.Invoke(d, new object[] { });
            }
            else
            {
                labelTemtemName.Text = temtemRow.name;
                labelEncounters.Text = temtemRow.encountered.ToString();
                labelChanceLuma.Text = HelperMethods.DoubleToPercentage(temtemRow.lumaChance);
                labelEncounteredPercent.Text = HelperMethods.DoubleToPercentage(temtemRow.encounteredPercent);
            }

        }

        private void IndividualTrackerWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
