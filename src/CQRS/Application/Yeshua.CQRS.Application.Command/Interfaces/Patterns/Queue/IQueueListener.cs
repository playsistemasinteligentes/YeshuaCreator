using System.Threading;
using Command.Patterns.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Command.Interfaces.Patterns.Queue;
public interface IQueueListener
{
    Task ListenAsync<TCommand>(
        string queueName,
        Func<TCommand, Task> handler,
        CancellationToken cancellationToken
    ) where TCommand : class;
}
