using System.Web.Mvc;
using PawPaw.DemoWeb.Models;
using PawPaw.Users;

namespace PawPaw.DemoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly GroupReader _groupReader;
        private readonly PostStreamReader _postStreamReader;
        private readonly IUserContext _userContext;

        public HomeController(GroupReader groupReader, PostStreamReader postStreamReader, IUserContext userContext)
        {
            _groupReader = groupReader;
            _postStreamReader = postStreamReader;
            _userContext = userContext;
        }

        public ActionResult Index(int? groupId)
        {
            var user = _userContext.GetCurrentUser();
            var groups = _groupReader.GetAll();
            var viewModel = new HomeViewModel { Groups = groups, User = user };
            if (groupId.HasValue)
            {
                viewModel.CurrentGroup = _groupReader.GetGroup(groupId.Value);
                viewModel.Posts = _postStreamReader.GetPostByGroup(groupId.Value);
            }
            
            return View(viewModel);
        }

    }
}
