using Command.Patterns.Queue;

namespace Command.Interfaces.Patterns.Queue;

public interface IQueuePublisher
{
    Task PublishAsync(
        string exchange,
        string routingKey,
        QueueMessage message,
        CancellationToken cancellationToken = default
    );
}