using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SyncDatabase
{
    public class ConnectionManager
    {
        String strConn = "";
        SqlConnection objConn = null;

        public bool conectar()
        {
            objConn = new SqlConnection(strConn);
            try
            {
                objConn.Open();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return false;
            }

            return true;
        }

        public bool conectar(string p_strConn)
        {
            objConn = new SqlConnection(p_strConn);
            try
            {
                objConn.Open();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return false;
            }

            return true;
        }

        public bool desconectar()
        {
            try
            {
                if (objConn.State != ConnectionState.Closed)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public DataTable retornarTabela(string p_strSql, List<SqlParameter> p_objParams, string p_strNmTabelaRetorno)
        {
            if (!this.conectar())
            {
                return null;
            }

            SqlCommand objCmd = new SqlCommand(p_strSql, objConn);
            foreach (SqlParameter param in p_objParams)
            {
                objCmd.Parameters.Add(param);
            }
            SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
            DataSet ds = new DataSet();

            try
            {
                objAdp.Fill(ds, p_strNmTabelaRetorno);
            }
            catch (Exception ex)
            {
                string exe = ex.Message;
                return null;
            }

            this.desconectar();

            return ds.Tables[p_strNmTabelaRetorno];
        }

        public DataTable retornarTabela(string p_strSql, string p_strNmTabelaRetorno, string strConn)
        {
            if (!this.conectar(strConn))
            {
                return null;
            }

            SqlCommand objCmd = new SqlCommand(p_strSql, objConn);
            
            SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
            DataSet ds = new DataSet();

            try
            {
                objAdp.Fill(ds, p_strNmTabelaRetorno);
            }
            catch (Exception ex)
            {
                string exe = ex.Message;
                return null;
            }

            this.desconectar();

            return ds.Tables[p_strNmTabelaRetorno];
        }
    }
}
