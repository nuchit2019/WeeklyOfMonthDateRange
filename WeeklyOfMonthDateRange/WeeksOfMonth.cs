using System;
using System.Collections.Generic;
using System.Globalization;

namespace WeeklyOfMonthDateRange
{
    public static class WeeksOfMonth
    {
        public static List<WeekOfMonthInfo> GetWeeksOfMonth(int year, int month)
        {
            List<WeekOfMonthInfo> weeks = new List<WeekOfMonthInfo>();

            DateTime firstDay = new DateTime(year, month, 1);
            DateTime lastDay = firstDay.AddMonths(1).AddDays(-1);

            DateTime startDate = firstDay;
            int weekNumber = 1;

            while (startDate <= lastDay)
            {
                DateTime endDate = startDate.AddDays(6 - (int)startDate.DayOfWeek); // จบที่วันอาทิตย์
                if (endDate > lastDay)
                {
                    endDate = lastDay;
                }

                weeks.Add(new WeekOfMonthInfo
                {
                    Month = month,
                    Week = weekNumber,
                    StartDate = startDate,
                    EndDate = endDate
                });

                startDate = endDate.AddDays(1);
                weekNumber++;
            }

            return weeks;
        }

        public static List<WeekOfMonthInfo> GetWeeksOfMonthSchedule(int year, int month)
        {
            List<WeekOfMonthInfo> weeks = new List<WeekOfMonthInfo>();

            DateTime firstDay = new DateTime(year, month, 1);
            DateTime lastDay = firstDay.AddMonths(1).AddDays(-1);
            DateTime startDate = firstDay;
            int weekNumber = 1;

            while (startDate <= lastDay)
            {
                DateTime endDate = startDate.AddDays(6 - (int)startDate.DayOfWeek); // ให้จบที่วันอาทิตย์
                if (endDate > lastDay)
                {
                    endDate = lastDay;
                }

                // คำนวณ Schedule เป็นวันถัดไปของ EndDate เวลา 00:30 น.
                DateTime scheduleDate = endDate.AddDays(1).Date.AddHours(0).AddMinutes(30);

                weeks.Add(new WeekOfMonthInfoSchedule
                {
                    Month = month,
                    Week = weekNumber,
                    StartDate = startDate,
                    EndDate = endDate,
                    Schedule = scheduleDate
                });

                startDate = endDate.AddDays(1);
                weekNumber++;
            }

            return weeks;
        }


        public static List<WeekOfMonthInfo> GetWeeksOfMonthScheduleTimeZone(int year, int month, string timeZoneId)
        {
            List<WeekOfMonthInfo> weeks = new List<WeekOfMonthInfo>();

            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            DateTime firstDay = new DateTime(year, month, 1);
            DateTime lastDay = firstDay.AddMonths(1).AddDays(-1);
            DateTime startDate = firstDay;
            int weekNumber = 1;

            while (startDate <= lastDay)
            {
                DateTime endDate = startDate.AddDays(6 - (int)startDate.DayOfWeek); // จบที่วันอาทิตย์
                if (endDate > lastDay)
                {
                    endDate = lastDay;
                }

                // กำหนด Schedule ให้เป็นวันถัดไปหลังจาก EndDate ที่เวลา 00:30 น.
                DateTime scheduleDate = endDate.AddDays(1).Date.AddHours(0).AddMinutes(30);
                DateTimeOffset scheduleWithTimeZone = TimeZoneInfo.ConvertTime(new DateTimeOffset(scheduleDate, TimeSpan.Zero), timeZone);

                weeks.Add(new WeekOfMonthInfoSheduleTimeZone
                {
                    Month = month,
                    Week = weekNumber,
                    StartDate = startDate,
                    EndDate = endDate,
                    Schedule = scheduleWithTimeZone
                });

                startDate = endDate.AddDays(1);
                weekNumber++;
            }

            return weeks;
        }

    }


}
