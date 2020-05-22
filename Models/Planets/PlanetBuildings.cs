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
        public decimal? PopulationMax { get; set; }
        public decimal? PopulationCost { get; set; }
        public decimal? Energy { get; set; }
        public decimal? EnergyCost { get; set; }
        public decimal? Food { get; set; }
        public decimal? Research { get; set; }
        public decimal? Mining { get; set; }
        public decimal? Infrastructure { get; set; }
        public decimal? MaterialCost { get; set; }
        public decimal? ProductionCost { get; set; }
    }
    
}