using System.Collections.Generic;
using PawPaw.Core;

namespace PawPaw.Readers
{
    public class WeightReader : ReaderBase
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

        public Weight GetWeightById(int weightId)
        {
            return _weightRepository.GetById(weightId);
        }

        public override SocialContentBase GetById(int id)
        {
            return GetWeightById(id);
        }
    }
}
