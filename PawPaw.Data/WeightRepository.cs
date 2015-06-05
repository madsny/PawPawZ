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

            return RunSelect(whereClause, InnerJoinPost, new {PostId = postId});
        }

        public IEnumerable<Weight> GetByComment(int commentId)
        {
            const string whereClause = "WHERE CommentId = @CommentId";
            return RunSelect(whereClause, InnerJoinComment, new { CommentId = commentId });
        }

        public Weight GetById(int weightId)
        {
            const string sql = "SELECT * FROM Weight WHERE Id = @WeightId";
            return Run(con => con.Query<Weight>(sql, new { WeightId = weightId })).SingleOrDefault();
        }

        public int Create(int? postId, int? commentId, Weight weight, int userId)
        {
            if (postId == null && commentId == null)
                throw new ArgumentNullException("postId and commentId can't both be null");

            var sql = @"
                INSERT INTO Weight(Amount, Created, CreatedByUserId)
                OUTPUT Inserted.Id
                VALUES(@Amount, @Created, @UserId);";

            var param = new DynamicParameters(weight);
            param.Add("UserId", userId);

            if (postId != null)
            {
                sql += @"
                    INSERT INTO WeightToPost(WeightId, PostId)
                    VALUES(@Id, @PostId);
                    UPDATE Post
                    SET Modified = @Created
                    WHERE Id = @PostId;";
                param.Add("PostId", postId);
            }
            if (commentId != null)
            {
                sql += @"
                    INSERT INTO WeightToComment(WeightId, CommentId)
                    VALUES(@Id, @CommentId);
                    UPDATE Comment
                    SET Modified = @Created
                    WHERE Id = @CommentId;";
                param.Add("CommentId", commentId);
            }

            return Run(con => con.Query<int>(sql, param)).Single();
        }

        public void Delete(int weightId)
        {
            DeleteFrom("Weight", weightId);
        }

        private const string SelectClause = @"
                SELECT * FROM 
                Weight 
                INNER JOIN [User] ON Weight.CreatedByUserId = [User].Id";
        private const string InnerJoinPost = @"
                INNER JOIN [WeightToPost] ON Weight.Id = [WeightToPost].WeightId";
        private const string InnerJoinComment = @"
                INNER JOIN [WeightToComment] ON Weight.Id = [WeightToComment].WeightId";

        private IEnumerable<Weight> RunSelect(string whereClause, string joinClause, object param)
        {
            return Run(con => con.Query<Weight, UserShort, Weight>(string.Format("{0} {1} {2}", SelectClause, joinClause, whereClause), MapPostAndUser, param));
        }

        private Weight MapPostAndUser(Weight weight, UserShort createdBy)
        {
            weight.CreatedBy = createdBy;
            return weight;
        }

    }
}
