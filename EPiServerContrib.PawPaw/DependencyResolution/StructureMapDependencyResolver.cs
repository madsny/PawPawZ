using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StructureMap;

namespace EPiServerContrib.PawPaw.DependencyResolution
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        private readonly IContainer container;

        public StructureMapDependencyResolver(IContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.IsInterface || serviceType.IsAbstract)
                return GetInterfaceService(serviceType);

            return GetConcreteService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.GetAllInstances(serviceType).Cast<object>();
        }

        private object GetConcreteService(Type serviceType)
        {
            return container.GetInstance(serviceType);
        }

        private object GetInterfaceService(Type serviceType)
        {
            return container.TryGetInstance(serviceType);
        }
    }
}