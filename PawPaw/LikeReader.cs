using System.Collections.Generic;
using System.Linq;
using PawPaw.Core;

namespace PawPaw
{
    public class LikeReader
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
            return new Like
            {
                Created = weight.Created,
                CreatedBy = weight.CreatedBy,
                Id = weight.Id,
                Modified = weight.Modified
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
    }
}
