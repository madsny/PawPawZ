using PawPaw.Core;
using PawPaw.Data;
using PawPaw.Users;
using StructureMap.Configuration.DSL;

namespace StructureMapContrib.PawPaw
{
    public class PawPawRegistry : Registry
    {
        public PawPawRegistry(IDataSettings datasettings, IIdentityContext identityContext)
        {
            For<ICommentRepository>().Use<CommentRepository>();
            For<IGroupRepository>().Use<GroupRepository>();
            For<IPostRepository>().Use<PostRepository>();
            For<IUserRepository>().Use<UserRepository>();

            For<IUserContext>().Use<UserContext>();

            For<IDataSettings>().Use(datasettings);
            For<IIdentityContext>().Use(identityContext);

            For<IWeightRepository>().Use<WeightRepository>();
        }
    }
}
