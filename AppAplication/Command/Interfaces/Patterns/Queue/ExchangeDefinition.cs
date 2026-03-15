using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Interfaces.Patterns.Queue
{
    public sealed class ExchangeDefinition
    {
        public string Name { get; init; } = default!;

        public string Type { get; init; } = "topic";

        public bool Durable { get; init; } = true;

        public List<QueueBindingDefinition> Bindings { get; init; } = new();
    }
}
