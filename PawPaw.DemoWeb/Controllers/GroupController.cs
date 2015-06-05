using System.Web.Mvc;
using PawPaw.Core;
using PawPaw.Writers;

namespace PawPaw.DemoWeb.Controllers
{
    public class GroupController : Controller
    {
        private readonly GroupWriter _groupWriter;

        public GroupController(GroupWriter groupWriter)
        {
            _groupWriter = groupWriter;
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Group group)
        {
            var id = _groupWriter.Create(group);
            return RedirectToAction("Index", "Home", new {GroupId= id});
        }
    }
}