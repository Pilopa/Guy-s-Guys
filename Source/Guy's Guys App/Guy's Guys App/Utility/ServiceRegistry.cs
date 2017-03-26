using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guys_Guys_App.Utility
{
    public class ServiceRegistry
    {
        private Dictionary<string, HashSet<Service>> Services { get; set; } = new Dictionary<string, HashSet<Service>>();

        /// <summary>
        /// Registeres the given provider under all services it implements.
        /// If this provider has not been registered at all before, its
        /// <code><see cref="Service.onRegistration(ServiceRegistry)"/></code> method will be called.
        /// </summary>
        /// <param name="provider">The provider to register</param>
        public void Register(Service provider)
        {
            bool isNew = false;

            // Register types
            foreach (Type interfaceType in provider.GetType().GetInterfaces())
            {
                var serviceName = interfaceType.Name;
                HashSet<Service> services;
                if (Services.TryGetValue(serviceName, out services))
                {
                    if (!services.Contains(provider))
                    {
                        isNew = true;
                        services.Add(provider);
                    }
                } else
                {
                    services = new HashSet<Service>();
                    services.Add(provider);
                    isNew = true;
                    Services.Add(serviceName, services);
                }
            }

            if (isNew)
            {
                // Call registration event
                provider.onRegistration(this);
            }
        }

        /// <summary>
        /// Deregisteres the given provider from all services it implements.
        /// If this provider has been actually registered, its
        /// <code><see cref="Service.onDeregistration(ServiceRegistry)"/></code> method will be called.
        /// </summary>
        /// <param name="provider">The provider to register</param>
        public void Deregister(Service provider)
        {
            bool existed = false;

            // Register types
            foreach (Type interfaceType in provider.GetType().GetInterfaces())
            {
                var serviceName = interfaceType.Name;
                HashSet<Service> services;
                if (Services.TryGetValue(serviceName, out services))
                {
                    if (services.Contains(provider))
                    {
                        existed = true;
                        services.Remove(provider);
                    }
                }
            }

            if (existed)
            {
                // Call registration event
                provider.onDeregistration(this);
            }
        }

        /// <summary>
        /// Returns a registered service provider that matches the desired type.
        /// No statement can be made which exact provider instance is returned.
        /// </summary>
        /// <typeparam name="T">The type of service to retrieve</typeparam>
        /// <returns>The service or null</returns>
        public T GetService<T>() where T : Service
        {
            HashSet<Service> services;
            if(Services.TryGetValue(typeof(T).Name, out services))
            {
                if (services.Count > 0)
                {
                    var service = services.First();
                    if (typeof(T).IsAssignableFrom(service.GetType()))
                    {
                        return (T) service;
                    } else
                    {
                        return default(T);
                    }
                } else
                {
                    return default(T);
                }
            } else
            {
                return default(T);
            }
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Services.Select(kvp => kvp.Key + ": [" + String.Join(", ", kvp.Value) + "]"));
        }
    }
}
