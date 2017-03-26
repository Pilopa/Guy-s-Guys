using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guys_Guys_App.Utility
{
    public interface Service
    {
        void onRegistration(ServiceRegistry registry);
        void onDeregistration(ServiceRegistry registry);
    }
}
