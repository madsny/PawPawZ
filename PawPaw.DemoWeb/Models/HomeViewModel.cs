using System.Collections.Generic;
using System.Linq;
using PawPaw.Core;

namespace PawPaw.DemoWeb.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Groups = Enumerable.Empty<Group>();
            Posts = Enumerable.Empty<Post>();
        }

        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public Group CurrentGroup { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }
    }
}