using System.Collections.Generic;
using System.Web.Http;
using PawPaw.Core;
using PawPaw.Web.Config;

namespace PawPaw.Web.Api
{
    [RoutePrefix(Constants.ApiPrefix)]
    public class PostApiController : ApiController
    {
        private readonly PostWriter _postWriter;
        private readonly PostStreamReader _postStreamReader;

        public PostApiController(
            PostWriter postWriter, 
            PostStreamReader postStreamReader)
        {
            _postWriter = postWriter;
            _postStreamReader = postStreamReader;
        }

        [Route("post/{postId:int}")]
        public Post Get(int postId)
        {
            return _postStreamReader.GetPost(postId);
        }

        [Route("group/{groupId:int}/post")]
        public IEnumerable<Post> GetByGroupId(int groupId)
        {
            return _postStreamReader.GetPostByGroup(groupId);
        }

        [HttpPost]
        [Route("post")]
        public void CreateNew(Post post, int? groupId)
        {
            _postWriter.CreatePost(post.Body, groupId);
        }

    }
}
