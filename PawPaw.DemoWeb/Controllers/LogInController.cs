using System.Web.Mvc;

namespace PawPaw.DemoWeb.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string username)
        {
            System.Web.HttpContext.Current.Session["username"] = username;

            return RedirectToAction("Index", "Home");
        }
    }
}