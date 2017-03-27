using Guys_Guys_App.Model.Entity;
using Guys_Guys_App.Model.Exception;
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
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        public ServiceRegistry ServiceRegistry { get; private set; }

        public LoginUserControl(ServiceRegistry registry)
        {
            InitializeComponent();
            this.ServiceRegistry = registry;
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            var username = this.txtbx_username.Text;
            var password = this.pwbx_password.Password;

            if (username.Length < 4)
            {
                MessageBox.Show("The username has to be at least 4 characters long!");
            }
            else if (password.Length < 4)
            {
                MessageBox.Show("The password has to be at least 4 characters long!");
            }
            else
            {
                var loginService = ServiceRegistry.GetService<LoginService>();

                if (loginService != null)
                {
                    try
                    {
                        loginService.Login(username, password);
                        ((MainWindow)Window.GetWindow(this)).ChangePage(new MembershipBrowsingUserControl(ServiceRegistry));
                    }
                    catch (UserNotFoundException)
                    {
                        MessageBox.Show("The User has not been found!");
                    }
                    catch (IncorrectPasswordException)
                    {
                        MessageBox.Show("The password is incorrect!");
                    } catch (LoginException)
                    {
                        MessageBox.Show("An uknown login error occurred!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The Login Service is not available!");
                }
            }
        }
    }
}
