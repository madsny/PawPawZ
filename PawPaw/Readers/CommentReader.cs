using PawPaw.Core;

namespace PawPaw.Readers
{
    public class CommentReader : ReaderBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentReader(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public Comment GetCommentById(int commentId)
        {
            return _commentRepository.GetById(commentId);
        }

        public override SocialContentBase GetById(int id)
        {
            return GetCommentById(id);
        }
    }
}
