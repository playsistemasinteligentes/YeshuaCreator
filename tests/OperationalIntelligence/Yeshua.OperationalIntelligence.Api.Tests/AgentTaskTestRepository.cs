using Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

namespace Yeshua.OperationalIntelligence.Api.Tests;

internal sealed class AgentTaskTestRepository : IAgentTaskRepository
{
    private readonly object _gate = new();
    private readonly List<(AgentTaskWorkItem Work, AgentTaskMessage Message)> _messages = [];
    private readonly Dictionary<Guid, AgentTaskSummary> _tasks = [];
    private readonly Dictionary<Guid, string> _threads = [];
    public int AcceptedCount { get { lock (_gate) return _messages.Count; } }

    public Task<AgentTaskReceipt> AcceptAsync(SendAgentTaskCommand command, int maximumPending, CancellationToken cancellationToken)
    {
        lock (_gate)
        {
            var previous = _messages.FirstOrDefault(entry => entry.Work.RequestId == command.RequestId);
            if (previous.Work is not null)
            {
                if (previous.Work.Message != command.Message || previous.Work.Mode != command.Mode ||
                    (command.TaskId.HasValue && command.TaskId != previous.Work.TaskId))
                    throw new ArgumentException("requestId ja foi usado para outro pedido.");
                return Task.FromResult(new AgentTaskReceipt(previous.Work.TaskId, command.RequestId,
                    previous.Message.Status, previous.Message.CreatedAtUtc, true));
            }
            if (_messages.Count(entry => entry.Message.Status is "Queued" or "Running") >= maximumPending)
                throw new ArgumentException("Limite de tarefas pendentes atingido.");
            if (command.TaskId.HasValue && !_tasks.ContainsKey(command.TaskId.Value))
                throw new ArgumentException("Tarefa nao encontrada.");
            var taskId = command.TaskId ?? Guid.NewGuid();
            var now = DateTime.UtcNow;
            _tasks[taskId] = new() { TaskId = taskId, Title = command.Title ?? command.Message, Status = "Queued", CreatedAtUtc = now, UpdatedAtUtc = now };
            var work = new AgentTaskWorkItem { TaskId = taskId, MessageId = _messages.Count + 1, RequestId = command.RequestId, Message = command.Message, Mode = command.Mode };
            _messages.Add((work, new() { RequestId = command.RequestId, Message = command.Message, Mode = command.Mode, Status = "Queued", CreatedAtUtc = now, UpdatedAtUtc = now }));
            return Task.FromResult(new AgentTaskReceipt(taskId, command.RequestId, "Queued", now, false));
        }
    }

    public Task<AgentTaskReadResult> ReadAsync(ReadAgentTaskQuery query, CancellationToken cancellationToken)
    {
        lock (_gate)
        {
            IReadOnlyList<AgentTaskSummary> tasks = _tasks.Values.Where(task => query.TaskId is null || task.TaskId == query.TaskId)
                .OrderByDescending(task => task.UpdatedAtUtc).ThenBy(task => task.TaskId).Take(query.Limit)
                .Select(task => task with { }).ToArray();
            IReadOnlyList<AgentTaskMessage> messages = query.TaskId is null ? [] : _messages.Where(entry => entry.Work.TaskId == query.TaskId)
                .Reverse().Take(query.Limit).Select(entry => new AgentTaskMessage
                {
                    RequestId = entry.Message.RequestId, Message = entry.Message.Message, Mode = entry.Message.Mode,
                    Status = entry.Message.Status, Response = entry.Message.Response, Progress = entry.Message.Progress,
                    CreatedAtUtc = entry.Message.CreatedAtUtc, UpdatedAtUtc = entry.Message.UpdatedAtUtc
                }).ToArray();
            return Task.FromResult(new AgentTaskReadResult(tasks, messages, "Consulte sem reenviar."));
        }
    }

    public Task<AgentTaskWorkItem?> ClaimAsync(CancellationToken cancellationToken)
    {
        lock (_gate)
        {
            var next = _messages.FirstOrDefault(entry => entry.Message.Status == "Queued");
            if (next.Work is null || _messages.Any(entry => entry.Message.Status == "Running"))
                return Task.FromResult<AgentTaskWorkItem?>(null);
            next.Message.Status = "Running";
            _tasks[next.Work.TaskId].Status = "Running";
            next.Work.ThreadId = _threads.GetValueOrDefault(next.Work.TaskId);
            next.Work.IsContinuation = _messages.Any(entry => entry.Work.TaskId == next.Work.TaskId && entry.Work.MessageId < next.Work.MessageId);
            return Task.FromResult<AgentTaskWorkItem?>(next.Work);
        }
    }

    public Task ProgressAsync(AgentTaskWorkItem item, AgentTaskProgress progress, CancellationToken cancellationToken)
    {
        lock (_gate)
        {
            _messages.Single(entry => entry.Work.MessageId == item.MessageId).Message.Progress = progress.Description;
            if (progress.ThreadId is not null) _threads[item.TaskId] = progress.ThreadId;
            return Task.CompletedTask;
        }
    }

    public Task CompleteAsync(AgentTaskWorkItem item, string status, string response, CancellationToken cancellationToken)
    {
        lock (_gate)
        {
            var message = _messages.Single(entry => entry.Work.MessageId == item.MessageId).Message;
            message.Status = status;
            message.Response = response;
            _tasks[item.TaskId].Status = status;
            return Task.CompletedTask;
        }
    }

    public Task RecoverInterruptedAsync(CancellationToken cancellationToken)
    {
        lock (_gate)
        {
            foreach (var entry in _messages.Where(entry => entry.Message.Status == "Running"))
            {
                entry.Message.Status = "Interrupted";
                _tasks[entry.Work.TaskId].Status = "Interrupted";
            }
            return Task.CompletedTask;
        }
    }
}
