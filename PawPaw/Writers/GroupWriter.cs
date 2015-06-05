using PawPaw.Core;

namespace PawPaw.Writers
{
    public class GroupWriter
    {
        private readonly IGroupRepository _groupRepository;

        public GroupWriter(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public int Create(Group group)
        {
            return _groupRepository.Create(group);
        }
    }
}
