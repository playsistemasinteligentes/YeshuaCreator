using System;
using System.Data;
using Dapper;
namespace Shered.DB.Connection
{

    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void ExecuteCommand(string sql, object parameters = null);
        T QuerySingle<T>(string sql, object parameters = null);
        void Commit();
        void BeginTran();
        void Rollback();
    }
}