using PawPaw.Core;

namespace PawPaw.Users
{
    public interface IUserRepository
    {
        User Get(string username);
        User Create(User user);
    }
}