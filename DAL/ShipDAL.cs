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
                    design.Armor = sqlReader.GetDoubleNullable("Armor");
                    design.Laser = sqlReader.GetDoubleNullable("Laser");
                    design.MaterialCost = sqlReader.GetDoubleNullable("MaterialCost");
                    design.MilitaryCost = sqlReader.GetInt32Nullable("MilitaryCost");
                    design.Missile = sqlReader.GetDoubleNullable("Missile");
                    design.Movement = sqlReader.GetDoubleNullable("Movement");
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
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.AddShipDesigns", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);

                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@UserID", design.UserID);
                DBCmd.Parameters.AddWithValue("@DesignName", design.DesignName);
                DBCmd.Parameters.AddWithValue("@HullID", design.HullID);
                DBCmd.Parameters.AddWithValue("@ShipYardLevel", design.ShipYardLevel);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);

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
    }
}