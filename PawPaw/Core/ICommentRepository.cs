using System.Collections.Generic;

namespace PawPaw.Core
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetByPost(int postId);
        int Create(int postId, Comment comment);
    }
}
