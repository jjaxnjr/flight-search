using CodeChallenge.Models;
using System.Collections.Generic;

namespace CodeChallenge.Interfaces
{
    public interface IAirportRepository
    {
        IEnumerable<AirportViewModel> GetAirports();
    }
}