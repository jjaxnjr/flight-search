using CodeChallenge.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge.DataAccess.Models;

namespace CodeChallenge.DataAccess
{
    public class AirportService : IAirportService
    {
        public IEnumerable<Airport> GetAirports()
        {
            return new List<Airport>();
        }
    }
}
