using Command.Patterns;
using IRepository.Read;
using Microsoft.Extensions.Configuration;
using RepositoryInterfaces.Patterns.Worker;

namespace Worker.Custon;

public sealed class SagaQueueHealthProbe
    : IWorkerQueueHealthProbe<SagaWorkerCommandHandler, InputCommand>
{
    private readonly IySagaReadRepository _repository;
    private readonly WorkerQueueItemHealthThresholds _thresholds;

    public SagaQueueHealthProbe(
        IySagaReadRepository repository,
        IConfiguration configuration)
    {
        _repository = repository;
        _thresholds = new WorkerQueueItemHealthThresholds(
            ExcessiveWaitSeconds: Math.Clamp(
                configuration.GetValue<long?>("YeshuaQueueHealth:Item:ExcessiveWaitSeconds") ?? 900,
                60,
                86_400),
            ProcessingStuckSeconds: Math.Clamp(
                configuration.GetValue<long?>("YeshuaQueueHealth:Item:ProcessingStuckSeconds") ?? 120,
                60,
                3_600),
            RecurrentExecutionCount: Math.Clamp(
                configuration.GetValue<int?>("YeshuaQueueHealth:Item:RecurrentExecutionCount") ?? 3,
                2,
                100),
            RepeatedFailureCount: Math.Clamp(
                configuration.GetValue<int?>("YeshuaQueueHealth:Item:RepeatedFailureCount") ?? 2,
                1,
                100));
    }

    public string QueueName => "Memorias.Saga";

    public WorkerQueueHealthSnapshot Capture() =>
        _repository.GetRunnableSagaHealth(_thresholds);

    public IReadOnlyList<WorkerQueueSickItem> CaptureSickItems(int limit) =>
        _repository.GetSickSagaItems(_thresholds, limit);
}
