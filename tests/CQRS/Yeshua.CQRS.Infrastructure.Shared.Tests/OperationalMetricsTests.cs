using Dominio.Interfaces;
using Dominio.Operational;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Operational;
using System.Collections.Concurrent;
using System.Diagnostics.Metrics;

namespace Yeshua.CQRS.Infrastructure.Shared.Tests;

[TestClass]
public sealed class OperationalMetricsTests
{
    [TestMethod]
    public void Command_EmitsExecutionDurationActiveAndWorkerMetrics()
    {
        var operation = $"Command-{Guid.NewGuid():N}";
        using var capture = new MetricCapture();

        OperationalMetrics.CommandStarted(operation);
        OperationalMetrics.CommandCompleted(
            operation,
            125,
            OperationalTechnicalOutcome.Succeeded,
            OperationalBusinessOutcome.Accepted,
            new WorkerCycleTelemetry(20, 4, 3, 1));

        Assert.AreEqual(1L, capture.SumLong("yeshua.operation.executions", operation));
        Assert.AreEqual(0L, capture.SumLong("yeshua.operation.active", operation));
        Assert.AreEqual(1L, capture.SumLong("yeshua.worker.cycles", operation));
        Assert.AreEqual(0L, capture.SumLong("yeshua.worker.saturated.cycles", operation));
        Assert.AreEqual(20L, capture.SumLong("yeshua.worker.items", operation, "batch_limit"));
        Assert.AreEqual(4L, capture.SumLong("yeshua.worker.items", operation, "claimed"));
        Assert.AreEqual(3L, capture.SumLong("yeshua.worker.items", operation, "processed"));
        Assert.AreEqual(1L, capture.SumLong("yeshua.worker.items", operation, "failed"));
        Assert.AreEqual(125D, capture.SingleDouble("yeshua.operation.duration", operation));

        var execution = capture.Single("yeshua.operation.executions", operation);
        Assert.AreEqual("Command", execution.Tags["component"]);
        Assert.AreEqual("succeeded", execution.Tags["outcome"]);
        Assert.AreEqual("accepted", execution.Tags["business_outcome"]);

        capture.CollectObservableInstruments();
        Assert.AreEqual(20L, capture.SingleByState("yeshua.worker.current", operation, "batch_limit").LongValue);
        Assert.AreEqual(4L, capture.SingleByState("yeshua.worker.current", operation, "claimed").LongValue);
        Assert.AreEqual(3L, capture.SingleByState("yeshua.worker.current", operation, "processed").LongValue);
        Assert.AreEqual(1L, capture.SingleByState("yeshua.worker.current", operation, "failed").LongValue);
    }

    [TestMethod]
    public void Repository_UsesOnlyBoundedOperationalTags()
    {
        var operation = $"Repository-{Guid.NewGuid():N}";
        using var capture = new MetricCapture();

        OperationalMetrics.RepositoryCompleted(
            operation,
            42,
            OperationalTechnicalOutcome.Failed);

        var execution = capture.Single("yeshua.operation.executions", operation);
        CollectionAssert.AreEquivalent(
            new[] { "component", "operation", "outcome", "business_outcome" },
            execution.Tags.Keys.ToArray());
        Assert.AreEqual("Repository", execution.Tags["component"]);
        Assert.AreEqual("failed", execution.Tags["outcome"]);
    }

    [TestMethod]
    public void WorkerCycle_ReachingBatchLimit_EmitsBacklogPressureSignal()
    {
        var operation = $"Worker-{Guid.NewGuid():N}";
        using var capture = new MetricCapture();

        OperationalMetrics.CommandCompleted(
            operation,
            10,
            OperationalTechnicalOutcome.Succeeded,
            OperationalBusinessOutcome.Accepted,
            new WorkerCycleTelemetry(4, 4, 4, 0));

        Assert.AreEqual(1L, capture.SumLong("yeshua.worker.cycles", operation));
        Assert.AreEqual(1L, capture.SumLong("yeshua.worker.saturated.cycles", operation));
    }

    [TestMethod]
    public void CurrentValue_ExportsLatestValueAsObservableGauge()
    {
        var metric = $"backlog-{Guid.NewGuid():N}";
        using var capture = new MetricCapture();

        OperationalMetrics.SetCurrentValue("Worker", metric, 8);
        OperationalMetrics.SetCurrentValue("Worker", metric, 5);
        capture.CollectObservableInstruments();

        var measurement = capture.SingleByMetric("yeshua.operational.current", metric);
        Assert.AreEqual(5L, measurement.LongValue);
        Assert.AreEqual("Worker", measurement.Tags["component"]);
    }

