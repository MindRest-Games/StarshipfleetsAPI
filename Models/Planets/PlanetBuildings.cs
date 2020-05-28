using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarshipfleetsAPI.Models.Planets
{
    public class PlanetBuildings
    {
        public int? BuildingID { get; set; }
        public string Name { get; set; }
        public double? PopulationMax { get; set; }
        public double? PopulationCost { get; set; }
        public double? Energy { get; set; }
        public double? EnergyCost { get; set; }
        public double? Food { get; set; }
        public double? Research { get; set; }
        public double? Mining { get; set; }
        public double? Infrastructure { get; set; }
        public double? Military { get; set; }
        public int? TradeRoutes { get; set; }
        public double? MaterialCost { get; set; }
        public double? ProductionCost { get; set; }
        public int? TechID { get; set; }
        public int? TechLevel { get; set; }
        public int? BldLevel { get; set; }
        public int? QuedLevel { get; set; }
    }

}