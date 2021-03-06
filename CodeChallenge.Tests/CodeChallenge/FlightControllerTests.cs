﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeChallenge.Controllers;
using CodeChallenge.Models;
using System.Collections.Generic;
using AutoMapper;
using CodeChallenge.DataAccess.Models;
using Moq;
using System;
using CodeChallenge.DataAccess.Interfaces;
using System.Linq;
using CodeChallenge.Repositories;

namespace CodeChallenge.Tests
{
    /*  Required Functionality
        - User should be able to search for flights between two different airports.
            - ArgumentException thrown for same airport as to and from.
            - Flights returned when two different airports.
            - Search results return as JsonResult.
        - User should be able to see a list of flights matching the search parameters on the previous step
            - Flights returned are only those which were selected in the from and to.
        - User should be able to sort the flights by price or departure
    */

    [TestClass]
    public class FlightControllerTests
    {
        private Mock<IFlightService> flightServiceMock;
        private IMapper mapper;

        [TestInitialize]
        public void Initialize()
        {
            mapper = MapperConfig.RegisterMappings();

            flightServiceMock = new Mock<IFlightService>();
            flightServiceMock.Setup(f => f.GetFlights()).Returns(SampleData.FlightData);
        }

        [TestMethod]
        public void GetFlightsReturnsIEnumerableFlightViewModelObject()
        {
            // Arrange
            var flightRepository = new FlightRepository(flightServiceMock.Object, mapper);
            var flightController = new FlightController(flightRepository);
            var flightSearch = new FlightSearch()
            {
                FromAirport = "SEA",
                ToAirport = "LAX"
            };

            // Act
            var flights = flightController.Post(flightSearch);

            // Assert
            Assert.IsInstanceOfType(flights, typeof(IEnumerable<FlightViewModel>));
        }

        [TestMethod]
        public void GetFlightsReturnsMulitpleFlightRecords()
        {
            // Arrange
            var flightRepository = new FlightRepository(flightServiceMock.Object, mapper);
            var flightController = new FlightController(flightRepository);
            var flightSearch = new FlightSearch()
            {
                FromAirport = "SEA",
                ToAirport = "LAX"
            };

            // Act
            var flights = flightController.Post(flightSearch);
            
            // Assert
            Assert.AreEqual(2, flights.Count());
        }

        [TestMethod]
        public void GetFlightsWithSameAirportReturnsEmptyResults()
        {
            // Arrange
            var flightRepository = new FlightRepository(flightServiceMock.Object, mapper);
            var flightController = new FlightController(flightRepository);
            var flightSearch = new FlightSearch()
            {
                FromAirport = "SEA",
                ToAirport = "SEA"
            };

            // Act
            var results = flightController.Post(flightSearch);
            var resultsData = results as List<FlightViewModel>;

            // Assert
            Assert.AreEqual(0, resultsData.Count);
        }

        [TestMethod]
        public void GetFlightsFromSeaToLasReturnsAFlightObject()
        {
            // Arrange
            var flightRepository = new FlightRepository(flightServiceMock.Object, mapper);
            var flightController = new FlightController(flightRepository);
            var flightSearch = new FlightSearch()
            {
                FromAirport = "SEA",
                ToAirport = "LAS"
            };

            // Act
            var flights = flightController.Post(flightSearch);
            var flightData = flights as List<FlightViewModel>;

            // Assert
            Assert.AreEqual(1, flightData.Count);
            Assert.AreEqual("SEA", flightData[0].From);
            Assert.AreEqual("LAS", flightData[0].To);
        }
    }
}
