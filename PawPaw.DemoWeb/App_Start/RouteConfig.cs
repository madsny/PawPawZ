using System.Web.Mvc;
using System.Web.Routing;

namespace PawPaw.DemoWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Details",
                url: "{controller}/{id}",
                defaults: new {action = "Get"},
                constraints: new { id = @"\d+" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Group", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}