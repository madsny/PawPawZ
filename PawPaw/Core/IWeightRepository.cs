using System.Collections.Generic;

namespace PawPaw.Core
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetByPost(int postId);
        Comment GetById(int commentId);
        int Create(int postId, Comment comment, int userId);
    }
}