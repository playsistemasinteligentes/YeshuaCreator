using System.Threading.Tasks;
using System.Threading;
using Command.Patterns.Queue;

namespace Command.Interfaces.Patterns.Queue;

public interface IQueuePublisher
{
    Task<bool> PublishAsync(string channelId, string exchange, string routingKey, QueueMessage message, CancellationToken cancellationToken = default);
    Task<bool> PublishCeleryAsync(string channelId, string exchange, string routingKey, string taskName, QueueMessage message, CancellationToken cancellationToken = default);
    

}