    [TestMethod]
    public void WorkerHealth_ExportsOnlyTheLatestRuntimeState()
    {
        var operation = $"WorkerHealth-{Guid.NewGuid():N}";
        using var capture = new MetricCapture();

        OperationalMetrics.WorkerCycleStarted(operation);
        OperationalMetrics.WorkerCycleCompleted(operation, succeeded: true, claimed: 0);
        OperationalMetrics.WorkerCycleStarted(operation);
        OperationalMetrics.WorkerCycleCompleted(operation, succeeded: true, claimed: 0);
        capture.CollectObservableInstruments();

        Assert.AreEqual(
            0L,
            capture.SingleByState("yeshua.worker.current", operation, "cycle_in_progress").LongValue);
        Assert.AreEqual(
            2L,
            capture.SingleByState("yeshua.worker.current", operation, "consecutive_empty_cycles").LongValue);
        Assert.IsTrue(
            capture.SingleByState("yeshua.worker.current", operation, "last_heartbeat_unix_seconds").LongValue > 0);
        Assert.IsTrue(
            capture.SingleByState("yeshua.worker.current", operation, "last_cycle_started_unix_seconds").LongValue > 0);
        Assert.IsTrue(
            capture.SingleByState("yeshua.worker.current", operation, "last_cycle_completed_unix_seconds").LongValue > 0);
        Assert.IsTrue(
            capture.SingleByState("yeshua.worker.current", operation, "last_success_unix_seconds").LongValue > 0);
    }

    [TestMethod]
    public void WorkerHealth_WorkResetsConsecutiveEmptyCycles()
    {
        var operation = $"WorkerHealthReset-{Guid.NewGuid():N}";
        using var capture = new MetricCapture();

        OperationalMetrics.WorkerCycleStarted(operation);
        OperationalMetrics.WorkerCycleCompleted(operation, succeeded: true, claimed: 0);
        OperationalMetrics.WorkerCycleStarted(operation);
        OperationalMetrics.WorkerCycleCompleted(operation, succeeded: true, claimed: 3);
        capture.CollectObservableInstruments();

        Assert.AreEqual(
            0L,
            capture.SingleByState("yeshua.worker.current", operation, "consecutive_empty_cycles").LongValue);
    }

    [TestMethod]
    public void QueueHealth_ExportsOnlyTheLatestSnapshot()
    {
        var queue = $"Queue-{Guid.NewGuid():N}";
        var operation = $"Operation-{Guid.NewGuid():N}";
        using var capture = new MetricCapture();

        OperationalMetrics.SetQueueHealthSnapshot(queue, operation, 12, 90);
        OperationalMetrics.SetQueueHealthSnapshot(queue, operation, 7, 120);
        capture.CollectObservableInstruments();

        Assert.AreEqual(
            7L,
            capture.SingleByQueueMetric("yeshua.queue.current", queue, "eligible_backlog").LongValue);
        Assert.AreEqual(
            120L,
            capture.SingleByQueueMetric("yeshua.queue.current", queue, "oldest_eligible_age_seconds").LongValue);
        Assert.AreEqual(
            0L,
            capture.SingleByQueueMetric("yeshua.queue.current", queue, "sample_failed").LongValue);
        Assert.AreEqual(
            operation,
            capture.SingleByQueueMetric("yeshua.queue.current", queue, "eligible_backlog").Tags["operation"]);
    }

    [TestMethod]
    public void QueueHealth_SuccessfulSnapshotClearsPreviousProbeFailure()
    {
        var queue = $"QueueFailure-{Guid.NewGuid():N}";
        var operation = $"OperationFailure-{Guid.NewGuid():N}";
        using var capture = new MetricCapture();

        OperationalMetrics.SetQueueHealthProbeFailure(queue, operation);
        OperationalMetrics.SetQueueHealthSnapshot(queue, operation, 2, 30);
        capture.CollectObservableInstruments();

        Assert.AreEqual(
            0L,
            capture.SingleByQueueMetric("yeshua.queue.current", queue, "sample_failed").LongValue);
    }

    [TestMethod]
    public void SagaRetry_EmitsOneRetryAndMeasuresTheStepOutcome()
    {
        var saga = $"Saga-{Guid.NewGuid():N}";
        var step = "EmitirDocumento";
        var operation = $"{saga}.{step}";
        using var capture = new MetricCapture();

        OperationalMetrics.SagaTransition(
            saga,
            step,
            "RetryScheduled",
            250,
            OperationalTechnicalOutcome.Failed,
            OperationalBusinessOutcome.NotEvaluated);

        Assert.AreEqual(1L, capture.SumLong("yeshua.saga.retries", saga, step));
        Assert.AreEqual(1L, capture.SumLong("yeshua.operation.executions", operation));
        Assert.AreEqual(250D, capture.SingleDouble("yeshua.operation.duration", operation));
    }

