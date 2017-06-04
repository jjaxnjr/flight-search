using CodeChallenge.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CodeChallenge.Tests.CodeChallenge.DataAccess
{
    [TestClass]
    public class FlightServiceTests
    {

        [TestMethod]
        public void GetFlightsReturnsAllFlightsFromCsv()
        {
            // Arrange
            var flightService = new FlightService();
            flightService.FlightData = @"\Debug\SampleData\Flights.csv";

            // Act
            var results = flightService.GetFlights();

            //Assert
            Assert.AreEqual(48, results.Count());
        }
    }
}
