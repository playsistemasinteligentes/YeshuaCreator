using System;

namespace Dominio.Patterns.Domain
{
    public interface IDomainEvent
    {
        string Name { get; }
        DateTime OccurredAt { get; }
    }
}
