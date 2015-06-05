using System.Collections.Generic;
using System.Web.Http;
using PawPaw.Core;
using PawPaw.Readers;
using PawPaw.Users;
using PawPaw.Web.Config;
using PawPaw.Writers;

namespace PawPaw.WebApi.Api
{
    [RoutePrefix(Constants.ApiPrefix)]
    public class CommentsApiController : ApiControllerBase
    {
        private readonly PostWriter _postWriter;
        private readonly PostStreamReader _postStreamReader;
        private readonly CommentReader _commentReader;

        public CommentsApiController(
            PostWriter postWriter, 
            PostStreamReader postStreamReader,
            IUserContext userContext, 
            CommentReader commentReader) : base(userContext)
        {
            _postWriter = postWriter;
            _postStreamReader = postStreamReader;
            _commentReader = commentReader;
        }

        [Route("posts/{postId:int}/comments")]
        public IEnumerable<Comment> GetByPost(int postId)
        {
            return _postStreamReader.GetComments(postId);
        }

        [Route("posts/{postId:int}/comments/{commentId:int}")]
        public Comment GetById(int postId, int commentId)
        {
            return _commentReader.GetCommentById(commentId);
        }

        [HttpPost]
        [Route("posts/{postId:int}/comments")]
        public int Create(int postId, Comment comment)
        {
            return _postWriter.CreateComment(postId, comment);
        }
    }
}
