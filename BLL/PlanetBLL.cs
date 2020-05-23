using StarshipfleetsAPI.DAL;
using StarshipfleetsAPI.Models.Planets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace StarshipfleetsAPI.BLL
{
    public class PlanetBLL
    {

        public static List<BuildingQue> GetBuildingQueue(int? PlanetID)
        {
            List<BuildingQue> buildingQues = PlanetDAL.GetBuildingQueue(PlanetID);
            DateTime UTC = DateTime.UtcNow;
            List<BuildingQue> BuildingsQueLeft = new List<BuildingQue>();
            foreach (BuildingQue item in buildingQues)
            {
                if (item.CompletetionDate < UTC)
                {
                    PlanetDAL.InsertUpdatePlanetBuilding(item.PlanetID, item.BuildingID);
                    PlanetDAL.RemoveBuildingQueue(item.BuildQueID);
                }
                else
                {
                    BuildingsQueLeft.Add(item);
                }
            }
            return BuildingsQueLeft;
        }

        public static PlanetDetail AddBuildingQueue(BuildingQue buildingQue)
        {
            List<PlanetBuildings> buildings = PlanetDAL.GetBuildingTypes(buildingQue.PlanetID);
            PlanetBuildings pb = buildings.Find(x => x.BuildingID == buildingQue.BuildingID);            
            PlanetDetail pl = PlanetDAL.GetPlanet(buildingQue.PlanetID, buildingQue.UserID);
            if (pl.Materials < pb.MaterialCost || pl.Population < pb.PopulationCost)
            {
                throw new Exception("Not enough resources");
            }
            else
            {
                PlanetDAL.UpdatePopAndMats(buildingQue.PlanetID, pl.Materials - buildingQue.MaterialCost, pl.Population - (int)pb.PopulationCost.Value);
                pl.Materials = pl.Materials - pb.MaterialCost;
                pl.Population = pl.Population - (int)pb.PopulationCost.Value;
            }

            List<BuildingQue> BuildingsQueLeft = GetBuildingQueue(buildingQue.PlanetID);
            DateTime UTC = DateTime.UtcNow;

            BuildingQue bq = new BuildingQue();
            bq.BuildingID = buildingQue.BuildingID;
            bq.PlanetID = buildingQue.PlanetID;
            bq.Seconds = buildingQue.Seconds;
            bq.UserID = buildingQue.UserID;

            DateTime? maxCompletetionDate = BuildingsQueLeft.Max(x => x.CompletetionDate);
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

        public static double GetBuildingLevel(int? BuildingID, PlanetDetail planet)
        {
            switch (BuildingID)
            {
                case 1:
                    return planet.BioDomes.Value;
                case 2:
                    return planet.Energy.Value;
                case 3:
                    return planet.Research.Value;
                case 4:
                    return planet.Metals.Value;
                case 5:
                    return planet.Food.Value;
                case 6:
                    return planet.Factories.Value; 
                default: return 8;
            }
        }
    }
}