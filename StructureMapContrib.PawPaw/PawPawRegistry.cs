using PawPaw.Core;
using PawPaw.Data;
using StructureMap.Configuration.DSL;

namespace StructureMapContrib.PawPaw
{
    public class PawPawRegistry : Registry
    {
        public PawPawRegistry(IDataSettings datasettings)
        {
            For<ICommentRepository>().Use<CommentRepository>();
            For<IGroupRepository>().Use<GroupRepository>();
            For<IPostRepository>().Use<PostRepository>();
            For<IDataSettings>().Use(datasettings);
        }
    }
}
