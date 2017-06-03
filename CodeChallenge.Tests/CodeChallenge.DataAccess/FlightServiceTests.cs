using CodeChallenge.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // Act
            var results = flightService.GetFlights();

            //Assert
            Assert.AreEqual(48, results.Count());
        }
    }
}
