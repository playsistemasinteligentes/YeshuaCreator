using Dominio.Interfaces;
using System.Buffers;
using System.Collections.Concurrent;
using System.Text;
using System.Text.Json;

namespace Shered.Logger
{
    public sealed class Logger : ILogger
    {
        private readonly ConcurrentDictionary<string, CommandState> _commands = new();
        private readonly ConcurrentDictionary<RepositoryKey, RepositoryState> _repositories = new();
        private readonly ConcurrentDictionary<string, OperationalMetricSnapshot> _metrics = new();
        private readonly IOperationalTelemetryPolicy? _policy;
        private readonly bool _localDetailEnabled = string.Equals(
            Environment.GetEnvironmentVariable("YESHUA_TELEMETRY_DETAIL"),
            "true",
            StringComparison.OrdinalIgnoreCase);

        public Logger()
        {
        }

        public Logger(IOperationalTelemetryPolicy policy)
        {
            _policy = policy;
        }

        public void Info(string message)
        {
            if (DetailEnabled("Application", "Info"))
                WriteApplication(message);
        }

        public void CommandStarted(string commandName)
        {
            var state = _commands.GetOrAdd(
                commandName,
                static name => new CommandState(name));
            lock (state.Sync)
            {
                state.Active++;
                state.LastStartedAtUtc = DateTimeOffset.UtcNow;
            }
        }

        public void CommandFinished(
            string commandName,
            string traceId,
            bool succeeded,
            long durationMs,
            int statusCode,
            WorkerCycleTelemetry? workerCycle = null)
        {
            var now = DateTimeOffset.UtcNow;
            var state = _commands.GetOrAdd(
                commandName,
                static name => new CommandState(name));
            var failed = !succeeded || statusCode >= 400;

            lock (state.Sync)
            {
                state.Active = Math.Max(0, state.Active - 1);
                state.Executions++;
                state.LastFinishedAtUtc = now;
                state.LastStatusCode = statusCode;
                state.LastDurationMs = durationMs;
                state.TotalDurationMs += durationMs;
                if (workerCycle is { } cycle)
                {
                    state.HasWorkerCycle = true;
                    state.BatchLimit = cycle.BatchLimit;
                    state.Claimed += cycle.Claimed;
                    state.Processed += cycle.Processed;
                    state.WorkerFailures += cycle.Failed;
                }

                if (failed)
                {
                    state.Failures++;
                    state.LastFailureAtUtc = now;
                }
            }

            if (failed || DetailEnabled("Command", commandName))
            {
                WriteCommand(
                    failed ? "Error" : "Information",
                    commandName,
                    traceId,
                    succeeded ? "concluido" : "falhou",
                    durationMs,
                    statusCode,
                    workerCycle,
                    null);
            }
        }

        public void CommandFailed(
            string commandName,
            string traceId,
            Exception ex,
            long durationMs)
        {
            var now = DateTimeOffset.UtcNow;
            var state = _commands.GetOrAdd(
                commandName,
                static name => new CommandState(name));
            lock (state.Sync)
            {
                state.Active = Math.Max(0, state.Active - 1);
                state.Executions++;
                state.Failures++;
                state.LastFinishedAtUtc = now;
                state.LastFailureAtUtc = now;
                state.LastStatusCode = 500;
                state.LastDurationMs = durationMs;
                state.TotalDurationMs += durationMs;
            }

            WriteCommand(
                "Error",
                commandName,
                traceId,
                "exception",
                durationMs,
                500,
                null,
                ex);
        }

        public void Repository(
            string operation,
            string queryId,
            string traceId,
            bool succeeded,
            long durationMs,
            Exception? exception = null)
        {
            var now = DateTimeOffset.UtcNow;
            var key = new RepositoryKey(operation, queryId);
            var state = _repositories.GetOrAdd(
                key,
                static value => new RepositoryState(value.Operation, value.QueryId));

            lock (state.Sync)
            {
                state.Executions++;
                state.LastFinishedAtUtc = now;
                state.LastDurationMs = durationMs;
                state.MaximumDurationMs = Math.Max(state.MaximumDurationMs, durationMs);
                state.TotalDurationMs += durationMs;
                if (!succeeded)
                {
                    state.Failures++;
                    state.LastFailureAtUtc = now;
                }
            }

            if (!succeeded || DetailEnabled("Repository", operation))
            {
                WriteRepository(
                    succeeded ? "Information" : "Error",
                    operation,
                    queryId,
                    traceId,
                    succeeded,
                    durationMs,
                    exception);
            }
        }

