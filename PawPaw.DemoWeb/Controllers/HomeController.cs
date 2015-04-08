using System.Web.Mvc;
using PawPaw.Data;
using PawPaw.DemoWeb.Settings;
using PawPaw.Posts;

namespace PawPaw.DemoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly PostRepository _postRepository;

        public HomeController()
        {
            _postRepository = new PostRepository(new AppConfiguration());
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(Post post)
        {
            var id = _postRepository.Create(post);
            return RedirectToAction("Post", new {Id = id});
        }

        public ActionResult Post(int id)
        {
            var post = _postRepository.Get(id);
            return View(post);
        }
    }
}
