using System.Text;
using System.Text.Json;
using Command.Interfaces.Patterns.Queue;
using Command.Patterns.Queue;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shered.ConcretInterfaces.Queue.RabbitMQ;

namespace Shared.InterfacesConcrete.Queue.RabbitMQ;

public sealed class RabbitMQQueueListener : IQueueListener
{
    private readonly RabbitMqConnectionManager _connectionManager;

    public RabbitMQQueueListener(RabbitMqConnectionManager connectionManager)
    {
        _connectionManager = connectionManager;
    }

    public async Task ListenAsync(string queueName, Func<QueueMessage, Task> handler, CancellationToken cancellationToken)
    {
        var connection = await _connectionManager.GetConnectionAsync(cancellationToken);

        var channel = await connection.CreateChannelAsync();

        await channel.BasicQosAsync(0, 1, false, cancellationToken);

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (_, args) =>
        {
            try
            {
                var json = Encoding.UTF8.GetString(args.Body.ToArray());

                var message = JsonSerializer.Deserialize<QueueMessage>(json)!;

                await handler(message);

                await channel.BasicAckAsync(args.DeliveryTag, false, cancellationToken);
            }
            catch
            {
                await channel.BasicNackAsync(args.DeliveryTag, false, true, cancellationToken);
            }
        };

        await channel.BasicConsumeAsync(queueName, false, consumer, cancellationToken);
    }
}