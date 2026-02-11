using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Queue;

public interface IQueueListener
{
    void Listen(
        string queueName,
        Func<IQueueMessage, Task> handler,
        CancellationToken cancellationToken = default
    );
}

