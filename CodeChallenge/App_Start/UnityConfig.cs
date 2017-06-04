using AutoMapper;
using CodeChallenge.DataAccess;
using CodeChallenge.DataAccess.Interfaces;
using CodeChallenge.Interfaces;
using CodeChallenge.Repositories;
using Microsoft.Practices.Unity;
using System.Web.Http;
using System.Web.Mvc;

namespace CodeChallenge
{
    public static class UnityConfig
    {
        public static void RegisterComponents(IMapper mapper)
        {
			var container = new UnityContainer();

            container.RegisterType<IFlightRepository, FlightRepository>();
            container.RegisterType<IFlightService, FlightService>();

            container.RegisterType<IAirportRepository, AirportRepository>();
            container.RegisterType<IAirportService, AirportService>();

            container.RegisterInstance(mapper);

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}