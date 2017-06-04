using AutoMapper;
using CodeChallenge.DataAccess.Interfaces;
using CodeChallenge.Interfaces;
using CodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private IFlightService flightService;
        private IMapper mapper;

        public FlightRepository(IFlightService fService, IMapper mapr)
        {
            flightService = fService;
            mapper = mapr;
        }

        public IEnumerable<FlightViewModel> GetFlights(string from, string to)
        {
            if (from.ToUpper().Equals(to.ToUpper()))
            {
                throw new ArgumentException("From and To airports must be different");
            }
            var results = flightService.GetFlights()
                                       .Where(f => f.From.ToUpper().Equals(from.ToUpper()) &&
                                                   f.To.ToUpper().Equals(to.ToUpper()));
            return mapper.Map<IEnumerable<FlightViewModel>>(results);
        }
    }
}
