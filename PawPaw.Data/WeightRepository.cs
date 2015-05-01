using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using PawPaw.Core;
using PawPaw.Users;

namespace PawPaw.Data
{
    public class WeightRepository : RepositoryBase, IWeightRepository
    {
        public WeightRepository(IDataSettings settings) : base(settings) { }

        public IEnumerable<Weight> GetByPost(int postId)
        {
            const string whereClause = "WHERE PostId = @PostId";

            return RunSelect(whereClause, new {PostId = postId});
        }

        public IEnumerable<Weight> GetByComment(int commentId)
        {
            const string whereClause = "WHERE CommentId = @CommentId";
            return RunSelect(whereClause, new { CommentId = commentId });
        }

        public int Create(int? postId, int? commentId, Weight weight, int userId)
        {
            if (postId == null && commentId == null)
                throw new ArgumentNullException("postId and commentId can't both be null");

            const string sql = @"
                INSERT INTO Weight(Amount, PostId, Created, CreatedByUserId)
                OUTPUT Inserted.Id
                VALUES(@Body, @PostId, @Created, @UserId);
                UPDATE Post
                SET Modified = @Created
                WHERE Id = @PostId";

            var param = new DynamicParameters(weight);
            if (postId != null) param.Add("PostId", postId);
            if (commentId != null) param.Add("CommentId", commentId);
            param.Add("UserId", userId);

            return Run(con => con.Query<int>(sql, param)).Single();
        }

        private const string SelectClause = @"
                SELECT * FROM 
                Weight 
                INNER JOIN [User] ON Weight.CreatedByUserId = [User].Id";

        private IEnumerable<Weight> RunSelect(string whereClause, object param)
        {
            return Run(con => con.Query<Weight, UserShort, Weight>(string.Format("{0} {1}", SelectClause, whereClause), MapPostAndUser, param));
        }

        private Weight MapPostAndUser(Weight weight, UserShort createdBy)
        {
            weight.CreatedBy = createdBy;
            return weight;
        }

    }
}
