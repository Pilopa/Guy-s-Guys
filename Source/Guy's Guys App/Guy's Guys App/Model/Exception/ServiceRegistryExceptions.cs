using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guys_Guys_App.Model.Exception
{
    public class ServiceRegistryException : System.Exception
    {
        public ServiceRegistryException()
        {
        }

        public ServiceRegistryException(string message) : base(message)
        {
        }

        public ServiceRegistryException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }

    public class ServiceRegistrationException : ServiceRegistryException
    {
        public ServiceRegistrationException()
        {
        }

        public ServiceRegistrationException(string message) : base(message)
        {
        }

        public ServiceRegistrationException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }

    public class ServiceDeregistrationException : ServiceRegistryException
    {
        public ServiceDeregistrationException()
        {
        }

        public ServiceDeregistrationException(string message) : base(message)
        {
        }

        public ServiceDeregistrationException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}
