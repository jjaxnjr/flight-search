using CodeChallenge.DataAccess;
using CodeChallenge.DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CodeChallenge.Tests.CodeChallenge.DataAccess
{
    [TestClass]
    public class AirportServiceTests
    {
        [TestMethod]
        public void GetAirportDataIsAnEnumerableOfAirports()
        {
            // Arrange
            var airportService = new AirportService();

            // Act
            var results = airportService.GetAirports();

            // Assert
            Assert.IsInstanceOfType(results, typeof(IEnumerable<Airport>));
        }


    }
}
