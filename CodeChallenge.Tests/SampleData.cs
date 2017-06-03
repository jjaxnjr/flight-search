using CodeChallenge.DataAccess.Models;
using CodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Tests
{
    public static class SampleData
    {
        public static List<Flight> FlightData
        {
            get
            {
                return new List<Flight>
                {
                    new Flight
                    {
                        From = "SEA",
                        To = "LAX",
                        Arrives = "8:00 PM",
                        Departs = "6:00 PM",
                        FirstClassPrice = "200",
                        FlightNumber = "1000",
                        MainCabinPrice = "100"
                    },
                    new Flight
                    {
                        From = "SEA",
                        To = "LAS",
                        Arrives = "9:00 PM",
                        Departs = "7:00 PM",
                        FirstClassPrice = "200",
                        FlightNumber = "2000",
                        MainCabinPrice = "100"
                    }
                };
            }
        }

        public static List<FlightViewModel> FlightViewModelData
        {
            get
            {
                return new List<FlightViewModel>
                {
                    new FlightViewModel
                    {
                        From = "SEA",
                        To = "LAX",
                        Arrives = "8:00 PM",
                        Departs = "6:00 PM",
                        FirstClassPrice = "200",
                        FlightNumber = "1000",
                        MainCabinPrice = "100"
                    },
                    new FlightViewModel
                    {
                        From = "SEA",
                        To = "LAS",
                        Arrives = "9:00 PM",
                        Departs = "7:00 PM",
                        FirstClassPrice = "200",
                        FlightNumber = "2000",
                        MainCabinPrice = "100"
                    }
                };
            }
        }
    }
}