    [TestMethod]
    public void DisabledDecision_DoesNotEnterTheMetricsHotPath()
    {
        var operation = $"Disabled-{Guid.NewGuid():N}";
        var logger = new Shered.Logger.Logger(null, NoOpLogSink.Instance);
        var disabled = new OperationalTelemetryDecision(false, "None", "D0");
        using var capture = new MetricCapture();

        logger.CommandStarted(operation, "trace", disabled);
        logger.CommandFinished(operation, "trace", true, 10, 200, null, disabled);

        Assert.AreEqual(0L, capture.SumLong("yeshua.operation.executions", operation));
        Assert.AreEqual(0L, capture.SumLong("yeshua.operation.active", operation));
    }

    [TestMethod]
    public void BusinessRejection_DoesNotBecomeTechnicalFailure()
    {
        var operation = $"Rejected-{Guid.NewGuid():N}";
        var logger = new Shered.Logger.Logger(null, NoOpLogSink.Instance);
        var enabled = new OperationalTelemetryDecision(true, "Information", "D0");
        using var capture = new MetricCapture();

        logger.CommandStarted(operation, "trace", enabled);
        logger.CommandFinished(operation, "trace", false, 10, 422, null, enabled);

        var execution = capture.Single("yeshua.operation.executions", operation);
        Assert.AreEqual("succeeded", execution.Tags["outcome"]);
        Assert.AreEqual("rejected", execution.Tags["business_outcome"]);
    }

    private sealed class MetricCapture : IDisposable
    {
        private readonly ConcurrentQueue<CapturedMeasurement> _measurements = new();
        private readonly MeterListener _listener = new();

        public MetricCapture()
        {
            _listener.InstrumentPublished = (instrument, listener) =>
            {
                if (instrument.Meter.Name == OperationalMetrics.MeterName)
                    listener.EnableMeasurementEvents(instrument);
            };
            _listener.SetMeasurementEventCallback<long>((instrument, value, tags, _) =>
                _measurements.Enqueue(Capture(instrument, value, null, tags)));
            _listener.SetMeasurementEventCallback<double>((instrument, value, tags, _) =>
                _measurements.Enqueue(Capture(instrument, null, value, tags)));
            _listener.Start();
        }

        public void CollectObservableInstruments() => _listener.RecordObservableInstruments();

        public long SumLong(string instrument, string operation, string? state = null) =>
            Matches(instrument, operation, state).Sum(value => value.LongValue ?? 0);

        public double SingleDouble(string instrument, string operation) =>
            Matches(instrument, operation, null).Single().DoubleValue ?? 0;

        public CapturedMeasurement Single(string instrument, string operation) =>
            Matches(instrument, operation, null).Single();

        public CapturedMeasurement SingleByMetric(string instrument, string metric) =>
            _measurements.Single(value =>
                value.Instrument == instrument &&
                value.Tags.TryGetValue("metric", out var capturedMetric) &&
                capturedMetric == metric);

        public CapturedMeasurement SingleByState(
            string instrument,
            string operation,
            string state) =>
            _measurements.Single(value =>
                value.Instrument == instrument &&
                value.Tags.TryGetValue("operation", out var capturedOperation) &&
                capturedOperation == operation &&
                value.Tags.TryGetValue("state", out var capturedState) &&
                capturedState == state);

        public CapturedMeasurement SingleByQueueMetric(
            string instrument,
            string queue,
            string metric) =>
            _measurements.Single(value =>
                value.Instrument == instrument &&
                value.Tags.TryGetValue("queue", out var capturedQueue) &&
                capturedQueue == queue &&
                value.Tags.TryGetValue("metric", out var capturedMetric) &&
                capturedMetric == metric);

        public void Dispose() => _listener.Dispose();

        private IEnumerable<CapturedMeasurement> Matches(
            string instrument,
            string operation,
            string? state)
        {
            return _measurements.Where(value =>
                value.Instrument == instrument &&
                ((value.Tags.TryGetValue("operation", out var capturedOperation) &&
                  capturedOperation == operation &&
                  (state is null ||
                   value.Tags.TryGetValue("state", out var capturedState) && capturedState == state)) ||
                 (value.Tags.TryGetValue("saga", out var capturedSaga) &&
                  capturedSaga == operation &&
                  state is not null &&
                  value.Tags.TryGetValue("step", out var capturedStep) && capturedStep == state)));
        }

        private static CapturedMeasurement Capture(
            Instrument instrument,
            long? longValue,
            double? doubleValue,
            ReadOnlySpan<KeyValuePair<string, object?>> tags)
        {
            return new CapturedMeasurement(
                instrument.Name,
                longValue,
                doubleValue,
                tags.ToArray().ToDictionary(
                    tag => tag.Key,
                    tag => tag.Value?.ToString() ?? string.Empty,
                    StringComparer.Ordinal));
        }
    }

    private sealed record CapturedMeasurement(
        string Instrument,
        long? LongValue,
        double? DoubleValue,
        IReadOnlyDictionary<string, string> Tags);

    private sealed class NoOpLogSink : IOperationalLogSink
    {
        public static readonly NoOpLogSink Instance = new();

        public void Write(string level, string category, ReadOnlySpan<byte> payload)
        {
        }
    }
}
