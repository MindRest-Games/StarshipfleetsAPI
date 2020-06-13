using StarshipfleetsAPI.Models.Planets;
using StarshipfleetsAPI.Models.Ships;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StarshipfleetsAPI.DAL
{
    public class ShipDAL
    {
        public static List<ShipDesignDetails> GetShipDesignDetails(int? ShipDesignID)
        {
            List<ShipDesignDetails> designs = new List<ShipDesignDetails>();

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.GetShipDesignDetails", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);
                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@ShipDesignID", ShipDesignID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (sqlReader.Read())
                {
                    ShipDesignDetails design = new ShipDesignDetails();
                    design.ShipDesignID = sqlReader.GetInt32Nullable("ShipDesignID");
                    design.DesignName = sqlReader.GetString("DesignName");
                    design.HullName = sqlReader.GetString("HullName");
                    design.Hull = sqlReader.GetDoubleNullable("Hull");
                    design.NumofPods = sqlReader.GetInt32Nullable("NumofPods");
                    design.ShipPodID = sqlReader.GetInt32Nullable("ShipPodID");
                    design.PodName = sqlReader.GetString("PodName");
                    design.Armor = sqlReader.GetDoubleNullable("Armor");
                    design.Energy = sqlReader.GetDoubleNullable("Energy");
                    design.EnergyCost = sqlReader.GetDoubleNullable("EnergyCost");
                    design.MilitaryCost = sqlReader.GetInt32Nullable("MilitaryCost");
                    design.Missile = sqlReader.GetDoubleNullable("Missile");
                    design.Movement = sqlReader.GetDoubleNullable("Movement");
                    design.Laser = sqlReader.GetDoubleNullable("Laser");
                    design.MaterialCost = sqlReader.GetDoubleNullable("MaterialCost");
                    design.Plasma = sqlReader.GetDoubleNullable("Plasma");
                    design.Shields = sqlReader.GetDoubleNullable("Shields");
                    design.Bays = sqlReader.GetDoubleNullable("Bays");
                    designs.Add(design);
                }
                return designs;
            }
        }

        public static ShipDesignDetails GetShipDesignSummary(int? ShipDesignID)
        {
            ShipDesignDetails design = new ShipDesignDetails();

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.GetShipDesignSummary", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);
                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@ShipDesignID", ShipDesignID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (sqlReader.Read())
                {
                    design.ShipDesignID = sqlReader.GetInt32Nullable("ShipDesignID");
                    design.DesignName = sqlReader.GetString("DesignName");
                    design.HullName = sqlReader.GetString("HullName");
                    design.Hull = sqlReader.GetDoubleNullable("Hull");
                    design.ShipYardLevel = sqlReader.GetInt32Nullable("ShipYardLevel");
                    design.MaterialCost = sqlReader.GetDoubleNullable("MaterialCost");
                    design.MilitaryCost = sqlReader.GetInt32Nullable("MilitaryCost");
                    design.Armor = sqlReader.GetDoubleNullable("Armor");
                    design.Laser = sqlReader.GetDoubleNullable("Laser");
                    design.Missile = sqlReader.GetDoubleNullable("Missile");                    
                    design.Plasma = sqlReader.GetDoubleNullable("Plasma");
                    design.Shields = sqlReader.GetDoubleNullable("Shields");
                    design.Bays = sqlReader.GetDoubleNullable("Bays");
                }
                return design;
            }
        }

        public static List<UserDesigns> RemoveShipDesigns(int? UserID, int? ShipDesignID)
        {
            ShipDesignDetails design = new ShipDesignDetails();

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.RemoveShipDesigns", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);
                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@ShipDesignID", ShipDesignID);
                DBCmd.Parameters.AddWithValue("@UserID", UserID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);
                List<UserDesigns> designs = GetShipDesignbyUser(UserID);
                return designs;
            }
        }
        

        public static List<UserDesigns> GetShipDesignbyUser(int? UserID)
        {
            List<UserDesigns> UserDesigns = new List<UserDesigns>();

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.GetShipDesignbyUser", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);
                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@UserID", UserID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (sqlReader.Read())
                {
                    UserDesigns UserDesign = new UserDesigns();
                    UserDesign.ShipDesignID = sqlReader.GetInt32Nullable("ShipDesignID");
                    UserDesign.UserID = sqlReader.GetInt32Nullable("UserID");
                    UserDesign.DesignName = sqlReader.GetString("DesignName");
                    UserDesign.HullID = sqlReader.GetInt32Nullable("HullID");
                    UserDesign.HullName = sqlReader.GetString("HullName");
                    UserDesign.ShipYardLevel = sqlReader.GetInt32Nullable("ShipYardLevel");
                    UserDesign.MaterialCost = sqlReader.GetDoubleNullable("MaterialCost");
                    UserDesign.MilitaryCost = sqlReader.GetInt32Nullable("MilitaryCost");
                    UserDesign.Energy = sqlReader.GetDoubleNullable("Energy");
                    UserDesign.EnergyCost = sqlReader.GetDoubleNullable("EnergyCost");
                    UserDesign.Laser = sqlReader.GetDoubleNullable("Laser");
                    UserDesign.Missile = sqlReader.GetDoubleNullable("Missile");
                    UserDesign.Plasma = sqlReader.GetDoubleNullable("Plasma");
                    UserDesign.Shields = sqlReader.GetDoubleNullable("Shields");
                    UserDesign.Armor = sqlReader.GetDoubleNullable("Armor");
                    UserDesign.Bays = sqlReader.GetDoubleNullable("Bays");
                    UserDesign.Movement = sqlReader.GetDoubleNullable("Movement");
                    UserDesigns.Add(UserDesign);
                }
                return UserDesigns;
            }
        }

        public static List<ShipPods> GetShipPods()
        {
            List<ShipPods> ShipPods = new List<ShipPods>();

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.GetShipPods", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);
                DBCmd.CommandType = CommandType.StoredProcedure;
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (sqlReader.Read())
                {
                    ShipPods ShipPod = new ShipPods();
                    ShipPod.ShipPodID = sqlReader.GetInt32Nullable("ShipPodID");
                    ShipPod.PodName = sqlReader.GetString("PodName");
                    ShipPod.SortOrder = sqlReader.GetInt32Nullable("SortOrder");
                    ShipPod.Mass = sqlReader.GetInt32Nullable("Mass");
                    ShipPod.MaterialCost = sqlReader.GetDoubleNullable("MaterialCost");
                    ShipPod.MilitaryCost = sqlReader.GetInt32Nullable("MilitaryCost");
                    ShipPod.Laser = sqlReader.GetDoubleNullable("Laser");
                    ShipPod.Energy = sqlReader.GetDoubleNullable("Energy");
                    ShipPod.EnergyCost = sqlReader.GetDoubleNullable("EnergyCost");
                    ShipPod.Missile = sqlReader.GetDoubleNullable("Missile");
                    ShipPod.Plasma = sqlReader.GetDoubleNullable("Plasma");
                    ShipPod.Shields = sqlReader.GetDoubleNullable("Shields");
                    ShipPod.Armor = sqlReader.GetDoubleNullable("Armor");
                    ShipPod.Bays = sqlReader.GetDoubleNullable("Bays");
                    ShipPod.Movement = sqlReader.GetDoubleNullable("Movement");
                    ShipPod.TechID = sqlReader.GetInt32Nullable("TechID");
                    ShipPod.TechLevel = sqlReader.GetInt32Nullable("TechLevel");
                    ShipPod.BuildingID = sqlReader.GetInt32Nullable("BuildingID");
                    ShipPod.BuildingLevel = sqlReader.GetInt32Nullable("BuildingLevel");
                    ShipPods.Add(ShipPod);
                }
                return ShipPods;
            }
        }

        public static List<ShipHulls> GetShipHulls()
        {
            List<ShipHulls> ShipHulls = new List<ShipHulls>();

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.GetShipHulls", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);
                DBCmd.CommandType = CommandType.StoredProcedure;
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (sqlReader.Read())
                {
                    ShipHulls ShipHull = new ShipHulls();
                    ShipHull.HullID = sqlReader.GetInt32Nullable("HullID");
                    ShipHull.HullName = sqlReader.GetString("HullName");
                    ShipHull.SortOrder = sqlReader.GetInt32Nullable("SortOrder");
                    ShipHull.MaterialCost = sqlReader.GetDoubleNullable("MaterialCost");
                    ShipHull.Hull = sqlReader.GetDoubleNullable("Hull");
                    ShipHull.NumPods = sqlReader.GetInt32Nullable("NumPods");
                    ShipHull.TechID = sqlReader.GetInt32Nullable("TechID");
                    ShipHull.TechLevel = sqlReader.GetInt32Nullable("TechLevel");
                    ShipHull.BuildingID = sqlReader.GetInt32Nullable("BuildingID");
                    ShipHull.BuildingLevel = sqlReader.GetInt32Nullable("BuildingLevel");
                    ShipHulls.Add(ShipHull);
                }
                return ShipHulls;
            }
        }

        public static List<UserDesigns> AddShipDesigns(UserDesigns design)
        {
            int? ShipDesignID = null;
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.AddShipDesigns", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);

                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@UserID", design.UserID);
                DBCmd.Parameters.AddWithValue("@DesignName", design.DesignName);
                DBCmd.Parameters.AddWithValue("@HullID", design.HullID);
                DBCmd.Parameters.AddWithValue("@ShipYardLevel", design.ShipYardLevel);
                DBCmd.Parameters.AddWithValue("@MaterialCost", design.MaterialCost);
                DBCmd.Parameters.AddWithValue("@MilitaryCost", design.MilitaryCost);
                DBCmd.Parameters.AddWithValue("@Laser", design.Laser);
                DBCmd.Parameters.AddWithValue("@Energy", design.Energy);
                DBCmd.Parameters.AddWithValue("@EnergyCost", design.EnergyCost);
                DBCmd.Parameters.AddWithValue("@Missile", design.Missile);
                DBCmd.Parameters.AddWithValue("@Plasma", design.Plasma); 
                DBCmd.Parameters.AddWithValue("@Shields", design.Shields);
                DBCmd.Parameters.AddWithValue("@Armor", design.Armor); 
                DBCmd.Parameters.AddWithValue("@Bays", design.Bays);
                DBCmd.Parameters.AddWithValue("@Movement", design.Movement);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sqlReader.Read())
                {
                    ShipDesignID = sqlReader.GetInt32Nullable("ShipDesignID");
                }
            }
            List<UserDesigns> designs = GetShipDesignbyUser(design.UserID);
            return designs;
        }

        public static ShipDesignDetails AddShipDesignPods(List<AddShipPods> Pods)
        {
            SqlConnection sqlConn = DatabaseHelper.GetConnection();
            sqlConn.Open();
            
            foreach (AddShipPods Pod in Pods)
            {
                SqlDataReader sqlReader = default(SqlDataReader);
                SqlCommand DBCmd = new SqlCommand("dbo.AddShipDesignPods", sqlConn);
                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@ShipDesignID", Pod.ShipDesignID);
                DBCmd.Parameters.AddWithValue("@PodID", Pod.PodID);
                DBCmd.Parameters.AddWithValue("@NumofPods", Pod.NumofPods);
                sqlReader = DBCmd.ExecuteReader();
                sqlReader.Close();
            }
            sqlConn.Close();
            ShipDesignDetails design = new ShipDesignDetails();
            if (Pods.Count > 0)
            {
                design = GetShipDesignSummary(Pods[0].ShipDesignID);
            }
            return design;
        }

        public static List<Fleet> GetUserFleets(int? UserID, int? PlanetID = null, int? FleetID = null)
        {
            FleetMoveComplete();
            List<Fleet> Fleets = new List<Fleet>();            

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.GetFleetsbyUser", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);
                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@UserID", UserID);
                DBCmd.Parameters.AddWithValue("@PlanetID", PlanetID);
                DBCmd.Parameters.AddWithValue("@FleetID", FleetID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (sqlReader.Read())
                {
                    Fleet fleet = new Fleet();
                    fleet.UserID = sqlReader.GetInt32Nullable("UserID");
                    fleet.FleetID = sqlReader.GetInt32Nullable("FleetID");
                    fleet.FleetName = sqlReader.GetString("FleetName");
                    fleet.Status = sqlReader.GetInt32Nullable("Status");
                    fleet.Destination = sqlReader.GetInt32Nullable("Destination");
                    fleet.Start = sqlReader.GetDateTimeNullable("Start");
                    fleet.Arrival = sqlReader.GetDateTimeNullable("Arrival");
                    fleet.PlanetID = sqlReader.GetInt32Nullable("PlanetID");
                    fleet.System = sqlReader.GetInt32Nullable("System");
                    fleet.Sector = sqlReader.GetStringNullable("Sector");
                    fleet.Galaxy = sqlReader.GetInt32Nullable("Galaxy");
                    fleet.XSysPosition = sqlReader.GetInt32Nullable("XSysPosition");
                    fleet.YSysPosition = sqlReader.GetInt32Nullable("YSysPosition");
                    Fleets.Add(fleet);
                }

                foreach(Fleet f in Fleets)
                {
                    f.Ships = GetFleetShips(f.FleetID);
                }
                return Fleets;
            }
        }

        public static List<FleetShips> GetFleetShips(int? FleetID)
        {
            List<FleetShips> Ships = new List<FleetShips>();
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.GetFleetShips", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);
                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@FleetID", FleetID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (sqlReader.Read())
                {
                    FleetShips ship = new FleetShips();
                    ship.UserID = sqlReader.GetInt32Nullable("UserID");
                    ship.FleetDetailID = sqlReader.GetInt32Nullable("FleetDetailID");
                    ship.FleetID = sqlReader.GetInt32Nullable("FleetID");
                    ship.DesignID = sqlReader.GetInt32Nullable("DesignID");
                    ship.DesignName = sqlReader.GetString("DesignName");
                    ship.ActualNumber = sqlReader.GetInt32Nullable("ActualNumber");
                    ship.EffectiveNumber = sqlReader.GetDoubleNullable("EffectiveNumber");
                    ship.Movement = sqlReader.GetDoubleNullable("Movement");
                    Ships.Add(ship);
                }
                return Ships;
            }
        }

        public static Fleet AddFleet(BuildingQue ship)
        {
            Fleet fl = new Fleet();
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.AddFleet", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);
                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@UserID", ship.UserID);
                DBCmd.Parameters.AddWithValue("@PlanetID", ship.PlanetID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sqlReader.Read())
                {
                    fl.FleetID = sqlReader.GetInt32Nullable("FleetID");
                }
            }
            AddFleetDetails(ship, fl.FleetID);
            List<Fleet> fls = GetUserFleets(ship.UserID, ship.PlanetID, fl.FleetID);
            fl = fls[0];
            return fl;
        }

        public static void AddFleetDetails(BuildingQue ship, int? FleetID)
        {            
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.AddFleetDetails", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);
                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@UserID", ship.UserID);
                DBCmd.Parameters.AddWithValue("@FleetID", FleetID);
                DBCmd.Parameters.AddWithValue("@DesignID", ship.BuildingID);
                DBCmd.Parameters.AddWithValue("@ActualNumber", 1);
                DBCmd.Parameters.AddWithValue("@EffectiveNumber", 1);
                DBCmd.Parameters.AddWithValue("@Movement", ship.Movement);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public static void SetMoveFleet(int? UserID, int? FleetID, int? PlanetID)
        {
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.SetMoveFleet", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);
                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@UserID", UserID);
                DBCmd.Parameters.AddWithValue("@FleetID", FleetID);
                DBCmd.Parameters.AddWithValue("@PlanetID", PlanetID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public static void FleetMoveComplete()
        {
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.FleetMoveComplete", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);
                DBCmd.CommandType = CommandType.StoredProcedure;
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
    }
}