using System.Security.Principal;

namespace PawPaw.Users
{
    public interface IIdentityContext
    {
        IIdentity GetCurrentIdentity();
    }
}
