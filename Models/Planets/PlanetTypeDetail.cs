﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarshipfleetsAPI.Models.Planets
{
    public class PlanetTypeDetail
    {
        public int? TypeId { get; set; }
        public int? TextureNo { get; set; }
        public decimal? Intrastructure { get; set; }
        public decimal? Mining { get; set; }
        public decimal? Research { get; set; }
        public decimal? Energy { get; set; }
        public bool? Barren { get; set; }
    }
}