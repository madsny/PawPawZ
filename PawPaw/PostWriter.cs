using System.Transactions;
using PawPaw.Core;

namespace PawPaw
{
    public class PostWriter
    {
        private readonly IPostRepository _postRepository;
        private readonly IGroupRepository _groupRepository;

        public PostWriter(IPostRepository postRepository, IGroupRepository groupRepository)
        {
            _postRepository = postRepository;
            _groupRepository = groupRepository;
        }

        public int CreatePost(Post post, int groupId)
        {
            int postId;
            using (var transaction = new TransactionScope())
            {
                postId = _postRepository.Create(post);

                _postRepository.AssociateWithGroup(postId, groupId);
                transaction.Complete();

            }
            return postId;
        }

    }
}
