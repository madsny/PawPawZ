using System.Security.Principal;
using System.Web;
using PawPaw.Users;

namespace PawPaw.DemoWeb.Settings
{
    public class FakeAuthIdentityContext : IIdentityContext
    {
        public IIdentity GetCurrentIdentity()
        {
            string username;
            var session = HttpContext.Current.Session;
            if (session != null)
            {
                username = session["username"] as string;
            }
            else
            {
                username = HttpContext.Current.Request.Headers.Get("Authorization");
            }

            return string.IsNullOrEmpty(username) ? null : new GenericIdentity(username);
        }
    }
}