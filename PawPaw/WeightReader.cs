using System.Collections.Generic;
using PawPaw.Core;

namespace PawPaw
{
    public class WeightReader 
    {
        private readonly IWeightRepository _weightRepository;

        public WeightReader(IWeightRepository weightRepository)
        {
            _weightRepository = weightRepository;
        }

        public IEnumerable<Weight> GetByPost(int postId)
        {
            return _weightRepository.GetByPost(postId);
        }

        public IEnumerable<Weight> GetByComment(int commentId)
        {
            return _weightRepository.GetByComment(commentId);
        }
    }
}
