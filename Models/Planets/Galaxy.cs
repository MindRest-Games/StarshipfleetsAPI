using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarshipfleetsAPI.Models.Planets
{
    public class GalaxyClass
    {
        public int? PlanetID { get; set; }
        public string PlanetName { get; set; }
        public int? PlanetType { get; set; }
        public int? Position { get; set; }
        public int? SubPosition { get; set; }
        public int? Galaxy { get; set; }
        public string Sector { get; set; }
        public int? System { get; set; }
        public int? SysPosition { get; set; }
        public bool? Moon { get; set; }
        public int? Owner { get; set; }
    }
}