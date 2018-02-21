using System;

namespace FrameworkCommon.Toolbox
{
    public class DateUtils
    {
        /// <summary>
        /// Gets the current date in yyyy-MM-dd format.
        /// </summary>
        /// <returns>Today's date as a string</returns>
        public static string GetCurrentDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Get's the current time in HH-mm-ss-fff format.
        /// </summary>
        /// <returns>The current time as a string</returns>
        public static string GetCurrentTime()
        {
            return DateTime.Now.ToString("HH-mm-ss-fff");
        }

        /// <summary>
        /// Returns a DateTime representing the first day of this month.
        /// </summary>
        public static DateTime GetStartOfThisMonth()
        {
            return DateTime.Today.AddDays(1 - DateTime.Today.Day);
        }

        /// <summary>
        /// Returns a DateTime representing the last day of this month.
        /// </summary>
        public static DateTime GetEndOfThisMonth()
        {
            return new DateTime
            (
                DateTime.Today.Year,
                DateTime.Today.Month,
                DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month)
            );
        }

        /// <summary>
        /// Returns the number of seconds that have elapsed since 1970-01-01T00:00:00Z.
        /// </summary>
        /// <returns>The number of seconds that have elapsed since 1970-01-01T00:00:00Z.</returns>
        public static long GetUnixTimeStamp()
        {
            // Get the time now
            DateTime now = DateTime.Now;
            // Convert and return the time
            return ((DateTimeOffset)now).ToUnixTimeSeconds();
        }
    }
}
