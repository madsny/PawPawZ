using PawPaw.Comments;

namespace PawPaw.DemoWeb.Models
{
    public class CreateCommentViewModel
    {
        public int PostId { get; private set; }
        public Comment Comment { get; set; }

        public CreateCommentViewModel(int postId)
        {
            PostId = postId;
        }
    }
}