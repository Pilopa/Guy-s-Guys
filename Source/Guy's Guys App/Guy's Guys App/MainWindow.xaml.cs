using Guys_Guys_App.Provider;
using Guys_Guys_App.Service;
using Guys_Guys_App.Utility;
using Guys_Guys_App.View.Control;
using System;
using System.Collections.Generic;
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

namespace Guys_Guys_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public LoginUserControl LoginUserControl { get; private set; }
        public ServiceRegistry ServiceRegistry { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            // Initialize service registry
            ServiceRegistry = new ServiceRegistry();

            // Initialize services
            ServiceRegistry.Register(new DataStoreProvider());
            ServiceRegistry.Register(new UserProvider(ServiceRegistry.GetService<DataStoreService>()));
            ServiceRegistry.Register(new PasswordProvider());
            ServiceRegistry.Register(new LoginProvider(ServiceRegistry.GetService<UserService>(), ServiceRegistry.GetService<PasswordService>()));

            // Initialize view components
            LoginUserControl = new LoginUserControl(ServiceRegistry);

            // Define initial view
            ChangePage(LoginUserControl);
        }

        public void ChangePage(UserControl page)
        {
            if (page == null)
                ContentHolder.Content = LoginUserControl;
            else
                ContentHolder.Content = page;
        }
    }
}
