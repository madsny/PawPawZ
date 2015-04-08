using System.Collections.Generic;

namespace PawPaw.Groups
{
    public interface IGroupRepository
    {
        int Create(Group group);
        Group Get(int id);
        IEnumerable<Group> GetAll();
    }
}
