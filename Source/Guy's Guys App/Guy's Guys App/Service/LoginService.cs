using Guys_Guys_App.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guys_Guys_App.Service
{

    public interface LoginService : Guys_Guys_App.Utility.Service
    {
        /// <summary>
        /// Attempts to log in the user with the given credentials.
        /// Returns the user object after a successful login, throws
        /// an appropriate exception if login fails. If the user is already logged in,
        /// it returns <code><see cref="GetActiveUser"/></code>.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>The user object on successful login</returns>
        /// <see cref="LoginException"/>
        User Login(string username, string password);

        /// <summary>
        /// Returns the currently active user. Returns null if no user is currently logged in.
        /// </summary>
        /// <returns>The active user or null</returns>
        User GetActiveUser();
    }
}
