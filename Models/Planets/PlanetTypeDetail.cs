using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarshipfleetsAPI.Models.Planets
{
    public class PlanetTypeDetail
    {
        public int? TypeId { get; set; }
        public string TypeName { get; set; }
        public int? TextureNo { get; set; }
        public double? Infrastructure { get; set; }
        public double? Food { get; set; }
        public double? Mining { get; set; }
        public double? Research { get; set; }
        public double? Energy { get; set; }
        public bool? Barren { get; set; }
    }
}