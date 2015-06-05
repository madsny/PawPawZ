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
    public class LikeApiController : ApiControllerBase
    {
        private readonly LikeWriter _likeWriter;
        private readonly LikeReader _likeReader;

        public LikeApiController(
            LikeWriter likeWriter, 
            LikeReader likeReader, 
            IUserContext userContext) : base(userContext)
        {
            _likeWriter = likeWriter;
            _likeReader = likeReader;
        }

        #region Get

        [Route("posts/{postId:int}/likes")]
        public IEnumerable<Like> GetForPost(int postId)
        {
            return _likeReader.GetLikesForPost(postId);
        }

        [Route("posts/{postId:int}/comments/{commentId:int}/likes")]
        public IEnumerable<Like> GetForComment(int postId, int commentId)
        {
            return _likeReader.GetLikesForComment(commentId);
        }

        #endregion

        #region Post

        [Route("posts/{postId:int}/likes")]
        [HttpPost]
        public int AddLikeToPost(int postId)
        {
            return _likeWriter.AddLikeToPost(postId);
        }

        [Route("posts/{postId:int}/comments/{commentId:int}/likes")]
        [HttpPost]
        public int AddLikeToComment(int postId, int commentId)
        {
            return _likeWriter.AddLikeToComment(commentId);
        }

        #endregion

        #region Delete

        [Route("posts/{postId:int}/likes/{likeId:int}")]
        [HttpDelete]
        public void RemoveLikeFromPost(int postId, int likeId)
        {
            CheckPermission(_likeReader, likeId);

            _likeWriter.RemoveLikeFromPost(likeId);
        }

        [Route("posts/{postId:int}/comments/{commentId:int}/likes/{likeId:int}")]
        [HttpDelete]
        public void RemoveLikeFromComment(int postId, int commentId, int likeId)
        {
            CheckPermission(_likeReader, likeId);

            _likeWriter.RemoveLikeFromPost(likeId);
        }

        #endregion
    }
}
