using AutoMapper;
using CodeChallenge.DataAccess.Interfaces;
using CodeChallenge.DataAccess.Models;
using CodeChallenge.Models;
using CodeChallenge.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Tests.CodeChallenge
{
    [TestClass]
    public class AirportRepositoryTests
    {
        private Mock<IAirportService> airportServiceMock;

        [TestInitialize]
        public void Initialize()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Airport, AirportViewModel>());

            airportServiceMock = new Mock<IAirportService>();
            airportServiceMock.Setup(a => a.GetAirports()).Returns(SampleData.AirportData);
        }

        [TestMethod]
        public void GetAirportsReturnsMultipleAirportViewModelObjects()
        {
            // Arrange
            var airportRepository = new AirportRepository(airportServiceMock.Object);

            // Act
            var airports = airportRepository.GetAirports();

            // Assert
            Assert.IsInstanceOfType(airports, typeof(List<AirportViewModel>));
            Assert.AreEqual(2, airports.Count());
        }
    }
}
