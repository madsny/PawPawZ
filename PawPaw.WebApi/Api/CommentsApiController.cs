using System.Collections.Generic;
using System.Web.Http;
using PawPaw.Core;
using PawPaw.Web.Config;

namespace PawPaw.Web.Api
{
    [RoutePrefix(Constants.ApiPrefix)]
    public class CommentsApiController : ApiController
    {
        private readonly PostWriter _postWriter;
        private readonly PostStreamReader _postStreamReader;

        public CommentsApiController(
            PostWriter postWriter, 
            PostStreamReader postStreamReader)
        {
            _postWriter = postWriter;
            _postStreamReader = postStreamReader;
        }

        [Route("post/{postId:int}/comment")]
        public IEnumerable<Comment> GetByPost(int postId)
        {
            return _postStreamReader.GetComments(postId);
        }

        [HttpPost]
        [Route("post/{postId:int}/comment")]
        public void Create(int postId, Comment comment)
        {
            _postWriter.CreateComment(postId, comment);
        }
    }
}
