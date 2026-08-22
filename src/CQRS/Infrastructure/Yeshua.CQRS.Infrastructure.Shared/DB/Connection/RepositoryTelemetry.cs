using Aplication.Interfaces.Services;
using Dominio.Interfaces;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Shered.DB.Connection
{
    public sealed class RepositoryTelemetry
    {
        private static readonly ConcurrentDictionary<string, string> QueryIds = new();
        private readonly ILogger _logger;
        private readonly IExecutionContext _context;

        public RepositoryTelemetry(ILogger logger, IExecutionContext context)
        {
            _logger = logger;
            _context = context;
        }

        public string GetQueryId(string sql)
        {
            return QueryIds.GetOrAdd(sql, static value => CreateQueryId(value));
        }

        public void Observe(string repository, string metric, long value)
        {
            _logger.Metric(repository, metric, value);
        }

        public void Complete(
            string operation,
            string queryId,
            long startedAt,
            bool succeeded,
            Exception? exception = null)
        {
            var durationMs = (long)Stopwatch
                .GetElapsedTime(startedAt)
                .TotalMilliseconds;
            _logger.Repository(
                operation,
                queryId,
                _context.TraceId,
                succeeded,
                durationMs,
                exception);
        }

        private static string CreateQueryId(string sql)
        {
            var hash = SHA256.HashData(Encoding.UTF8.GetBytes(sql.Trim()));
            return Convert.ToHexString(hash.AsSpan(0, 8));
        }
    }
}
