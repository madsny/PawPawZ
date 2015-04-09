using System.Web.Mvc;
using PawPaw.Core;
using PawPaw.DemoWeb.Models;

namespace PawPaw.DemoWeb.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [Route("post/{postId:int}/comment")]
        public ActionResult GetByPost(int postId)
        {
            var comments = _commentRepository.GetByPost(postId);
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
            _commentRepository.Create(postId, comment);
            return RedirectToAction("Get", "Post", new{Id=postId});
        }
    }
}