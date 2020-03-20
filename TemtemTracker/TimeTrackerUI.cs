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
