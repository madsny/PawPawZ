using PawPaw.Core;

namespace PawPaw.Users
{
    public interface IUserContext
    {
        User GetCurrentUser();
    }
}
