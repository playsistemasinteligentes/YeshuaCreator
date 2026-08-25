using System.Collections.Generic;

namespace Dominio.Patterns.Domain
{
    public sealed class DomainBehaviorResult
    {
        public List<string> Errors { get; } = new();
        public List<IDomainEvent> Events { get; } = new();
        public bool IsValid => Errors.Count == 0;

        public void AddErrors(IEnumerable<string> errors)
        {
            foreach (var error in errors)
            {
                if (!string.IsNullOrWhiteSpace(error))
                {
                    Errors.Add(error);
                }
            }
        }
    }
}
