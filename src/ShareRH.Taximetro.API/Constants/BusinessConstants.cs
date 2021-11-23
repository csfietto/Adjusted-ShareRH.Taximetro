namespace ShareRH.Taximetro.API.Constants
{
    /// <summary>
    /// Keep all the constant values used on this API.
    /// </summary>
    public static class BusinessConstants
    {
        /// <summary>
        /// Indicate since which hour the overnight starts.
        /// </summary>
        public const int OverNightHourStart = 22;

        /// <summary>
        /// Indicate until when the overnight is still valid.
        /// </summary>
        public const int OverNightHourEnd = 6;

        /// <summary>
        /// The minimum value to consider the trip as a short one.
        /// </summary>
        public const int LongDistanceSinceFrom = 100;

        /// <summary>
        /// Minimum distance allowed.
        /// </summary>
        public const int MinimumAllowedDistance = 1;

        /// <summary>
        /// The initial cost of the meter.
        /// </summary>
        public const double CommonCostByMeter = 0.1;

        /// <summary>
        /// The price of the meter when it is a long trip.
        /// </summary>
        public const double LongDistanceCostByMeter = 0.15;

        /// <summary>
        /// How much must be multiply the meter's price when the trip is in a red flag period.
        /// </summary>
        public const double RedFlagDateFareMultiplier = 2;
    }
}
