
namespace Command.Patterns.Queue;

public sealed class QueueMessage
{
    public QueueMessage(string type, DateTime occurredAt, object payload)
    {
        Type = type;
        OccurredAt = occurredAt;
        Payload = payload;
    }

    public Guid Id { get; init; } = Guid.NewGuid();
    public string Type { get; init; } = default!;
    public DateTime OccurredAt { get; init; } = DateTime.UtcNow;
    public object Payload { get; init; } = default!;
}


