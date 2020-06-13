using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using StarshipfleetsAPI.Models.Planets;
using StarshipfleetsAPI.Models.User;

namespace StarshipfleetsAPI.DAL
{
    public class UserDAL
    {
        public static User UserLogin(string UserEmail, string Password)
        {
            User user = new User();

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.UserLogin", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);

                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@UserEmail", UserEmail);
                DBCmd.Parameters.AddWithValue("@Password", Password);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (sqlReader.Read())
                {
                    user.UserID = sqlReader.GetInt32Nullable("UserID");
                    user.UserEmail = sqlReader.GetString("UserEmail");
                    user.Premium = sqlReader.GetBooleanNullable("Premium");
                    user.PremiumExpires = sqlReader.GetDateTimeNullable("PremiumExpires");
                    user.LastLogin = sqlReader.GetDateTimeNullable("LastLogin");
                    user.IPAddress = sqlReader.GetStringNullable("IPAddress");
                    user.Joined = sqlReader.GetDateTimeNullable("Joined");
                    user.Banned = sqlReader.GetBooleanNullable("Banned");
                }
                return user;
            }
        }

        public static User CreateLogin(string UserEmail, string Password)
        {
            User user = new User();

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.CreateLogin", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);

                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@UserEmail", UserEmail);
                DBCmd.Parameters.AddWithValue("@Password", Password);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (sqlReader.Read())
                {
                    user.UserID = sqlReader.GetInt32Nullable("UserID");
                    user.UserEmail = sqlReader.GetString("UserEmail");
                    user.Premium = sqlReader.GetBooleanNullable("Premium");
                    user.PremiumExpires = sqlReader.GetDateTimeNullable("PremiumExpires");
                    user.LastLogin = sqlReader.GetDateTimeNullable("LastLogin");
                    user.IPAddress = sqlReader.GetStringNullable("IPAddress");
                    user.Joined = sqlReader.GetDateTimeNullable("Joined");
                    user.Banned = sqlReader.GetBooleanNullable("Banned");
                }
                return user;
            }
        }

        public static List<PlanetDetail> GetFirstPlanet(int? UserID)
        {
            if (!UserID.HasValue)
            {
                throw new ArgumentNullException("UserID", $"UserID cannot be null.");
            }

            int? PlanetID = 0;
            List<PlanetDetail> planets = new List<PlanetDetail>();

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.GetFirstPlanet", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);
                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@UserID", (int)UserID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);


                if (sqlReader.Read())
                {
                    PlanetID = sqlReader.GetInt32Nullable("PlanetID");
                }
            }
            planets = UserDAL.GetPlanetList(UserID);
            return planets;
        }

        public static List<PlanetDetail> GetPlanetList(int? UserID)
        {
            if (!UserID.HasValue)
            {
                throw new ArgumentNullException("UserID", $"UserID cannot be null.");
            }

            List<PlanetDetail> planets = new List<PlanetDetail>();

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.GetPlanetList", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);

                DBCmd.CommandType = CommandType.StoredProcedure;
                
                DBCmd.Parameters.AddWithValue("@UserID", (int)UserID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (sqlReader.Read())
                {
                    PlanetDetail planet = new PlanetDetail();
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
                    planets.Add(planet);
                }
                return planets;
            }
        }
    }
}