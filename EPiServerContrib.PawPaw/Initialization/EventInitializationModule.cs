using EPiServer;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace EPiServerContrib.PawPaw.Initialization
{
    [InitializableModule]
    public class EventInitializationModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            DataFactory.Instance.PublishedContent += Events.PublishedContent;
        }

        public void Preload(string[] parameters) { }

        public void Uninitialize(InitializationEngine context)
        {
            DataFactory.Instance.PublishedContent -= Events.PublishedContent;
        }
    }
}