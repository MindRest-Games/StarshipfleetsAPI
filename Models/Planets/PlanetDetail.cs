using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarshipfleetsAPI.Models.Planets
{
    public class PlanetDetail
    {
        public int? PlanetID { get; set; }
        public string PlanetName { get; set; }
        public int? PlanetType { get; set; }
        public int? Galaxy { get; set; }
        public string Sector { get; set; }
        public int? System { get; set; }
        public int? XSysPosition { get; set; }
        public bool? Moon { get; set; }
        public int? Owner { get; set; }
        public decimal? Energy { get; set; }
        public decimal? Metals { get; set; }
        public decimal? Research { get; set; }
        public decimal? Food { get; set; }
        public decimal? Materials { get; set; }
        public decimal? BioDomes { get; set; }
        public decimal? Factories { get; set; }
        public int? Population {get; set;}
        public int? InfrastructurePop { get; set; }
        public int? InfrastructurePopMetal { get; set; }
        public int? EnergyPop { get; set; }
        public int? MetalsPop { get; set; }
        public int? ResearchPop { get; set; }
        public int? FoodPop { get; set; }
        public bool? Barren { get; set; }
        public decimal? ptEnergy { get; set; }
        public decimal? ptFood { get; set; }
        public decimal? ptInfrastructure { get; set; }
        public decimal? ptMining { get; set; }
        public decimal? ptResearch { get; set; }
        public string TypeName { get; set; }
        public DateTime? LastHarvest { get; set; }

    }
}

