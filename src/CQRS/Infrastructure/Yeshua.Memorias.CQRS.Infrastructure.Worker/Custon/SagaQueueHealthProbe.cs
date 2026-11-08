using Command.Patterns;
using IRepository.Read;
using RepositoryInterfaces.Patterns.Worker;

namespace Worker.Custon;

public sealed class SagaQueueHealthProbe
    : IWorkerQueueHealthProbe<SagaWorkerCommandHandler, InputCommand>
{
    private readonly IySagaReadRepository _repository;

    public SagaQueueHealthProbe(IySagaReadRepository repository)
    {
        _repository = repository;
    }

    public string QueueName => "Memorias.Saga";

    public WorkerQueueHealthSnapshot Capture() =>
        _repository.GetRunnableSagaHealth();
}
