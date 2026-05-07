// Shered.DB.Connection — InstrumentedUnitOfWork.cs
using Aplication.Interfaces.Services;
using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.UnitOfWork;
using System.Diagnostics;

namespace Shered.DB.Connection
{
    public class InstrumentedUnitOfWork : IUnitOfWork
    {
        private readonly UnitOfWork _inner;
        private readonly ILogger _logger;
        private readonly IExecutionContext _context;

        public InstrumentedUnitOfWork(
            UnitOfWork inner,
            ILogger logger,
            IExecutionContext context)
        {
            _inner = inner;
            _logger = logger;
            _context = context;
        }

        public void Open() => _inner.Open();
        public void Close() => _inner.Close();
        public void BeginTran() => _inner.BeginTran();
        public void Commit() => _inner.Commit();
        public void Rollback() => _inner.Rollback();
        public void Dispose() => _inner.Dispose();

        public int Execute(string sql, object param = null)
        {
            var sw = Stopwatch.StartNew();
            var result = _inner.Execute(sql, param);
            sw.Stop();
            _logger.Info(BuildSqlLog(sql, param, sw.ElapsedMilliseconds));
            return result;
        }

        public T ExecuteScalar<T>(string sql, object param = null)
        {
            var sw = Stopwatch.StartNew();
            var result = _inner.ExecuteScalar<T>(sql, param);
            sw.Stop();
            _logger.Info(BuildSqlLog(sql, param, sw.ElapsedMilliseconds));
            return result;
        }

        public IEnumerable<T> Query<T>(string sql, object param = null)
        {
            var sw = Stopwatch.StartNew();
            var result = _inner.Query<T>(sql, param);
            sw.Stop();
            _logger.Info(BuildSqlLog(sql, param, sw.ElapsedMilliseconds));
            return result;
        }

        public T QuerySingle<T>(string sql, object param = null)
        {
            var sw = Stopwatch.StartNew();
            var result = _inner.QuerySingle<T>(sql, param);
            sw.Stop();
            _logger.Info(BuildSqlLog(sql, param, sw.ElapsedMilliseconds));
            return result;
        }

        public T QueryFirstOrDefault<T>(string sql, object param = null)
        {
            var sw = Stopwatch.StartNew();
            var result = _inner.QueryFirstOrDefault<T>(sql, param);
            sw.Stop();
            _logger.Info(BuildSqlLog(sql, param, sw.ElapsedMilliseconds));
            return result;
        }

        // ── Monta a mensagem — débito técnico assumido ───────────────────────
        private string BuildSqlLog(string sql, object param, long durationMs)
        {
            var sb = new System.Text.StringBuilder();
            sb.Append($"[SQL] {sql.Trim()} | {durationMs}ms | trace: {_context.TraceId}");

            if (param != null)
            {
                try
                {
                    // débito técnico — reflection assumido, será resolvido com AOT
                    var props = param.GetType().GetProperties();
                    if (props.Length > 0)
                    {
                        var paramStr = string.Join(", ", props.Select(p => $"{p.Name}={p.GetValue(param)}"));
                        sb.Append($" | params: {paramStr}");
                    }
                    else if (param is System.Dynamic.ExpandoObject expando)
                    {
                        var dict = (IDictionary<string, object>)expando;
                        var paramStr = string.Join(", ", dict.Select(k => $"{k.Key}={k.Value}"));
                        sb.Append($" | params: {paramStr}");
                    }
                }
                catch { /* silencioso — log nunca pode derrubar o sistema */ }
            }

            return sb.ToString();
        }
    }
}