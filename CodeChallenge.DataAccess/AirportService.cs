using CodeChallenge.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge.DataAccess.Models;
using System.IO;
using CsvHelper;

namespace CodeChallenge.DataAccess
{
    public class AirportService : IAirportService
    {
        private string airportData;

        private IEnumerable<Airport> _airports;
        private IEnumerable<Airport> Airports
        {
            get
            {
                if (_airports == null)
                {
                    using (var stream = new StreamReader(airportData))
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

        public AirportService()
        {
            airportData = Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ApplicationBase) + @"\Debug\SampleData\Airports.csv";
        }


        public IEnumerable<Airport> GetAirports()
        {
            return Airports.ToList();
        }
    }
}
