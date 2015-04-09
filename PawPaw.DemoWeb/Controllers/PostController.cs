using System.Web.Mvc;
using PawPaw.Core;

namespace PawPaw.DemoWeb.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
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