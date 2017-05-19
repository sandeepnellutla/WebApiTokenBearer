using MSTCloud.Utilities;
using Oracle.DataAccess.Client;
using System;
using System.Data;

namespace MSTCloud.DAL
{
    public class DataFactory
    {
        public static bool DBExecuteQuery(string query, string env, string DBName)
        {
            OracleConnection conn = null;
            OracleCommand cmd = null;

            try
            {
                AppHelper _helper = new AppHelper();
                conn = new OracleConnection(_helper.GetConnectionString(DBName, env));
                cmd = new OracleCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        public static DataTable DBExecuteQueryReturnDT(string query, string env, string DBName)
        {
            OracleConnection conn = null;
            OracleCommand cmd = null;
            DataTable dt = new DataTable();

            try
            {
                AppHelper _helper = new AppHelper();
                conn = new OracleConnection(_helper.GetConnectionString(DBName, env));
                cmd = new OracleCommand(query, conn);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
}