using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarshipfleetsAPI.Models.Ships
{
    public class UserDesigns
    {
        public int? ShipDesignID { get; set; }
        public int? UserID { get; set; }
        public string DesignName { get; set; }
        public int? HullID { get; set; }
        public string HullName { get; set; }
    }
}