using AutoMapper;
using CodeChallenge.DataAccess.Interfaces;
using CodeChallenge.Interfaces;
using CodeChallenge.Models;
using System;
using System.Collections.Generic;

namespace CodeChallenge
{
    public class FlightRepository : IFlightRepository
    {
        private IFlightService flightService;

        public FlightRepository(IFlightService fService)
        {
            flightService = fService;
        }

        public IEnumerable<FlightViewModel> GetFlights(string from, string to)
        {
            if (from.ToUpper().Equals(to.ToUpper()))
            {
                throw new ArgumentException("From and To airports must be different");
            }
            return Mapper.Map<IEnumerable<FlightViewModel>>(flightService.GetFlights());
        }
    }
}
