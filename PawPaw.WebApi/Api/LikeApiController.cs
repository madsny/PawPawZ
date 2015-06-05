using System.Collections.Generic;
using System.Web.Http;
using PawPaw.Core;
using PawPaw.Web.Config;

namespace PawPaw.WebApi.Api
{
    [RoutePrefix(Constants.ApiPrefix)]
    public class LikeApiController : ApiController
    {
        private readonly LikeWriter _likeWriter;
        private readonly LikeReader _likeReader;

        public LikeApiController(
            LikeWriter likeWriter, 
            LikeReader likeReader)
        {
            _likeWriter = likeWriter;
            _likeReader = likeReader;
        }

        [Route("posts/{postId:int}/likes")]
        public IEnumerable<Like> Get(int postId)
        {
            return _likeReader.GetLikesForPost(postId);
        }

        [Route("posts/{postId:int}/likes")]
        [HttpPost]
        public int AddLike(int postId)
        {
            return _likeWriter.AddLikeToPost(postId);
        }

    }
}
