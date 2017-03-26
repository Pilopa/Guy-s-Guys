using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guys_Guys_App.Service;
using Guys_Guys_App.Model;
using Guys_Guys_App.Model.Exception;
using Guys_Guys_App.Utility;

namespace Guys_Guys_App.Provider
{
    class LoginProvider : LoginService
    {
        private UserService UserService { get; set; }
        private PasswordService PasswordService { get; set; }

        public LoginProvider(UserService userService, PasswordService passwordService)
        {
            this.UserService = userService;
            this.PasswordService = passwordService;
        }

        #region LoginService

        public User Login(string username, string password)
        {
            // Attempt to retrieve user from user service
            User loginUser = null;
            try
            {
                loginUser = UserService.GetUser(username);
            } catch (Exception e)
            {
                throw new LoginException(e.Message, e);
            }

            // Check if the user has been found
            if (loginUser != null)
            {
                // If yes, verify the password
                if(PasswordService.Verify(password, loginUser.Password)) {
                    return loginUser;
                } else
                {
                    throw new IncorrectPasswordException();
                }
            } else
            {
                throw new UserNotFoundException();
            }
        }

        #endregion

        #region Service

        public void onRegistration(ServiceRegistry registry)
        {
            // Do nothing
        }

        public void onDeregistration(ServiceRegistry registry)
        {
            // Do nothing
        }

        #endregion
    }
}
