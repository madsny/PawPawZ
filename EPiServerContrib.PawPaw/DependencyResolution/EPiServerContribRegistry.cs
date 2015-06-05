using EPiServerContrib.PawPaw.Settings;
using PawPaw;
using PawPaw.Readers;
using PawPaw.Writers;
using StructureMap.Configuration.DSL;
using StructureMapContrib.PawPaw;

namespace EPiServerContrib.PawPaw.DependencyResolution
{
    public class EPiServerContribRegistry : Registry
    {
        public EPiServerContribRegistry()
        {
            For<PostWriter>().Use<PostWriter>();
            For<PostStreamReader>().Use<PostStreamReader>();
            IncludeRegistry(new PawPawRegistry(new AppConfiguration(), new FakeAuthIdentityContext()));
        }
    }
}