using System;
using PawPaw.Core;
using PawPaw.Users;

namespace PawPaw
{
    public class WeightWriter
    {
        private readonly IWeightRepository _weightRepository;
        private readonly IUserContext _userContext;

        public WeightWriter(
            IWeightRepository weightRepository,
            IUserContext userContext)
        {
            _weightRepository = weightRepository;
            _userContext = userContext;
        }

        public int AddWeightToPost(int postId, int amount)
        {
            return AddWeightTo(postId, null, amount);
        }

        public int AddWeightToComment(int commentId, int amount)
        {
            return AddWeightTo(null, commentId, amount);
        }

        private int AddWeightTo(int? postId, int? commentId, int amount)
        {
            var weight = new Weight
            {
                Amount = amount,
                Created = DateTime.Now,
            };

            var user = _userContext.GetCurrentUser();

            return _weightRepository.Create(postId, commentId, weight, user.Id);
        }
    }
}
