using System.Collections.Generic;

namespace PawPaw.Core
{
    public interface IWeightRepository
    {
        IEnumerable<Weight> GetByPost(int postId);
        IEnumerable<Weight> GetByComment(int commentId);
        int Create(int? postId, int? commentId, Weight weight, int userId);
    }
}