using System.Linq;
using Dapper;
using PawPaw.Posts;

namespace PawPaw.Data
{
    public class PostRepository : RepositoryBase, IPostRepository
    {
        public PostRepository(IDataSettings settings) : base(settings) { }

        public Post Create(Post post)
        {
            const string sql = @"
INSERT INTO Post(Body) 
OUTPUT Inserted.Id
VALUES(@Body);";


            var id = Run(con => con.Query<int>(sql, post)).Single();
            return Get(id);
        }

        public Post Get(int id)
        {
            const string sql = @"SELECT * FROM Post WHERE Id = @Id";

            return Run(con => con.Query<Post>(sql, new {Id = id})).SingleOrDefault();
        }
    }
}
