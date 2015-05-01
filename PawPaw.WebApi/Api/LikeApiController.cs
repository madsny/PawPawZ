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

        [Route("post/{postId:int}/like")]
        public IEnumerable<Like> Get(int postId)
        {
            return _likeReader.GetLikesForPost(postId);
        }

        [Route("post/{postId:int}/like")]
        [HttpPost]
        public int AddLike(int postId)
        {
            return _likeWriter.AddLikeToPost(postId);
        }

    }
}
