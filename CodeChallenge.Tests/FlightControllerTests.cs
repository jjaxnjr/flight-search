using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeChallenge.Controllers;
using System.Web.Mvc;
using CodeChallenge.Models;

namespace CodeChallenge.Tests
{
    [TestClass]
    public class FlightControllerTests
    {
        [TestMethod]
        public void GetFlightsReturnsJsonResultObject()
        {
            // Arrange
            var fieldController = new FieldController();
            var fromAirport = "SEA";
            var toAirport = "LAX";

            // Act
            var flights = fieldController.GetFlights(fromAirport, toAirport);

            // Assert
            Assert.IsInstanceOfType(flights, typeof(JsonResult));
        }

        [TestMethod]
        public void GetFlightsWithSeaAndLaxReturnsFieldJsonObject()
        {
            // Arrange
            var fieldController = new FieldController();
            var fromAirport = "SEA";
            var toAirport = "LAX";

            // Act
            var flights = fieldController.GetFlights(fromAirport, toAirport);

            // Assert
            Assert.IsInstanceOfType(flights.Data, typeof(Flight));
        }
    }
}
