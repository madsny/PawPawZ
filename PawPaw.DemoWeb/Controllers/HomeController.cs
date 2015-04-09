using System.Web.Mvc;
using PawPaw.DemoWeb.Models;

namespace PawPaw.DemoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly GroupReader _groupReader;
        private readonly PostStreamReader _postStreamReader;

        public HomeController(GroupReader groupReader, PostStreamReader postStreamReader)
        {
            _groupReader = groupReader;
            _postStreamReader = postStreamReader;
        }

        public ActionResult Index(int? groupId)
        {
            var groups = _groupReader.GetAll();
            var viewModel = new HomeViewModel {Groups = groups};
            if (groupId.HasValue)
            {
                viewModel.CurrentGroup = _groupReader.GetGroup(groupId.Value);
                viewModel.Posts = _postStreamReader.GetPostByGroup(groupId.Value);
            }
            
            return View(viewModel);
        }

    }
}
