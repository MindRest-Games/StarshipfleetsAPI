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
                    TypeDetail.Mining = sqlReader.GetDecimalNullable("Mining");
                    TypeDetail.Research = sqlReader.GetDecimalNullable("Research");
                    TypeDetail.Energy = sqlReader.GetDecimalNullable("Energy");
                    TypeDetail.Barren = sqlReader.GetBooleanNullable("Barren");

                }
                return TypeDetail;
            }
        }
    }
}