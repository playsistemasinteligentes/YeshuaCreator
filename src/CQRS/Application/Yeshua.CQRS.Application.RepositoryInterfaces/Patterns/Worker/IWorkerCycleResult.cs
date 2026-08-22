namespace RepositoryInterfaces.Patterns.Worker;

public interface IWorkerCycleResult
{
    int BatchLimit { get; }
    int Claimed { get; }
    int Processed { get; }
    int Failed { get; }
}
