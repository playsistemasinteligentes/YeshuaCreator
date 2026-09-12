using System;
using System.Data;
namespace RepositoryInterfaces.Patterns.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Open();
        void Close();
        void BeginTran();
        void Commit();
        void Rollback();

        int Execute(string sql, object? param = null);
        T ExecuteScalar<T>(string sql, object? param = null);

        IEnumerable<T> Query<T>(string sql, object? param = null);
        T QuerySingle<T>(string sql, object? param = null);
        T QueryFirstOrDefault<T>(string sql, object? param = null);
    }
}
