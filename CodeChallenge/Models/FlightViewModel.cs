using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeChallenge.Models
{
    public class FlightViewModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string FlightNumber { get; set; }
        public string Departs { get; set; }
        public string Arrives { get; set; }
        public string MainCabinPrice { get; set; }
        public string FirstClassPrice { get; set; }
    }
}