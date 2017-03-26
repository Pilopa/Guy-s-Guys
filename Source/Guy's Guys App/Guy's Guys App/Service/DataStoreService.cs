using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guys_Guys_App.Service
{
    public interface DataStoreService : Guys_Guys_App.Utility.Service
    {
        DatabaseModel GetDataStoreContext();
    }
}
