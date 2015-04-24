using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using PawPaw.Data.Migrations;
using PawPaw.DemoWeb.DependencyResolution;
using PawPaw.DemoWeb.Settings;

namespace PawPaw.DemoWeb
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.EnsureInitialized();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DemoWebDependencyResolverModule.ConfigureContainer();

            var migrator = new Migrator(new AppConfiguration());
            migrator.MigrateToLatest();
        }
    }
}