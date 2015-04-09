using System.Collections.Generic;

namespace PawPaw.Core
{
    public interface IGroupRepository
    {
        int Create(Group group);
        Group Get(int id);
        IEnumerable<Group> GetAll();
    }
}
