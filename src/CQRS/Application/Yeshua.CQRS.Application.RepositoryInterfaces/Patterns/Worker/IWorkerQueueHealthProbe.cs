namespace RepositoryInterfaces.Patterns.Worker;

public enum WorkerQueueItemDisease
{
    None = 0,
    ExcessiveWait = 1,
    StaleProcessing = 2,
    RecurrentExecution = 3,
    RepeatedFailure = 4,
    TerminalFailure = 5
}

public readonly record struct WorkerQueueItemHealthThresholds(
    long ExcessiveWaitSeconds,
    long ProcessingStuckSeconds,
    int RecurrentExecutionCount,
    int RepeatedFailureCount)
{
    public static WorkerQueueItemHealthThresholds Default => new(
        ExcessiveWaitSeconds: 900,
        ProcessingStuckSeconds: 120,
        RecurrentExecutionCount: 3,
        RepeatedFailureCount: 2);
}

public readonly record struct WorkerQueueHealthSnapshot(
    long EligibleCount,
    long OldestEligibleAgeSeconds,
    long SickItemCount = 0,
    long ExcessiveWaitCount = 0,
    long StaleProcessingCount = 0,
    long RecurrentExecutionCount = 0,
    long RepeatedFailureCount = 0,
    long TerminalFailureCount = 0);

public readonly record struct WorkerQueueSickItem(
    int TenantId,
    string ItemReference,
    string ItemType,
    WorkerQueueItemDisease Disease,
    string Severity,
    long EligibleAgeSeconds,
    long ProcessingAgeSeconds,
    int ExecutionCount,
    int RetryCount,
    string LastOutcome,
    string? OperationalEntityId,
    string? RootOperationId,
    string? ExecutionId,
    string? ErrorSignature);

public interface IWorkerQueueHealthProbe<TReceiver, TCommand>
{
    string QueueName { get; }
    WorkerQueueHealthSnapshot Capture();

    IReadOnlyList<WorkerQueueSickItem> CaptureSickItems(int limit) =>
        Array.Empty<WorkerQueueSickItem>();
}
