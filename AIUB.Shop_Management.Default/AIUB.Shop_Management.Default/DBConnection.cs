using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AIUB.Shop_Management.Default
{
    public static class DBConnection
    {
        private static string connectionString = "Data Source=NAZIBMAHFUZ;Initial Catalog=SuperShopManagementSystem;Integrated Security=True";
        private static SqlConnection _connection;

        public static SqlConnection Connection
        {
            get
            {
                if (_connection == null)
                    _connection = new SqlConnection(connectionString);
                else if(_connection.State!=ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }

        }

        //for select query
        public static DataSet GetDataSet(string query)
        {
            SqlCommand command = new SqlCommand(query, Connection);
            SqlDataAdapter adp = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            return ds;
        }

        public static DataTable GetDataTable(string query)
        {
            DataSet ds = GetDataSet(query);
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }


        public static int ExecuteQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, Connection);
            return command.ExecuteNonQuery();
            
        }

    }
}
