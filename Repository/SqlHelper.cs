using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;


namespace OSHABM_proj
{
    
    public class SqlHelper : IDisposable
    {
        private SqlConnection con = null;
        private SqlCommand cmd = null;
        private SqlDataReader dr = null;
        private SqlDataAdapter ad = null;

        private void OpenConnection()
        {


            if (con == null)
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["OSHABM_projectDB"].ConnectionString);
            }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.Connection = con;


        }
        private void CloseConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
        public int ExecuteNonQueryByQuery(string _Query, SqlParameter[] _Parameters)
        {

            this.OpenConnection();
            cmd.CommandText = _Query;
            SqlParameter sp = new SqlParameter();
            if (cmd.Parameters.Count > 0)
            {
                cmd.Parameters.Clear();
            }
            foreach (SqlParameter param in _Parameters)
            {
                sp = param;
                cmd.Parameters.Add(sp);
            }
            //CloseConnection();
            int i = cmd.ExecuteNonQuery();
            CloseConnection();
            return i;

        }
        public SqlDataReader ExecuteReaderByQuery(string query)
        {
            this.OpenConnection();
            cmd.CommandText = query;
            dr = cmd.ExecuteReader();


            return dr;

        }
        public int ExecuteNonQueryByProc(string query, SqlParameter[] _Parameters)
        {
            this.OpenConnection();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = new SqlParameter();
            if (cmd.Parameters.Count > 0)
            {
                cmd.Parameters.Clear();
            }
            foreach (SqlParameter param in _Parameters)
            {
                sp = param;
                cmd.Parameters.Add(sp);
            }
            int i = cmd.ExecuteNonQuery();
            CloseConnection();
            return i;
        }
        public SqlDataReader ExecuteReaderByProc(string query, SqlParameter[] _Parameters)
        {
            this.OpenConnection();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = new SqlParameter();
            if (cmd.Parameters.Count > 0)
            {
                cmd.Parameters.Clear();
            }
            foreach (SqlParameter i in _Parameters)
            {
                sp = i;
                cmd.Parameters.Add(sp);
            }
            dr = cmd.ExecuteReader();
            return dr;
        }
        public SqlDataReader GetDataReaderByProc(string query, SqlParameter[] _Parameters)
        {
            this.OpenConnection();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = new SqlParameter();
            if (cmd.Parameters.Count > 0)
            {
                cmd.Parameters.Clear();
            }
            foreach (SqlParameter i in _Parameters)
            {
                sp = i;
                cmd.Parameters.Add(sp);
            }
            dr = cmd.ExecuteReader();
            return dr;
        }

        public DataTable GetDataTableByproc(string _procedureName)
        {
            this.OpenConnection();
            DataTable _objTable = new DataTable();
            ad = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = _procedureName;
            ad.SelectCommand = cmd;
            ad.Fill(_objTable);
            this.OpenConnection();
            return _objTable;

        }
        public DataTable GetDataTable(string _procedureName, SqlParameter[] _Parameters)
        {
            this.OpenConnection();
            DataTable _objTable = new DataTable();
            ad = new SqlDataAdapter();
            SqlParameter _sqlParameter = new SqlParameter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = _procedureName;
            if (cmd.Parameters.Count > 0)
                cmd.Parameters.Clear();
            ad.SelectCommand = cmd;
            foreach (SqlParameter LoopVar_Param in _Parameters)
            {
                _sqlParameter = LoopVar_Param;
                cmd.Parameters.Add(_sqlParameter);
            }
            ad.Fill(_objTable);
            this.CloseConnection();

            return _objTable;
        }

        public void Dispose()
        {
            if (con != null)
            {
                con.Dispose();
                con = null;
            }
        }
    }
}