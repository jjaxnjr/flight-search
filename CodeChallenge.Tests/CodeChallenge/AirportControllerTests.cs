using AutoMapper;
using CodeChallenge.Controllers;
using CodeChallenge.DataAccess.Interfaces;
using CodeChallenge.DataAccess.Models;
using CodeChallenge.Models;
using CodeChallenge.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CodeChallenge.Tests.CodeChallenge
{
    [TestClass]
    public class AirportControllerTests
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
        public void GetAirportsReturnsJsonResultObject()
        {
            // Arrange
            var airportRepository = new AirportRepository(airportServiceMock.Object);
            var airportController = new AirportController(airportRepository);

            // Act
            var results = airportController.GetAirports();

            // Assert
            Assert.IsInstanceOfType(results, typeof(JsonResult));
        }
    }
}
