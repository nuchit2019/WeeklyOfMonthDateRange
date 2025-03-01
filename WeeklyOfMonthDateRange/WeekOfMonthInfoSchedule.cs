using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyOfMonthDateRange
{
    internal class WeekOfMonthInfoSchedule : WeekOfMonthInfo
    {
        public DateTime Schedule { get; set; }
        public override string ToString()
        {
            return $"{Month},{Week},{StartDate:yyyy-MM-dd},{EndDate:yyyy-MM-dd},{Schedule:yyyy-MM-dd HH:mm}";
        }
    }
}
