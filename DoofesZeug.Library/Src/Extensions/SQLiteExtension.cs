using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;



namespace DoofesZeug.Extensions
{
    public static class SQLiteExtension
    {
        /// <summary>
        /// Analyzes the specified database connection.
        /// </summary>
        /// <param name="dbConnection">The database connection.</param>
        public static void Analyze( this SQLiteConnection dbConnection )
        {
            using SQLiteCommand dbCommand = new("ANALYZE", dbConnection);

            dbCommand.ExecuteNonQuery();
        }


        /// <summary>
        /// Reindexes the specified database connection.
        /// </summary>
        /// <param name="dbConnection">The database connection.</param>
        public static void Reindex( this SQLiteConnection dbConnection )
        {
            using SQLiteCommand dbCommand = new("REINDEX", dbConnection);

            dbCommand.ExecuteNonQuery();
        }


        /// <summary>
        /// Vacuums the specified database connection.
        /// </summary>
        /// <param name="dbConnection">The database connection.</param>
        public static void Vacuum( this SQLiteConnection dbConnection )
        {
            using SQLiteCommand dbCommand = new("VACUUM", dbConnection);

            dbCommand.ExecuteNonQuery();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Drops the table.
        /// </summary>
        /// <param name="dbConnection">The database connection.</param>
        /// <param name="strTablename">The string tablename.</param>
        public static void DropTable( this SQLiteConnection dbConnection, string strTablename ) => dbConnection.ExecuteNonQuery("DROP TABLE {0}", strTablename);


        /// <summary>
        /// Tables the exists.
        /// </summary>
        /// <param name="dbConnection">The db connection.</param>
        /// <param name="strTablename">The STR tablename.</param>
        /// <returns></returns>
        public static bool TableExists( this SQLiteConnection dbConnection, string strTablename ) => 1 == (long) dbConnection.ExecuteScalar("SELECT COUNT(1) FROM SQLITE_MASTER WHERE TYPE = 'table' AND LOWER(NAME) = '{0}'", strTablename.ToLower());


        /// <summary>
        /// Gets the table names.
        /// </summary>
        /// <param name="dbConnection">The database connection.</param>
        /// <returns></returns>
        public static List<string> GetTableNames( this SQLiteConnection dbConnection ) => dbConnection.Select("SELECT NAME FROM SQLITE_MASTER WHERE TYPE='table' AND NAME NOT LIKE 'sqlite_%'").Select(dbResult => dbResult.GetString(0)).ToList();


        /// <summary>
        /// Gets the view names.
        /// </summary>
        /// <param name="dbConnection">The database connection.</param>
        /// <returns></returns>
        public static List<string> GetViewNames( this SQLiteConnection dbConnection ) => dbConnection.Select("SELECT NAME FROM SQLITE_MASTER WHERE TYPE='view' AND NAME NOT LIKE 'sqlite_%'").Select(dbResult => dbResult.GetString(0)).ToList();

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Truncates the specified string tablename.
        /// </summary>
        /// <param name="dbConnection">The database connection.</param>
        /// <param name="strTablename">The string tablename.</param>
        public static void Truncate( this SQLiteConnection dbConnection, string strTablename )
        {
            using SQLiteTransaction transaction = dbConnection.BeginTransaction();

            // In SQLite gibt es nicht wirklich ein Truncate, deswegen ein DELETE mit Transaction
            using SQLiteCommand dbCommand = new($"DELETE FROM {strTablename}", dbConnection);

            dbCommand.ExecuteNonQuery();

            transaction.Commit();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Gets the last primarykey.
        /// </summary>
        /// <param name="dbConnection">The database connection.</param>
        /// <returns></returns>
        public static long GetLastPrimarykey( this SQLiteConnection dbConnection )
        {
            using SQLiteCommand dbCommand = new("SELECT LAST_INSERT_ROWID()", dbConnection);

            return (long) dbCommand.ExecuteScalar();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Gets the columns as data table.
        /// </summary>
        /// <param name="dbConnection">The database connection.</param>
        /// <param name="strTablename">The string tablename.</param>
        /// <returns></returns>
        public static DataTable GetColumnsAsDataTable( this SQLiteConnection dbConnection, string strTablename )
        {
            DataTable dt = new(strTablename);

            dt.Columns.AddRange(new []
            {
                new DataColumn { ColumnName = "ColumnName" , DataType = typeof(string) },
                new DataColumn { ColumnName = "DataType" , DataType = typeof(string) },
                new DataColumn { ColumnName = "NotNull" , DataType = typeof(bool) },
                new DataColumn { ColumnName = "PrimaryKey" , DataType = typeof(bool) }
            });

#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            using( SQLiteCommand dbSelectColumns = new($"PRAGMA TABLE_INFO({strTablename})", dbConnection) )
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            {
                using SQLiteDataReader dbResult = dbSelectColumns.ExecuteReader();

                while( dbResult.Read() )
                {
                    dt.Rows.Add((string) dbResult [1], (string) dbResult [2], ( (long) dbResult [3] ) > 0, ( (long) dbResult [5] ) > 0);
                }

                dbResult.Close();
            }

            return dt;
        }


        /// <summary>
        /// Gets the simplified columns.
        /// </summary>
        /// <param name="dbConnection">The database connection.</param>
        /// <param name="strTablename">The string tablename.</param>
        /// <returns></returns>
        public static SortedDictionary<string, string> GetSimplifiedColumns( this SQLiteConnection dbConnection, string strTablename )
        {
            SortedDictionary<string, string> sdColumns = new();

#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            using( SQLiteCommand dbSelectColumns = new($"PRAGMA TABLE_INFO({strTablename})", dbConnection) )
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            {
                using SQLiteDataReader dbResult = dbSelectColumns.ExecuteReader();

                while( dbResult.Read() )
                {
                    sdColumns.Add((string) dbResult [1], (string) dbResult [2]);
                }

                dbResult.Close();
            }

            return sdColumns;
        }


        /// <summary>
        /// Gets the name of the primary key column.
        /// </summary>
        /// <param name="dbConnection">The database connection.</param>
        /// <param name="strTablename">The string tablename.</param>
        /// <returns></returns>
        public static string GetPrimaryKeyColumnName( this SQLiteConnection dbConnection, string strTablename )
        {
            string strPrimaryKeyColumnName = null;

#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            using( SQLiteCommand dbSelectColumns = new($"PRAGMA TABLE_INFO({strTablename})", dbConnection) )
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            {
                using SQLiteDataReader dbResult = dbSelectColumns.ExecuteReader();

                while( dbResult.Read() )
                {
                    if( ( (long) dbResult [5] ) > 0 )
                    {
                        strPrimaryKeyColumnName = (string) dbResult [1];
                        break;
                    }
                }

                dbResult.Close();
            }

            return strPrimaryKeyColumnName;
        }
    }
}
