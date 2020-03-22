using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemtemTracker
{
    public partial class TimeTrackerUI : UserControl
    {
        private static readonly string TIME_TITLE_PAUSED = "Time - Paused";
        private static readonly string TIME_TITLE_RUNNING = "Time"; 

        private delegate void SafeTimeUpdateDelegate(long timeMilis);
        private delegate void SafeTemtemHUpdateDelegate(double temtemH);

        public TimeTrackerUI()
        {
            InitializeComponent();
        }

        public void UpdateTime(long timeMilis)
        {
            if(this.InvokeRequired)
            {
                SafeTimeUpdateDelegate d = new SafeTimeUpdateDelegate(UpdateTime);
                this.Invoke(d, new object[] { timeMilis });
            }
            else
            {
                TimeSpan ts = TimeSpan.FromMilliseconds(timeMilis);
                timeLabel.Text = ((int)ts.TotalHours).ToString("00") + ts.ToString(@"\:mm\:ss");
            }
        }

        public void TogglePausedVisualIndication(bool timerState)
        {
            if (timerState)
            {
                //Set the timer label color and font back to normal
                timeLabel.ForeColor = Color.Black;
                timeLabel.Font = new Font(timeLabel.Font, FontStyle.Regular);
                //Set the color of the title and the text back to normal
                labelTimeTitle.ForeColor = Color.Black;
                labelTimeTitle.Font = new Font(labelTimeTitle.Font, FontStyle.Bold);
                labelTimeTitle.Text = TIME_TITLE_RUNNING;
            }
            else
            {
                //Set the timer label color red and text bold
                timeLabel.ForeColor = Color.Red;
                timeLabel.Font = new Font(timeLabel.Font, FontStyle.Bold);
                //Set the color of the title to red, font to bold and text to paused text
                labelTimeTitle.ForeColor = Color.Red;
                labelTimeTitle.Font = new Font(labelTimeTitle.Font, FontStyle.Bold);
                labelTimeTitle.Text = TIME_TITLE_PAUSED;
            }
        }

        public void UpdateTemtemH(double temtemH)
        {
            if (this.InvokeRequired)
            {
                SafeTemtemHUpdateDelegate d = new SafeTemtemHUpdateDelegate(UpdateTemtemH);
                this.Invoke(d, new object[] { temtemH });
            }
            else
            {
                temtemHLabel.Text = Math.Round(temtemH, 2).ToString();
            }
        }

    }
}
