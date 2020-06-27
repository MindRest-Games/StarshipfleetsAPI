using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using StarshipfleetsAPI.Models.Planets;

namespace StarshipfleetsAPI.DAL
{
    public class PlanetDAL
    {
        public static PlanetTypeDetail GetPlanetTypeDetail(int? PlanetTypeID)
        {
            if (!PlanetTypeID.HasValue)
            {
                throw new ArgumentNullException("PlanetTypeID", $"PlanetTypeID cannot be null.");
            }

            PlanetTypeDetail TypeDetail = new PlanetTypeDetail();

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.GetPlanetTypeDetail", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);

                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@PlanetTypeID", (int)PlanetTypeID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (sqlReader.Read())
                {
                    TypeDetail.TypeId = sqlReader.GetInt32Nullable("TypeID");
                    TypeDetail.TypeName = sqlReader.GetStringNullable("TypeName");
                    TypeDetail.TextureNo = sqlReader.GetInt32Nullable("TextureNo");
                    TypeDetail.Infrastructure = sqlReader.GetDoubleNullable("Infrastructure");
                    TypeDetail.Food = sqlReader.GetDoubleNullable("Food");
                    TypeDetail.Mining = sqlReader.GetDoubleNullable("Mining");
                    TypeDetail.Research = sqlReader.GetDoubleNullable("Research");
                    TypeDetail.Energy = sqlReader.GetDoubleNullable("Energy");
                    TypeDetail.Barren = sqlReader.GetBooleanNullable("Barren");

                }
                return TypeDetail;
            }
        }

