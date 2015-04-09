using System.Collections.Generic;
using PawPaw.Core;

namespace PawPaw
{
    public class PostStreamReader
    {
        private readonly IPostRepository _postRepository;

        public PostStreamReader(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IEnumerable<Post> GetPostByGroup(int groupId)
        {
            return _postRepository.GetByGroupId(groupId);
        }

        public Post GetPost(int postId)
        {
            return _postRepository.Get(postId);
        }
    }
}
