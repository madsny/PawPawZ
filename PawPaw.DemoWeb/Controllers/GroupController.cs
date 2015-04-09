using System.Web.Mvc;
using PawPaw.Core;

namespace PawPaw.DemoWeb.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupRepository _groupRepository;

        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Group group)
        {
            var id = _groupRepository.Create(group);
            return RedirectToAction("Index", "Home", new {GroupId= id});
        }

        public ActionResult Get(int id)
        {
            var group = _groupRepository.Get(id);
            return View(group);
        }
    }
}