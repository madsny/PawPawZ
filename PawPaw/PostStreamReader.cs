using System.Collections.Generic;
using PawPaw.Core;

namespace PawPaw
{
    public class PostStreamReader
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;

        public PostStreamReader(IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }

        public IEnumerable<Post> GetPostByGroup(int groupId)
        {
            return _postRepository.GetByGroupId(groupId);
        }

        public Post GetPost(int postId)
        {
            return _postRepository.Get(postId);
        }

        public IEnumerable<Comment> GetComments(int postId)
        {
            return _commentRepository.GetByPost(postId);
        }
    }
}
