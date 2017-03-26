using Guys_Guys_App.Service;
using Guys_Guys_App.Model.Entity;
using Guys_Guys_App.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;

namespace Guys_Guys_App.Provider
{
    class UserProvider : UserService
    {

        public DataStoreService DataStoreService { get; private set; }

        public UserProvider(DataStoreService dataStoreService)
        {
            this.DataStoreService = dataStoreService;
        }

        #region UserService

        public User GetUser(string username)
        {
            using (var db = DataStoreService.GetDataStoreContext())
                return db
                    .Users
                    .Where(user => user.Name == username)
                    .FirstOrDefault();
        }

        public HashSet<User> GetUsers()
        {
            using (var db = DataStoreService.GetDataStoreContext())
                return new HashSet<User>(db.Users.ToList<User>());
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
