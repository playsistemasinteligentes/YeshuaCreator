using Dominio.Operational;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Worker;
using Shared.Operational;

namespace Worker.Custon;

public sealed class PollingWorker<TReceiver, TCommand, TResponse> : BackgroundService
    where TReceiver : class, IReceiver<TCommand, TResponse>
    where TCommand : class, ICommand, new()
{
    private static readonly string WorkerOperation =
        typeof(TCommand).FullName ?? typeof(TCommand).Name;
    private static readonly long QueueHealthProbeIntervalMs =
        (long)TimeSpan.FromSeconds(30).TotalMilliseconds;
    private const int SickItemEvidenceLimit = 25;
    private const int ReportedSickItemCapacity = 100;

    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<PollingWorker<TReceiver, TCommand, TResponse>> _logger;
    private readonly TimeSpan _interval;
    private readonly Dictionary<string, string> _reportedSickItems =
        new(StringComparer.Ordinal);
    private readonly Dictionary<string, WorkerQueueSickItem> _reportedSickItemDetails =
        new(StringComparer.Ordinal);
    private long _nextQueueHealthProbeAt;

    public PollingWorker(
        IServiceProvider serviceProvider,
        ILogger<PollingWorker<TReceiver, TCommand, TResponse>> logger,
        TimeSpan interval)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _interval = interval;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var workerName = typeof(TReceiver).Name;
        _logger.LogInformation("Worker {Worker} iniciado.", workerName);

        while (!stoppingToken.IsCancellationRequested)
        {
            OperationalMetrics.WorkerCycleStarted(WorkerOperation);
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var receiver = scope.ServiceProvider.GetRequiredService<TReceiver>();
                var result = await receiver.ExecuteAsync(new TCommand(), stoppingToken);
                var claimed = result.Data is IWorkerCycleResult progress
                    ? progress.Claimed
                    : (int?)null;
                OperationalMetrics.WorkerCycleCompleted(
                    WorkerOperation,
                    result.StatusCode < 500,
                    claimed);
                CaptureQueueHealthIfDue(scope.ServiceProvider);
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                OperationalMetrics.WorkerCycleAborted(WorkerOperation);
                break;
            }
            catch (Exception)
            {
                OperationalMetrics.WorkerCycleCompleted(
                    WorkerOperation,
                    succeeded: false,
                    claimed: null);
                // A excecao do Command ja foi registrada pelo ReciverBase.
            }

            await Task.Delay(_interval, stoppingToken);
        }
    }

    private void CaptureQueueHealthIfDue(IServiceProvider services)
    {
        if (!OperationalMetrics.QueueHealthEnabled)
            return;

        var now = Environment.TickCount64;
        var next = Volatile.Read(ref _nextQueueHealthProbeAt);
        if (now < next ||
            Interlocked.CompareExchange(
                ref _nextQueueHealthProbeAt,
                now + QueueHealthProbeIntervalMs,
                next) != next)
        {
            return;
        }

        var probe = services.GetService<IWorkerQueueHealthProbe<TReceiver, TCommand>>();
        if (probe is null)
            return;

        try
        {
            var snapshot = probe.Capture();
            OperationalMetrics.SetQueueHealthSnapshot(
                probe.QueueName,
                WorkerOperation,
                snapshot.EligibleCount,
                snapshot.OldestEligibleAgeSeconds);
            OperationalMetrics.SetQueueItemHealthSnapshot(
                probe.QueueName,
                WorkerOperation,
                snapshot.SickItemCount,
                snapshot.ExcessiveWaitCount,
                snapshot.StaleProcessingCount,
                snapshot.RecurrentExecutionCount,
                snapshot.RepeatedFailureCount,
                snapshot.TerminalFailureCount);
            PublishSickItemEvidence(probe, snapshot.SickItemCount);
        }
        catch
        {
            OperationalMetrics.SetQueueHealthProbeFailure(probe.QueueName, WorkerOperation);
        }
    }

    private void PublishSickItemEvidence(
        IWorkerQueueHealthProbe<TReceiver, TCommand> probe,
        long sickItemCount)
    {
        if (sickItemCount <= 0)
        {
            PublishRecoveredSickItems(probe, [.. _reportedSickItems.Keys]);
            return;
        }

        var items = probe.CaptureSickItems(SickItemEvidenceLimit);
        if (items.Count == 0)
            return;

        OperationalEvidencePublisher? evidencePublisher = null;
        HashSet<string>? currentItems = sickItemCount <= SickItemEvidenceLimit &&
            items.Count == sickItemCount
                ? new HashSet<string>(StringComparer.Ordinal)
                : null;

        foreach (var item in items)
        {
            var key = $"{probe.QueueName}|{item.TenantId}|{item.ItemType}|{item.ItemReference}";
            currentItems?.Add(key);

            var state = $"{(int)item.Disease}|{item.ExecutionCount}|{item.RetryCount}|" +
                $"{item.LastOutcome}|{item.ErrorSignature}|{item.FailureCategory}|" +
                $"{item.FailureNature}|{item.FailureTransience}|{item.FailureOrigin}|" +
                $"{item.FailureRetryable}|{item.FailureCode}|{item.OperationalEntityId}|" +
                $"{item.RootOperationId}|{item.ExecutionId}";
            if (_reportedSickItems.TryGetValue(key, out var previousState) &&
                string.Equals(previousState, state, StringComparison.Ordinal))
            {
                _reportedSickItemDetails[key] = item;
                continue;
            }

            if (_reportedSickItems.Count >= ReportedSickItemCapacity &&
                !_reportedSickItems.ContainsKey(key))
            {
                _reportedSickItems.Clear();
                _reportedSickItemDetails.Clear();
            }

            _reportedSickItems[key] = state;
            _reportedSickItemDetails[key] = item;
            evidencePublisher ??=
                _serviceProvider.GetRequiredService<OperationalEvidencePublisher>();
            PublishSickItemHealthChanged(probe, item, evidencePublisher);
        }

        if (currentItems is null)
            return;

        List<string>? recoveredItems = null;
        foreach (var key in _reportedSickItems.Keys)
        {
            if (currentItems.Contains(key))
                continue;

            recoveredItems ??= [];
            recoveredItems.Add(key);
        }

        if (recoveredItems is null)
            return;

        PublishRecoveredSickItems(probe, recoveredItems);
    }

    private static void PublishSickItemHealthChanged(
        IWorkerQueueHealthProbe<TReceiver, TCommand> probe,
        WorkerQueueSickItem item,
        OperationalEvidencePublisher evidencePublisher)
    {
        var technicalOutcome = item.FailureCategory switch
        {
            "Technical" => OperationalTechnicalOutcome.Failed,
            "Business" => OperationalTechnicalOutcome.Succeeded,
            _ => OperationalTechnicalOutcome.NotEvaluated
        };
        var businessOutcome = item.FailureCategory == "Business"
            ? OperationalBusinessOutcome.Rejected
            : OperationalBusinessOutcome.NotEvaluated;

        var envelope = new OperationalEvidenceEnvelope(
            "QueueItemHealth",
            WorkerOperation,
            OperationalEvidenceAxes.ParseSeverity(item.Severity),
            OperationalDepth.D0,
            technicalOutcome,
            businessOutcome,
            RootOperationId: item.RootOperationId,
            ExecutionId: item.ExecutionId,
            OperationalEntityId: item.OperationalEntityId);
        OperationalEvidenceField[] fields =
        [
            new("EventName", "QueueItem.HealthChanged"),
            new("TenantId", item.TenantId),
            new("Queue", probe.QueueName),
            new("ItemType", item.ItemType),
            new("ItemReference", item.ItemReference),
            new("Disease", item.Disease.ToString()),
            new("Severity", item.Severity),
            new("EligibleAgeSeconds", item.EligibleAgeSeconds),
            new("ProcessingAgeSeconds", item.ProcessingAgeSeconds),
            new("ExecutionCount", item.ExecutionCount),
            new("RetryCount", item.RetryCount),
            new("LastOutcome", item.LastOutcome),
            new("FailureCategory", item.FailureCategory),
            new("FailureNature", item.FailureNature),
            new("FailureTransience", item.FailureTransience),
            new("FailureOrigin", item.FailureOrigin),
            new("FailureRetryable", item.FailureRetryable),
            new("FailureCode", item.FailureCode),
            new("ErrorSignature", item.ErrorSignature)
        ];
        evidencePublisher.Publish(envelope, fields);
    }

    private void PublishRecoveredSickItems(
        IWorkerQueueHealthProbe<TReceiver, TCommand> probe,
        IReadOnlyCollection<string> recoveredItems)
    {
        if (recoveredItems.Count == 0)
            return;

        OperationalEvidencePublisher? evidencePublisher = null;
        foreach (var key in recoveredItems)
        {
            if (!_reportedSickItemDetails.TryGetValue(key, out var item))
            {
                _reportedSickItems.Remove(key);
                continue;
            }

            evidencePublisher ??=
                _serviceProvider.GetRequiredService<OperationalEvidencePublisher>();
            var envelope = new OperationalEvidenceEnvelope(
                "QueueItemHealth",
                WorkerOperation,
                OperationalSeverity.Information,
                OperationalDepth.D0,
                OperationalTechnicalOutcome.Succeeded,
                OperationalBusinessOutcome.NotEvaluated,
                RootOperationId: item.RootOperationId,
                ExecutionId: item.ExecutionId,
                OperationalEntityId: item.OperationalEntityId);
            OperationalEvidenceField[] fields =
            [
                new("EventName", "QueueItem.HealthChanged"),
                new("TenantId", item.TenantId),
                new("Queue", probe.QueueName),
                new("ItemType", item.ItemType),
                new("ItemReference", item.ItemReference),
                new("Disease", WorkerQueueItemDisease.None.ToString()),
                new("Severity", "information"),
                new("EligibleAgeSeconds", 0),
                new("ProcessingAgeSeconds", 0),
                new("ExecutionCount", item.ExecutionCount),
                new("RetryCount", item.RetryCount),
                new("LastOutcome", "Recovered"),
                new("FailureCategory", item.FailureCategory),
                new("FailureNature", item.FailureNature),
                new("FailureTransience", item.FailureTransience),
                new("FailureOrigin", item.FailureOrigin),
                new("FailureRetryable", item.FailureRetryable),
                new("FailureCode", item.FailureCode),
                new("ErrorSignature", item.ErrorSignature)
            ];
            evidencePublisher.Publish(envelope, fields);
            _reportedSickItems.Remove(key);
            _reportedSickItemDetails.Remove(key);
        }
    }

}