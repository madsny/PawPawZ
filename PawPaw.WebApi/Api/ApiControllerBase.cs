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
            return user.Id != _userContext.GetCurrentUser().Id;
        }

        protected bool IsCreatedByCurrentUser(ICreatedByUser content)
        {
            return content.CreatedBy.Id == _userContext.GetCurrentUser().Id;
        }

        protected void CheckPermission(ReaderBase reader, int id)
        {
            var like = reader.GetById(id);
            if (!IsCreatedByCurrentUser(like))
                throw new HttpResponseException(HttpStatusCode.Forbidden);
        }
    }
}
