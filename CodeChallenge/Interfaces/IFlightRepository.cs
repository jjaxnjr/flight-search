using System.Collections.Generic;
using CodeChallenge.Models;

namespace CodeChallenge.Interfaces
{
    public interface IFlightRepository
    {
        IEnumerable<FlightViewModel> GetFlights(string from, string to);
    }
}