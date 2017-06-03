using CodeChallenge.DataAccess.Interfaces;
using CodeChallenge.DataAccess.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeChallenge.DataAccess
{
    public class FlightService : IFlightService
    {
        private string flightData;

        private IEnumerable<Flight> _flights;
        private IEnumerable<Flight> Flights
        {
            get
            {
                if(_flights == null)
                {
                    using (var stream = new StreamReader(flightData))
                    {
                        using (var csv = new CsvReader(stream))
                        {
                            _flights = csv.GetRecords<Flight>().ToList();
                        }
                    }
                }
                return _flights;
            }
        }

        public FlightService()
        {
            flightData = Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ApplicationBase) + @"\Debug\SampleData\Flights.csv";
        }

        public IEnumerable<Flight> GetFlights()
        {
            return Flights.ToList();
        }
    }
}
