using System.Security.Principal;
using PawPaw.Users;

namespace EPiServerContrib.PawPaw.Settings
{
    public class FakeAuthIdentityContext : IIdentityContext
    {
        public IIdentity GetCurrentIdentity()
        {
            return new GenericIdentity("skjelbek");
        }
    }
}