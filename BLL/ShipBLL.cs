using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using StarshipfleetsAPI.DAL;
using StarshipfleetsAPI.Models.Planets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Web.WebSockets;
using StarshipfleetsAPI.Models.Ships;

namespace StarshipfleetsAPI.BLL
{
    public class ShipBLL
    {
        public static PlanetDetail AddShipQueue(BuildingQue buildingQue)
        {
            PlanetDetail pl = PlanetDAL.GetPlanet(buildingQue.PlanetID, buildingQue.UserID);
            UserDesigns ship = ShipDAL.GetShipDesignbyUser(buildingQue.UserID).Find( x => x.ShipDesignID == buildingQue.BuildingID);
            if (pl.Materials < ship.MaterialCost || pl.Military < ship.MilitaryCost)
            {
                throw new Exception("Not enough resources");
            }
            else
            {
                PlanetDAL.UpdatePopAndMats(buildingQue.PlanetID, pl.Materials - buildingQue.MaterialCost, pl.Population, pl.Military - (int)ship.MilitaryCost.Value);
                pl.Materials -= buildingQue.MaterialCost;
                pl.Military -= (int)ship.MilitaryCost.Value;
            }


            AllbuildQues BuildingsQueLeft = PlanetBLL.GetBuildingQueue(buildingQue.PlanetID, buildingQue.UserID);
            DateTime UTC = DateTime.UtcNow;

            BuildingQue bq = new BuildingQue();
            bq.BuildingID = buildingQue.BuildingID;
            bq.PlanetID = buildingQue.PlanetID;
            bq.Seconds = buildingQue.Seconds;
            bq.UserID = buildingQue.UserID;
            bq.MaterialCost = buildingQue.MaterialCost;
            bq.UpgradeDesignID = buildingQue.UpgradeDesignID;
            bq.Type = 3;

            DateTime? maxCompletetionDate = BuildingsQueLeft.shipQue.FindAll(x => x.Type == 3).Max(x => x.CompletetionDate);
            if (maxCompletetionDate.HasValue)
            {
                bq.CompletetionDate = maxCompletetionDate.Value.AddSeconds(buildingQue.Seconds.Value);
            }
            else
            {
                bq.CompletetionDate = UTC.AddSeconds(buildingQue.Seconds.Value);
            }
            PlanetDAL.AddBuildingQue(bq);
            return pl;
        }

        public static List<Fleet> InsertUpdatePlayerShip(BuildingQue ship)
        {           
            List<Fleet> fleets = ShipDAL.GetUserFleets(ship.UserID, ship.PlanetID);
            if (fleets.Count == 0)
            {
                ShipDAL.AddFleet(ship);                
            }
            else
            {
                ShipDAL.AddFleetDetails(ship, fleets[0].FleetID);
            }
            fleets = ShipDAL.GetUserFleets(ship.UserID, ship.PlanetID);
            return fleets;
        }
    }


}
