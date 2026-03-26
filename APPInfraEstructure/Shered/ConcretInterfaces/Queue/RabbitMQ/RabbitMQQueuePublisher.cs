using System.Text;
using System.Text.Json;
using Command.Interfaces.Patterns.Queue;
using Command.Patterns.Queue;
using RabbitMQ.Client;
using Shered.ConcretInterfaces.Queue.RabbitMQ;

namespace Shared.InterfacesConcrete.Queue.RabbitMQ;

public sealed class RabbitMQQueuePublisher : IQueuePublisher
{
    private readonly RabbitMqConnectionManager _connectionManager;

    public RabbitMQQueuePublisher(RabbitMqConnectionManager connectionManager)
    {
        _connectionManager = connectionManager;
    }

    public async Task PublishAsync(
        string exchange,
        string routingKey,
        QueueMessage message,
        CancellationToken cancellationToken = default)
    {

        Console.WriteLine("MEnsagem");
        var channel = await _connectionManager.CreateChannelAsync(cancellationToken);

        var body = Encoding.UTF8.GetBytes(
            JsonSerializer.Serialize(message));

        await channel.BasicPublishAsync(
            exchange: exchange,
            routingKey: routingKey,
            body: body,
            cancellationToken: cancellationToken);
    }
}