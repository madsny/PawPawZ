using System.Web.Mvc;
using PawPaw.Core;

namespace PawPaw.DemoWeb.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly PostStreamReader _streamReader;

        public PostController(IPostRepository postRepository,PostStreamReader streamReader)
        {
            _postRepository = postRepository;
            _streamReader = streamReader;
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

        [Route("group/{groupId:int}/posts")]
        public ActionResult GetByGroup(int groupId)
        {
            var posts = _streamReader.GetPostByGroup(groupId);
            return PartialView("Index", posts);
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