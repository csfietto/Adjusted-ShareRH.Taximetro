using System;
using ShareRH.Taximetro.API.Constants;
using ShareRH.Taximetro.API.Extensions;

namespace ShareRH.Taximetro.API.Models
{
    /// <summary>
    /// Encapsulate the trip attributes.
    /// </summary>
    public class Trip
    {
        /// <summary>
        /// The distance of the trip.
        /// </summary>
        public int Distance { get; }
        
        /// <summary>
        /// When the trip happened.
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Creates an instance of <see cref="Trip"/>.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> when the trip was done.</param>
        /// <param name="distance">The distance of the trip.</param>
        public Trip(DateTime date, int distance) =>
            (Date, Distance) = (date, distance);

        /// <summary>
        /// Calculate the price of the trip based on some conditions.
        /// </summary>
        /// <returns>The <see cref="double"/> value representing the total cost of the trip.</returns>
        public double CalculatePrice()
        {
            if (!Distance.IsValidDistance()) return 0;

            var costByMeter = Distance.IsLongDistance()
                ? BusinessConstants.LongDistanceCostByMeter
                : BusinessConstants.CommonCostByMeter;

            if (Date.IsRedFlag())
                costByMeter *= BusinessConstants.RedFlagDateFareMultiplier;

            return Distance * costByMeter;
        }

        /// <summary>
        /// Check if the <see cref="Trip"/> instance is valid.
        /// The <see cref="Trip.Distance"/> must be greater than 0.
        /// </summary>
        /// <returns>True when the instance of <see cref="Trip"/> is valid.</returns>
        public bool IsValid() => Distance.IsValidDistance();
    }
}
