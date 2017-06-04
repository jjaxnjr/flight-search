using CodeChallenge.Interfaces;
using CodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;

namespace CodeChallenge.Controllers
{
    public class FlightController : ApiController
    {
        private IFlightRepository flightRepository;

        public FlightController(IFlightRepository flightRepo)
        {
            flightRepository = flightRepo;
        }

        public IEnumerable<FlightViewModel> Post(FlightSearch flightSearch)
        {
            try
            {
                var flights = flightRepository.GetFlights(flightSearch.FromAirport, flightSearch.ToAirport);
                return flights;
            }
            catch (ArgumentException aex)
            {
                // TODO: Log Exception
                return new List<FlightViewModel>();
            }
        }
    }
}