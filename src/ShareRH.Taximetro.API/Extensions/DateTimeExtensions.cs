using System;
using ShareRH.Taximetro.API.Constants;

namespace ShareRH.Taximetro.API.Extensions
{
    /// <summary>
    /// Provide extensions methods for <see cref="DateTime"/> objects.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Is considered as overnight when the hour is between <see cref="BusinessConstants.OverNightHourStart"/> and <see cref="BusinessConstants.OverNightHourEnd"/>.
        /// </summary>
        /// <param name="hour">The given hour to check if it is overnight.</param>
        /// <returns>True when it is overnight.</returns>
        private static bool IsOverNight(this int hour) => hour is > BusinessConstants.OverNightHourStart or < BusinessConstants.OverNightHourEnd;

        /// <summary>
        /// Check if the given date is Sunday.
        /// </summary>
        /// <param name="datetime">The date to check.</param>
        /// <returns>True when it is Sunday.</returns>
        private static bool IsSunday(this DateTime datetime) => datetime.DayOfWeek == DayOfWeek.Sunday;

        /// <summary>
        /// Check if the given <see cref="DateTime"/> is in a costly period.
        /// </summary>
        /// <param name="datetime">The <see cref="DateTime"/> object to validate.</param>
        /// <returns>True when the <see cref="DateTime"/> is in a costly period.</returns>
        public static bool IsRedFlag(this DateTime datetime) => IsOverNight(datetime.Hour) || IsSunday(datetime);
    }
}
