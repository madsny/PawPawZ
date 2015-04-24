using System;
using PawPaw.Users;

namespace PawPaw.Core
{
    public class Weight
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public UserShort CreatedBy { get; set; } 
    }
}