using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarshipfleetsAPI.Models.Research
{
    public class Technology
    {
        public int? TechnologyID { get; set; }
        public string Name { get; set; }        
        public double? Energy { get; set; }
        public double? Food { get; set; }
        public double? Research { get; set; }
        public double? Mining { get; set; }
        public double? Infrastructure { get; set; }
        public double? PopulationMax { get; set; }
        public double? Military { get; set; }
        public double? Laser { get; set; }
        public double? Missile { get; set; }
        public double? Plasma { get; set; }
        public double? Shields { get; set; }
        public double? Armor { get; set; }
        public double? BodyArmor { get; set; }
        public double? Weapons { get; set; }
        public double? TechnologyCost { get; set; }
        public int? TechID { get; set; }
        public int? TechLevel { get; set; }
        public int? BldLevel { get; set; }
        public int? QuedLevel { get; set; }
    }

}
