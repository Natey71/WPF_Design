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
        public static ObservableCollection<Items> _Items = new ObservableCollection<Items>()
        {
            new Items() {Color1 = "GREEN", Color2 = "GREEN", Color3 = "RED", Color4 = "GREEN"},
            new Items() {Color1 = "GREEN", Color2 = "GREEN", Color3 = "GREEN", Color4 = "GREEN"},
            new Items() {Color1 = "GREEN", Color2 = "GREEN", Color3 = "GREEN", Color4 = "GREEN"},
            new Items() {Color1 = "RED", Color2 = "GREEN", Color3 = "GREEN", Color4 = "GREEN"},
            new Items() {Color1 = "GREEN", Color2 = "GREEN", Color3 = "GREEN", Color4 = "RED"},
            new Items() {Color1 = "GREEN", Color2 = "YELLOW", Color3 = "YELLOW", Color4 = "GREEN"},
            new Items() {Color1 = "GREEN", Color2 = "GREEN", Color3 = "GREEN", Color4 = "GREEN"},
            new Items() {Color1 = "RED", Color2 = "GREEN", Color3 = "RED", Color4 = "GREEN"},
            new Items() {Color1 = "GREEN", Color2 = "GREEN", Color3 = "GREEN", Color4 = "GREEN"},
            new Items() {Color1 = "GREEN", Color2 = "YELLOW", Color3 = "GREEN", Color4 = "GREEN"},
            new Items() {Color1 = "GREEN", Color2 = "GREEN", Color3 = "GREEN", Color4 = "GREEN"},
            new Items() {Color1 = "GREEN", Color2 = "YELLOW", Color3 = "RED", Color4 = "GREEN"}
        };

        public static ObservableCollection<Items> getColors()
        {
            return _Items;
        }

        public static ObservableCollection<User> GetUsers()
        {

            SqlConnection sqlConnection = Connection.Connection.newConnection();
            string query = "SELECT rectangle01, rectangle01_color FROM dashboard";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                _DatabaseUsers.Add(new User() { Name = reader["rectangle01"].ToString(), Email = reader["rectangle01_color"].ToString() });
            }
            sqlConnection.Close();
            return _DatabaseUsers;
        }


        public static void AddUser(User user)
        {
            _DatabaseUsers.Add(user);

            string query = @"INSERT INTO [dbo].[dashboard]
                                           ([year]
                                           ,[month]
                                           ,[day]
                                           ,[rectangle01]
                                           ,[rectangle01_color]
                                           ,[rectangle02]
                                           ,[rectangle02_color])
                                     VALUES
                                           (2023, 8, 12, @rec1, @color1, NULL, NULL)";
            SqlConnection conn = Connection.Connection.newConnection();

            SqlCommand sqlCommand = new SqlCommand( query, conn);
            sqlCommand.Parameters.AddWithValue("@rec1", user.Name);
            sqlCommand.Parameters.AddWithValue("@color1", user.Email);
            conn.Open();
            sqlCommand.ExecuteNonQuery();
            conn.Close();


        }

    }
}
