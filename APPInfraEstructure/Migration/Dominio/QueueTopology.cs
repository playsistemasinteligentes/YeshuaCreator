using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{


    public sealed class QueueTopology
    {
        public List<ExchangeDefinition> Exchanges { get; init; } = new();
    }
    public sealed class ExchangeDefinition
    {
        public string Name { get; init; } = default!;

        public ExchangeType Type { get; init; } = ExchangeType.topic;

        public bool Durable { get; init; } = true;

        public List<QueueBindingDefinition> Bindings { get; init; } = new();
    }
    public sealed class QueueBindingDefinition
    {
        public string QueueName { get; init; } = default!;

        public string RoutingKey { get; init; } = default!;

        public bool Durable { get; init; } = true;
    }


    public enum ExchangeType
    {
        direct,
        fanout,
        topic,
        headers
    }
}