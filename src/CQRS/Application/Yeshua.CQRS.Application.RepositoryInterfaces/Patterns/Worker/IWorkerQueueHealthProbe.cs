namespace RepositoryInterfaces.Patterns.Worker;

public readonly record struct WorkerQueueHealthSnapshot(
    long EligibleCount,
    long OldestEligibleAgeSeconds);

public interface IWorkerQueueHealthProbe<TReceiver, TCommand>
{
    string QueueName { get; }
    WorkerQueueHealthSnapshot Capture();
}
