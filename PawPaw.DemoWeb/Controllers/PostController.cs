using System.Web.Mvc;
using PawPaw.Core;
using PawPaw.DemoWeb.Models;

namespace PawPaw.DemoWeb.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly PostStreamReader _streamReader;
        private readonly PostWriter _postWriter;

        public PostController(IPostRepository postRepository, PostStreamReader streamReader, PostWriter postWriter)
        {
            _postRepository = postRepository;
            _streamReader = streamReader;
            _postWriter = postWriter;
        }

        public ActionResult Index()
        {
            var posts = _postRepository.GetAll();
            return View(new PostListingViewModel(posts));
        }


        [Route("group/{groupId:int}/posts")]
        public ActionResult GetByGroup(int groupId)
        {
            var posts = _streamReader.GetPostByGroup(groupId);
            return PartialView("Index", new PostListingViewModel(posts, groupId));
        }

        public ActionResult New(int? groupId)
        {
            return PartialView(new CreatePostViewModel { GroupId = groupId });
        }

        [HttpPost]
        public ActionResult New(Post post, int? groupId)
        {
            var id = groupId.HasValue ? _postWriter.CreatePost(post, groupId.Value) : _postRepository.Create(post);
            return RedirectToAction("Get", new { Id = id });
        }

        public ActionResult Get(int id)
        {
            var post = _postRepository.Get(id);
            return View(post);
        }
    }
}