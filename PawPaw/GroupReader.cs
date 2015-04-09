using System.Collections.Generic;
using PawPaw.Core;

namespace PawPaw
{
    public class GroupReader 
    {
        private readonly IGroupRepository _groupRepository;

        public GroupReader(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public IEnumerable<Group> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public Group GetGroup(int groupId)
        {
            return _groupRepository.Get(groupId);
        }
    }
}
