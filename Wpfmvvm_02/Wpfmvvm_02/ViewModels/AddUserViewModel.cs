using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpfmvvm_02.Commands;
using Wpfmvvm_02.Models;

namespace Wpfmvvm_02.ViewModels
{
    public class AddUserViewModel
    {

        public ICommand AddUserCommand { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public AddUserViewModel()
        {
            AddUserCommand = new RelayCommand(AddUser, CanAddUser);

        }

        private bool CanAddUser(object obj)
        {
            return true;
        }

        private void AddUser(object obj)
        {
            var user = new User() { Name = Name, Email = Email };
            if (!UserManager.DoesUserExist(user))
            {
                UserManager.AddUser(user);
            }
            else
            {
                MessageBox.Show("Sorry this user exist");
            }
            SqlConnection conn = Connection.Connection.newConnection();
            

        }
    }
}
