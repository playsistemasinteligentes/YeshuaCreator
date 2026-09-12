using Dapper;
using Microsoft.Data.SqlClient;
using Migration.Interfaces;
using System;
using System.Data;


namespace Infra
{

    public class UnitOfWorkMok : IUnitOfWork
    {
        private readonly IDbConnection _connection;

        public UnitOfWorkMok(IDbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public UnitOfWorkMok(IDbConnection connection, bool checkAndCreateDatabase = false)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            _connection = connection;


        }

        private void EnsureDatabaseExistsAndUse(IDbConnection connection, string databaseName)
        {
        }

        private string RemoveDatabaseFromConnectionString(string connectionString)
        {
            return string.Empty;
        }
        private string getDatabaseFromConnectionString(string connectionString)
        {
            return string.Empty;
        }

        private string UpdateDatabaseInConnectionString(string connectionString, string databaseName)
        {
            return string.Empty;
        }


        public void BeginTran()
        {
        }

        public IDbConnection Connection => _connection;
        public IDbTransaction Transaction => null!;

        public void ExecuteCommand(string sql, object parameters = null)
        {
            try
            {
                Console.WriteLine(sql);
            }
            catch (Exception )
            {

                throw;
            }
        }

        public T QuerySingle<T>(string sql, object parameters = null)
        {
            return _connection.QuerySingle<T>(sql, parameters);
        }


        public void Commit()
        {
        }

        public void Rollback()
        {
        }

        public void Dispose()
        {
        }
    }

}
