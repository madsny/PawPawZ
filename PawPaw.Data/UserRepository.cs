using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PawPaw.Core;
using PawPaw.Users;

namespace PawPaw.Data
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(IDataSettings settings) : base(settings) { }

        public User Get(string username)
        {
            const string sql = @"SELECT * FROM [User] WHERE Username = @Username";

            return Run(con => con.Query<User>(sql, new {Username = username})).SingleOrDefault();
        }

        private User Get(int id)
        {
            const string sql = @"SELECT * FROM [User] WHERE Id = @Id";

            return Run(con => con.Query<User>(sql, new {Id = id})).SingleOrDefault();
        }

        public User Create(User user)
        {
            const string sql = @"
INSERT INTO [User](Username, FullName)
OUTPUT Inserted.Id
VALUES(@Username, @FullName)";

            var id = Run(con => con.Query<int>(sql, user)).Single();

            return Get(id);
        }


    }
}
