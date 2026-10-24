using Dapper;
using Microsoft.Data.SqlClient;
using Yeshua.OperationalIntelligence.Api.Database;
using Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

namespace Yeshua.OperationalIntelligence.Api.Repositories;

public sealed class AgentTaskRepository(OperationalIntelligenceDatabase database) : IAgentTaskRepository
{
    public async Task<AgentTaskReceipt> AcceptAsync(
        SendAgentTaskCommand command, int maximumPending, CancellationToken cancellationToken)
    {
        await using var connection = await database.OpenConnectionAsync(cancellationToken);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(cancellationToken);
        await connection.ExecuteAsync(Command("""
            DECLARE @LockResult INT;
            EXEC @LockResult = sp_getapplock @Resource = 'OI_AgentTask_Submit',
                @LockMode = 'Exclusive', @LockOwner = 'Transaction', @LockTimeout = 5000;
            IF @LockResult < 0 THROW 51000, 'Agent task submission unavailable.', 1;
            """, null, cancellationToken, transaction));
        var previous = await connection.QuerySingleOrDefaultAsync<StoredSubmission>(Command("""
            SELECT TaskId, RequestId, Message, Mode, Status,
                TODATETIMEOFFSET(CreatedAtUtc, '+00:00') AS CreatedAtUtc
            FROM OI_AgentTaskMessages WHERE RequestId = @RequestId;
            """, new { command.RequestId }, cancellationToken, transaction));
        if (previous is not null)
        {
            if ((command.TaskId.HasValue && command.TaskId != previous.TaskId) ||
                !string.Equals(command.Message, previous.Message, StringComparison.Ordinal) ||
                !string.Equals(command.Mode, previous.Mode, StringComparison.Ordinal))
                throw new ArgumentException("requestId ja foi usado para outro pedido. Use outro identificador para uma nova ordem.");
            await transaction.CommitAsync(cancellationToken);
            return new(previous.TaskId, previous.RequestId, previous.Status, previous.CreatedAtUtc, true);
        }

        var pending = await connection.ExecuteScalarAsync<int>(Command(
            "SELECT COUNT(*) FROM OI_AgentTaskMessages WHERE Status IN ('Queued', 'Running');",
            null, cancellationToken, transaction));
        if (pending >= maximumPending)
            throw new ArgumentException("Limite de tarefas pendentes atingido. Consulte as tarefas existentes antes de enviar outra.");

        var taskId = command.TaskId ?? Guid.NewGuid();
        var now = DateTime.UtcNow;
        if (command.TaskId.HasValue)
        {
            var exists = await connection.ExecuteScalarAsync<int>(Command(
                "SELECT COUNT(*) FROM OI_AgentTasks WHERE TaskId = @TaskId;",
                new { TaskId = taskId }, cancellationToken, transaction));
            if (exists == 0)
                throw new ArgumentException("Tarefa nao encontrada. Liste as tarefas ou omita taskId para criar uma.");
            await connection.ExecuteAsync(Command("""
                UPDATE OI_AgentTasks SET UpdatedAtUtc = @Now,
                    Status = CASE WHEN Status = 'Running' THEN Status ELSE 'Queued' END
                WHERE TaskId = @TaskId;
                """, new { TaskId = taskId, Now = now }, cancellationToken, transaction));
        }
        else
        {
            var title = string.IsNullOrWhiteSpace(command.Title) ? command.Message.Trim() : command.Title.Trim();
            title = title[..Math.Min(title.Length, 160)];
            await connection.ExecuteAsync(Command("""
                INSERT INTO OI_AgentTasks(TaskId, Title, Status, CreatedAtUtc, UpdatedAtUtc)
                VALUES(@TaskId, @Title, 'Queued', @Now, @Now);
                """, new { TaskId = taskId, Title = title, Now = now }, cancellationToken, transaction));
        }
        await connection.ExecuteAsync(Command("""
            INSERT INTO OI_AgentTaskMessages(TaskId, RequestId, Message, Mode, Status, CreatedAtUtc, UpdatedAtUtc)
            VALUES(@TaskId, @RequestId, @Message, @Mode, 'Queued', @Now, @Now);
            """, new { TaskId = taskId, command.RequestId, command.Message, command.Mode, Now = now }, cancellationToken, transaction));
        await transaction.CommitAsync(cancellationToken);
        return new(taskId, command.RequestId, "Queued", now, false);
    }

