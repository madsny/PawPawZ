using System.Collections.Generic;
using System.Linq;
using Dapper;
using PawPaw.Core;

namespace PawPaw.Data
{
    public class CommentRepository : RepositoryBase, ICommentRepository
    {
        public CommentRepository(IDataSettings settings) : base(settings) {}

        public IEnumerable<Comment> GetByPost(int postId)
        {
            const string sql = @"SELECT * FROM Comment WHERE PostId = @PostId";

            return Run(con => con.Query<Comment>(sql, new {PostId = postId}));
        }

        public int Create(int postId, Comment comment, int userId)
        {
            const string sql = @"
INSERT INTO Comment(Body, PostId, Created, CreatedByUserId)
OUTPUT Inserted.Id
VALUES(@Body, @PostId, @Created, @UserId);
UPDATE Post
SET Modified = @Created
WHERE Id = @PostId";

            var param = new DynamicParameters(comment);
            param.Add("PostId", postId);
            param.Add("UserId", userId);

            return Run(con => con.Query<int>(sql, param)).Single();
        }
    }
}
