using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarshipfleetsAPI.Models.Planets
{
    public class PlanetStats
    {
        public double? Energy { get; set; }
        public double? EnergyCost { get; set; }
        public double? Food { get; set; }
        public double? Research { get; set; }
        public double? Mining { get; set; }
        public double? Military { get; set; }
        public int? TradeRoutes { get; set; }
        public double? Infrastructure { get; set; }
        public double? PopulationMax { get; set; }

    }
}