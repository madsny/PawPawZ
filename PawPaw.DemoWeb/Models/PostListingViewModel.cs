using System.Collections.Generic;
using PawPaw.Core;

namespace PawPaw.DemoWeb.Models
{
    public class PostListingViewModel
    {
        public PostListingViewModel(IEnumerable<Post> posts, int? groupId = null)
        {
            Posts = posts;
            GroupId = groupId;
        }

        public int? GroupId { get; set; }
        public IEnumerable<Post> Posts { get; set; } 
    }
}