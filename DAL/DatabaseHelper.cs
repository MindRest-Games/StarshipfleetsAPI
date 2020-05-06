using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;

namespace StarshipfleetsAPI.DAL
{
    public static class DatabaseHelper
    {
        public static SqlConnection GetConnection(string connStringName = "Aries")
        {
            string constr = ConfigurationManager.ConnectionStrings[connStringName].ToString();
            SqlConnection sqlConn = new SqlConnection(constr);
            return sqlConn;
        }


        /// <summary>
        /// Overload of SqlDataReader.GetBoolean() that accepts a column name instead of a column index.
        /// </summary>
        /// <param name="dataReader">SqlDataReader object that is being operated on.</param>
        /// <param name="columnName">Name of the column you want to retrieve the value for.</param>
        /// <returns></returns>
        public static bool GetBoolean(this SqlDataReader dataReader, string columnName)
        {
            var columnIndex = dataReader.GetOrdinal(columnName);
            return dataReader.GetBoolean(columnIndex);
        }

        /// <summary>
        /// Overload of SqlDataReader.GetBoolean() that accepts a column name instead of a column index. Allows nulls.
        /// </summary>
        /// <param name="dataReader">SqlDataReader object that is being operated on.</param>
        /// <param name="columnName">Name of the column you want to retrieve the value for.</param>
        /// <returns></returns>
        public static bool? GetBooleanNullable(this SqlDataReader dataReader, string columnName)
        {
            var columnIndex = dataReader.GetOrdinal(columnName);
            if (dataReader.IsDBNull(columnIndex))
            {
                return null;
            }
            return dataReader.GetBoolean(columnIndex);
        }

        /// <summary>
        /// Overload of SqlDataReader.GetByte() that accepts a column name instead of a column index.
        /// </summary>
        /// <param name="dataReader">SqlDataReader object that is being operated on.</param>
        /// <param name="columnName">Name of the column you want to retrieve the value for.</param>
        /// <returns></returns>
        public static byte GetByte(this SqlDataReader dataReader, string columnName)
        {
            var columnIndex = dataReader.GetOrdinal(columnName);
            return dataReader.GetByte(columnIndex);
        }

        /// <summary>
        /// Overload of SqlDataReader.GetByte() that accepts a column name instead of a column index. Allows nulls.
        /// </summary>
        /// <param name="dataReader">SqlDataReader object that is being operated on.</param>
        /// <param name="columnName">Name of the column you want to retrieve the value for.</param>
        /// <returns></returns>
        public static byte? GetByteNullable(this SqlDataReader dataReader, string columnName)
        {
            var columnIndex = dataReader.GetOrdinal(columnName);
            if (dataReader.IsDBNull(columnIndex))
            {
                return null;
            }
            return dataReader.GetByte(columnIndex);
        }

        /// <summary>
        /// Overload of SqlDataReader.GetDateTime() that accepts a column name instead of a column index.
        /// </summary>
        /// <param name="dataReader">SqlDataReader object that is being operated on.</param>
        /// <param name="columnName">Name of the column you want to retrieve the value for.</param>
        /// <returns></returns>
        public static DateTime GetDateTime(this SqlDataReader dataReader, string columnName)
        {
            var columnIndex = dataReader.GetOrdinal(columnName);
            return dataReader.GetDateTime(columnIndex);
        }

        /// <summary>
        /// Overload of SqlDataReader.GetDateTime() that accepts a column name instead of a column index. Allows nulls.
        /// </summary>
        /// <param name="dataReader">SqlDataReader object that is being operated on.</param>
        /// <param name="columnName">Name of the column you want to retrieve the value for.</param>
        /// <returns></returns>
        public static DateTime? GetDateTimeNullable(this SqlDataReader dataReader, string columnName)
        {
            var columnIndex = dataReader.GetOrdinal(columnName);
            if (dataReader.IsDBNull(columnIndex))
            {
                return null;
            }
            return dataReader.GetDateTime(columnIndex);
        }

        /// <summary>
        /// Overload of SqlDataReader.GetGuid() that accepts a column name instead of a column index.
        /// </summary>
        /// <param name="dataReader">SqlDataReader object that is being operated on.</param>
        /// <param name="columnName">Name of the column you want to retrieve the value for.</param>
        /// <returns></returns>
        public static Guid GetGuid(this SqlDataReader dataReader, string columnName)
        {
            var columnIndex = dataReader.GetOrdinal(columnName);
            return dataReader.GetGuid(columnIndex);
        }

        /// <summary>
        /// Overload of SqlDataReader.GetGuid() that accepts a column name instead of a column index. Allows nulls.
        /// </summary>
        /// <param name="dataReader">SqlDataReader object that is being operated on.</param>
        /// <param name="columnName">Name of the column you want to retrieve the value for.</param>
        /// <returns></returns>
        public static Guid? GetGuidNullable(this SqlDataReader dataReader, string columnName)
        {
            var columnIndex = dataReader.GetOrdinal(columnName);
            if (dataReader.IsDBNull(columnIndex))
            {
                return null;
            }
            return dataReader.GetGuid(columnIndex);
        }

