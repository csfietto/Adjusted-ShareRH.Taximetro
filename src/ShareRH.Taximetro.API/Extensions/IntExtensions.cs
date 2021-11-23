using System;
using ShareRH.Taximetro.API.Constants;
using ShareRH.Taximetro.API.Models;

namespace ShareRH.Taximetro.API.Extensions
{
    /// <summary>
    /// Provide extensions methods for <see cref="int"/> values.
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Check if the distance is higher than the limit to consider as common.
        /// The limit is defined in <see cref="BusinessConstants.LongDistanceSinceFrom"/>.
        /// </summary>
        /// <param name="distance">The distance to check if it is long or short.</param>
        /// <returns>True when we have a long distance.</returns>
        public static bool IsLongDistance(this int distance) => distance > BusinessConstants.LongDistanceSinceFrom;

        /// <summary>
        /// Check if the distance is valid. Must be greater than 0.
        /// </summary>
        /// <param name="distance">The distance to check if it is valid.</param>
        /// <returns>True for a valid distance.</returns>
        public static bool IsValidDistance(this int distance) => distance >= BusinessConstants.MinimumAllowedDistance;

        /// <summary>
        /// Creates a trip based on the given distance and date.
        /// </summary>
        /// <param name="distance">The <see cref="int"/> value representing the distance of the trip.</param>
        /// <param name="datetime">The <see cref="DateTime"/> value to indicate when this trip was done.</param>
        /// <returns>An instance of <see cref="Trip"/>.</returns>
        public static Trip ToTrip(this int distance, DateTime datetime) => new Trip(datetime, distance);
    }
}
