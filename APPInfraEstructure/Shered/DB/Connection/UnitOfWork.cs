using System;
using System.Data;
using Dapper;
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

        public UnitOfWork(ISqlFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            _connection = factory.SqlConnection();

            if (_connection.State != ConnectionState.Open)
                _connection.Open();
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
            if (_connection.State != ConnectionState.Open)
                _connection.Open();

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