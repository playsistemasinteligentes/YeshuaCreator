using Command.Interfaces.Patterns.Queue;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Shared.InterfacesConcrete.Queue.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shered.ConcretInterfaces.Queue.RabbitMQ
{

    public sealed class RabbitMqTopologyInitializer : IQueueTopologyInitializer
    {
        private readonly RabbitMqOptions _options;

        public RabbitMqTopologyInitializer(IOptions<RabbitMqOptions> options)
        {
            _options = options.Value;
        }

        public async Task InitializeAsync(
            QueueTopology topology,
            CancellationToken cancellationToken = default)
        {
            var factory = new ConnectionFactory
            {
                HostName = _options.HostName,
                Port = _options.Port,
                UserName = _options.UserName,
                Password = _options.Password,
                VirtualHost = _options.VirtualHost
            };


            Console.WriteLine($"host{_options.HostName}");
            Console.WriteLine("factory inicializando ");

            await using var connection =
                await factory.CreateConnectionAsync(cancellationToken);

            await using var channel =
                await connection.CreateChannelAsync();

            Console.WriteLine("factory inicializando bindins");

            foreach (var exchange in topology.Exchanges)
            {
                await channel.ExchangeDeclareAsync(
                    exchange: exchange.Name,
                    type: exchange.Type,
                    durable: exchange.Durable,
                    cancellationToken: cancellationToken);

                foreach (var binding in exchange.Bindings)
                {
                    await channel.QueueDeclareAsync(
                        queue: binding.QueueName,
                        durable: binding.Durable,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null,
                        cancellationToken: cancellationToken);

                    await channel.QueueBindAsync(
                        queue: binding.QueueName,
                        exchange: exchange.Name,
                        routingKey: binding.RoutingKey,
                        cancellationToken: cancellationToken);
                }
            }
            Console.WriteLine("factory fim bindins");
        }
    }
}
