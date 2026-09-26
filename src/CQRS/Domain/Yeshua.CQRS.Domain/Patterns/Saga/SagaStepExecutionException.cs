using System;

namespace Dominio.Patterns.Saga
{
    public sealed class SagaStepExecutionException : Exception
    {
        public bool Retryable { get; }

        public SagaStepExecutionException(string message, bool retryable, Exception? innerException = null)
            : base(message, innerException)
        {
            Retryable = retryable;
        }
    }
}
