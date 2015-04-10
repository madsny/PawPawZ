using System.Web.Mvc;
using EPiServerContrib.PawPaw.DependencyResolution;

namespace PawPaw.Alloy
{
    public class EPiServerApplication : global::EPiServer.Global
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //Tip: Want to call the EPiServer API on startup? Add an initialization module instead (Add -> New Item.. -> EPiServer -> Initialization Module)
        }
    }
}