using Guys_Guys_App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guys_Guys_App.Utility;

namespace Guys_Guys_App.Provider
{
    public class PasswordProvider : PasswordService
    {
        #region PasswordService

        public string Encode(string password)
        {
            return password;
        }

        public bool Verify(string providedPassword, string storedPassword)
        {
            return Encode(providedPassword).Equals(storedPassword);
        }

        #endregion

        #region Service

        public void stop(ServiceRegistry registry)
        {
            // Do nothing
        }

        public void start(ServiceRegistry registry)
        {
            // Do nothing
        }

        #endregion
    }
}
