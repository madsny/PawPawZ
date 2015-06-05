using System;

namespace PawPaw.Core
{
    public class Weight : SocialContentBase
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime? Modified { get; set; }
    }
}