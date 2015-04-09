using System.Web.Mvc;
using PawPaw.Core;
using PawPaw.DemoWeb.Models;

namespace PawPaw.DemoWeb.Controllers
{
    public class CommentController : Controller
    {
        private readonly PostWriter _postWriter;
        private readonly PostStreamReader _postStreamReader;

        public CommentController(PostWriter postWriter, PostStreamReader postStreamReader)
        {
            _postWriter = postWriter;
            _postStreamReader = postStreamReader;
        }

        [Route("post/{postId:int}/comment")]
        public ActionResult GetByPost(int postId)
        {
            var comments = _postStreamReader.GetComments(postId);
            return PartialView(comments);
        }

        [Route("post/{postId:int}/comment/new")]
        public ActionResult New(int postId)
        {
            return PartialView(new CreateCommentViewModel(postId));
        }

        [HttpPost]
        [Route("post/{postId:int}/comment")]
        public ActionResult Create(int postId, Comment comment)
        {
            _postWriter.CreateComment(postId, comment);
            return RedirectToAction("Get", "Post", new{Id=postId});
        }
    }
}