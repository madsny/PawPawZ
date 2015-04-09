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

        public int CreatePost(Post post, int? groupId)
        {
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

    }
}
