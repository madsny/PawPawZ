using System.Web;
using System.Web.Mvc;
using PawPaw.DemoWeb.Filters;

namespace PawPaw.DemoWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new FakeAuthenticationFilter());
        }
    }
}