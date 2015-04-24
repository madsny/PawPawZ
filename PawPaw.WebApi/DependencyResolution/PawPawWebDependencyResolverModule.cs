using PawPaw.Data;
using PawPaw.Users;
using StructureMap;
using StructureMapContrib.PawPaw;

namespace PawPaw.Web.DependencyResolution
{
    public class PawPawWebDependencyResolverModule
    {
        public static void ConfigureContainer(
            IDataSettings dataSettings,
            IIdentityContext identityContext)
        {
            var container = ObjectFactory.Container;
            container.Configure(expression => 
                ConfigureContainer(expression, dataSettings, identityContext));
        }

        private static void ConfigureContainer(
            ConfigurationExpression container, 
            IDataSettings dataSettings,
            IIdentityContext identityContext)
        {
            container.AddRegistry(new PawPawRegistry(dataSettings, identityContext));
        }
    }
}