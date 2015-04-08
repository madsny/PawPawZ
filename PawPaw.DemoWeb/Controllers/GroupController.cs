using System;
using System.Web.Mvc;
using PawPaw.Data;
using PawPaw.DemoWeb.Settings;
using PawPaw.Groups;

namespace PawPaw.DemoWeb.Controllers
{
    public class GroupController : Controller
    {
        private readonly GroupRepository _groupRepository;

        public GroupController()
        {
            _groupRepository = new GroupRepository(new AppConfiguration());
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