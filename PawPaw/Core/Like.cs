using System;
using PawPaw.Users;

namespace PawPaw.Core
{
    public class Like
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public UserShort CreatedBy { get; set; } 
    }
}