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

        private bool _manualOpen = false;
        private bool _inTransaction = false;
        private bool _disposed = false;

        public UnitOfWork(ISqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        // ========================
        // CONTROLE DE CONEXÃO
        // ========================

        private void EnsureConnectionOpen()
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
        }

        private void AutoCloseIfNeeded()
        {
            if (!_manualOpen && !_inTransaction)
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }

        public void Open()
        {
            EnsureConnectionOpen();
            _manualOpen = true;
        }

        public void Close()
        {
            if (_connection.State == ConnectionState.Open)
                _connection.Close();

            _manualOpen = false;
            _inTransaction = false;
        }

        // ========================
        // TRANSAÇÃO
        // ========================

        public void BeginTran()
        {
            EnsureConnectionOpen();
            _transaction = _connection.BeginTransaction();
            _inTransaction = true;
        }

        public void Commit()
        {
            _transaction?.Commit();
            DisposeTransaction();
            Close();
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            DisposeTransaction();
            Close();
        }

        private void DisposeTransaction()
        {
            _transaction?.Dispose();
            _transaction = null;
            _inTransaction = false;
        }

        // ========================
        // DAPPER WRAPPER
        // ========================

        public int Execute(string sql, object? param = null)
        {
            EnsureConnectionOpen();

            var result = _connection.Execute(sql, param, _transaction);

            AutoCloseIfNeeded();

            return result;
        }

        public T ExecuteScalar<T>(string sql, object? param = null)
        {
            EnsureConnectionOpen();

            var result = _connection.ExecuteScalar<T>(sql, param, _transaction);

            AutoCloseIfNeeded();

            return result;
        }

        public IEnumerable<T> Query<T>(string sql, object? param = null)
        {
            EnsureConnectionOpen();

            var result = _connection.Query<T>(sql, param, _transaction);

            AutoCloseIfNeeded();

            return result;
        }

        public T QuerySingle<T>(string sql, object? param = null)
        {
            EnsureConnectionOpen();

            var result = _connection.QuerySingle<T>(sql, param, _transaction);

            AutoCloseIfNeeded();

            return result;
        }

        public T QueryFirstOrDefault<T>(string sql, object? param = null)
        {
            EnsureConnectionOpen();

            var result = _connection.QueryFirstOrDefault<T>(sql, param, _transaction);

            AutoCloseIfNeeded();

            return result!;
        }

        // ========================
        // DISPOSE
        // ========================

        public void Dispose()
        {
            if (_disposed) return;

            try
            {
                _transaction?.Rollback();
            }
            catch { }

            _transaction?.Dispose();

            if (_connection.State == ConnectionState.Open)
                _connection.Close();

            _connection.Dispose();

            _disposed = true;
        }
    }
}