        public static List<GalaxyClass> GetGalaxySystems(int? GalaxyID)
        {
            if (!GalaxyID.HasValue)
            {
                throw new ArgumentNullException("GalaxyID", $"GalaxyID cannot be null.");
            }

            List<GalaxyClass> GalaxyObj = new List<GalaxyClass>();

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.GetGalaxySystems", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);

                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@Galaxy", (int)GalaxyID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (sqlReader.Read())
                {
                    GalaxyClass gc = new GalaxyClass();
                    gc.Galaxy = sqlReader.GetInt32Nullable("Galaxy");
                    gc.Sector = sqlReader.GetStringNullable("Sector");
                    gc.System = sqlReader.GetInt32Nullable("System");
                    gc.XSysPosition = sqlReader.GetInt32Nullable("XSysPosition");
                    gc.YSysPosition = sqlReader.GetInt32Nullable("YSysPosition");
                    GalaxyObj.Add(gc);
                }
                return GalaxyObj;
            }
        }

        public static List<GalaxyClass> GetGalaxy(int? GalaxyID, string Sector = null, int? System = null)
        {
            if (!GalaxyID.HasValue)
            {
                throw new ArgumentNullException("GalaxyID", $"GalaxyID cannot be null.");
            }

            List<GalaxyClass> GalaxyObj = new List<GalaxyClass>();

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.GetGalaxy", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);

                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@Galaxy", (int)GalaxyID);
                DBCmd.Parameters.AddWithValue("@Sector", Sector);
                DBCmd.Parameters.AddWithValue("@System", System);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (sqlReader.Read())
                {
                    GalaxyClass gc = new GalaxyClass();
                    gc.PlanetID = sqlReader.GetInt32Nullable("PlanetID");
                    gc.PlanetName = sqlReader.GetStringNullable("PlanetName");
                    gc.PlanetType = sqlReader.GetInt32Nullable("PlanetType");
                    gc.Position = sqlReader.GetInt32Nullable("Position");
                    gc.SubPosition = sqlReader.GetInt32Nullable("SubPosition");
                    gc.Galaxy = sqlReader.GetInt32Nullable("Galaxy");
                    gc.Sector = sqlReader.GetStringNullable("Sector");
                    gc.System = sqlReader.GetInt32Nullable("System");
                    gc.XSysPosition = sqlReader.GetInt32Nullable("XSysPosition");
                    gc.YSysPosition = sqlReader.GetInt32Nullable("YSysPosition");
                    gc.Moon = sqlReader.GetBooleanNullable("Moon");
                    gc.Owner = sqlReader.GetInt32Nullable("Owner");
                    GalaxyObj.Add(gc);
                }
                return GalaxyObj;
            }
        }

        public static PlanetDetail GetPlanet(int? PlanetID, int? UserID)
        {
            if (!PlanetID.HasValue)
            {
                throw new ArgumentNullException("PlanetID", $"PlanetID cannot be null.");
            }

            PlanetDetail planet = new PlanetDetail();

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.GetPlanetDetailbyID", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);

                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@PlanetID", (int)PlanetID);
                DBCmd.Parameters.AddWithValue("@UserID", (int)UserID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (sqlReader.Read())
                {
                    planet.PlanetID = sqlReader.GetInt32Nullable("PlanetID");
                    planet.PlanetName = sqlReader.GetStringNullable("PlanetName");
                    planet.PlanetType = sqlReader.GetInt32Nullable("PlanetType");
                    planet.Galaxy = sqlReader.GetInt32Nullable("Galaxy");
                    planet.Sector = sqlReader.GetStringNullable("Sector");
                    planet.System = sqlReader.GetInt32Nullable("System");
                    planet.XSysPosition = sqlReader.GetInt32Nullable("XSysPosition");
                    planet.YSysPosition = sqlReader.GetInt32Nullable("YSysPosition");
                    planet.Moon = sqlReader.GetBooleanNullable("Moon");
                    planet.Owner = sqlReader.GetInt32Nullable("Owner");                    
                    planet.Materials = sqlReader.GetDoubleNullable("Materials");
                    planet.Population = sqlReader.GetInt32Nullable("Population");
                    planet.Military = sqlReader.GetInt32Nullable("Military");
                    planet.InfrastructurePop = sqlReader.GetInt32Nullable("InfrastructurePop");
                    planet.InfrastructurePopMetal = sqlReader.GetInt32Nullable("InfrastructurePopMetal");
                    planet.EnergyPop = sqlReader.GetInt32Nullable("EnergyPop");
                    planet.MetalsPop = sqlReader.GetInt32Nullable("MetalsPop");
                    planet.ResearchPop = sqlReader.GetInt32Nullable("ResearchPop");
                    planet.FoodPop = sqlReader.GetInt32Nullable("FoodPop");
                    planet.Barren = sqlReader.GetBooleanNullable("Barren");
                    planet.ptEnergy = sqlReader.GetDoubleNullable("ptEnergy");
                    planet.ptFood = sqlReader.GetDoubleNullable("ptFood");
                    planet.ptInfrastructure = sqlReader.GetDoubleNullable("ptInfrastructure");
                    planet.ptMining = sqlReader.GetDoubleNullable("ptMining");
                    planet.ptResearch = sqlReader.GetDoubleNullable("ptResearch");
                    planet.TypeName = sqlReader.GetStringNullable("TypeName");
                    planet.LastHarvest = sqlReader.GetDateTimeNullable("LastHarvest");
                    planet.LastPopChange = sqlReader.GetDateTimeNullable("LastPopChange");                    
                }
                return planet;
            }
        }

        public static PlanetStats UpdatePlanetPop(PlanetDetail planetDetail)
        {
            if (!planetDetail.PlanetID.HasValue)
            {
                throw new ArgumentNullException("PlanetID", $"PlanetID cannot be null.");
            }
            if (!planetDetail.Owner.HasValue)
            {
                throw new ArgumentNullException("UserID", $"UserID cannot be null.");
            }
            PlanetDetail planet = new PlanetDetail();

            PlanetDetail chkPlanet = GetPlanet(planetDetail.PlanetID, planetDetail.Owner);
            int? totalPop = planetDetail.InfrastructurePopMetal + planetDetail.InfrastructurePop + planetDetail.EnergyPop + planetDetail.MetalsPop + planetDetail.FoodPop + planetDetail.ResearchPop;
            if (!chkPlanet.Owner.HasValue || chkPlanet.Owner != planetDetail.Owner)
            {
                throw new ArgumentNullException("Owner", $"Owner does not match.");
            }
            if (totalPop>100)
            {
                throw new ArgumentNullException("Focus", $"Focus over 100.");
            }    

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.UpdatePlanetPop", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);
                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@PlanetID", (int)planetDetail.PlanetID);
                DBCmd.Parameters.AddWithValue("@InfrastructurePop", (int)planetDetail.InfrastructurePop);
                DBCmd.Parameters.AddWithValue("@InfrastructurePopMetal", (int)planetDetail.InfrastructurePopMetal);
                DBCmd.Parameters.AddWithValue("@EnergyPop", (int)planetDetail.EnergyPop);
                DBCmd.Parameters.AddWithValue("@MetalsPop", (int)planetDetail.MetalsPop);
                DBCmd.Parameters.AddWithValue("@FoodPop", (int)planetDetail.FoodPop);
                DBCmd.Parameters.AddWithValue("@ResearchPop", (int)planetDetail.ResearchPop);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            PlanetStats ps = new PlanetStats();
            return ps;
        }

        public static DateTime? UpdatePlanetHarvest(PlanetDetail planetDetail)
        {
            if (!planetDetail.PlanetID.HasValue)
            {
                throw new ArgumentNullException("PlanetID", $"PlanetID cannot be null.");
            }
            if (!planetDetail.Materials.HasValue)
            {
                throw new ArgumentNullException("Materials", $"UserID cannot be null.");
            }

            DateTime? NewHarvest = DateTime.UtcNow.AddHours(1);

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.UpdatePlanetHarvest", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);
                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@PlanetID", (int)planetDetail.PlanetID);
                DBCmd.Parameters.AddWithValue("@Materials", (double)planetDetail.Materials);
                DBCmd.Parameters.AddWithValue("@Military", (double)planetDetail.Military);
                DBCmd.Parameters.AddWithValue("@Population", (int)planetDetail.Population);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (sqlReader.Read())
                {
                    NewHarvest = sqlReader.GetDateTimeNullable("NewHarvest");
                }
            }
            return NewHarvest;
        }

        public static PlanetDetail ColonizePlanet(PlanetDetail planetDetail)
        {
            if (!planetDetail.PlanetID.HasValue)
            {
                throw new ArgumentNullException("PlanetID", $"PlanetID cannot be null.");
            }
            if (!planetDetail.Owner.HasValue)
            {
                throw new ArgumentNullException("UserID", $"UserID cannot be null.");
            }
            PlanetDetail planet = new PlanetDetail();

            //Check for colony Ship at planet, get pods for update

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.ColonizePlanet", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);
                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@UserID", (int)planetDetail.Owner);
                DBCmd.Parameters.AddWithValue("@PlanetID", (int)planetDetail.PlanetID);
                DBCmd.Parameters.AddWithValue("@Population", (int)planetDetail.Population);
                DBCmd.Parameters.AddWithValue("@Materials", (decimal)planetDetail.Materials);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);
            }

            PlanetDetail getPlanet = GetPlanet(planetDetail.PlanetID, planetDetail.Owner);
            return getPlanet;
        }

        public static List<PlanetBuildings> GetBuildingTypes(int? PlanetID)
        {
            List<PlanetBuildings> BuildingsObjs = new List<PlanetBuildings>();

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.GetBuildingTypes", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);
                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@PlanetID", (int)PlanetID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (sqlReader.Read())
                {
                    PlanetBuildings bld = new PlanetBuildings();
                    bld.BuildingID = sqlReader.GetInt32Nullable("BuildingID");
                    bld.Name = sqlReader.GetStringNullable("Name");
                    bld.PopulationMax = sqlReader.GetDoubleNullable("PopulationMax");
                    bld.PopulationCost = sqlReader.GetDoubleNullable("PopulationCost");
                    bld.Energy = sqlReader.GetDoubleNullable("Energy");
                    bld.EnergyCost = sqlReader.GetDoubleNullable("EnergyCost");
                    bld.Food = sqlReader.GetDoubleNullable("Food");
                    bld.Research = sqlReader.GetDoubleNullable("Research");
                    bld.Mining = sqlReader.GetDoubleNullable("Mining");
                    bld.Infrastructure = sqlReader.GetDoubleNullable("Infrastructure"); 
                    bld.Military = sqlReader.GetDoubleNullable("Military"); 
                    bld.TradeRoutes = sqlReader.GetInt32Nullable("TradeRoutes");
                    bld.MaterialCost = sqlReader.GetDoubleNullable("MaterialCost");
                    bld.ProductionCost = sqlReader.GetDoubleNullable("ProductionCost");
                    bld.TechID = sqlReader.GetInt32Nullable("TechID");
                    bld.TechLevel = sqlReader.GetInt32Nullable("TechLevel");
                    bld.BldLevel = sqlReader.GetInt32Nullable("BldLevel");
                    bld.QuedLevel = sqlReader.GetInt32Nullable("QuedLevel");
                    bld.ShowFlag = sqlReader.GetBooleanNullable("ShowFlag");
                    BuildingsObjs.Add(bld);
                }
                return BuildingsObjs;
            }
        }

        public static List<BuildingQue> GetBuildingQueue( int? UserID)
        {
            if (!UserID.HasValue)
            {
                throw new ArgumentNullException("UserID", $"UserID cannot be null.");
            }

            List<BuildingQue> GetBuildingQueue = new List<BuildingQue>();
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.GetBuildingQueue", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);

                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@UserID", (int)UserID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);


                while (sqlReader.Read())
                {
                    BuildingQue bld = new BuildingQue();
                    bld.BuildQueID = sqlReader.GetInt32Nullable("BuildQueID");
                    bld.BuildingID = sqlReader.GetInt32Nullable("BuildingID");
                    bld.PlanetID = sqlReader.GetInt32Nullable("PlanetID");
                    bld.UserID = sqlReader.GetInt32Nullable("UserID");
                    bld.Seconds = sqlReader.GetDoubleNullable("Seconds");
                    bld.CompletetionDate = sqlReader.GetDateTimeNullable("CompletetionDate");
                    bld.DateQued = sqlReader.GetDateTimeNullable("DateQued");
                    bld.BuildingName = sqlReader.GetStringNullable("BuildingName");
                    bld.TechName = sqlReader.GetStringNullable("TechName");
                    bld.ShipName = sqlReader.GetStringNullable("ShipName");
                    bld.Movement = sqlReader.GetDoubleNullable("Movement");
                    bld.Type = sqlReader.GetInt32Nullable("Type");
                    GetBuildingQueue.Add(bld);
                }
                return GetBuildingQueue;
            }
        }

        public static PlanetStats GetPlanetStats(int? PlanetID)
        {
            if (!PlanetID.HasValue)
            {
                throw new ArgumentNullException("PlanetID", $"PlanetID cannot be null.");
            }

            PlanetStats PlanetStats = new PlanetStats();
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.GetPlanetStats", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);

                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@PlanetID", (int)PlanetID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);


                if (sqlReader.Read())
                {
                    PlanetStats.Energy = sqlReader.GetDoubleNullable("Energy");
                    PlanetStats.EnergyCost = sqlReader.GetDoubleNullable("EnergyCost");
                    PlanetStats.Food = sqlReader.GetDoubleNullable("Food");
                    PlanetStats.Mining = sqlReader.GetDoubleNullable("Mining");
                    PlanetStats.Research = sqlReader.GetDoubleNullable("Research");
                    PlanetStats.Infrastructure = sqlReader.GetDoubleNullable("Infrastructure");
                    PlanetStats.PopulationMax = sqlReader.GetDoubleNullable("PopulationMax");
                    PlanetStats.Military = sqlReader.GetDoubleNullable("Military");
                    PlanetStats.TradeRoutes = sqlReader.GetInt32Nullable("TradeRoutes");
                }
                return PlanetStats;
            }
        }

        public static void AddBuildingQue(BuildingQue buildingQue)
        {
            if (!buildingQue.PlanetID.HasValue)
            {
                throw new ArgumentNullException("PlanetID", $"PlanetID cannot be null.");
            }

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.AddBuildingQue", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);

                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@BuildingID", (int)buildingQue.BuildingID);
                DBCmd.Parameters.AddWithValue("@PlanetID", (int)buildingQue.PlanetID);
                DBCmd.Parameters.AddWithValue("@UserID", (int)buildingQue.UserID);
                DBCmd.Parameters.AddWithValue("@Seconds", (int)buildingQue.Seconds);
                DBCmd.Parameters.AddWithValue("@MaterialCost", (int)buildingQue.MaterialCost);
                DBCmd.Parameters.AddWithValue("@CompletetionDate", (DateTime)buildingQue.CompletetionDate);
                DBCmd.Parameters.AddWithValue("@Type", (int)buildingQue.Type);
                DBCmd.Parameters.AddWithValue("@Movement", buildingQue.Movement);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
        public static void RemoveBuildingQueue(int? BuildQueID)
        {
            if (!BuildQueID.HasValue)
            {
                throw new ArgumentNullException("BuildQueID", $"BuildQueID cannot be null.");
            }

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.RemoveBuildingQueue", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);

                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@BuildQueID", (int)BuildQueID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public static void UpdatePopAndMats(int? PlanetID, double? Materials, int? Population, int? Military)
        {
            if (!PlanetID.HasValue)
            {
                throw new ArgumentNullException("PlanetID", $"PlanetID cannot be null.");
            }

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.UpdatePopAndMats", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);

                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@Materials", (double)Materials);
                DBCmd.Parameters.AddWithValue("@PlanetID", (int)PlanetID);
                DBCmd.Parameters.AddWithValue("@Population", (int)Population);
                DBCmd.Parameters.AddWithValue("@Military", (int)Military);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public static void InsertUpdatePlanetBuilding (int? PlanetID, int? BuildingID)
        {
            if (!PlanetID.HasValue)
            {
                throw new ArgumentNullException("PlanetID", $"PlanetID cannot be null.");
            }

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.AddPlanetBuilding", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);

                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@PlanetID", (int)PlanetID);
                DBCmd.Parameters.AddWithValue("@BuildingID", (int)BuildingID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
    }
}
