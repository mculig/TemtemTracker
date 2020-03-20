using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemtemTracker.Data
{
    public class TemtemDataTable
    {
        public List<TemtemDataRow> rows;
        public TemtemDataRow total;
        public TimerData timer;
    }
}
