using System.Collections.Generic;
using System.Linq;
using Dapper;
using PawPaw.Core;
using PawPaw.Users;

namespace PawPaw.Data
{
    public class PostRepository : RepositoryBase, IPostRepository
    {
        public PostRepository(IDataSettings settings) : base(settings) { }

        public Post Get(int id)
        {
            const string whereClause = "WHERE Post.Id = @Id";

            return RunSelect(whereClause, new {Id = id}).SingleOrDefault();
        }
        
        public IEnumerable<Post> GetByGroupId(int groupId)
        {
            const string sql = @"
INNER JOIN GroupToPost ON Post.Id = GroupToPost.PostId
WHERE GroupId = @GroupId";

            return RunSelect(sql, new {GroupId = groupId});
        }

        public Post GetByExternalId(string externalId)
        {
            const string sql = @"
INNER JOIN ExternalIdToPost ON Post.Id = ExternalIdToPost.PostId
WHERE ExternalIdToPost.ExternalId = @ExternalId";

            return RunSelect(sql, new {ExternalId = externalId}).SingleOrDefault();
        }

        public int Create(Post post, int userId)
        {
            const string sql = @"
INSERT INTO Post(Body, Created, CreatedByUserId) 
OUTPUT Inserted.Id
VALUES(@Body, @Created, @UserId);";

            var param = new DynamicParameters(post);
            param.Add("UserId", userId);

            return Run(con => con.Query<int>(sql, param)).Single();
        }

        public void AssociateWithGroup(int postId, int groupId)
        {
            const string sql = @"
INSERT INTO 
GroupToPost(PostId, GroupId)
VALUES(@PostId, @GroupId)";

            Run(con => con.Execute(sql, new {PostId = postId, GroupId = groupId}));
        }

        public void AssociateWithExternalId(int postId, string externalId)
        {
            const string sql = @"
INSERT INTO 
ExternalIdToPost(ExternalId, PostId)
VALUES(@ExternalId, @PostId)";

            Run(con => con.Execute(sql, new {ExternalId = externalId, PostId = postId}));
        }

        private const string SelectClause = @"
SELECT * FROM 
Post 
INNER JOIN [User] ON Post.CreatedByUserId = [User].Id";

        private IEnumerable<Post> RunSelect(string whereClause, object param)
        {
            return Run(con => con.Query<Post, UserShort, Post>(string.Format("{0} {1}", SelectClause, whereClause), MapPostAndUser, param));
        }

        private Post MapPostAndUser(Post post, UserShort createdBy)
        {
            post.CreatedBy = createdBy;
            return post;
        }


    }
}
