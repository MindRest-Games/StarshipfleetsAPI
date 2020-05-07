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
                }
                return user;
            }
        }
    }
}