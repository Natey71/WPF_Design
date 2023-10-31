using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Wpfmvvm_02.Models
{
    public class UserManager
    {
        public static ObservableCollection<User> _DatabaseUsers = new ObservableCollection<User>();

        public static ObservableCollection<User> GetUsers()
        {

            SqlConnection sqlConnection = Connection.Connection.newConnection();
            string query = "SELECT ENAME, EMAIL FROM EMPLOYEE";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                _DatabaseUsers.Add(new User() { Name = reader["ENAME"].ToString(), Email = reader["EMAIL"].ToString() });
            }
            sqlConnection.Close();
            return _DatabaseUsers;
        }

        public static bool DoesUserExist(User user)
        {
            bool result = false;    
            SqlConnection sqlConnection = Connection.Connection.newConnection();
            string query = "SELECT ENAME, EMAIL FROM EMPLOYEE WHERE ENAME = @NAME AND EMAIL = @EMAIL";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@NAME", user.Name);
            sqlCommand.Parameters.AddWithValue("@EMAIL", user.Email);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                result = true;
            }
            sqlConnection.Close();
            return result;
        }
        public static void AddUser(User user)
        {
            _DatabaseUsers.Add(user);

            string query = @"INSERT INTO [dbo].[EMPLOYEE]
                                           ([ENAME], [EMAIL])
                                     VALUES
                                           (@NAME, @EMAIL)";
            SqlConnection conn = Connection.Connection.newConnection();

            SqlCommand sqlCommand = new SqlCommand( query, conn);
            sqlCommand.Parameters.AddWithValue("@NAME", user.Name);
            sqlCommand.Parameters.AddWithValue("@EMAIL", user.Email);
            conn.Open();
            sqlCommand.ExecuteNonQuery();
            conn.Close();


        }

    }
}
