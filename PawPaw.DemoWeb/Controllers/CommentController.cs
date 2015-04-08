using System.Web.Mvc;
using PawPaw.Comments;
using PawPaw.Data;
using PawPaw.DemoWeb.Models;
using PawPaw.DemoWeb.Settings;

namespace PawPaw.DemoWeb.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentRepository _commentRepository;

        public CommentController()
        {
            _commentRepository = new CommentRepository(new AppConfiguration());
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