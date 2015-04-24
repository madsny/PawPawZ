using System.Web.Http;
using PawPaw.DemoWeb.Settings;
using PawPaw.Web.Config;

namespace PawPaw.DemoWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            PawPawWebConfig.Configure(config, new AppConfiguration(), new FakeAuthIdentityContext());
        }
    } 
}