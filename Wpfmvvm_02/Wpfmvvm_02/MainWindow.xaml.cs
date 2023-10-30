using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpfmvvm_02.Models;
using Wpfmvvm_02.ViewModels;

namespace Wpfmvvm_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel mainview;
        public MainWindow()
        {
            InitializeComponent();
            ViewModels.MainWindowViewModel mainViewModel = new ViewModels.MainWindowViewModel();
            this.DataContext = mainViewModel;
        }
        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserList.Items.Filter = FilterMethod;

        }

        private bool FilterMethod(object obj)
        {
            var item = (Items)obj;

            return item.Color1.Contains(FilterTextBox.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            writejson();
        }

        public void writejson()
        {
            string json = JsonConvert.SerializeObject(mainview.Users);
            string file = @"C:\\Users\mende\vsCode\JSON\user.json";

            using (var item = new StreamWriter(file, true))
            {
                item.WriteLine(json.ToString());
                item.Close();
            }
        }

    }
}
