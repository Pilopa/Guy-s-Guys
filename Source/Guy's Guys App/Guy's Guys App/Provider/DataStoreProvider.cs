using Guys_Guys_App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guys_Guys_App.Utility;

namespace Guys_Guys_App.Provider
{
    class DataStoreProvider : DataStoreService
    {
        public DatabaseModel Context { get; set; }

        public DataStoreProvider()
        {
            Context = new DatabaseModel();
        }

        #region DataStoreService

        public DatabaseModel GetDataStoreContext()
        {
            return Context;
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