        /// <summary>
        /// Overload of SqlDataReader.GetInt16() that accepts a column name instead of a column index.
        /// </summary>
        /// <param name="dataReader">SqlDataReader object that is being operated on.</param>
        /// <param name="columnName">Name of the column you want to retrieve the value for.</param>
        /// <returns></returns>
        public static short GetInt16(this SqlDataReader dataReader, string columnName)
        {
            var columnIndex = dataReader.GetOrdinal(columnName);
            return dataReader.GetInt16(columnIndex);
        }

        /// <summary>
        /// Overload of SqlDataReader.GetInt16() that accepts a column name instead of a column index. Allows nulls.
        /// </summary>
        /// <param name="dataReader">SqlDataReader object that is being operated on.</param>
        /// <param name="columnName">Name of the column you want to retrieve the value for.</param>
        /// <returns></returns>
        public static short? GetInt16Nullable(this SqlDataReader dataReader, string columnName)
        {
            var columnIndex = dataReader.GetOrdinal(columnName);
            if (dataReader.IsDBNull(columnIndex))
            {
                return null;
            }
            return dataReader.GetInt16(columnIndex);
        }

        /// <summary>
        /// Overload of SqlDataReader.GetInt32() that accepts a column name instead of a column index.
        /// </summary>
        /// <param name="dataReader">SqlDataReader object that is being operated on.</param>
        /// <param name="columnName">Name of the column you want to retrieve the value for.</param>
        /// <returns></returns>
        public static int GetInt32(this SqlDataReader dataReader, string columnName)
        {
            var columnIndex = dataReader.GetOrdinal(columnName);
            return dataReader.GetInt32(columnIndex);
        }

        /// <summary>
        /// Overload of SqlDataReader.GetInt32() that accepts a column name instead of a column index. Allows nulls.
        /// </summary>
        /// <param name="dataReader">SqlDataReader object that is being operated on.</param>
        /// <param name="columnName">Name of the column you want to retrieve the value for.</param>
        /// <returns></returns>
        public static int? GetInt32Nullable(this SqlDataReader dataReader, string columnName)
        {
            var columnIndex = dataReader.GetOrdinal(columnName);
            if (dataReader.IsDBNull(columnIndex))
            {
                return null;
            }
            return dataReader.GetInt32(columnIndex);
        }

        /// <summary>
        /// Overload of SqlDataReader.GetDecimal() that accepts a column name instead of a column index.
        /// </summary>
        /// <param name="dataReader">SqlDataReader object that is being operated on.</param>
        /// <param name="columnName">Name of the column you want to retrieve the value for.</param>
        /// <returns></returns>
        public static decimal GetDecimal(this SqlDataReader dataReader, string columnName)
        {
            var columnIndex = dataReader.GetOrdinal(columnName);
            return dataReader.GetDecimal(columnIndex);
        }

        /// <summary>
        /// Overload of SqlDataReader.GetDecimal() that accepts a column name instead of a column index. Allows nulls.
        /// </summary>
        /// <param name="dataReader">SqlDataReader object that is being operated on.</param>
        /// <param name="columnName">Name of the column you want to retrieve the value for.</param>
        /// <returns></returns>
        public static decimal? GetDecimalNullable(this SqlDataReader dataReader, string columnName)
        {
            var columnIndex = dataReader.GetOrdinal(columnName);
            if (dataReader.IsDBNull(columnIndex))
            {
                return null;
            }
            return dataReader.GetDecimal(columnIndex);
        }

        /// <summary>
        /// Overload of SqlDataReader.GetString() that accepts a column name instead of a column index.
        /// </summary>
        /// <param name="dataReader">SqlDataReader object that is being operated on.</param>
        /// <param name="columnName">Name of the column you want to retrieve the value for.</param>
        /// <returns></returns>
        public static string GetString(this SqlDataReader dataReader, string columnName)
        {
            var columnIndex = dataReader.GetOrdinal(columnName);
            return dataReader.GetString(columnIndex);
        }

        /// <summary>
        /// Overload of SqlDataReader.GetString() that accepts a column name instead of a column index. Allows nulls.
        /// </summary>
        /// <param name="dataReader">SqlDataReader object that is being operated on.</param>
        /// <param name="columnName">Name of the column you want to retrieve the value for.</param>
        /// <returns></returns>
        public static string GetStringNullable(this SqlDataReader dataReader, string columnName)
        {
            var columnIndex = dataReader.GetOrdinal(columnName);
            if (dataReader.IsDBNull(columnIndex))
            {
                return null;
            }
            return dataReader.GetString(columnIndex);
        }
    }
}