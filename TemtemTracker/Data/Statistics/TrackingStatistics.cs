using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemtemTracker.Data
{
    public class TrackingStatistics
    {
        public List<DailyEncounterStatistics> dailyEncounters;
        public int singleBattlesTotal;
        public int doubleBattlesTotal;
        public List<DailyPlaytimeStatistics> dailyPlaytime;
    }
}
