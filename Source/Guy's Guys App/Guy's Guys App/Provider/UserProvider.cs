using Guys_Guys_App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guys_Guys_App.Model;
using Guys_Guys_App.Utility;

namespace Guys_Guys_App.Provider
{
    class UserProvider : UserService
    {
        #region UserService

        public User GetUser(string username)
        {
            if (username.ToLower() == "admin")
            {
                return new User(username, "admin");
            } else
            {
                return null;
            }
        }

        #endregion

        #region Service

        public void onDeregistration(ServiceRegistry registry)
        {
            // Do nothing
        }

        public void onRegistration(ServiceRegistry registry)
        {
            // Do nothing
        }

        #endregion
    }
}
