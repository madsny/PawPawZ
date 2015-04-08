using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using PawPaw.Data.Migrations;
using PawPaw.DemoWeb.Settings;

namespace PawPaw.DemoWeb
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var migrator = new Migrator(new AppConfiguration());
            migrator.MigrateToLatest();
        }
    }
}