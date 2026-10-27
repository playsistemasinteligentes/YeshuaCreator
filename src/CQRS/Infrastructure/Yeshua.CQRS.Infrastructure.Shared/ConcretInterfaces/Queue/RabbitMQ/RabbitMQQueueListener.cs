using System.Text.Json;
using Command.Interfaces.Patterns.Queue;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shered.ConcretInterfaces.Queue.RabbitMQ;
namespace Shared.InterfacesConcrete.Queue.RabbitMQ;

public sealed class RabbitMQQueueListener : IQueueListener
{
    private readonly RabbitMqConnectionManager _connectionManager;
    public RabbitMQQueueListener(RabbitMqConnectionManager manager) => _connectionManager = manager;

    public async Task ListenAsync<TCommand>(string queueName, Func<TCommand, Task> handler, CancellationToken cancellationToken)
        where TCommand : class
    {
        var connection = await _connectionManager.GetConnectionAsync(cancellationToken);
        await using var channel = await connection.CreateChannelAsync(cancellationToken: cancellationToken);
        await channel.BasicQosAsync(0, 1, false, cancellationToken);
        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += async (_, delivery) =>
        {
            try
            {
                var message = JsonSerializer.Deserialize<TCommand>(delivery.Body.Span)
                    ?? throw new JsonException("Mensagem nula.");
                await handler(message);
                await channel.BasicAckAsync(delivery.DeliveryTag, false, cancellationToken);
            }
            catch (JsonException)
            {
                // Invalid envelopes cannot be recovered by redelivery.
                await channel.BasicNackAsync(delivery.DeliveryTag, false, false, cancellationToken);
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested) { }
            catch (Exception exception)
            {
                Console.WriteLine($"Falha no consumidor de fila: {exception.GetType().Name}");
                await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
                await channel.BasicNackAsync(delivery.DeliveryTag, false, true, cancellationToken);
            }
        };
        await channel.BasicConsumeAsync(queueName, false, consumer, cancellationToken);
        try { await Task.Delay(Timeout.Infinite, cancellationToken); }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested) { }
    }
}
