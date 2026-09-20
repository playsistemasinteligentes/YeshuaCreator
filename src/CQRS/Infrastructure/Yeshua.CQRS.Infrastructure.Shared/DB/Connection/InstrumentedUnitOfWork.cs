using Aplication.Interfaces.Services;
using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.UnitOfWork;
using System.Diagnostics;

namespace Shered.DB.Connection
{
    public sealed class InstrumentedUnitOfWork : IUnitOfWork
    {
        private readonly UnitOfWork _inner;
        private readonly RepositoryTelemetry _telemetry;

        public InstrumentedUnitOfWork(
            UnitOfWork inner,
            ILogger logger,
            IExecutionContext context)
            : this(inner, new RepositoryTelemetry(logger, context))
        {
        }

        public InstrumentedUnitOfWork(
            UnitOfWork inner,
            RepositoryTelemetry telemetry)
        {
            _inner = inner;
            _telemetry = telemetry;
        }

        public void Open() => _inner.Open();
        public void Close() => _inner.Close();
        public void BeginTran() => _inner.BeginTran();
        public void Commit() => _inner.Commit();
        public void Rollback() => _inner.Rollback();
        public void Dispose() => _inner.Dispose();

        public int Execute(string sql, object? param = null)
        {
            // OBS: F-EXP-00 - sem hash, cronometro ou try/catch quando desligado.
            var telemetry = _telemetry.Evaluate("Execute");
            if (!telemetry.Enabled)
                return _inner.Execute(sql, param);

            var queryId = _telemetry.GetQueryId(sql);
            var startedAt = Stopwatch.GetTimestamp();
            try
            {
                var result = _inner.Execute(sql, param);
                _telemetry.Complete("Execute", queryId, startedAt, true, telemetry);
                return result;
            }
            catch (Exception exception)
            {
                _telemetry.Complete("Execute", queryId, startedAt, false, telemetry, exception);
                throw;
            }
        }

        public T ExecuteScalar<T>(string sql, object? param = null)
        {
            var telemetry = _telemetry.Evaluate("ExecuteScalar");
            if (!telemetry.Enabled)
                return _inner.ExecuteScalar<T>(sql, param);

            var queryId = _telemetry.GetQueryId(sql);
            var startedAt = Stopwatch.GetTimestamp();
            try
            {
                var result = _inner.ExecuteScalar<T>(sql, param);
                _telemetry.Complete("ExecuteScalar", queryId, startedAt, true, telemetry);
                return result;
            }
            catch (Exception exception)
            {
                _telemetry.Complete("ExecuteScalar", queryId, startedAt, false, telemetry, exception);
                throw;
            }
        }

        public IEnumerable<T> Query<T>(string sql, object? param = null)
        {
            var telemetry = _telemetry.Evaluate("Query");
            if (!telemetry.Enabled)
                return _inner.Query<T>(sql, param);

            var queryId = _telemetry.GetQueryId(sql);
            var startedAt = Stopwatch.GetTimestamp();
            try
            {
                var result = _inner.Query<T>(sql, param);
                _telemetry.Complete("Query", queryId, startedAt, true, telemetry);
                return result;
            }
            catch (Exception exception)
            {
                _telemetry.Complete("Query", queryId, startedAt, false, telemetry, exception);
                throw;
            }
        }

        public T QuerySingle<T>(string sql, object? param = null)
        {
            var telemetry = _telemetry.Evaluate("QuerySingle");
            if (!telemetry.Enabled)
                return _inner.QuerySingle<T>(sql, param);

            var queryId = _telemetry.GetQueryId(sql);
            var startedAt = Stopwatch.GetTimestamp();
            try
            {
                var result = _inner.QuerySingle<T>(sql, param);
                _telemetry.Complete("QuerySingle", queryId, startedAt, true, telemetry);
                return result;
            }
            catch (Exception exception)
            {
                _telemetry.Complete("QuerySingle", queryId, startedAt, false, telemetry, exception);
                throw;
            }
        }

        public T QueryFirstOrDefault<T>(string sql, object? param = null)
        {
            var telemetry = _telemetry.Evaluate("QueryFirstOrDefault");
            if (!telemetry.Enabled)
                return _inner.QueryFirstOrDefault<T>(sql, param);

            var queryId = _telemetry.GetQueryId(sql);
            var startedAt = Stopwatch.GetTimestamp();
            try
            {
                var result = _inner.QueryFirstOrDefault<T>(sql, param);
                _telemetry.Complete("QueryFirstOrDefault", queryId, startedAt, true, telemetry);
                return result;
            }
            catch (Exception exception)
            {
                _telemetry.Complete("QueryFirstOrDefault", queryId, startedAt, false, telemetry, exception);
                throw;
            }
        }
    }
}
