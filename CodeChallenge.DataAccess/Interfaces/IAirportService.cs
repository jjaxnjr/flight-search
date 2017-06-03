using CodeChallenge.DataAccess.Models;
using System.Collections.Generic;

namespace CodeChallenge.DataAccess.Interfaces
{
    public interface IAirportService
    {
        IEnumerable<Airport> GetAirports();
    }
}
