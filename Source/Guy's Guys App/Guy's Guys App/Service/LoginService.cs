using Guys_Guys_App.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guys_Guys_App.Service
{

    interface LoginService : Guys_Guys_App.Utility.Service
    {
        /// <summary>
        /// Attempts to log in the user with the given credentials.
        /// Returns the user object after a successful login, throws
        /// an appropriate exception if login fails.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>The user object on successful login</returns>
        /// <see cref="LoginException"/>
        User Login(string username, string password);
    }
}
