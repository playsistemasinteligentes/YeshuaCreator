using Command.Patterns.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Interfaces.Patterns.Queue;
public interface IQueueListener
{
    Task ListenAsync(string queueName, Func<QueueMessage, Task> handler, CancellationToken cancellationToken);
}

