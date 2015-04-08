using System;
using System.Data.SqlClient;

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
    }
}