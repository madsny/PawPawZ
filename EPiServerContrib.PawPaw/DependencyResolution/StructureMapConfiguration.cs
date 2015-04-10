using StructureMap;

namespace EPiServerContrib.PawPaw.DependencyResolution
{
    public class StructureMapConfiguration
    {
        public static void Configure(IContainer container)
        {
            container.Configure(
              x =>
              {
                  x.AddRegistry<EPiServerContribRegistry>();
              });
        }
    }
}
