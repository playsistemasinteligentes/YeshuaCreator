namespace Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

public sealed record SendAgentTaskCommand(
    string RequestId, string Message, Guid? TaskId = null, string Mode = "observe", string? Title = null);
public sealed record ReadAgentTaskQuery(Guid? TaskId = null, int Limit = 10);
public sealed record RestartAgentCommand(Guid TaskId, string RequestId, bool Confirm = false);
public sealed record AgentRestartReceipt(Guid TaskId, string RequestId, string Status, string Instruction);
public sealed record AgentActiveExecution(Guid TaskId, string RequestId, bool RestartRequested);
public sealed record AgentTaskReceipt(Guid TaskId, string RequestId, string Status, DateTimeOffset AcceptedAtUtc, bool Duplicate);

public sealed record AgentTaskSummary
{
    public int? SelectionNumber { get; set; }
    public Guid TaskId { get; set; }
    public string Title { get; set; } = "";
    public string Status { get; set; } = "";
    public DateTimeOffset CreatedAtUtc { get; set; }
    public DateTimeOffset UpdatedAtUtc { get; set; }
}

public sealed class AgentTaskMessage
{
    public string RequestId { get; set; } = "";
    public string Status { get; set; } = "";
    public string Message { get; set; } = "";
    public string Mode { get; set; } = "";
    public string? Response { get; set; }
    public string? Progress { get; set; }
    public DateTimeOffset CreatedAtUtc { get; set; }
    public DateTimeOffset UpdatedAtUtc { get; set; }
}

public sealed record AgentTaskReadResult(
    IReadOnlyList<AgentTaskSummary> Tasks, IReadOnlyList<AgentTaskMessage> Messages, string Instruction,
    AgentActiveExecution? ActiveExecution = null);

public sealed class AgentTaskWorkItem
{
    public long MessageId { get; set; }
    public Guid TaskId { get; set; }
    public string RequestId { get; set; } = "";
    public string Message { get; set; } = "";
    public string Mode { get; set; } = "";
    public string? ThreadId { get; set; }
    public bool IsContinuation { get; set; }
}

public sealed record AgentTaskProgress(string? ThreadId, string Description);
public sealed record AgentTaskExecutionResult(string Response, bool Success);

public interface IAgentTaskRepository
{
    Task<AgentTaskReceipt> AcceptAsync(SendAgentTaskCommand command, int maximumPending, CancellationToken cancellationToken);
    Task<AgentTaskReadResult> ReadAsync(ReadAgentTaskQuery query, CancellationToken cancellationToken);
    Task<AgentTaskWorkItem?> ClaimAsync(CancellationToken cancellationToken);
    Task ProgressAsync(AgentTaskWorkItem item, AgentTaskProgress progress, CancellationToken cancellationToken);
    Task CompleteAsync(AgentTaskWorkItem item, string status, string response, CancellationToken cancellationToken);
    Task RecoverInterruptedAsync(CancellationToken cancellationToken);
}

public interface IAgentTaskExecutor
{
    Task<AgentTaskExecutionResult> ExecuteAsync(
        AgentTaskWorkItem item, Func<AgentTaskProgress, CancellationToken, Task> progress,
        CancellationToken cancellationToken);
}
