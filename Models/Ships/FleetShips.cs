using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarshipfleetsAPI.Models.Ships
{
    public class FleetShips
    {
        public int? FleetDetailID { get; set; }
        public int? FleetID { get; set; }
        public int? DesignID { get; set; }
        public string DesignName { get; set; }
        public int? ActualNumber { get; set; }
        public double? EffectiveNumber { get; set; }
        public int? UserID { get; set; }
        public double? Movement { get; set; }
    }
}