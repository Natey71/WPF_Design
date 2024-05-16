using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wpfmvvm_02.ViewModels.Button1_5
{
    public class LoadFileDataGridVM:ViewModelBase
    {

        public ICommand LoadFileCommand { get; set; }

        private int _progressValue { get; set; }
        public int ProgressValue 
        {
            
            get { return _progressValue; }
            set
            {
                _progressValue = value;
                OnPropertyChanged(nameof(ProgressValue));
            }
        }
        public int ProgressMax { get; set; }

        public LoadFileDataGridVM()
        {


        }

        private async void loadFileintoDataGrid(string filepath)
        {
            
        }


    }
}
