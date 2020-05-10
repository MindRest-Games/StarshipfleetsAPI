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
                    TypeDetail.Intrastructure = sqlReader.GetDecimalNullable("Intrastructure");
                    TypeDetail.Food = sqlReader.GetDecimalNullable("Food");
                    TypeDetail.Mining = sqlReader.GetDecimalNullable("Mining");
                    TypeDetail.Research = sqlReader.GetDecimalNullable("Research");
                    TypeDetail.Energy = sqlReader.GetDecimalNullable("Energy");
                    TypeDetail.Barren = sqlReader.GetBooleanNullable("Barren");

                }
                return TypeDetail;
            }
        }

        public static List<GalaxyClass> GetGalaxy(int? GalaxyID, string Sector = null)
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
                    gc.SysPosition = sqlReader.GetInt32Nullable("SysPosition");
                    gc.Moon = sqlReader.GetBooleanNullable("Moon");
                    gc.Owner = sqlReader.GetInt32Nullable("Owner");
                    GalaxyObj.Add(gc);
                }
                return GalaxyObj;
            }
        }

        public static GalaxyClass GetPlanet(int? PlanetID)
        {
            if (!PlanetID.HasValue)
            {
                throw new ArgumentNullException("PlanetID", $"PlanetID cannot be null.");
            }

            GalaxyClass planet = new GalaxyClass();

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            using (SqlCommand DBCmd = new SqlCommand("dbo.GetPlanetDetailbyID", sqlConn))
            {
                SqlDataReader sqlReader = default(SqlDataReader);

                DBCmd.CommandType = CommandType.StoredProcedure;
                DBCmd.Parameters.AddWithValue("@PlanetID", (int)PlanetID);
                sqlConn.Open();
                sqlReader = DBCmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (sqlReader.Read())
                {
                    planet.PlanetID = sqlReader.GetInt32Nullable("PlanetID");
                    planet.PlanetName = sqlReader.GetStringNullable("PlanetName");
                    planet.PlanetType = sqlReader.GetInt32Nullable("PlanetType");
                    planet.Position = sqlReader.GetInt32Nullable("Position");
                    planet.SubPosition = sqlReader.GetInt32Nullable("SubPosition");
                    planet.Galaxy = sqlReader.GetInt32Nullable("Galaxy");
                    planet.Sector = sqlReader.GetStringNullable("Sector");
                    planet.System = sqlReader.GetInt32Nullable("System");
                    planet.SysPosition = sqlReader.GetInt32Nullable("SysPosition");
                    planet.Moon = sqlReader.GetBooleanNullable("Moon");
                    planet.Owner = sqlReader.GetInt32Nullable("Owner");
                }
                return planet;
            }
        }
    }
}