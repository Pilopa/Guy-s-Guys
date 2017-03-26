using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guys_Guys_App.Service
{
    interface PasswordService : Guys_Guys_App.Utility.Service
    {
        /// <summary>
        /// Encodes the given password for secure storage.
        /// </summary>
        /// <param name="password">The password to encode</param>
        /// <returns>The encoded password</returns>
        string Encode(string password);

        /// <summary>
        /// Encodes the provided password and compares it with the already
        /// encoded stored password.
        /// </summary>
        /// <param name="providedPassword">The password provided by the user</param>
        /// <param name="storedPassword">The encoded password retrieved from a data store</param>
        /// <returns>Whether the provided password matches the stored password.</returns>
        bool Verify(string providedPassword, string storedPassword);
    }
}
