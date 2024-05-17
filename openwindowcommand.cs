    public class Helper
    {

        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
                ? Application.Current.Windows.OfType<T>().Any()
                : Application.Current.Windows.OfType<T>().Any(x => x.Name.Equals(name));
        }

    }
// how to use it
 public class MainWindowVM
 {

     public ICommand CommandAddCustomer { get; private set; }
     

     public MainWindowVM()
     {
         CommandAddCustomer = new RelayCommand(OpenWindowAddCustomer);
     }

     private AddCustomerWindow _addCustomerWindow;
     private void OpenWindowAddCustomer()
     {
         if (!Helper.Helper.IsWindowOpen<AddCustomerWindow>())
         {
             _addCustomerWindow = new AddCustomerWindow();
             _addCustomerWindow.Show();
         }
         else
         {
             _addCustomerWindow.Topmost = true;
             _addCustomerWindow.Focus();
             _addCustomerWindow.Topmost = false; 
         }

     }
 }
