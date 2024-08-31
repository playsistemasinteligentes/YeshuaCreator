using System;
using System.Data;
using Dapper;

namespace Shered.DB.Connection
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;

        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _connection.Open();
        }

        public void BeginTran()
        {
            _transaction = _connection.BeginTransaction();
        }

        public IDbConnection Connection => _connection;
        public IDbTransaction Transaction => _transaction;

        public void ExecuteCommand(string sql, object parameters = null)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(UnitOfWork));

            _connection.Execute(sql, parameters, _transaction);
        }

        public T QuerySingle<T>(string sql, object parameters = null)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(UnitOfWork));

            return _connection.QuerySingle<T>(sql, parameters, _transaction);
        }


        public void Commit()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(UnitOfWork));

            _transaction.Commit();
            Dispose(); // Dispose the transaction and connection after commit
        }

        public void Rollback()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(UnitOfWork));

            _transaction.Rollback();
            Dispose(); // Dispose the transaction and connection after rollback
        }

        public void Dispose()
        {
            if (_disposed) return;

            _transaction?.Dispose();
            _connection?.Close();
            _connection?.Dispose();
            _disposed = true;
        }
    }

}