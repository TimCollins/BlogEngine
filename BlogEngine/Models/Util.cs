using System;
using System.Globalization;

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

            if (dateDiff.TotalSeconds > 0 && dateDiff.TotalSeconds < 3600)
            {
                if (dateDiff.TotalSeconds < 60)
                {
                    return "Just now";
                }

                return ((int)Math.Round(dateDiff.TotalSeconds / 60)) + " mins ago";
            }

            if (dateDiff.TotalHours < 24)
            {
                int hours = (int)Math.Floor(dateDiff.TotalHours);

                return hours + (hours == 1 ? " hour ago" : " hours ago");
            }

            if (dateDiff.TotalHours > 24 && dateDiff.TotalHours < 48)
            {
                return "Yesterday";
            }

            if (dateDiff.TotalHours > 48 && dateDiff.TotalHours < 72)
            {
                return "2 days ago";
            }

            string month = date.ToString("MMM", CultureInfo.InvariantCulture);

            return string.Format("{0} {1} {2}",
                month,
                date.Day,
                date.Year);
        }
    }
}