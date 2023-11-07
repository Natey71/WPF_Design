using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpfmvvm_02.Connection
{
    public class Connection
    {

        SqlConnection con = new SqlConnection();
        private string ConnectionString = "Data Source=localhost;Integrated Security=SSPI;";
        public static SqlConnection newConnection()
        {
            string connectionString = "Data Source=localhost;Integrated Security=SSPI;Database=" + "PT;";
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }
        public void OpenConection()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }


        public void CloseConnection()
        {
            con.Close();
        }


        public void ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.ExecuteNonQuery();
        }


        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }


        public object ShowDataInGridView(string Query_)
        {
            SqlDataAdapter dr = new SqlDataAdapter(Query_, ConnectionString);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            object dataum = ds.Tables[0];
            return dataum;
        }
    }
}
