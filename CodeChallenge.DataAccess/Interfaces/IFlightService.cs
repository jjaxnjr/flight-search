using System.Collections.Generic;
using CodeChallenge.DataAccess.Models;

namespace CodeChallenge.DataAccess.Interfaces
{
    public interface IFlightService
    {
        IEnumerable<Flight> GetFlights();
    }
}