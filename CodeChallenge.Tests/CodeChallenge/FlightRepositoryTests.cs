using AutoMapper;
using CodeChallenge.DataAccess.Interfaces;
using CodeChallenge.DataAccess.Models;
using CodeChallenge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Tests.CodeChallenge.DataAccess
{
    [TestClass]
    public class FlightRepositoryTests
    {
        private Mock<IFlightService> flightServiceMock;

        [TestInitialize]
        public void Initialize()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Flight, FlightViewModel>());

            flightServiceMock = new Mock<IFlightService>();
            flightServiceMock.Setup(f => f.GetFlights()).Returns(SampleData.FlightData);
        }

        [TestMethod]
        public void GetFlightsReturnsMultipleFlightViewModelResults()
        {
            // Arrange
            var flightRepo = new FlightRepository(flightServiceMock.Object);
            string fromFlight = "SEA";
            string toFlight = "LAX";

            // Act
            var results = flightRepo.GetFlights(fromFlight, toFlight);

            // Assert
            Assert.AreEqual(2, results.Count());
        }

        [TestMethod]
        public void GetFlightsFromSeaToLasReturnsAFlightObject()
        {
            // Arrange
            var flightRepo = new FlightRepository(flightServiceMock.Object);
            var from = "SEA";
            var to = "LAS";

            // Act
            var flights = flightRepo.GetFlights(from, to);
            var flightData = flights as List<FlightViewModel>;

            // Assert
            Assert.AreEqual(1, flightData.Count);
            Assert.AreEqual("SEA", flightData[0].From);
            Assert.AreEqual("LAS", flightData[0].To);
        }
    }
}
