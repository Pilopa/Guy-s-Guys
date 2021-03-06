﻿using Guys_Guys_App.Model.Entity;
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

        public void Refresh()
        {
            lstbx_members.ItemsSource = ServiceRegistry.GetService<UserService>().GetUsers();
        }

        private void lstbx_members_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selection = lstbx_members.SelectedItem;

            if (selection != null)
            {
                ((MainWindow)Window.GetWindow(this)).ChangePage(new MemberDisplayUserControl(ServiceRegistry, (User) selection));
            }
        }
    }
}
