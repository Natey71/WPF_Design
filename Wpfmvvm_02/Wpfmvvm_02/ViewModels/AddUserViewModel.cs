using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            UserManager.AddUser(new User() { Name = Name, Email = Email });
            SqlConnection conn = Connection.Connection.newConnection();
            

        }
    }
}
