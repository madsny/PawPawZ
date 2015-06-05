using System;

namespace PawPaw.Core
{
    public class Post : SocialContentBase
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime? Modified { get; set; }
    }
}
