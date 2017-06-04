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
        public string FlightData {
            get
            {
                if(flightData == null)
                {
                    //Default location when running the application
                    flightData = Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ApplicationBase) + @"\bin\SampleData\Flights.csv";
                }
                return flightData;
            }
            set
            {
                //Allows flightData to be overriden in such cases like Unit Tests where the location is different.
                flightData = Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ApplicationBase) + value;
            }
        }

        private IEnumerable<Flight> _flights;
        private IEnumerable<Flight> Flights
        {
            get
            {
                if(_flights == null)
                {
                    using (var stream = new StreamReader(FlightData))
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

        public IEnumerable<Flight> GetFlights()
        {
            return Flights.ToList();
        }
    }
}
