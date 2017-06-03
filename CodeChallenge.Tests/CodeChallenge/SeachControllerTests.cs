using CodeChallenge.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CodeChallenge.Tests.CodeChallenge
{
    [TestClass]
    public class SeachControllerTests
    {
        [TestMethod]
        public void IndexReturnsView()
        {
            // Arrange
            var searchController = new SearchController();

            // Act
            var results = searchController.Index();

            // Assert
            Assert.IsInstanceOfType(results, typeof(ViewResult));
            Assert.AreEqual("Index", results.ViewName);
        }
    }
}