    public async Task<AgentTaskReadResult> ReadAsync(ReadAgentTaskQuery query, CancellationToken cancellationToken)
    {
        await using var connection = await database.OpenConnectionAsync(cancellationToken);
        var tasks = (await connection.QueryAsync<AgentTaskSummary>(Command("""
            SELECT TOP (@Limit) TaskId, Title, Status,
                TODATETIMEOFFSET(CreatedAtUtc, '+00:00') AS CreatedAtUtc,
                TODATETIMEOFFSET(UpdatedAtUtc, '+00:00') AS UpdatedAtUtc
            FROM OI_AgentTasks WHERE @TaskId IS NULL OR TaskId = @TaskId
            ORDER BY UpdatedAtUtc DESC, TaskId;
            """, query, cancellationToken))).AsList();
        IReadOnlyList<AgentTaskMessage> messages = [];
        if (query.TaskId.HasValue)
            messages = (await connection.QueryAsync<AgentTaskMessage>(Command("""
                SELECT TOP (@Limit) RequestId, Message, Mode, Status, Response, Progress,
                    TODATETIMEOFFSET(CreatedAtUtc, '+00:00') AS CreatedAtUtc,
                    TODATETIMEOFFSET(UpdatedAtUtc, '+00:00') AS UpdatedAtUtc
                FROM OI_AgentTaskMessages WHERE TaskId = @TaskId ORDER BY MessageId DESC;
                """, query, cancellationToken))).AsList();
        return new(tasks, messages,
            "Leia Status, Progress e Response. Para continuar use o mesmo taskId e um novo requestId. Para conferir andamento apenas consulte; nao reenvie o pedido. Interrupted nao foi repetido automaticamente.");
    }

    public async Task<AgentTaskWorkItem?> ClaimAsync(CancellationToken cancellationToken)
    {
        await using var connection = await database.OpenConnectionAsync(cancellationToken);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(cancellationToken);
        var item = await connection.QuerySingleOrDefaultAsync<AgentTaskWorkItem>(Command("""
            DECLARE @LockResult INT;
            EXEC @LockResult = sp_getapplock @Resource = 'OI_AgentTask_Claim',
                @LockMode = 'Exclusive', @LockOwner = 'Transaction', @LockTimeout = 0;
            IF @LockResult < 0 RETURN;
            IF EXISTS(SELECT 1 FROM OI_AgentTaskMessages WHERE Status = 'Running') RETURN;
            DECLARE @MessageId BIGINT;
            SELECT TOP (1) @MessageId = MessageId FROM OI_AgentTaskMessages WITH (UPDLOCK)
                WHERE Status = 'Queued' ORDER BY MessageId;
            IF @MessageId IS NULL RETURN;
            UPDATE OI_AgentTaskMessages SET Status = 'Running', Progress = 'Iniciando agente.',
                UpdatedAtUtc = SYSUTCDATETIME() WHERE MessageId = @MessageId;
            UPDATE t SET Status = 'Running', UpdatedAtUtc = SYSUTCDATETIME()
                FROM OI_AgentTasks t JOIN OI_AgentTaskMessages m ON m.TaskId = t.TaskId
                WHERE m.MessageId = @MessageId;
            SELECT m.MessageId, m.TaskId, m.RequestId, m.Message, m.Mode, t.ThreadId,
                CAST(CASE WHEN EXISTS(SELECT 1 FROM OI_AgentTaskMessages previous
                    WHERE previous.TaskId = m.TaskId AND previous.MessageId < m.MessageId)
                    THEN 1 ELSE 0 END AS BIT) AS IsContinuation
                FROM OI_AgentTaskMessages m JOIN OI_AgentTasks t ON t.TaskId = m.TaskId
                WHERE m.MessageId = @MessageId;
            """, null, cancellationToken, transaction));
        await transaction.CommitAsync(cancellationToken);
        return item;
    }

