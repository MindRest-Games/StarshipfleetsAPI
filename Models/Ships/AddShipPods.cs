using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace StarshipfleetsAPI.Models.Ships
{
    public class AddShipPods
    {
        public int? ShipDesignID { get; set; }
        public int? PodID { get; set; }
        public int? NumofPods { get; set; }
        public int? UserID { get; set; }
    }
}