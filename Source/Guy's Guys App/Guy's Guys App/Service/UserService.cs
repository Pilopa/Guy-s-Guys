using Guys_Guys_App.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guys_Guys_App.Service
{
    interface UserService : Guys_Guys_App.Utility.Service
    {
        /// <summary>
        /// Retrieves the user from an underlying data store and returns it, if possible.
        /// Otherwise returns null. Throws an exception if there is a problem with the underlying
        /// data store.
        /// </summary>
        /// <param name="username">The username of the user to look up.</param>
        /// <returns>The user or null, if there is no user with the given username.</returns>
        User GetUser(string username);

        /// <summary>
        /// Returns a list of all users.
        /// </summary>
        /// <returns>A list of all users</returns>
        Task<List<User>> GetUsers();
    }
}
