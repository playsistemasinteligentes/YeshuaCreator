using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Interfaces.Patterns.Queue
{
    public interface IQueueTopologyInitializer
    {
        Task InitializeAsync(
            QueueTopology topology,
            CancellationToken cancellationToken = default);
    }
}
