using AutoMapper;
using CodeChallenge.DataAccess.Models;
using CodeChallenge.Models;

namespace CodeChallenge
{
    public class MapperConfig
    {
        public static IMapper RegisterMappings()
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Flight, FlightViewModel>();
                    cfg.CreateMap<Airport, AirportViewModel>();
                });

            return config.CreateMapper();
        }
    }
}