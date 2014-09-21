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

            if (dateDiff.TotalSeconds > 0 && dateDiff.TotalSeconds < 60)
            {
                return "Just now";
            }

            return ((int)Math.Round(dateDiff.TotalSeconds / 60)) + " mins ago";
        }

    }
}