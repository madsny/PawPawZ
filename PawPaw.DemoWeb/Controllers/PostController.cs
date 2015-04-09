using System.Web.Mvc;
using PawPaw.Core;
using PawPaw.Data;
using PawPaw.DemoWeb.Settings;

namespace PawPaw.DemoWeb.Controllers
{
    public class PostController : Controller
    {
        private readonly PostRepository _postRepository;

        public PostController()
        {
            _postRepository = new PostRepository(new AppConfiguration());
        }

        public ActionResult Index()
        {
            var posts = _postRepository.GetAll();
            return View(posts);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Post post)
        {
            var id = _postRepository.Create(post);
            return RedirectToAction("Get", new { Id = id });
        }

        public ActionResult Get(int id)
        {
            var post = _postRepository.Get(id);
            return View(post);
        }
    }
}