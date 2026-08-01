using System.Text;
using System.Text.Json;
using System.Windows.Input;
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



    public async Task ListenAsync<TCommand>(string queueName, Func<TCommand, Task> handler, CancellationToken cancellationToken)
       where TCommand : class
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

                // 🔥 desserializa para o tipo correto
                var message = JsonSerializer.Deserialize<TCommand>(json);

                if (message == null)
                    throw new Exception("Mensagem inválida ou nula");

                await handler(message);
            }
            catch (Exception ex)
            {
                // loga erro (não quebra o worker)
                Console.WriteLine($"Erro ao processar mensagem: {ex}");
            }

            // 🔥 ACK SEMPRE (ou você pode sofisticar depois)
            await channel.BasicAckAsync(args.DeliveryTag, false, cancellationToken);
        };

        await channel.BasicConsumeAsync(
            queue: queueName,
            autoAck: false,
            consumer: consumer,
            cancellationToken: cancellationToken
        );
    }
}