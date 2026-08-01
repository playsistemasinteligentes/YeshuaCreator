using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Interfaces.Patterns.Queue
{
    public sealed class QueueTopology
    {
        public List<ExchangeDefinition> Exchanges { get; init; } = new();
    }
}
