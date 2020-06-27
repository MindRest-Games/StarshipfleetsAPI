using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarshipfleetsAPI.Models.Ships
{
    public class ShipHulls
    {
        public int? HullID { get; set; }
        public string HullName { get; set; }
        public int? SortOrder { get; set; }
        public double? MaterialCost { get; set; }
        public double? Hull { get; set; }
        public int? NumPods { get; set; }
        public int? TechID { get; set; }
        public int? TechLevel { get; set; }
        public int? BuildingID { get; set; }
        public int? BuildingLevel { get; set; }
        public bool? RequiresBay { get; set; }
    }
}