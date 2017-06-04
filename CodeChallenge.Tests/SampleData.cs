using AutoMapper;
using CodeChallenge.DataAccess.Models;
using CodeChallenge.Models;
using System.Collections.Generic;

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
                        FlightNumber = "1000",
                        From = "SEA",
                        To = "LAX",
                        Departs = "6:00 PM",
                        Arrives = "8:00 PM",
                        MainCabinPrice = "100",
                        FirstClassPrice = "200"
                    },
                    new Flight
                    {
                        FlightNumber = "1100",
                        From = "SEA",
                        To = "LAX",
                        Departs = "7:00 PM",
                        Arrives = "9:00 PM",
                        MainCabinPrice = "150",
                        FirstClassPrice = "250"
                    },
                    new Flight
                    {
                        FlightNumber = "2000",
                        From = "SEA",
                        To = "LAS",
                        Departs = "5:00 PM",
                        Arrives = "7:00 PM",
                        MainCabinPrice = "200",
                        FirstClassPrice = "400"
                    }
                };
            }
        }

        public static List<FlightViewModel> FlightViewModelData
        {
            get
            {
                return Mapper.Map<List<FlightViewModel>>(FlightData);
            }
        }

        public static List<Airport> AirportData
        {
            get
            {
                return new List<Airport>
                {
                    new Airport
                    {
                        Code = "SEA",
                        Name = "Seattle/Tacoma Airport"
                    },
                    new Airport
                    {
                        Code = "LAX",
                        Name = "Los Angeles Airport"
                    }
                };
            }
        }

        public static List<AirportViewModel> AirportViewModelData
        {
            get
            {
                return Mapper.Map<List<AirportViewModel>>(AirportData);
            }
        }
    }
}
