using Guys_Guys_App.Service;
using Guys_Guys_App.Utility;
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

namespace Guys_Guys_App.View.Control
{
    /// <summary>
    /// Interaction logic for MembershipBrowsingUserControl.xaml
    /// </summary>
    public partial class MembershipBrowsingUserControl : UserControl
    {
        public ServiceRegistry ServiceRegistry { get; private set; }

        public MembershipBrowsingUserControl(ServiceRegistry registry)
        {
            InitializeComponent();
            this.ServiceRegistry = registry;
            Refresh();
        }

        public async void Refresh()
        {
            var users = await ServiceRegistry.GetService<UserService>().GetUsers();
            lstbx_members.ItemsSource = users;
        }
    }
}
