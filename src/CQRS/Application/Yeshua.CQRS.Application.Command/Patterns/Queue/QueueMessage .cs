using Dominio.Operational;

namespace Command.Patterns.Queue;

public sealed class QueueMessage
{
    public QueueMessage(string type, object payload)
    {
        Type = type;
        Payload = payload;
    }

    public QueueMessage(
        string type,
        object payload,
        OperationalExecutionIdentity identity)
        : this(type, payload)
    {
        RootOperationId = identity.RootOperationId;
        OperationId = identity.OperationId;
        ExecutionId = identity.ExecutionId;
        CausationId = identity.CausationId;
    }

    public Guid Id { get; init; } = Guid.NewGuid();

    // tipo lógico da mensagem
    public string Type { get; init; } = default!;

    // quando ocorreu
    public DateTime OccurredAt { get; init; } = DateTime.UtcNow;

    // rastreabilidade entre serviços
    public string? MenssageId { get; init; }
    public string? CorrelationId { get; init; }
    public string? RootOperationId { get; init; }
    public string? OperationId { get; init; }
    public string? ExecutionId { get; init; }
    public string? CausationId { get; init; }

    public OperationalExecutionIdentity OperationalIdentity =>
        new(RootOperationId, OperationId, ExecutionId, CausationId);

    // quem originou
    public string? Source { get; init; }

    // versão do contrato
    public int Version { get; init; } = 1;

    // dados da mensagem
    public object Payload { get; init; } = default!;
}
