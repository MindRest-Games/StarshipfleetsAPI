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

namespace StarshipfleetsAPI.BLL
{
    public class ResearchBLL
    {
        public static PlanetDetail AddResearchQueue(BuildingQue buildingQue)
        {            
            PlanetDetail pl = PlanetDAL.GetPlanet(buildingQue.PlanetID, buildingQue.UserID);            
            AllbuildQues BuildingsQueLeft = PlanetBLL.GetBuildingQueue(buildingQue.PlanetID, buildingQue.UserID);
            DateTime UTC = DateTime.UtcNow;

            BuildingQue bq = new BuildingQue();
            bq.BuildingID = buildingQue.BuildingID;
            bq.PlanetID = buildingQue.PlanetID;
            bq.Seconds = buildingQue.Seconds;
            bq.UserID = buildingQue.UserID;
            bq.MaterialCost = 0;
            bq.Type = 2;

            DateTime? maxCompletetionDate = BuildingsQueLeft.researchQue.FindAll(x => x.Type==2).Max(x => x.CompletetionDate);
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
    }
}