using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public sealed record OperationalTelemetrySnapshot(
        IReadOnlyList<CommandTelemetrySnapshot> Commands,
        IReadOnlyList<RepositoryTelemetrySnapshot> Repositories,
        IReadOnlyList<OperationalMetricSnapshot> Metrics,
        DateTimeOffset ObservedAtUtc);

    public readonly record struct OperationalTelemetryDecision(
        bool Enabled,
        string Level,
        string Depth);

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
    }

    public interface ILogger
    {
        void Info(string message);
        void CommandStarted(string commandName);
        void CommandFinished(
            string commandName,
            string traceId,
            bool succeeded,
            long durationMs,
            int statusCode,
            WorkerCycleTelemetry? workerCycle = null);
        void CommandFailed(
            string commandName,
            string traceId,
            Exception ex,
            long durationMs);
        void Repository(
            string operation,
            string queryId,
            string traceId,
            bool succeeded,
            long durationMs,
            Exception? exception = null);
        void Metric(string component, string metric, long value);
        OperationalTelemetrySnapshot Snapshot();
    }
}
