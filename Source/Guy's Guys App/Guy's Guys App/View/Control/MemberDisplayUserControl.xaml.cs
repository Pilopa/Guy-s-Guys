using Guys_Guys_App.Model.Entity;
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
    /// Interaction logic for MemberDisplayUserControl.xaml
    /// </summary>
    public partial class MemberDisplayUserControl : UserControl
    {
        public ServiceRegistry ServiceRegistry { get; private set; }
        public User Displayed { get; private set; }

        public MemberDisplayUserControl(ServiceRegistry registry, User toDisplay)
        {
            InitializeComponent();
            this.ServiceRegistry = registry;
            this.Displayed = toDisplay;
            Refresh();
        }

        public void Refresh()
        {
            this.txtbx_id.Text = Displayed.Id.ToString();
            this.txtbx_name.Text = Displayed.Name;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).ChangePage(new MembershipBrowsingUserControl(ServiceRegistry));
        }
    }
}
