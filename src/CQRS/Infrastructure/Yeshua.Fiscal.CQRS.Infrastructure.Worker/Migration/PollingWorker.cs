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

    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<PollingWorker<TReceiver, TCommand, TResponse>> _logger;
    private readonly TimeSpan _interval;
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
        }
        catch
        {
            OperationalMetrics.SetQueueHealthProbeFailure(probe.QueueName, WorkerOperation);
        }
    }

}
