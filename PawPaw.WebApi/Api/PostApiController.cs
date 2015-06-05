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
    public class PostApiController : ApiControllerBase
    {
        private readonly PostWriter _postWriter;
        private readonly PostStreamReader _postStreamReader;

        public PostApiController(
            PostWriter postWriter, 
            PostStreamReader postStreamReader,
            IUserContext userContext) : base(userContext)
        {
            _postWriter = postWriter;
            _postStreamReader = postStreamReader;
        }

        [Route("posts/{postId:int}")]
        public Post Get(int postId)
        {
            return _postStreamReader.GetPost(postId);
        }

        [Route("groups/{groupId:int}/posts")]
        public IEnumerable<Post> GetByGroupId(int groupId)
        {
            return _postStreamReader.GetPostByGroup(groupId);
        }

        [HttpPost]
        [Route("posts")]
        public void CreateNew(Post post, int? groupId)
        {
            _postWriter.CreatePost(post.Body, groupId);
        }

    }
}
