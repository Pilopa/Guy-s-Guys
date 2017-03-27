using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guys_Guys_App.Service;
using Guys_Guys_App.Model.Entity;
using Guys_Guys_App.Model.Exception;
using Guys_Guys_App.Utility;

namespace Guys_Guys_App.Provider
{
    public class LoginProvider : LoginService
    {
        private UserService UserService { get; set; }
        private PasswordService PasswordService { get; set; }
        private User ActiveUser { get; set; }

        public LoginProvider(UserService userService, PasswordService passwordService)
        {
            this.UserService = userService;
            this.PasswordService = passwordService;
        }

        #region LoginService

        public User Login(string username, string password)
        {
            // Check if the user is already logged in
            if (ActiveUser != null) return ActiveUser;

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
                    ActiveUser = loginUser;
                    return ActiveUser;
                } else
                {
                    throw new IncorrectPasswordException();
                }
            } else
            {
                throw new UserNotFoundException();
            }
        }

        public User GetActiveUser()
        {
            return ActiveUser;
        }

        #endregion

        #region Service

        public void start(ServiceRegistry registry)
        {
            // Do nothing
        }

        public void stop(ServiceRegistry registry)
        {
            // Do nothing
        }

        #endregion
    }
}
