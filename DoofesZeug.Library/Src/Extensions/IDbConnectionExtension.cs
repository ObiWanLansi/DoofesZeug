using System;
using System.Collections.Generic;
using System.Data;



namespace DoofesZeug.Extensions
{
    public static class IDbConnectionExtension
    {
        public static IEnumerable<IDataReader> Select( this IDbConnection dbConnection, string strFormat, params object [] args )
        {
            string strSQLStatement = args != null && args.Length > 0 ? string.Format(strFormat, args) : strFormat;

            using IDbCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = strSQLStatement;
            dbCommand.CommandTimeout = 0;

            using IDataReader dbResult = dbCommand.ExecuteReader();

            while( dbResult.Read() )
            {
                yield return dbResult;
            }

            dbResult.Close();
        }


        public static IEnumerable<IDataReader> Select( this IDbConnection dbConnection, string strSelectStatement )
        {
            using IDbCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = strSelectStatement;
            dbCommand.CommandTimeout = 0;

            using IDataReader dbResult = dbCommand.ExecuteReader();

            while( dbResult.Read() )
            {
                yield return dbResult;
            }

            dbResult.Close();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static int ExecuteNonQuery( this IDbConnection dbConnection, string strFormat, params object [] args )
        {
            string strSQLStatement = args != null && args.Length > 0 ? string.Format(strFormat, args) : strFormat;

            using IDbCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = strSQLStatement;

            return dbCommand.ExecuteNonQuery();
        }


        public static int ExecuteNonQuery( this IDbConnection dbConnection, int iTimeout, bool bTransaction, string strFormat, params object [] args )
        {
            string strSQLStatement = args != null && args.Length > 0 ? string.Format(strFormat, args) : strFormat;

            using IDbCommand dbCommand = dbConnection.CreateCommand();

            IDbTransaction dbTransaction = null;

            if( bTransaction == true )
            {
                dbTransaction = dbConnection.BeginTransaction();
                dbCommand.Transaction = dbTransaction;
            }

            dbCommand.CommandText = strSQLStatement;
            dbCommand.CommandTimeout = iTimeout;

            int iResult = dbCommand.ExecuteNonQuery();

            dbTransaction?.Commit();

            return iResult;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static object ExecuteScalar( this IDbConnection dbConnection, string strFormat, params object [] args ) => ExecuteScalar(dbConnection, 0, strFormat, args);


        public static object ExecuteScalar( this IDbConnection dbConnection, int iTimeOut, string strFormat, params object [] args )
        {
            string strSQLStatement = args != null && args.Length > 0 ? string.Format(strFormat, args) : strFormat;

            using IDbCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = strSQLStatement;
            dbCommand.CommandTimeout = iTimeOut;

            return dbCommand.ExecuteScalar();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static SortedDictionary<T1, T2> GetSortedDictionary<T1, T2>( this IDbConnection dbConnection, string strSelectStatement )
        {
            using IDbCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = strSelectStatement;

            using IDataReader dbResult = dbCommand.ExecuteReader();

            SortedDictionary<T1, T2> sdResult = new();

            while( dbResult.Read() )
            {
                sdResult.Add((T1) dbResult.GetValue(0), (T2) dbResult.GetValue(1));
            }

            dbResult.Close();

            return sdResult;
        }


        public static Dictionary<T1, T2> GetDictionary<T1, T2>( this IDbConnection dbConnection, string strSelectStatement )
        {
            using IDbCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = strSelectStatement;

            using IDataReader dbResult = dbCommand.ExecuteReader();

            Dictionary<T1, T2> sdResult = new();

            while( dbResult.Read() )
            {
                sdResult.Add((T1) dbResult.GetValue(0), (T2) dbResult.GetValue(1));
            }

            dbResult.Close();

            return sdResult;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static void CloseIfOpen( this IDbConnection dbConnection )
        {
            if( dbConnection.State == ConnectionState.Open )
            {
                try
                {
                    dbConnection.Close();
                }
                catch( Exception )
                {
                    // Can be ignored!
                }
            }
        }
    }
}
