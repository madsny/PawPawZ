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

        public ActionResult Index()
        {
            var groups = _groupRepository.GetAll();
            return View(groups);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Group group)
        {
            _groupRepository.Create(group);
            return RedirectToAction("Index");
        }

        public ActionResult Get(int id)
        {
            var group = _groupRepository.Get(id);
            return View(group);
        }
    }
}