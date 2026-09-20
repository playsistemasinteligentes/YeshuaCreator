using Aplication.Interfaces.Services;
using Dominio.Interfaces;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Shered.DB.Connection
{
    public readonly record struct RepositoryTelemetrySelection(
        bool CaptureCounters,
        bool EmitEvents)
    {
        public bool Enabled => CaptureCounters || EmitEvents;
    }

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

        public RepositoryTelemetrySelection Evaluate(string operation)
        {
            // OBS: F-EXP-04 - capacidades decididas na borda antes do custo de medicao.
            var captureCounters = _logger
                .Evaluate("RepositoryCounters", operation)
                .Enabled;
            var eventDecision = _logger.Evaluate("RepositoryEvents", operation);
            var emitEvents = eventDecision.Enabled &&
                (eventDecision.Level.Equals("Trace", StringComparison.OrdinalIgnoreCase) ||
                 eventDecision.Level.Equals("Debug", StringComparison.OrdinalIgnoreCase) ||
                 !eventDecision.Depth.Equals("D0", StringComparison.OrdinalIgnoreCase));

            return new RepositoryTelemetrySelection(captureCounters, emitEvents);
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
            RepositoryTelemetrySelection selection,
            Exception? exception = null)
        {
            // OBS: F-EXP-04 - nunca recebe SQL nem parametros, somente o identificador opaco.
            var durationMs = (long)Stopwatch
                .GetElapsedTime(startedAt)
                .TotalMilliseconds;
            _logger.Repository(
                operation,
                queryId,
                _context.TraceId,
                succeeded,
                durationMs,
                selection.CaptureCounters,
                selection.EmitEvents,
                exception);
        }

        private static string CreateQueryId(string sql)
        {
            var hash = SHA256.HashData(Encoding.UTF8.GetBytes(sql.Trim()));
            return Convert.ToHexString(hash.AsSpan(0, 8));
        }
    }
}
