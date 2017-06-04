using CodeChallenge.DataAccess;
using CodeChallenge.DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Tests.CodeChallenge.DataAccess
{
    [TestClass]
    public class AirportServiceTests
    {
        [TestMethod]
        public void GetAirportsReturnsAnEnumerableOfAirport()
        {
            // Arrange
            var airportService = new AirportService();
            airportService.AirportData = @"\Debug\SampleData\Airports.csv";

            // Act
            var results = airportService.GetAirports();

            // Assert
            Assert.IsInstanceOfType(results, typeof(IEnumerable<Airport>));
        }

        [TestMethod]
        public void GetAirportsReturnsCsvData()
        {
            // Arrange
            var airportService = new AirportService();
            airportService.AirportData = @"\Debug\SampleData\Airports.csv";

            // Act
            var results = airportService.GetAirports();

            // Assert
            Assert.AreEqual(4, results.Count());
        }

    }
}
