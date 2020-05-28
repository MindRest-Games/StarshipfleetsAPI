using StarshipfleetsAPI.Models.Research;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StarshipfleetsAPI.DAL
{
    public class ResearchDAL
    {
        public static List<Technology> GetResearchTypes(int? UserID)
        {
            List<Technology> BuildingsObjs = new List<Technology>();

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.GetResearchTypes", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);
                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@UserID", (int)UserID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (sqlReader.Read())
                {
                    Technology bld = new Technology();
                    bld.TechnologyID = sqlReader.GetInt32Nullable("TechnologyID");
                    bld.Name = sqlReader.GetStringNullable("Name");
                    bld.PopulationMax = sqlReader.GetDoubleNullable("PopulationMax");
                    bld.Energy = sqlReader.GetDoubleNullable("Energy");
                    bld.Food = sqlReader.GetDoubleNullable("Food");
                    bld.Research = sqlReader.GetDoubleNullable("Research");
                    bld.Mining = sqlReader.GetDoubleNullable("Mining");
                    bld.Infrastructure = sqlReader.GetDoubleNullable("Infrastructure");
                    bld.Military = sqlReader.GetDoubleNullable("Military");
                    bld.Laser = sqlReader.GetDoubleNullable("Laser");
                    bld.Missile = sqlReader.GetDoubleNullable("Missile");
                    bld.Plasma = sqlReader.GetDoubleNullable("Plasma");
                    bld.Shields = sqlReader.GetDoubleNullable("Shields");
                    bld.Armor = sqlReader.GetDoubleNullable("Armor"); 
                    bld.BodyArmor = sqlReader.GetDoubleNullable("BodyArmor"); 
                    bld.Weapons = sqlReader.GetDoubleNullable("Weapons"); 
                    bld.TechnologyCost = sqlReader.GetDoubleNullable("TechnologyCost");
                    bld.TechID = sqlReader.GetInt32Nullable("TechID");
                    bld.TechLevel = sqlReader.GetInt32Nullable("TechLevel");
                    bld.BldLevel = sqlReader.GetInt32Nullable("BldLevel");
                    bld.QuedLevel = sqlReader.GetInt32Nullable("QuedLevel");
                    BuildingsObjs.Add(bld);
                }
                return BuildingsObjs;
            }
        }


        public static void InsertUpdatePlayerTech(int? UserID, int? TechID)
        {
            if (!UserID.HasValue)
            {
                throw new ArgumentNullException("UserID", $"UserID cannot be null.");
            }

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.AddPlayerTech", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);

                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@UserID", (int)UserID);
                DBCmd.Parameters.AddWithValue("@TechID", (int)TechID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
    }
}