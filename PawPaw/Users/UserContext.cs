using PawPaw.Core;

namespace PawPaw.Users
{
    public class UserContext : IUserContext
    {
        private readonly IIdentityContext _identityContext;
        private readonly IUserRepository _userRepository;

        public UserContext(IIdentityContext identityContext, IUserRepository userRepository)
        {
            _identityContext = identityContext;
            _userRepository = userRepository;
        }

        public User GetCurrentUser()
        {
            var identity = _identityContext.GetCurrentIdentity();

            if (identity == null)
                return null;

            var user = _userRepository.Get(identity.Name);
            if (user != null)
                return user;

            return _userRepository.Create(new User {Username = identity.Name});
        }
    }
}
