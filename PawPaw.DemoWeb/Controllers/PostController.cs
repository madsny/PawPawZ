using System.Web.Mvc;
using PawPaw.Core;
using PawPaw.Readers;
using PawPaw.Writers;

namespace PawPaw.DemoWeb.Controllers
{
    public class PostController : Controller
    {
        private readonly PostWriter _postWriter;
        private readonly PostStreamReader _postStreamReader;

        public PostController(PostWriter postWriter, PostStreamReader postStreamReader)
        {
            _postWriter = postWriter;
            _postStreamReader = postStreamReader;
        }


        [HttpPost]
        public ActionResult Index(Post post, int? groupId)
        {
            var id = _postWriter.CreatePost(post.Body, groupId);
            return RedirectToAction("Get", new { Id = id });
        }

        public ActionResult Get(int id)
        {
            var post = _postStreamReader.GetPost(id);
            return View(post);
        }
    }
}