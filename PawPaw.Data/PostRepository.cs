using System.Collections.Generic;
using System.Linq;
using Dapper;
using PawPaw.Core;

namespace PawPaw.Data
{
    public class PostRepository : RepositoryBase, IPostRepository
    {
        public PostRepository(IDataSettings settings) : base(settings) { }

        public int Create(Post post)
        {
            const string sql = @"
INSERT INTO Post(Body) 
OUTPUT Inserted.Id
VALUES(@Body);";

            return Run(con => con.Query<int>(sql, post)).Single();
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
    }
}
