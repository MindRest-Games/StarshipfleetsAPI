using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarshipfleetsAPI.Models.Planets
{
    public class AllbuildQues
    {
        public List<BuildingQue> buildingQue { get; set; }
        public List<BuildingQue> researchQue { get; set; }
        public List<BuildingQue> shipQue { get; set; }

    }
}