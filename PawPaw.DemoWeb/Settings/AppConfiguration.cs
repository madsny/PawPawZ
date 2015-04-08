using System.Configuration;
using PawPaw.Data;

namespace PawPaw.DemoWeb.Settings
{
    public class AppConfiguration : IDataSettings
    {
        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["PawPaw"].ConnectionString; }
        }
    }
}