﻿using System.Collections.Generic;
using System.Web.Http;
using PawPaw.Core;
using PawPaw.Web.Config;

namespace PawPaw.Web.Api
{
    [RoutePrefix(Constants.ApiPrefix)]
    public class GroupApiController : ApiController
    {
        private readonly GroupReader _groupReader;
        private readonly GroupWriter _groupWriter;

        public GroupApiController(
            GroupReader groupReader, 
            GroupWriter groupWriter)
        {
            _groupReader = groupReader;
            _groupWriter = groupWriter;
        }

        [Route("group")]
        public IEnumerable<Group> GetALl()
        {
            return _groupReader.GetAll();
        }

        [Route("group/{groupId:int}")]
        public Group Get(int groupId)
        {
            return _groupReader.GetGroup(groupId);
        }

        [HttpPost]
        [Route("group")]
        public void New(Group group)
        {
            _groupWriter.Create(group);
        }
    }
}