    public async Task ProgressAsync(AgentTaskWorkItem item, AgentTaskProgress progress, CancellationToken cancellationToken)
    {
        await using var connection = await database.OpenConnectionAsync(cancellationToken);
        await connection.ExecuteAsync(Command("""
            UPDATE OI_AgentTaskMessages SET Progress = @Progress, UpdatedAtUtc = SYSUTCDATETIME()
                WHERE MessageId = @MessageId AND Status = 'Running';
            UPDATE OI_AgentTasks SET ThreadId = COALESCE(ThreadId, @ThreadId), UpdatedAtUtc = SYSUTCDATETIME()
                WHERE TaskId = @TaskId;
            """, new { item.MessageId, item.TaskId, progress.ThreadId, Progress = progress.Description[..Math.Min(progress.Description.Length, 300)] }, cancellationToken));
    }

    public async Task CompleteAsync(AgentTaskWorkItem item, string status, string response, CancellationToken cancellationToken)
    {
        await using var connection = await database.OpenConnectionAsync(cancellationToken);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(cancellationToken);
        await connection.ExecuteAsync(Command("""
            UPDATE OI_AgentTaskMessages SET Status = @Status, Response = @Response, Progress = NULL,
                UpdatedAtUtc = SYSUTCDATETIME() WHERE MessageId = @MessageId AND Status = 'Running';
            UPDATE OI_AgentTasks SET UpdatedAtUtc = SYSUTCDATETIME(),
                Status = CASE WHEN EXISTS(SELECT 1 FROM OI_AgentTaskMessages
                    WHERE TaskId = @TaskId AND Status = 'Queued') THEN 'Queued' ELSE @Status END
                WHERE TaskId = @TaskId;
            """, new { item.MessageId, item.TaskId, Status = status, Response = response }, cancellationToken, transaction));
        await transaction.CommitAsync(cancellationToken);
    }

    public async Task RecoverInterruptedAsync(CancellationToken cancellationToken)
    {
        await using var connection = await database.OpenConnectionAsync(cancellationToken);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(cancellationToken);
        await connection.ExecuteAsync(Command("""
            UPDATE OI_AgentTaskMessages SET Status = 'Interrupted',
                Response = 'O servidor interrompeu esta execucao. Confira o workspace antes de enviar outra ordem. O pedido nao foi repetido automaticamente.',
                Progress = NULL, UpdatedAtUtc = SYSUTCDATETIME() WHERE Status = 'Running';
            UPDATE OI_AgentTasks SET UpdatedAtUtc = SYSUTCDATETIME(),
                Status = CASE WHEN EXISTS(SELECT 1 FROM OI_AgentTaskMessages m
                    WHERE m.TaskId = OI_AgentTasks.TaskId AND m.Status = 'Queued') THEN 'Queued' ELSE 'Interrupted' END
                WHERE Status = 'Running';
            """, null, cancellationToken, transaction));
        await transaction.CommitAsync(cancellationToken);
    }

    private CommandDefinition Command(string sql, object? parameters, CancellationToken cancellationToken,
        SqlTransaction? transaction = null) => new(sql, parameters, transaction,
            commandTimeout: database.CommandTimeoutSeconds, cancellationToken: cancellationToken);

    private sealed class StoredSubmission
    {
        public Guid TaskId { get; set; }
        public string RequestId { get; set; } = "";
        public string Message { get; set; } = "";
        public string Mode { get; set; } = "";
        public string Status { get; set; } = "";
        public DateTimeOffset CreatedAtUtc { get; set; }
    }
}
