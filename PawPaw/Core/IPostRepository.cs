using System.Collections.Generic;

namespace PawPaw.Core
{
    public interface IPostRepository
    {
        int Create(Post post, int userId);
        Post Get(int id);
        IEnumerable<Post> GetAll();
        void AssociateWithGroup(int postId, int groupId);
        IEnumerable<Post> GetByGroupId(int groupId);
        void AssociateWithExternalId(int postId, string externalId);
        Post GetByExternalId(string externalId);
    }
}
