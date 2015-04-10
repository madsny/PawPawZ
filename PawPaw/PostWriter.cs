using System;
using System.Transactions;
using PawPaw.Core;
using PawPaw.Users;

namespace PawPaw
{
    public class PostWriter
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IUserContext _userContext;

        public PostWriter(IPostRepository postRepository, ICommentRepository commentRepository, IUserContext userContext )
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
            _userContext = userContext;
        }

        public int CreatePost(string body, int? groupId = null, string externalId = null)
        {
            var post = new Post {Created = DateTime.Now};

            var user = _userContext.GetCurrentUser();

            int postId;
            using (var transaction = new TransactionScope())
            {
                postId = _postRepository.Create(post, user.Id);

                if (groupId.HasValue)
                {
                    _postRepository.AssociateWithGroup(postId, groupId.Value);
                }
                if (!string.IsNullOrWhiteSpace(externalId))
                {
                    _postRepository.AssociateWithExternalId(postId, externalId);
                }
                transaction.Complete();

            }
            return postId;
        }

        public void CreateComment(int postId, Comment comment)
        {
            var user = _userContext.GetCurrentUser();
            comment.Created = DateTime.Now;
            _commentRepository.Create(postId, comment, user.Id);
        }
    }
}
