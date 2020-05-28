using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemtemTracker.Data
{
    public class PlayingSessionTime
    {
        public DateTime dayPlaying; //The day when the day duration field way valid. A new day means starting from 0
        public long dayDuration; //Time played during this day
        public long sessionDuration; //Time played during the last play session
    }
}
