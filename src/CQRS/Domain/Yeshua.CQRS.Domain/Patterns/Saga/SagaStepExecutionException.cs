using System;
using Dominio.Operational;

namespace Dominio.Patterns.Saga
{
    public sealed class SagaStepExecutionException : Exception
    {
        public bool Retryable { get; }
        public OperationalFailureNature Nature { get; }
        public OperationalFailureOrigin Origin { get; }
        public string StableCode { get; }

        public SagaStepExecutionException(
            string message,
            bool retryable,
            Exception? innerException = null,
            OperationalFailureNature? nature = null,
            OperationalFailureOrigin origin = OperationalFailureOrigin.Unknown,
            string? stableCode = null)
            : base(message, innerException)
        {
            Retryable = retryable;
            Nature = nature ?? (retryable
                ? OperationalFailureNature.Technical
                : OperationalFailureNature.Business);
            Origin = origin;
            StableCode = string.IsNullOrWhiteSpace(stableCode)
                ? GetType().Name
                : stableCode;
        }

        public OperationalFailureClassification Classification => new(
            Nature,
            Retryable
                ? OperationalFailureTransience.Transient
                : OperationalFailureTransience.Permanent,
            Origin,
            Retryable,
            StableCode);
    }
}
