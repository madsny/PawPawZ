namespace PawPaw.Posts
{
    public interface IPostRepository
    {
        Post Create(Post post);
        Post Get(int id);
    }
}
