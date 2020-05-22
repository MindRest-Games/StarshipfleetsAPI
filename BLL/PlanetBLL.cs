using StarshipfleetsAPI.Models.Planets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace StarshipfleetsAPI.BLL
{
    public class PlanetBLL
    {
        public static PlanetDetail PlanetQueue(int? PlanetID, int? UserID)
        {
            //Math.round(((building.productionCost+(getLevel(building.name)*2.5*building.productionCost))/PlanetStats.Infrastructure)*10)
            PlanetDetail gg = new PlanetDetail();
            return gg;
        }
    }
}