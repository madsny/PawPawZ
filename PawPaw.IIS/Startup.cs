using System.Configuration;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using PawPaw.IIS.Settings;
using PawPaw.WebApi.Config;

namespace PawPaw.IIS
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            UseFileServer(app);
            app.UseWebApi(
                PawPawWebConfig.Configure(
                    new HttpConfiguration(),
                    new AppConfiguration(),
                    new FakeAuthIdentityContext()));
        }

        private static void UseFileServer(IAppBuilder app)
        {
            var fileStreamPrefix = ConfigurationManager.AppSettings["ReactProjectPath"];

            app.UseFileServer(new FileServerOptions
            {
                RequestPath = PathString.Empty,
                FileSystem = new PhysicalFileSystem(string.Format("{0}{1}", fileStreamPrefix, "public"))
            });
        }
    }
}