using System;
using System.Transactions;
using PawPaw.Core;

namespace PawPaw
{
    public class PostWriter
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;

        public PostWriter(IPostRepository postRepository, ICommentRepository commentRepository )
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }

        public int CreatePost(Post post, int? groupId)
        {
            post.Created = DateTime.Now;

            int postId;
            using (var transaction = new TransactionScope())
            {
                postId = _postRepository.Create(post);

                if (groupId.HasValue)
                {
                    _postRepository.AssociateWithGroup(postId, groupId.Value);
                }
                transaction.Complete();

            }
            return postId;
        }

        public void CreateComment(int postId, Comment comment)
        {
            comment.Created = DateTime.Now;
            _commentRepository.Create(postId, comment);
        }
    }
}
