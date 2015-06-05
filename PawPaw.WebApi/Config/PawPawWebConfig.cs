using System.Web.Http;
using System.Web.Http.Dispatcher;
using PawPaw.Data;
using PawPaw.Users;
using PawPaw.Web.DependencyResolution;

namespace PawPaw.WebApi.Config
{
    public static class PawPawWebConfig
    {
        public static HttpConfiguration Configure(
            HttpConfiguration config, 
            IDataSettings dataSettings, 
            IIdentityContext identityContext)
        {
            PawPawWebDependencyResolverModule.ConfigureContainer(dataSettings, identityContext);
            Register(config);
            return config;
        }

        private static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Services.Replace(typeof(IHttpControllerActivator), new ServiceActivator(config));
        }
    }
}