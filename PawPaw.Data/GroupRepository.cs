using System.Collections.Generic;
using System.Linq;
using Dapper;
using PawPaw.Groups;

namespace PawPaw.Data
{
    public class GroupRepository : RepositoryBase, IGroupRepository
    {
        public GroupRepository(IDataSettings settings) : base(settings) { }

        public int Create(Group group)
        {
            const string sql = @"
INSERT INTO [Group](Name, Description)
OUTPUT Inserted.Id
VALUES(@Name, @Description)
";
            return Run(con => con.Query<int>(sql, group)).Single();
        }

        public Group Get(int id)
        {
            const string sql = @"SELECT * FROM [Group] WHERE Id = @Id";

            return Run(con => con.Query<Group>(sql, new {Id = id})).SingleOrDefault();
        }

        public IEnumerable<Group> GetAll()
        {
            const string sql = @"SELECT * FROM [Group]";

            return Run(con => con.Query<Group>(sql));
        }
    }
}