        public void Metric(string component, string metric, long value)
        {
            var snapshot = new OperationalMetricSnapshot(
                component,
                metric,
                value,
                DateTimeOffset.UtcNow);
            _metrics[$"{component}:{metric}"] = snapshot;
        }

        public OperationalTelemetrySnapshot Snapshot()
        {
            var commands = _commands.Values
                .Select(state =>
                {
                    lock (state.Sync)
                        return state.Snapshot();
                })
                .OrderBy(item => item.Command)
                .ToArray();
            var repositories = _repositories.Values
                .Select(state =>
                {
                    lock (state.Sync)
                        return state.Snapshot();
                })
                .OrderBy(item => item.Operation)
                .ThenBy(item => item.QueryId)
                .ToArray();

            return new OperationalTelemetrySnapshot(
                commands,
                repositories,
                _metrics.Values.OrderBy(item => item.Component).ThenBy(item => item.Metric).ToArray(),
                DateTimeOffset.UtcNow);
        }

        private static void WriteApplication(string message)
        {
            try
            {
                var buffer = new ArrayBufferWriter<byte>(256);
                using var writer = new Utf8JsonWriter(buffer);
                WriteHeader(writer, "Information", "Application");
                writer.WriteString("Message", message);
                WriteFooter(writer, buffer);
            }
            catch
            {
                // A escrita de log nunca interrompe o fluxo de negocio.
            }
        }

        private static void WriteCommand(
            string level,
            string commandName,
            string traceId,
            string phase,
            long durationMs,
            int statusCode,
            WorkerCycleTelemetry? workerCycle,
            Exception? exception)
        {
            try
            {
                var buffer = new ArrayBufferWriter<byte>(512);
                using var writer = new Utf8JsonWriter(buffer);
                WriteHeader(writer, level, "Command");
                writer.WriteString("Command", commandName);
                writer.WriteString("TraceId", traceId);
                writer.WriteString("Phase", phase);
                writer.WriteNumber("DurationMs", durationMs);
                writer.WriteNumber("StatusCode", statusCode);
                if (workerCycle is { } cycle)
                {
                    writer.WritePropertyName("WorkerCycle");
                    writer.WriteStartObject();
                    writer.WriteNumber("BatchLimit", cycle.BatchLimit);
                    writer.WriteNumber("Claimed", cycle.Claimed);
                    writer.WriteNumber("Processed", cycle.Processed);
                    writer.WriteNumber("Failed", cycle.Failed);
                    writer.WriteEndObject();
                }

                if (exception is not null)
                {
                    writer.WriteString("ExceptionType", exception.GetType().FullName);
                    writer.WriteString("ExceptionMessage", exception.Message);
                    writer.WriteString("StackTrace", exception.StackTrace);
                }

                WriteFooter(writer, buffer);
            }
            catch
            {
                // A escrita de log nunca interrompe o fluxo de negocio.
            }
        }

        private static void WriteRepository(
            string level,
            string operation,
            string queryId,
            string traceId,
            bool succeeded,
            long durationMs,
            Exception? exception)
        {
            try
            {
                var buffer = new ArrayBufferWriter<byte>(384);
                using var writer = new Utf8JsonWriter(buffer);
                WriteHeader(writer, level, "Repository");
                writer.WriteString("Operation", operation);
                writer.WriteString("QueryId", queryId);
                writer.WriteString("TraceId", traceId);
                writer.WriteBoolean("Succeeded", succeeded);
                writer.WriteNumber("DurationMs", durationMs);
                if (exception is not null)
                {
                    writer.WriteString("ExceptionType", exception.GetType().FullName);
                    writer.WriteString("ExceptionMessage", exception.Message);
                }

                WriteFooter(writer, buffer);
            }
            catch
            {
                // A escrita de log nunca interrompe o fluxo de negocio.
            }
        }

