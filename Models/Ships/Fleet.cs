using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarshipfleetsAPI.Models.Ships
{
    public class Fleet
    {
        public int? UserID { get; set; }
        public int? FleetID { get; set; }
        public string FleetName { get; set; }
        public int? Status { get; set; }
        public int? Destination { get; set; }
        public DateTime? Arrival { get; set; }
        public int? PlanetID { get; set; }
        public int? System { get; set; }
        public string Sector { get; set; }
        public int? Galaxy { get; set; }        
        public List<FleetShips> Ships { get; set; }
    }
}