using System.Net;
using System.Web.Http;
using PawPaw.Core;
using PawPaw.Readers;
using PawPaw.Users;

namespace PawPaw.WebApi.Api
{
    public class ApiControllerBase : ApiController
    {
        private readonly IUserContext _userContext;
        public ApiControllerBase(
            IUserContext userContext)
        {
            _userContext = userContext;
        }

        protected bool IsSameAsCurrentUser(UserShort user)
        {
            var currentUser = _userContext.GetCurrentUser();
            return currentUser != null && user.Id != currentUser.Id;
        }

        protected bool IsCreatedByCurrentUser(ICreatedByUser content)
        {
            return IsSameAsCurrentUser(content.CreatedBy);
        }

        protected void CheckPermission(ReaderBase reader, int id)
        {
            var like = reader.GetById(id);
            if (!IsCreatedByCurrentUser(like))
                throw new HttpResponseException(HttpStatusCode.Forbidden);
        }
    }
}