        private static void WriteHeader(Utf8JsonWriter writer, string level, string category)
        {
            writer.WriteStartObject();
            writer.WriteString("TimestampUtc", DateTimeOffset.UtcNow);
            writer.WriteString("Level", level);
            writer.WriteString("Category", category);
            writer.WritePropertyName("Data");
            writer.WriteStartObject();
        }

        private static void WriteFooter(
            Utf8JsonWriter writer,
            ArrayBufferWriter<byte> buffer)
        {
            writer.WriteEndObject();
            writer.WriteEndObject();
            writer.Flush();
            Console.WriteLine(Encoding.UTF8.GetString(buffer.WrittenSpan));
        }

        private bool DetailEnabled(string component, string operation)
        {
            if (_policy is null)
                return _localDetailEnabled;

            try
            {
                var decision = _policy.Evaluate(component, operation);
                return decision.Enabled &&
                       (decision.Level.Equals("Trace", StringComparison.OrdinalIgnoreCase) ||
                        decision.Level.Equals("Debug", StringComparison.OrdinalIgnoreCase) ||
                        !decision.Depth.Equals("D0", StringComparison.OrdinalIgnoreCase));
            }
            catch
            {
                return false;
            }
        }

        private sealed class CommandState
        {
            public CommandState(string command) => Command = command;
            public object Sync { get; } = new();
            public string Command { get; }
            public int Active { get; set; }
            public long Executions { get; set; }
            public long Failures { get; set; }
            public long TotalDurationMs { get; set; }
            public long LastDurationMs { get; set; }
            public bool HasWorkerCycle { get; set; }
            public long BatchLimit { get; set; }
            public long Claimed { get; set; }
            public long Processed { get; set; }
            public long WorkerFailures { get; set; }
            public DateTimeOffset? LastStartedAtUtc { get; set; }
            public DateTimeOffset? LastFinishedAtUtc { get; set; }
            public DateTimeOffset? LastFailureAtUtc { get; set; }
            public int? LastStatusCode { get; set; }
            public CommandTelemetrySnapshot Snapshot()
            {
                IReadOnlyDictionary<string, long> measurements = HasWorkerCycle
                    ? new Dictionary<string, long>
                    {
                        ["BatchLimit"] = BatchLimit,
                        ["Claimed"] = Claimed,
                        ["Processed"] = Processed,
                        ["Failed"] = WorkerFailures
                    }
                    : EmptyMeasurements;

                return new CommandTelemetrySnapshot(
                    Command,
                    Active,
                    Executions,
                    Failures,
                    LastStartedAtUtc,
                    LastFinishedAtUtc,
                    LastFailureAtUtc,
                    LastStatusCode,
                    LastDurationMs,
                    Executions == 0 ? 0 : Math.Round((double)TotalDurationMs / Executions, 2),
                    measurements);
            }
        }

        private static readonly IReadOnlyDictionary<string, long> EmptyMeasurements =
            new Dictionary<string, long>(0);

        private readonly record struct RepositoryKey(string Operation, string QueryId);

        private sealed class RepositoryState
        {
            public RepositoryState(string operation, string queryId)
            {
                Operation = operation;
                QueryId = queryId;
            }

            public object Sync { get; } = new();
            public string Operation { get; }
            public string QueryId { get; }
            public long Executions { get; set; }
            public long Failures { get; set; }
            public long TotalDurationMs { get; set; }
            public long LastDurationMs { get; set; }
            public long MaximumDurationMs { get; set; }
            public DateTimeOffset? LastFinishedAtUtc { get; set; }
            public DateTimeOffset? LastFailureAtUtc { get; set; }

            public RepositoryTelemetrySnapshot Snapshot() => new(
                Operation,
                QueryId,
                Executions,
                Failures,
                LastFinishedAtUtc,
                LastFailureAtUtc,
                LastDurationMs,
                MaximumDurationMs,
                Executions == 0 ? 0 : Math.Round((double)TotalDurationMs / Executions, 2));
        }
    }
}
