using CodeChallenge.Interfaces;
using System;
using System.Web.Mvc;

namespace CodeChallenge.Controllers
{
    public class FlightController : Controller
    {
        private IFlightRepository flightRepository;

        public FlightController(IFlightRepository flightRepo)
        {
            flightRepository = flightRepo;
        }

        // GET: Field
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetFlights(string from, string to)
        {
            var flights = flightRepository.GetFlights(from, to);
            return Json(flights, JsonRequestBehavior.AllowGet);
        }
    }
}