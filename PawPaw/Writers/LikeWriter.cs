namespace PawPaw.Writers
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

        public int AddLikeToComment(int commentId)
        {
            return _weightWriter.AddWeightToComment(commentId, 1);
        }

        public void RemoveLikeFromPost(int likeId)
        {
            _weightWriter.DeleteWeight(likeId);
        }
    }
}
