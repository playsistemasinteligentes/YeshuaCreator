using Microsoft.Data.Sqlite;
using System.Data;


namespace Shered.DB.Connection
{
    public class SqlFactoryMokSqlite: ISqlFactory
    {
        private readonly string _connectionString;

        public SqlFactoryMokSqlite(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection SqlConnection()
        {
            return new SqliteConnection(_connectionString);
        }
    }
}
