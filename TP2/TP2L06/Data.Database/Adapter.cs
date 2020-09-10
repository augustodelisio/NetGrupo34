using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        private SqlConnection _sqlConn;
        const string consKeyDefaultCnnString = "ConnStringExpress";

        public SqlConnection SqlConn { get => _sqlConn; set => _sqlConn = value; }

        protected void OpenConnection()
        {
            string conString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            SqlConn = new SqlConnection();
            SqlConn.ConnectionString = conString;
            SqlConn.Open();
        }

        protected void CloseConnection()
        {
            SqlConn.Close();
            SqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
