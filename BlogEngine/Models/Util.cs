using System;

namespace BlogEngine.Models
{
    public static class Util
    {
        /// <summary>
        /// Extension method to convert a given DateTime value to a string representing how recently
        /// the date occurred.
        /// </summary>
        /// <param name="date">The DateTime value to parse.</param>
        /// <returns>A string.</returns>
        public static string ToDisplayDate(this DateTime date)
        {
            DateTime now = DateTime.Now;
            TimeSpan dateDiff = now - date;

            if (dateDiff.Seconds > 0 && dateDiff.Seconds < 60)
            {
                return "Just now";
            }

            return "";
        }

    }
}