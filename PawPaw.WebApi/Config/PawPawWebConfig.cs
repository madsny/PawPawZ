using System.Web.Http;
using System.Web.Http.Dispatcher;
using PawPaw.Data;
using PawPaw.Users;
using PawPaw.Web.DependencyResolution;

namespace PawPaw.Web.Config
{
    public static class PawPawWebConfig
    {
        public static void Configure(
            HttpConfiguration config, 
            IDataSettings dataSettings, 
            IIdentityContext identityContext)
        {
            PawPawWebDependencyResolverModule.ConfigureContainer(dataSettings, identityContext);
            Register(config);
        }

        private static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Services.Replace(typeof(IHttpControllerActivator), new ServiceActivator(config));
        }
    }
}