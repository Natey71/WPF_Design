using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Wpfmvvm_02.Commands
{
    public class OpenWindowCommand : ICommand
    {
        private Type _windowType;
        private List<Window> _openWindows = new List<Window>();
        public event EventHandler CanExecuteChanged;

        public OpenWindowCommand(Type windowType)
        {
            _windowType = windowType ?? throw new ArgumentNullException(nameof(windowType));
        }

        public bool CanExecute(object parameter)
        {
            return true; // You can add conditions here if needed
        }

        public void Execute(object parameter)
        {
            if (parameter is Window window)
            {
                if (_openWindows.Any(w => w.GetType() == _windowType))
                {
                    // Window of this type is already open
                    MessageBox.Show(String.Format("The Window {0} is already open", _windowType.Name), "Window", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Window newWindow = (Window)Activator.CreateInstance(_windowType);
                newWindow.Owner = window;
                newWindow.Closed += (sender, e) => _openWindows.Remove(newWindow);
                _openWindows.Add(newWindow);

                newWindow.Show();
            }
        }
    }
}
