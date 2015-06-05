using System.Collections.Generic;
using System.Web.Http;
using PawPaw.Core;
using PawPaw.Readers;
using PawPaw.Users;
using PawPaw.Web.Config;
using PawPaw.Writers;

namespace PawPaw.WebApi.Api
{
    [RoutePrefix(Constants.ApiPrefix)]
    public class GroupApiController : ApiControllerBase
    {
        private readonly GroupReader _groupReader;
        private readonly GroupWriter _groupWriter;

        public GroupApiController(
            GroupReader groupReader, 
            GroupWriter groupWriter,
            IUserContext userContext) : base(userContext)
        {
            _groupReader = groupReader;
            _groupWriter = groupWriter;
        }

        [Route("groups")]
        public IEnumerable<Group> GetALl()
        {
            return _groupReader.GetAll();
        }

        [Route("groups/{groupId:int}")]
        public Group Get(int groupId)
        {
            return _groupReader.GetGroup(groupId);
        }

        [HttpPost]
        [Route("groups")]
        public void New(Group group)
        {
            _groupWriter.Create(group);
        }
    }
}
