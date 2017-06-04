using CodeChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeChallenge.Models;
using CodeChallenge.DataAccess.Interfaces;
using AutoMapper;

namespace CodeChallenge.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private IAirportService airportService;
        private IMapper mapper;

        public AirportRepository(IAirportService aService, IMapper mapr)
        {
            airportService = aService;
            mapper = mapr;
        }

        public IEnumerable<AirportViewModel> GetAirports()
        {
            return mapper.Map<IEnumerable<AirportViewModel>>(airportService.GetAirports());
        }
    }
}