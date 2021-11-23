namespace ShareRH.Taximetro.API.Models
{
    /// <summary>
    /// Encapsulate the taxi methods.
    /// </summary>
    public interface ITaxi
    {
        /// <summary>
        /// Include in the history of trips the name of the current passenger.
        /// </summary>
        /// <param name="passengerName">The name of the passenger that is doing the trip.</param>
        void AddTripFor(string passengerName);

        /// <summary>
        /// Retrieve the latest passenger name after the three firsts.
        /// Before complete three trips no passengers name will be returned.
        /// </summary>
        /// <returns>The name of the latest passenger after complete the minimum trips to fill the history.</returns>
        string GetLastPassenger();
    }
}
