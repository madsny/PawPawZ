using System;
using PawPaw.Users;

namespace PawPaw.Core
{
    public abstract class SocialContentBase : ICreatedByUser
    {
        public UserShort CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
