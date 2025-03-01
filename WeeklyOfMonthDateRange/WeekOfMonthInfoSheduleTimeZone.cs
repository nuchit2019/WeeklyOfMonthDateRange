using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WeeklyOfMonthDateRange
{
    public class WeekOfMonthInfoSheduleTimeZone : WeekOfMonthInfo
    {
        public DateTimeOffset Schedule { get; set; }
        public override string ToString()
        {
            return $"{Month},{Week},{StartDate:yyyy-MM-dd},{EndDate:yyyy-MM-dd},{Schedule:yyyy-MM-dd HH:mm zzz}";
        }
    }
}
