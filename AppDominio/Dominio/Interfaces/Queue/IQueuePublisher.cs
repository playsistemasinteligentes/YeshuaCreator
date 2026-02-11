using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Queue;

public interface IQueuePublisher
{
    Task PublishAsync(
        string queueName,
        IQueueMessage message,
        CancellationToken cancellationToken = default
    );
}

