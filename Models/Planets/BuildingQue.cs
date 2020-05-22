using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarshipfleetsAPI.Models.Planets
{
    public class BuildingQue
    {
        public int? BuildQueID { get; set; }
        public int? BuildingID { get; set; }
        public int? PlanetID { get; set; }
        public int? UserID { get; set; }
        public DateTime? CompletetionDate { get; set; }
        public DateTime? DateQued { get; set; }
        public string BuildingName { get; set; }
        public int? BuildTime { get; set; }
    }
}