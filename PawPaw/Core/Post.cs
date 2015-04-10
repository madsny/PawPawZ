using System;

namespace PawPaw.Core
{
    public class Post
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
