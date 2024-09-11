using System;
using System.Data;
using Dapper;

namespace Shered.DB.Connection
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;

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
            _connection.Execute(sql, parameters, _transaction);
        }

        public T QuerySingle<T>(string sql, object parameters = null)
        {
            return _connection.QuerySingle<T>(sql, parameters, _transaction);
        }


        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Close();
            _connection?.Dispose();
        }
    }

}