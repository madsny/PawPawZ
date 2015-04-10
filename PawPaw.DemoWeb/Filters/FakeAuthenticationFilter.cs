using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PawPaw.DemoWeb.Filters
{
    public class FakeAuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session == null || HttpContext.Current.Session["username"] == null && filterContext.ActionDescriptor.ControllerDescriptor.ControllerName != "LogIn")
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller", "LogIn"},
                        {"action", "Index"}
                    });
            }

            base.OnActionExecuting(filterContext);
        }
    }
}