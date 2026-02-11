using Domain.Interfaces.Queue;

namespace Shared.InterfacesConcrete.Queue.RabbitMQ;

public sealed class RabbitQueueMessage : IQueueMessage
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Type { get; init; } = default!;
    public DateTime OccurredAt { get; init; } = DateTime.UtcNow;
    public object Payload { get; init; } = default!;
}


