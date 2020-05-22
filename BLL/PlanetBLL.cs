using StarshipfleetsAPI.DAL;
using StarshipfleetsAPI.Models.Planets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace StarshipfleetsAPI.BLL
{
    public class PlanetBLL
    {
        public static BuildingQue BuildingQueue(int? BuildingID, int? PlanetID, int? UserID)
        {
            PlanetDetail planet = PlanetDAL.GetPlanet(PlanetID, UserID);
            List<BuildingQue> buildingQues = PlanetDAL.GetBuildingQueue(PlanetID);
            List<PlanetBuildings> buildings = PlanetDAL.GetBuildingTypes();
            PlanetBuildings building = buildings.Find(x => x.BuildingID == BuildingID);

            double? mineYD = buildings.Find(x => x.Name == "Mine").Mining;
            double? farmYD = buildings.Find(x => x.Name == "Farm").Food;
            double? factoryYD = buildings.Find(x => x.Name == "Factory").Infrastructure;
            double? plantYD = buildings.Find(x => x.Name == "Power Plant").Energy;
            double? labYD = buildings.Find(x => x.Name == "Research Lab").Research;
            double? bioYD = buildings.Find(x => x.Name == "Biodome").Infrastructure;
            double? shipYD = buildings.Find(x => x.Name == "Mine").Infrastructure;

            //const mineYD = BuildingStats.filter(x => x.name == "Mine")[0].mining;
            //const farmYD = BuildingStats.filter(x => x.name == "Farm")[0].food;
            //const factoryYD = BuildingStats.filter(x => x.name == "Factory")[0].infrastructure;
            //const plantYD = BuildingStats.filter(x => x.name == "Power Plant")[0].energy;
            //const labYD = BuildingStats.filter(x => x.name == "Research Lab")[0].research;
            //const bioYD = BuildingStats.filter(x => x.name == "Biodome")[0].infrastructure;

            //const infraYD = ((planet.food * planet.ptInfrastructure * bioYD) + (planet.factories * planet.ptInfrastructure * factoryYD))
            //    * ((PlanetPop.infrastructurePop / 100))


            double seconds = Math.Round(((building.ProductionCost.Value + (GetBuildingLevel(BuildingID, planet) * 2.5))));

            //Math.round(((building.productionCost+(getLevel(building.name)*2.5*building.productionCost))/PlanetStats.Infrastructure)*10)



            BuildingQue bq = new BuildingQue();





            return bq;
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