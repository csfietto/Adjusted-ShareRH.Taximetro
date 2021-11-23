using System.Collections.Generic;
using System.Linq;

namespace ShareRH.Taximetro.API.Models
{
    /// <inheritdoc />
    public class Taxi : ITaxi
    {
        /// <summary>
        /// Memory repository of passengers.
        /// </summary>
        private static readonly List<string> _passengers = new();

        /// <inheritdoc />
        public void AddTripFor(string passengerName) => _passengers.Add(passengerName);

        /// <inheritdoc />
        public string GetLastPassenger() =>
            _passengers.Count > 3
                ? _passengers.LastOrDefault() ?? "No last passenger was found"
                : "There is no enough history to return the passenger name";
    }
}
