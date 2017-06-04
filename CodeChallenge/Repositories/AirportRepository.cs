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

        public AirportRepository(IAirportService aService)
        {
            airportService = aService;
        }

        public IEnumerable<AirportViewModel> GetAirports()
        {
            return Mapper.Map<IEnumerable<AirportViewModel>>(airportService.GetAirports());
        }
    }
}