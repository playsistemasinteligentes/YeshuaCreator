using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Queue
{
    public interface IQueueMessage
    {
        Guid Id { get; }
        string Type { get; }
        DateTime OccurredAt { get; }
        object Payload { get; }
    }
}