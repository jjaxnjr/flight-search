using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using CodeChallenge.Interfaces;
using CodeChallenge.DataAccess.Interfaces;
using CodeChallenge.DataAccess;

namespace CodeChallenge
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IFlightRepository, FlightRepository>();
            container.RegisterType<IFlightService, FlightService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}