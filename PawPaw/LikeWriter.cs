namespace PawPaw
{
    public class LikeWriter
    {
        private readonly WeightWriter _weightWriter;

        public LikeWriter(WeightWriter weightWriter)
        {
            _weightWriter = weightWriter;
        }

        public int AddLikeToPost(int postId)
        {
            return _weightWriter.AddWeightToPost(postId, 1);
        }

        public int AddLikeToComment(int commentId, int amount)
        {
            return _weightWriter.AddWeightToComment(commentId, 1);
        }
    }
}
