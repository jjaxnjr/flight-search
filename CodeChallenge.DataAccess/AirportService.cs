using CodeChallenge.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using CodeChallenge.DataAccess.Models;
using System.IO;
using CsvHelper;

namespace CodeChallenge.DataAccess
{
    public class AirportService : IAirportService
    {
        private string airportData;
        public string AirportData
        {
            get
            {
                if (airportData == null)
                {
                    //Default location when running the application
                    airportData = Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ApplicationBase) + @"\bin\SampleData\Airports.csv";
                }
                return airportData;
            }
            set
            {
                //Allows airportData to be overriden in such cases like Unit Tests where the location is different.
                airportData = Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ApplicationBase) + value;
            }
        }

        private IEnumerable<Airport> _airports;
        private IEnumerable<Airport> Airports
        {
            get
            {
                if (_airports == null)
                {
                    using (var stream = new StreamReader(AirportData))
                    {
                        using (var csv = new CsvReader(stream))
                        {
                            _airports = csv.GetRecords<Airport>().ToList();
                        }
                    }
                }
                return _airports;
            }
        }
        
        public IEnumerable<Airport> GetAirports()
        {
            return Airports.ToList();
        }
    }
}
