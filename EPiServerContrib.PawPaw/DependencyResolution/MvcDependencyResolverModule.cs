namespace EPiServerContrib.PawPaw.DependencyResolution
{
    using System.Web.Mvc;
    using EPiServer.Framework;
    using EPiServer.Framework.Initialization;
    using EPiServer.ServiceLocation;
    using StructureMap;

    [ModuleDependency(typeof(ServiceContainerInitialization))]
    public class MvcDependencyResolverModule : IConfigurableModule
    {
        private IContainer container;

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            container = context.Container;
            DependencyResolver.SetResolver(
                new StructureMapDependencyResolver(context.Container));
        }

        public void Initialize(InitializationEngine context)
        {
            StructureMapConfiguration.Configure(container);
        }

        public void Preload(string[] parameters)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}