using System;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Shered.DB.Connection
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;
        public IDbConnection Connection => _connection;
        public IDbTransaction Transaction => _transaction;
        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public UnitOfWork(IDbConnection connection, bool checkAndCreateDatabase = false)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            _connection = connection;

            if (checkAndCreateDatabase)
            {
                EnsureDatabaseExistsAndUse(_connection, getDatabaseFromConnectionString(connection.ConnectionString));
            }

            _connection.Open();
        }

        private void EnsureDatabaseExistsAndUse(IDbConnection connection, string databaseName)
        {
            var connectionString = connection.ConnectionString;

            using (var tempConnection = new SqlConnection(RemoveDatabaseFromConnectionString(connectionString)))
            {
                tempConnection.Open();

                using (var command = tempConnection.CreateCommand())
                {
                    // Verifica se o banco existe
                    command.CommandText = "SELECT COUNT(*) FROM sys.databases WHERE name = @dbName";
                    var param = command.CreateParameter();
                    param.ParameterName = "@dbName";
                    param.Value = databaseName;
                    command.Parameters.Add(param);

                    int databaseCount = (int)command.ExecuteScalar();

                    if (databaseCount == 0)
                    {
                        // Se o banco não existir, cria
                        command.CommandText = $"CREATE DATABASE [{databaseName}];";
                        command.ExecuteNonQuery();
                    }
                }
            }

            // Agora, atualiza a conexão para usar o banco de dados criado
            _connection.ConnectionString = UpdateDatabaseInConnectionString(connectionString, databaseName);
        }

        private string RemoveDatabaseFromConnectionString(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            builder.InitialCatalog = ""; // Remove o banco de dados para conexão inicial
            return builder.ToString();
        }
        private string getDatabaseFromConnectionString(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            return builder.InitialCatalog.ToString();
        }

        private string UpdateDatabaseInConnectionString(string connectionString, string databaseName)
        {
            var builder = new SqlConnectionStringBuilder(connectionString)
            {
                InitialCatalog = databaseName // Define o banco de dados específico
            };
            return builder.ToString();
        }


        public void BeginTran()
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            _transaction = _connection.BeginTransaction();
        }

        public void ExecuteCommand(string sql, object parameters = null)
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
            _connection.Execute(sql, parameters, _transaction);
        }

        public T QuerySingle<T>(string sql, object parameters = null)
        {
            return _connection.QuerySingle<T>(sql, parameters, _transaction);
        }

        public void Commit()
        {
            _transaction?.Commit();
            DisposeTransaction();
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            DisposeTransaction();
        }

        private void DisposeTransaction()
        {
            _transaction?.Dispose();
            _transaction = null;
        }

        public void Dispose()
        {
            if (_disposed) return;

            try
            {
                _transaction?.Rollback();
            }
            catch { }

            _transaction?.Dispose();
            _connection?.Dispose();

            _disposed = true;
        }
    }

}