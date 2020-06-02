using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarshipfleetsAPI.Models.Ships
{
    public class ShipDesignDetails
    {
        public int? ShipDesignID { get; set; }
        public string DesignName { get; set; }
        public string HullName { get; set; }
        public double? Hull { get; set; }
        public int? NumofPods { get; set; }
        public int? ShipPodID { get; set; }
        public string PodName { get; set; }
        public double? Armor { get; set; }
        public double? Energy { get; set; }
        public double? EnergyCost { get; set; }
        public int? MilitaryCost { get; set; }
        public double? Laser { get; set; }
        public double? MaterialCost { get; set; }
        public double? Missile { get; set; }
        public double? Movement { get; set; }
        public double? Plasma { get; set; }
        public double? Shields { get; set; }
        public double? Bays { get; set; }


    }
}