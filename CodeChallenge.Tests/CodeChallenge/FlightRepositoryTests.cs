using CodeChallenge.DataAccess.Interfaces;
using CodeChallenge.DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Tests.CodeChallenge.DataAccess
{
    [TestClass]
    public class FlightRepositoryTests
    {
        private Mock<IFlightService> flightService;

        [TestInitialize]
        public void Initialize()
        {
            flightService = new Mock<IFlightService>();
            flightService.Setup(f => f.GetFlights()).Returns(SampleData.FlightData);
        }

        [TestMethod]
        public void GetFlightsReturnsMultipleFlightViewModelResults()
        {
            // Arrange
            var flightRepo = new FlightRepository(flightService.Object);
            string fromFlight = "SEA";
            string toFlight = "LAX";

            // Act
            var results = flightRepo.GetFlights(fromFlight, toFlight);

            // Assert
            Assert.AreEqual(2, results.Count());
        }
    }
}
