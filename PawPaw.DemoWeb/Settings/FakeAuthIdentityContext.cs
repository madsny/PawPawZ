using System.Security.Principal;
using System.Web;
using PawPaw.Users;

namespace PawPaw.DemoWeb.Settings
{
    public class FakeAuthIdentityContext : IIdentityContext
    {
        public IIdentity GetCurrentIdentity()
        {
            var username = HttpContext.Current.Session["username"] as string;
            if (string.IsNullOrEmpty(username))
                return null;
            return new GenericIdentity(username);
        }
    }
}