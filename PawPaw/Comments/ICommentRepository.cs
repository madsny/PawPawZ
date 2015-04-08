using System.Collections.Generic;

namespace PawPaw.Comments
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetByPost(int postId);
        int Create(int postId, Comment comment);
    }
}
