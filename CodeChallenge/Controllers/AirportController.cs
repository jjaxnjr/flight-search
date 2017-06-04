using CodeChallenge.Interfaces;
using CodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CodeChallenge.Controllers
{
    public class AirportController : ApiController
    {
        private IAirportRepository airportRepository;

        public AirportController(IAirportRepository aRepository)
        {
            airportRepository = aRepository;
        }

        public IEnumerable<AirportViewModel> Get()
        {
            var airports = airportRepository.GetAirports();
            return airports;
        }
    }
}