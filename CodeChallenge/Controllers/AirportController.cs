using CodeChallenge.Interfaces;
using CodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeChallenge.Controllers
{
    public class AirportController : Controller
    {
        private IAirportRepository airportRepository;

        public AirportController(IAirportRepository aRepository)
        {
            airportRepository = aRepository;
        }

        public JsonResult GetAirports()
        {
            var airports = airportRepository.GetAirports();
            return Json(airports, JsonRequestBehavior.AllowGet);
        }
    }
}