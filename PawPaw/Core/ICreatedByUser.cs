using System;
using PawPaw.Users;

namespace PawPaw.Core
{
    public interface ICreatedByUser
    {
        UserShort CreatedBy { get; set; }
        DateTime Created { get; set; }
    }
}
