
using WeeklyOfMonthDateRange;
 
int year = 2025;
string timeZoneId = "Asia/Bangkok"; // ปรับค่า TimeZone ได้ตามต้องการ
List<WeekOfMonthInfo> weeksList = new List<WeekOfMonthInfo>();

for (int month = 1; month <= 12; month++)
{
    weeksList.AddRange(WeeksOfMonth.GetWeeksOfMonthScheduleTimeZone(year, month, timeZoneId));
}

// แสดงผลข้อมูล
Console.WriteLine("Month,Week,Start_Date,End_Date,Schedule");
foreach (var week in weeksList)
{
    Console.WriteLine(week);
}