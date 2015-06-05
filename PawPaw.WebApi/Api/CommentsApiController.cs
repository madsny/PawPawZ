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

        public CommentsApiController(
            PostWriter postWriter, 
            PostStreamReader postStreamReader,
            IUserContext userContext) : base(userContext)
        {
            _postWriter = postWriter;
            _postStreamReader = postStreamReader;
        }

        [Route("posts/{postId:int}/comments")]
        public IEnumerable<Comment> GetByPost(int postId)
        {
            return _postStreamReader.GetComments(postId);
        }

        [HttpPost]
        [Route("posts/{postId:int}/comments")]
        public void Create(int postId, Comment comment)
        {
            _postWriter.CreateComment(postId, comment);
        }
    }
}
