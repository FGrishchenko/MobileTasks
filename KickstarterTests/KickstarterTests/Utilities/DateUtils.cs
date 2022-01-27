using System;
using System.Globalization;

namespace KickstarterTests.Utilities
{
    public static class DateUtils
    {
        private static string DateFormat = "MMM dd, yyyy";

        public static string AddDaysAndReturnValidFormat(DateTime TodayDate, string days)
        {
            var ExpectedDate = TodayDate.AddDays(double.Parse(days)); // DaysToGo
            return ExpectedDate.ToString(DateFormat, CultureInfo.GetCultureInfo("en-en"));
        }
    }
}
