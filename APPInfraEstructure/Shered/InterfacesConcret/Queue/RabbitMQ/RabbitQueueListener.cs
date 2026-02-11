using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces.Queue;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Shared.InterfacesConcrete.Queue.RabbitMQ
{
    public sealed class RabbitMQQueueListener : IQueueListener
    {
        private readonly RabbitMqOptions _options;

        public RabbitMQQueueListener(RabbitMqOptions options)
        {
            _options = options;
        }

        public void Listen(
            string queueName,
            Func<IQueueMessage, Task> handler,
            CancellationToken cancellationToken = default)
        {
            // Fire-and-forget para respeitar void Listen
            _ = Task.Run(async () =>
            {
                var factory = new ConnectionFactory
                {
                    HostName = _options.HostName,
                    Port = _options.Port,
                    UserName = _options.UserName,
                    Password = _options.Password
                };

                // Conexão async
                var connection = await factory.CreateConnectionAsync(cancellationToken);

                // Canal async (sem CancellationToken — CreateChannelAsync não aceita)
                var channel = await connection.CreateChannelAsync();

                // Declara fila
                await channel.QueueDeclareAsync(
                    queue: queueName,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null,
                    cancellationToken: cancellationToken);

                // QoS para processar 1 mensagem por vez
                await channel.BasicQosAsync(
                    prefetchSize: 0,
                    prefetchCount: 1,
                    global: false,
                    cancellationToken: cancellationToken);

                // Consumidor async
                var consumer = new AsyncEventingBasicConsumer(channel);

                consumer.ReceivedAsync += async (_, args) =>
                {
                    try
                    {
                        var json = Encoding.UTF8.GetString(args.Body.ToArray());

                        // ⚠️ Assume que teu motor resolve o tipo concreto
                        var message = JsonSerializer.Deserialize<IQueueMessage>(json)!;

                        await handler(message);

                        // ACK manual
                        await channel.BasicAckAsync(
                            args.DeliveryTag,
                            multiple: false,
                            cancellationToken);
                    }
                    catch
                    {
                        // NACK com requeue automático
                        await channel.BasicNackAsync(
                            args.DeliveryTag,
                            multiple: false,
                            requeue: true,
                            cancellationToken);
                    }
                };

                // Começa a consumir
                await channel.BasicConsumeAsync(
                    queue: queueName,
                    autoAck: false,
                    consumer: consumer,
                    cancellationToken: cancellationToken);

            }, cancellationToken);
        }
    }
}
