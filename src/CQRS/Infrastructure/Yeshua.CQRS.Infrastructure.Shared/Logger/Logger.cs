using Dominio.Interfaces;
using Dominio.Operational;
using Shared.Operational;
using System.Collections.Concurrent;

namespace Shered.Logger
{
    public sealed class Logger : ILogger
    {
        private readonly ConcurrentDictionary<string, CommandState> _commands = new();
        private readonly ConcurrentDictionary<RepositoryKey, RepositoryState> _repositories = new();
        private readonly ConcurrentQueue<SagaTelemetryEventSnapshot> _sagas = new();
        private readonly ConcurrentDictionary<string, OperationalMetricSnapshot> _metrics = new();
        private readonly IOperationalTelemetryPolicy? _policy;
        private readonly OperationalEvidencePublisher _evidencePublisher;
        private readonly bool _localDetailEnabled = string.Equals(
            Environment.GetEnvironmentVariable("YESHUA_TELEMETRY_DETAIL"),
            "true",
            StringComparison.OrdinalIgnoreCase);

        public Logger()
            : this(null, ConsoleJsonlOperationalLogSink.Instance, null)
        {
        }

        public Logger(IOperationalTelemetryPolicy policy)
            : this(policy, ConsoleJsonlOperationalLogSink.Instance, null)
        {
        }

        public Logger(
            IOperationalTelemetryPolicy? policy,
            IOperationalLogSink logSink,
            IRuntimeIdentityProvider? runtimeIdentityProvider = null)
        {
            _policy = policy;
            _evidencePublisher = new OperationalEvidencePublisher(
                logSink,
                runtimeIdentityProvider?.Current);
        }

        public OperationalTelemetryDecision Evaluate(
            string component,
            string? operation = null,
            string? entity = null,
            string? recordId = null)
            => Evaluate(component, operation, entity, recordId, null);

        public OperationalTelemetryDecision Evaluate(
            string component,
            string? operation,
            string? entity,
            string? recordId,
            string? operationId)
        {
            if (_policy is null)
            {
                return new OperationalTelemetryDecision(
                    true,
                    "Information",
                    "D0");
            }

            try
            {
                return _policy.Evaluate(
                    component,
                    operation,
                    entity,
                    recordId,
                    null,
                    operationId);
            }
            catch
            {
                return new OperationalTelemetryDecision(false, "None", "D0");
            }
        }

        public void Info(string message)
        {
            var telemetry = Evaluate("Application", "Info");
            if (DetailEnabled(telemetry))
                WriteApplication(message, telemetry);
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

        public void CommandStarted(
            string commandName,
            string traceId,
            OperationalTelemetryDecision telemetry,
            OperationalExecutionIdentity executionIdentity = default,
            string? operationalEntityId = null)
        {
            CommandStarted(commandName);
            var envelope = new OperationalEvidenceEnvelope(
                "Command",
                commandName,
                telemetry.Severity,
                telemetry.DiagnosticDepth,
                OperationalTechnicalOutcome.NotEvaluated,
                OperationalBusinessOutcome.NotEvaluated,
                TraceId: traceId,
                RootOperationId: executionIdentity.RootOperationId,
                OperationId: executionIdentity.OperationId,
                ExecutionId: executionIdentity.ExecutionId,
                CausationId: executionIdentity.CausationId,
                OperationalEntityId: operationalEntityId,
                DiagnosticSessionId: telemetry.DiagnosticSessionId,
                AuthorizedFields: telemetry.AuthorizedFields);
            OperationalEvidenceField[] fields =
            [
                new("EventName", "Command.Started"),
                new("Command", commandName),
                new("Phase", "started")
            ];
            _evidencePublisher.Publish(envelope, fields);
        }

        public void CommandFinished(
            string commandName,
            string traceId,
            bool succeeded,
            long durationMs,
            int statusCode,
            WorkerCycleTelemetry? workerCycle,
            OperationalTelemetryDecision telemetry,
            OperationalExecutionIdentity executionIdentity = default,
            string? operationalEntityId = null)
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

            WriteCommand(
                commandName,
                traceId,
                "completed",
                durationMs,
                statusCode,
                workerCycle,
                null,
                telemetry,
                executionIdentity,
                operationalEntityId);
        }

