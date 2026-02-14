using System.Text;
using System.Text.Json;
using Command.Interfaces.Patterns.Queue;
using Command.Patterns.Queue;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Shared.InterfacesConcrete.Queue.RabbitMQ;

public sealed class RabbitMQQueuePublisher : IQueuePublisher
{
    private readonly RabbitMqOptions _options;

    public RabbitMQQueuePublisher(IOptions<RabbitMqOptions> options)
    {
        _options = options.Value;
    }

    public async Task PublishAsync(
        string queueName,
        QueueMessage message,
        CancellationToken cancellationToken = default)
    {
        var factory = new ConnectionFactory
        {
            HostName = _options.HostName,
            Port = _options.Port,
            UserName = _options.UserName,
            Password = _options.Password
        };

        await using var connection =
            await factory.CreateConnectionAsync(cancellationToken);

        await using var channel = await connection.CreateChannelAsync();


        await channel.QueueDeclareAsync(
            queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null,
            cancellationToken: cancellationToken);

        var body = Encoding.UTF8.GetBytes(
            JsonSerializer.Serialize(message));

        await channel.BasicPublishAsync(
            exchange: "",
            routingKey: queueName,
            body: body,
            cancellationToken: cancellationToken);
    }
}
