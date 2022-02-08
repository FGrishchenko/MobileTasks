using System;
using System.Globalization;

namespace KickstarterTests.Utilities
{
    public static class DateUtils
    {
        private static string DateFormat = "MMM dd, yyyy";

        public static string AddDaysAndReturnValidFormat(DateTime todayDate, string days)
        {
            var ExpectedDate = todayDate.AddDays(double.Parse(days));
            return ExpectedDate.ToString(DateFormat, CultureInfo.GetCultureInfo("en-en"));
        }
    }
}
