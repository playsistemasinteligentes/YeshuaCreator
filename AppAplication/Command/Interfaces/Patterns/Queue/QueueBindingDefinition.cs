using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Interfaces.Patterns.Queue
{
    public sealed class QueueBindingDefinition
    {
        public string QueueName { get; init; } = default!;

        public string RoutingKey { get; init; } = default!;

        public bool Durable { get; init; } = true;
    }
}