        public void CommandFailed(
            string commandName,
            string traceId,
            Exception ex,
            long durationMs,
            OperationalTelemetryDecision telemetry,
            OperationalExecutionIdentity executionIdentity = default,
            string? operationalEntityId = null)
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
                commandName,
                traceId,
                "exception",
                durationMs,
                500,
                null,
                ex,
                telemetry,
                executionIdentity,
                operationalEntityId);
        }

        public void Repository(
            string operation,
            string queryId,
            string traceId,
            bool succeeded,
            long durationMs,
            bool captureCounter,
            bool emitEvent,
            OperationalTelemetryDecision eventDecision,
            Exception? exception = null,
            OperationalExecutionIdentity executionIdentity = default)
        {
            if (captureCounter)
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
            }

            if (emitEvent)
            {
                WriteRepository(
                    operation,
                    queryId,
                    traceId,
                    succeeded,
                    durationMs,
                    exception,
                    eventDecision,
                    executionIdentity);
            }
        }

        public void DomainValueChanged(
            string entity,
            string field,
            string traceId,
            string? operation,
            string? recordId,
            object? value,
            OperationalDataClassification classification = OperationalDataClassification.Restricted,
            OperationalExecutionIdentity executionIdentity = default)
        {
            var telemetry = _policy?.Evaluate(
                    "DomainTracker",
                    operation,
                    entity,
                    recordId,
                    field,
                    executionIdentity.OperationId)
                ?? Evaluate("DomainTracker", operation, entity, recordId);
            if (!telemetry.Enabled)
                return;

            WriteDomainValueChanged(
                entity,
                field,
                traceId,
                operation,
                recordId,
                value,
                classification,
                telemetry,
                executionIdentity);
        }

        public void Metric(string component, string metric, long value)
        {
            if (!Evaluate(component, metric).Enabled)
                return;

            var snapshot = new OperationalMetricSnapshot(
                component,
                metric,
                value,
                DateTimeOffset.UtcNow);
            _metrics[$"{component}:{metric}"] = snapshot;
        }

        public void Saga(
            string saga,
            string step,
            string correlationId,
            string phase,
            int attempt = 0,
            string? executionId = null,
            string? causationId = null)
        {
            try
            {
                var telemetry = Evaluate("Saga", saga, step, correlationId);
                if (!telemetry.Enabled)
                    return;

                Saga(new SagaOperationalTransition(
                    saga,
                    step,
                    correlationId,
                    phase,
                    attempt,
                    0,
                    phase.Contains("fail", StringComparison.OrdinalIgnoreCase)
                        ? OperationalTechnicalOutcome.Failed
                        : OperationalTechnicalOutcome.Succeeded,
                    OperationalBusinessOutcome.NotEvaluated,
                    telemetry,
                    new OperationalExecutionIdentity(
                        correlationId,
                        saga,
                        executionId,
                        causationId),
                    correlationId,
                    ErrorCode: phase.Contains("fail", StringComparison.OrdinalIgnoreCase)
                        ? phase
                        : null));
            }
            catch
            {
                // A telemetria nunca interrompe a saga.
            }
        }

        public void Saga(SagaOperationalTransition transition)
        {
            try
            {
                if (!transition.Telemetry.Enabled)
                    return;

                var snapshot = new SagaTelemetryEventSnapshot(
                    transition.Saga,
                    transition.Step,
                    transition.CorrelationId,
                    transition.Phase,
                    transition.Attempt,
                    transition.ExecutionIdentity.ExecutionId ?? string.Empty,
                    transition.ExecutionIdentity.CausationId,
                    DateTimeOffset.UtcNow,
                    transition.DurationMs,
                    transition.ExecutionIdentity.RootOperationId,
                    transition.ExecutionIdentity.OperationId,
                    transition.OperationalEntityId,
                    transition.TechnicalOutcome,
                    transition.BusinessOutcome,
                    transition.Dependency,
                    transition.ErrorCode,
                    transition.ErrorSummary,
                    transition.NextExecutionAtUtc);
                _sagas.Enqueue(snapshot);
                while (_sagas.Count > 512)
                    _sagas.TryDequeue(out _);

                WriteSaga(snapshot, transition.Telemetry);
            }
            catch
            {
                // A telemetria nunca interrompe a saga.
            }
        }

        public void Transition(
            OperationalEvidenceTransition transition,
            OperationalTelemetryDecision telemetry)
        {
            try
            {
                if (!telemetry.Enabled)
                    return;

                var failed = transition.TechnicalOutcome is OperationalTechnicalOutcome.Failed
                    or OperationalTechnicalOutcome.TimedOut
                    or OperationalTechnicalOutcome.Unavailable;
                var severity = failed
                    ? OperationalSeverity.Error
                    : transition.BusinessOutcome == OperationalBusinessOutcome.Rejected
                        ? OperationalSeverity.Warning
                        : telemetry.Severity;
                var envelope = new OperationalEvidenceEnvelope(
                    transition.Component,
                    transition.Operation,
                    severity,
                    telemetry.DiagnosticDepth,
                    transition.TechnicalOutcome,
                    transition.BusinessOutcome,
                    RootOperationId: transition.ExecutionIdentity.RootOperationId,
                    OperationId: transition.ExecutionIdentity.OperationId,
                    ExecutionId: transition.ExecutionIdentity.ExecutionId,
                    CausationId: transition.ExecutionIdentity.CausationId,
                    OperationalEntityId: transition.OperationalEntityId,
                    ErrorCode: transition.ErrorCode,
                    DiagnosticSessionId: telemetry.DiagnosticSessionId,
                    AuthorizedFields: telemetry.AuthorizedFields);
                var fields = new List<OperationalEvidenceField>(12)
                {
                    new("EventName", $"{transition.Component}.{transition.Phase}"),
                    new("Phase", transition.Phase),
                    new("DurationMs", transition.DurationMs, OperationalDataClassification.Public),
                    new("Attempt", transition.Attempt, OperationalDataClassification.Public)
                };

                AddOptional(fields, "Entity", transition.Entity);
                AddOptional(fields, "RecordId", transition.RecordId);
                AddOptional(fields, "CorrelationId", transition.CorrelationId);
                AddOptional(fields, "MessageId", transition.MessageId);
                AddOptional(fields, "Dependency", transition.Dependency);
                AddOptional(fields, "ErrorSummary", transition.ErrorSummary);
                if (transition.StatusCode.HasValue)
                {
                    fields.Add(new OperationalEvidenceField(
                        "StatusCode",
                        transition.StatusCode.Value,
                        OperationalDataClassification.Public));
                }

                _evidencePublisher.Publish(envelope, fields.ToArray());
            }
            catch
            {
                // A telemetria nunca interrompe a transicao operacional.
            }
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
                _sagas.ToArray(),
                _metrics.Values.OrderBy(item => item.Component).ThenBy(item => item.Metric).ToArray(),
                DateTimeOffset.UtcNow);
        }

        private void WriteApplication(
            string message,
            OperationalTelemetryDecision telemetry)
        {
            var envelope = new OperationalEvidenceEnvelope(
                "Application",
                "Info",
                telemetry.Severity,
                telemetry.DiagnosticDepth,
                OperationalTechnicalOutcome.NotEvaluated,
                OperationalBusinessOutcome.NotEvaluated,
                DiagnosticSessionId: telemetry.DiagnosticSessionId,
                AuthorizedFields: telemetry.AuthorizedFields);
            OperationalEvidenceField[] fields =
            [
                new("Message", message, OperationalDataClassification.Confidential)
            ];
            _evidencePublisher.Publish(envelope, fields);
        }

        private void WriteCommand(
            string commandName,
            string traceId,
            string phase,
            long durationMs,
            int statusCode,
            WorkerCycleTelemetry? workerCycle,
            Exception? exception,
            OperationalTelemetryDecision telemetry,
            OperationalExecutionIdentity executionIdentity,
            string? operationalEntityId)
        {
            var technicalOutcome = exception is not null || statusCode >= 500
                ? OperationalTechnicalOutcome.Failed
                : OperationalTechnicalOutcome.Succeeded;
            var businessOutcome = statusCode switch
            {
                >= 200 and < 400 => OperationalBusinessOutcome.Accepted,
                >= 400 and < 500 => OperationalBusinessOutcome.Rejected,
                _ => OperationalBusinessOutcome.NotEvaluated
            };
            var severity = technicalOutcome == OperationalTechnicalOutcome.Failed
                ? OperationalSeverity.Error
                : businessOutcome == OperationalBusinessOutcome.Rejected
                    ? OperationalSeverity.Warning
                    : telemetry.Severity;
            var envelope = new OperationalEvidenceEnvelope(
                "Command",
                commandName,
                severity,
                telemetry.DiagnosticDepth,
                technicalOutcome,
                businessOutcome,
                TraceId: traceId,
                RootOperationId: executionIdentity.RootOperationId,
                OperationId: executionIdentity.OperationId,
                ExecutionId: executionIdentity.ExecutionId,
                CausationId: executionIdentity.CausationId,
                OperationalEntityId: operationalEntityId,
                ErrorCode: exception?.GetType().Name ?? (statusCode >= 400 ? statusCode.ToString() : null),
                DiagnosticSessionId: telemetry.DiagnosticSessionId,
                AuthorizedFields: telemetry.AuthorizedFields);

            var fields = new List<OperationalEvidenceField>(12)
            {
                new("EventName", "Command.Completed"),
                new("Command", commandName),
                new("Phase", phase),
                new("DurationMs", durationMs, OperationalDataClassification.Public),
                new("StatusCode", statusCode, OperationalDataClassification.Public)
            };

            if (workerCycle is { } cycle)
            {
                fields.Add(new("BatchLimit", cycle.BatchLimit));
                fields.Add(new("Claimed", cycle.Claimed));
                fields.Add(new("Processed", cycle.Processed));
                fields.Add(new("Failed", cycle.Failed));
            }

            if (exception is not null)
            {
                fields.Add(new("ExceptionType", exception.GetType().FullName));
                fields.Add(new(
                    "ExceptionMessage",
                    exception.Message,
                    OperationalDataClassification.Restricted));
                fields.Add(new(
                    "StackTrace",
                    exception.StackTrace,
                    OperationalDataClassification.Restricted));
            }

            if (exception is not null || statusCode >= 400)
            {
                fields.Add(new(
                    "ErrorSummary",
                    SanitizedErrorSummary(exception, statusCode)));
            }

            _evidencePublisher.Publish(envelope, fields.ToArray());
        }

        private static string SanitizedErrorSummary(Exception? exception, int statusCode)
        {
            if (exception is not null)
                return $"Operation failed with {exception.GetType().Name}.";

            return statusCode >= 500
                ? "Operation returned a technical failure."
                : "Operation was rejected by business validation.";
        }

        private static void AddOptional(
            List<OperationalEvidenceField> fields,
            string name,
            string? value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                fields.Add(new OperationalEvidenceField(name, value));
        }

        private void WriteRepository(
            string operation,
            string queryId,
            string traceId,
            bool succeeded,
            long durationMs,
            Exception? exception,
            OperationalTelemetryDecision telemetry,
            OperationalExecutionIdentity executionIdentity)
        {
            var technicalOutcome = succeeded
                ? OperationalTechnicalOutcome.Succeeded
                : OperationalTechnicalOutcome.Failed;
            var envelope = new OperationalEvidenceEnvelope(
                "Repository",
                operation,
                succeeded ? telemetry.Severity : OperationalSeverity.Error,
                telemetry.DiagnosticDepth,
                technicalOutcome,
                OperationalBusinessOutcome.NotEvaluated,
                TraceId: traceId,
                RootOperationId: executionIdentity.RootOperationId,
                OperationId: executionIdentity.OperationId,
                ExecutionId: executionIdentity.ExecutionId,
                CausationId: executionIdentity.CausationId,
                ErrorCode: exception?.GetType().Name,
                DiagnosticSessionId: telemetry.DiagnosticSessionId,
                AuthorizedFields: telemetry.AuthorizedFields);
            var fields = new List<OperationalEvidenceField>(6)
            {
                new("EventName", "Repository.Completed"),
                new("Dependency", "SQL"),
                new("QueryId", queryId),
                new("Succeeded", succeeded, OperationalDataClassification.Public),
                new("DurationMs", durationMs, OperationalDataClassification.Public)
            };
            if (exception is not null)
            {
                fields.Add(new("ExceptionType", exception.GetType().FullName));
                fields.Add(new(
                    "ExceptionMessage",
                    exception.Message,
                    OperationalDataClassification.Restricted));
                fields.Add(new(
                    "ErrorSummary",
                    $"Repository operation failed with {exception.GetType().Name}."));
            }

            _evidencePublisher.Publish(envelope, fields.ToArray());
        }

        private void WriteSaga(
            SagaTelemetryEventSnapshot snapshot,
            OperationalTelemetryDecision telemetry)
        {
            var failed = snapshot.TechnicalOutcome is OperationalTechnicalOutcome.Failed
                or OperationalTechnicalOutcome.TimedOut
                or OperationalTechnicalOutcome.Unavailable;
            var envelope = new OperationalEvidenceEnvelope(
                "Saga",
                snapshot.Saga,
                failed ? OperationalSeverity.Error : telemetry.Severity,
                telemetry.DiagnosticDepth,
                snapshot.TechnicalOutcome,
                snapshot.BusinessOutcome,
                RootOperationId: snapshot.RootOperationId,
                OperationId: snapshot.OperationId,
                ExecutionId: snapshot.ExecutionId,
                CausationId: snapshot.CausationId,
                OperationalEntityId: snapshot.OperationalEntityId,
                ErrorCode: snapshot.ErrorCode,
                DiagnosticSessionId: telemetry.DiagnosticSessionId,
                AuthorizedFields: telemetry.AuthorizedFields);
            var fields = new List<OperationalEvidenceField>(12)
            {
                new("EventName", $"Saga.{snapshot.Phase}"),
                new("Saga", snapshot.Saga),
                new("Step", snapshot.Step),
                new("CorrelationId", snapshot.CorrelationId),
                new("Phase", snapshot.Phase),
                new("Attempt", snapshot.Attempt, OperationalDataClassification.Public),
                new("DurationMs", snapshot.DurationMs, OperationalDataClassification.Public)
            };

            if (!string.IsNullOrWhiteSpace(snapshot.Dependency))
                fields.Add(new("Dependency", snapshot.Dependency));

            if (!string.IsNullOrWhiteSpace(snapshot.ErrorSummary))
                fields.Add(new("ErrorSummary", snapshot.ErrorSummary));

            if (snapshot.NextExecutionAtUtc is { } nextExecutionAtUtc)
                fields.Add(new("NextExecutionAtUtc", nextExecutionAtUtc));

            _evidencePublisher.Publish(envelope, fields.ToArray());
        }

        private void WriteDomainValueChanged(
            string entity,
            string field,
            string traceId,
            string? operation,
            string? recordId,
            object? value,
            OperationalDataClassification classification,
            OperationalTelemetryDecision telemetry,
            OperationalExecutionIdentity executionIdentity)
        {
            var envelope = new OperationalEvidenceEnvelope(
                "DomainTracker",
                operation ?? "ValueChanged",
                telemetry.Severity,
                telemetry.DiagnosticDepth,
                OperationalTechnicalOutcome.Succeeded,
                OperationalBusinessOutcome.NotEvaluated,
                TraceId: traceId,
                RootOperationId: executionIdentity.RootOperationId,
                OperationId: executionIdentity.OperationId,
                ExecutionId: executionIdentity.ExecutionId,
                CausationId: executionIdentity.CausationId,
                OperationalEntityId: recordId,
                DiagnosticSessionId: telemetry.DiagnosticSessionId,
                AuthorizedFields: telemetry.AuthorizedFields);
            var valueClassification = OperationalEvidenceProtection.IsForbiddenName(field)
                ? OperationalDataClassification.NeverCapture
                : classification;
            OperationalEvidenceField[] fields =
            [
                new("Entity", entity),
                new("Field", field),
                new("Value", value, valueClassification)
            ];
            _evidencePublisher.Publish(envelope, fields);
        }

        private bool DetailEnabled(OperationalTelemetryDecision decision)
        {
            if (_policy is null)
                return _localDetailEnabled;

            return decision.Enabled &&
                   (decision.Level.Equals("Trace", StringComparison.OrdinalIgnoreCase) ||
                    decision.Level.Equals("Debug", StringComparison.OrdinalIgnoreCase) ||
                    !decision.Depth.Equals("D0", StringComparison.OrdinalIgnoreCase));
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
