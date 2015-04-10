using System.Collections.Generic;
using System.Linq;
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
            return _postRepository.GetByGroupId(groupId)
                .OrderByDescending(p => p.Modified ?? p.Created);
        }

        public Post GetPost(int postId)
        {
            return _postRepository.Get(postId);
        }

        public IEnumerable<Comment> GetComments(int postId)
        {
            return _commentRepository.GetByPost(postId)
                .OrderByDescending(c => c.Modified ?? c.Created);
        }
    }
}
