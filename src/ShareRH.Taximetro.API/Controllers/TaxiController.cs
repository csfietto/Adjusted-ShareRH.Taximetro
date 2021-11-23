using Microsoft.AspNetCore.Mvc;
using System;
using ShareRH.Taximetro.API.Extensions;
using ShareRH.Taximetro.API.Models;

namespace ShareRH.Taximetro.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxiController : ControllerBase
    {
        /// <summary>
        /// An instance injected of <see cref="ITaxi"/>.
        /// </summary>
        private readonly ITaxi _taxi;

        /// <summary>
        /// Constructor method for <see cref="TaxiController"/>.
        /// </summary>
        /// <param name="taxi">An instance injected of <see cref="ITaxi"/>.</param>
        public TaxiController(ITaxi taxi) => _taxi = taxi;

        /// <summary>
        /// Calculates the price of the trip based on the given distance and datetime.
        /// Save the trip history with the passengers name.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> when the trip happened.</param>
        /// <param name="distance">The distance ran by the taxi on this trip.</param>
        /// <param name="passengerName">The name of the passenger.</param>
        /// <returns>The price of the trip.</returns>
        [HttpPost] 
        public double CalculateTrip(DateTime date, int distance, string passengerName)
        {
            try
            {
                var trip = distance.ToTrip(date);
                if (!trip.IsValid()) return 0;

                _taxi.AddTripFor(passengerName);

                return trip.CalculatePrice();
            }
            catch (Exception ex)
            {
                //TODO: Register in the log the ex.ToString() with a WARNING level once the application will not crash
                return 0;
            }
        }

        /// <summary>
        /// Return the name of the last passenger only after complete 3 trips.
        /// </summary>
        /// <returns>The name of the latest passenger, since the fourth one.</returns>
        [HttpGet]
        public string GetLastPassengerNameAfterThreeFirsts() => _taxi.GetLastPassenger();
    }
}
