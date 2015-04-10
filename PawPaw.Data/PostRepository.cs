using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using PawPaw.Core;

namespace PawPaw.Data
{
    public class PostRepository : RepositoryBase, IPostRepository
    {
        public PostRepository(IDataSettings settings) : base(settings) { }

        public int Create(Post post, int userId)
        {
            const string sql = @"
INSERT INTO Post(Body, Created, CreatedBy) 
OUTPUT Inserted.Id
VALUES(@Body, @Created, @UserId);";

            var param = new DynamicParameters(post);
            param.Add("UserId", userId);

            return Run(con => con.Query<int>(sql, param)).Single();
        }

        public Post Get(int id)
        {
            const string sql = @"SELECT * FROM Post WHERE Id = @Id";

            return Run(con => con.Query<Post>(sql, new {Id = id})).SingleOrDefault();
        }

        public IEnumerable<Post> GetAll()
        {
            const string sql = @"SELECT * FROM Post";

            return Run(con => con.Query<Post>(sql));
        }

        public void AssociateWithGroup(int postId, int groupId)
        {
            const string sql = @"
INSERT INTO 
GroupToPost(PostId, GroupId)
VALUES(@PostId, @GroupId)";

            Run(con => con.Execute(sql, new {PostId = postId, GroupId = groupId}));
        }

        public IEnumerable<Post> GetByGroupId(int groupId)
        {
            const string sql = @"
SELECT Post.* FROM 
Post
INNER JOIN GroupToPost ON Post.Id = GroupToPost.PostId
WHERE GroupId = @GroupId";

            return Run(con => con.Query<Post>(sql, new {GroupId = groupId}));
        }

        public Post GetByExternalId(string externalId)
        {
            const string sql = @"
SELECT Post.* FROM
Post
INNER JOIN ExternalIdToPost ON Post.Id = ExternalIdToPost.PostId
WHERE ExternalIdToPost.ExternalId = @ExternalId";

            return Run(con => con.Query<Post>(sql, new {ExternalId = externalId})).SingleOrDefault();

        }

        public void AssociateWithExternalId(int postId, string externalId)
        {
            const string sql = @"
INSERT INTO 
ExternalIdToPost(ExternalId, PostId)
VALUES(@ExternalId, @PostId)";

            Run(con => con.Execute(sql, new {ExternalId = externalId, PostId = postId}));
        }


    }
}
