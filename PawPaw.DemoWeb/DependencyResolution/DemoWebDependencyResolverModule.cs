using System.Web.Mvc;
using BI.NO.Web.DependencyResolution;
using PawPaw.DemoWeb.Settings;
using StructureMap;
using StructureMapContrib.PawPaw;

namespace PawPaw.DemoWeb.DependencyResolution
{
    public class DemoWebDependencyResolverModule
    {
        public static void ConfigureContainer()
        {
            var container = ObjectFactory.Container;
            container.Configure(ConfigureContainer);
            var resolver = new StructureMapDependencyResolver(container);

            DependencyResolver.SetResolver(resolver);
        }

        private static void ConfigureContainer(ConfigurationExpression container)
        {
            container.AddRegistry<DemoWebRegistry>();
            container.AddRegistry(new PawPawRegistry(new AppConfiguration(), new FakeAuthIdentityContext()));
        }
    }
}