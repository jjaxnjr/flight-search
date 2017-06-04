using AutoMapper;
using CodeChallenge.Controllers;
using CodeChallenge.DataAccess.Interfaces;
using CodeChallenge.DataAccess.Models;
using CodeChallenge.Models;
using CodeChallenge.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace CodeChallenge.Tests.CodeChallenge
{
    [TestClass]
    public class AirportControllerTests
    {
        private Mock<IAirportService> airportServiceMock;
        private IMapper mapper;

        [TestInitialize]
        public void Initialize()
        {
            mapper = MapperConfig.RegisterMappings();

            airportServiceMock = new Mock<IAirportService>();
            airportServiceMock.Setup(a => a.GetAirports()).Returns(SampleData.AirportData);
        }

        [TestMethod]
        public void GetReturnsIEnumerableAirportViewModelObject()
        {
            // Arrange
            var airportRepository = new AirportRepository(airportServiceMock.Object, mapper);
            var airportController = new AirportController(airportRepository);

            // Act
            var results = airportController.Get();

            // Assert
            Assert.IsInstanceOfType(results, typeof(IEnumerable<AirportViewModel>));
        }

        [TestMethod]
        public void GetReturnsMultipleAirportViewModelObjects()
        {
            // Arrange
            var airportRepository = new AirportRepository(airportServiceMock.Object, mapper);
            var airportController = new AirportController(airportRepository);

            // Act
            var results = airportController.Get();
            var resultsData = results as List<AirportViewModel>;

            // Assert
            Assert.AreEqual(2, resultsData.Count);
        }
    }
}
