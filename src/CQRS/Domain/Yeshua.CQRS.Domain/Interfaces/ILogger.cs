using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio.Operational;

namespace Dominio.Interfaces
{
    public sealed record CommandTelemetrySnapshot(
        string Command,
        int Active,
        long Executions,
        long Failures,
        DateTimeOffset? LastStartedAtUtc,
        DateTimeOffset? LastFinishedAtUtc,
        DateTimeOffset? LastFailureAtUtc,
        int? LastStatusCode,
        long LastDurationMs,
        double AverageDurationMs,
        IReadOnlyDictionary<string, long> Measurements);

    public sealed record RepositoryTelemetrySnapshot(
        string Operation,
        string QueryId,
        long Executions,
        long Failures,
        DateTimeOffset? LastFinishedAtUtc,
        DateTimeOffset? LastFailureAtUtc,
        long LastDurationMs,
        long MaximumDurationMs,
        double AverageDurationMs);

    public sealed record OperationalMetricSnapshot(
        string Component,
        string Metric,
        long Value,
        DateTimeOffset ObservedAtUtc);

    public sealed record SagaTelemetryEventSnapshot(
        string Saga,
        string Step,
        string CorrelationId,
        string Phase,
        int Attempt,
        string ExecutionId,
        string? CausationId,
        DateTimeOffset ObservedAtUtc,
        long DurationMs = 0,
        string? RootOperationId = null,
        string? OperationId = null,
        string? OperationalEntityId = null,
        OperationalTechnicalOutcome TechnicalOutcome = OperationalTechnicalOutcome.NotEvaluated,
        OperationalBusinessOutcome BusinessOutcome = OperationalBusinessOutcome.NotEvaluated,
        string? Dependency = null,
        string? ErrorCode = null,
        string? ErrorSummary = null,
        DateTimeOffset? NextExecutionAtUtc = null);

    public readonly record struct SagaOperationalTransition(
        string Saga,
        string Step,
        string CorrelationId,
        string Phase,
        int Attempt,
        long DurationMs,
        OperationalTechnicalOutcome TechnicalOutcome,
        OperationalBusinessOutcome BusinessOutcome,
        OperationalTelemetryDecision Telemetry,
        OperationalExecutionIdentity ExecutionIdentity,
        string? OperationalEntityId = null,
        string? Dependency = null,
        string? ErrorCode = null,
        string? ErrorSummary = null,
        DateTimeOffset? NextExecutionAtUtc = null);

    public sealed record OperationalTelemetrySnapshot(
        IReadOnlyList<CommandTelemetrySnapshot> Commands,
        IReadOnlyList<RepositoryTelemetrySnapshot> Repositories,
        IReadOnlyList<SagaTelemetryEventSnapshot> Sagas,
        IReadOnlyList<OperationalMetricSnapshot> Metrics,
        DateTimeOffset ObservedAtUtc);

    public readonly record struct OperationalTelemetryDecision(
        bool Enabled,
        string Level,
        string Depth,
        string Mode = "Live")
    {
        public OperationalSeverity Severity => OperationalEvidenceAxes.ParseSeverity(Level);
        public OperationalDepth DiagnosticDepth => OperationalEvidenceAxes.ParseDepth(Depth);
        public OperationalExecutionMode ExecutionMode => OperationalEvidenceAxes.ParseMode(Mode);
    }

    public readonly record struct WorkerCycleTelemetry(
        int BatchLimit,
        int Claimed,
        int Processed,
        int Failed);

    public interface IOperationalTelemetryPolicy
    {
        OperationalTelemetryDecision Evaluate(
            string component,
            string? operation = null,
            string? entity = null,
            string? recordId = null);

        OperationalTelemetryDecision Evaluate(
            string component,
            string? operation,
            string? entity,
            string? recordId,
            string? field)
            => Evaluate(component, operation, entity, recordId);
    }

    public interface IDomainTrackingPolicy
    {
        ulong GetMask(
            string entity,
            string? operation = null,
            string? recordId = null);
    }

    public interface ILogger
    {
        OperationalTelemetryDecision Evaluate(
            string component,
            string? operation = null,
            string? entity = null,
            string? recordId = null);
        void Info(string message);
        void CommandStarted(string commandName);
        void CommandStarted(
            string commandName,
            string traceId,
            OperationalTelemetryDecision telemetry,
            OperationalExecutionIdentity executionIdentity = default,
            string? operationalEntityId = null)
            => CommandStarted(commandName);
        void CommandFinished(
            string commandName,
            string traceId,
            bool succeeded,
            long durationMs,
            int statusCode,
            WorkerCycleTelemetry? workerCycle = null)
            => CommandFinished(
                commandName,
                traceId,
                succeeded,
                durationMs,
                statusCode,
                workerCycle,
                Evaluate("Command", commandName));
        void CommandFinished(
            string commandName,
            string traceId,
            bool succeeded,
            long durationMs,
            int statusCode,
            WorkerCycleTelemetry? workerCycle,
            OperationalTelemetryDecision telemetry,
            OperationalExecutionIdentity executionIdentity = default,
            string? operationalEntityId = null);
        void CommandFailed(
            string commandName,
            string traceId,
            Exception ex,
            long durationMs)
            => CommandFailed(
                commandName,
                traceId,
                ex,
                durationMs,
                Evaluate("Command", commandName));
        void CommandFailed(
            string commandName,
            string traceId,
            Exception ex,
            long durationMs,
            OperationalTelemetryDecision telemetry,
            OperationalExecutionIdentity executionIdentity = default,
            string? operationalEntityId = null);
        void Repository(
            string operation,
            string queryId,
            string traceId,
            bool succeeded,
            long durationMs,
            bool captureCounter,
            bool emitEvent,
            OperationalTelemetryDecision eventDecision,
            Exception? exception = null,
            OperationalExecutionIdentity executionIdentity = default);
        void DomainValueChanged(
            string entity,
            string field,
            string traceId,
            string? operation,
            string? recordId,
            object? value,
            OperationalDataClassification classification = OperationalDataClassification.Restricted,
            OperationalExecutionIdentity executionIdentity = default);
        void Saga(
            string saga,
            string step,
            string correlationId,
            string phase,
            int attempt = 0,
            string? executionId = null,
            string? causationId = null);
        void Saga(SagaOperationalTransition transition) =>
            Saga(
                transition.Saga,
                transition.Step,
                transition.CorrelationId,
                transition.Phase,
                transition.Attempt,
                transition.ExecutionIdentity.ExecutionId,
                transition.ExecutionIdentity.CausationId);
        void Transition(
            OperationalEvidenceTransition transition,
            OperationalTelemetryDecision telemetry)
        {
        }
        void Metric(string component, string metric, long value);
        OperationalTelemetrySnapshot Snapshot();
    }
}
