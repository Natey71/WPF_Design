﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents.Serialization;
using System.Windows.Input;
using Wpfmvvm_02.Commands;
using Wpfmvvm_02.Models;
using Wpfmvvm_02.Views;

namespace Wpfmvvm_02.ViewModels
{
    public class MainWindowViewModel
    {

        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Items> Items { get; set; }
        public ICommand ShowButtonWindowCommand { get; set; }   

        public MainWindowViewModel()
        {
            Users = new ObservableCollection<User>();
            Users = UserManager.GetUsers();
            ShowButtonWindowCommand = new OpenWindowCommand(typeof(HelpWindow));
        
        }




    }
}
