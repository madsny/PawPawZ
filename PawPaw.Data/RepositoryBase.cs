using System;
using System.Data.SqlClient;
using Dapper;

namespace PawPaw.Data
{
    public abstract class RepositoryBase
    {
        private readonly IDataSettings _settings;

        protected RepositoryBase(IDataSettings settings)
        {
            _settings = settings;
        }

        protected T Run<T>(Func<SqlConnection, T> query)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return query(connection);
            }
        }

        private SqlConnection CreateConnection()
        {
            var connection = new SqlConnection(_settings.ConnectionString);
            return connection;
        }

        protected void DeleteFrom(string table, int itemId)
        {
            var  sql = string.Format(@"
                UPDATE {0}
                SET Deleted = 1
                WHERE Id = @ItemId", table);

            Run(con => con.Execute(sql, new {ItemId = itemId}));
        }
    }
}