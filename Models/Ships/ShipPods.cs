using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarshipfleetsAPI.Models.Ships
{
    public class ShipPods
    {
        public int? ShipPodID { get; set; }
        public string PodName { get; set; }
        public int? SortOrder { get; set; }
        public double? MaterialCost { get; set; }
        public double? EnergyCost { get; set; }
        public int? MilitaryCost { get; set; }
        public double? Energy { get; set; }
        public double? Laser { get; set; }
        public double? Missile { get; set; }
        public double? Plasma { get; set; }
        public double? Shields { get; set; }
        public double? Armor { get; set; }
        public double? Movement { get; set; }
        public int? TechID { get; set; }
        public int? TechLevel { get; set; }
        public int? BuildingID { get; set; }
        public int? BuildingLevel { get; set; }

    }
}