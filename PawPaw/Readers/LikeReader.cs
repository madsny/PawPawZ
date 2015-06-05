using System.Collections.Generic;
using System.Linq;
using PawPaw.Core;

namespace PawPaw.Readers
{
    public class LikeReader : ReaderBase
    {
        private readonly WeightReader _weightReader;

        public LikeReader(WeightReader weightReader)
        {
            _weightReader = weightReader;
        }

        public IEnumerable<Like> GetLikesForPost(int postId)
        {
            return _weightReader.GetByPost(postId).Where(w => w.Amount > 0).Select(ConvertToLike);
        }

        public IEnumerable<Like> GetLikesForComment(int commentId)
        {
            return _weightReader.GetByComment(commentId).Where(w => w.Amount > 0).Select(ConvertToLike);
        }

        private static Like ConvertToLike(Weight weight)
        {
            if (weight == null) 
                return null;

            return new Like
            {
                Created = weight.Created,
                CreatedBy = weight.CreatedBy,
                Id = weight.Id,
            };
        }

        public int GetLikeCountForPost(int postId)
        {
            return _weightReader.GetByPost(postId).Count(w => w.Amount > 0);
        }

        public int GetLikeCountForComment(int commentId)
        {
            return _weightReader.GetByComment(commentId).Count(w => w.Amount > 0);
        }

        public Like GetLikeById(int likeId)
        {
            return ConvertToLike(_weightReader.GetWeightById(likeId));
        }

        public override SocialContentBase GetById(int id)
        {
            return GetLikeById(id);
        }
    }
}
