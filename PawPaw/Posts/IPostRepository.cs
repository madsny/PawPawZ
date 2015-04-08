using System.Collections.Generic;

namespace PawPaw.Posts
{
    public interface IPostRepository
    {
        int Create(Post post);
        Post Get(int id);
        IEnumerable<Post> GetAll();
    }
}
