using Guys_Guys_App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guys_Guys_App.Utility;

namespace Guys_Guys_App.Provider
{
    public class DataStoreProvider : DataStoreService
    {

        #region DataStoreService

        public DatabaseModel GetDataStoreContext()
        {
            return new DatabaseModel();
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
