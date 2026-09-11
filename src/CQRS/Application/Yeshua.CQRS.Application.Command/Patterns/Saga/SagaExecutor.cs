using Command.Interfaces;
using Dominio.Patterns.Saga;
using RepositoryInterfaces.Patterns.Saga;
using System;
using System.Linq;

namespace Command.Patterns
{
    public class SagaExecutor : ISagaExecutor
    {
        public void Execute(SagaBase saga, ISagaHandlerResolver resolver)
        {
            var step = saga.GetCurrent();

            if (step == null)
                return;

            var handlers = resolver.GetHandlers();

            if (!handlers.TryGetValue(step.Key, out var handler))
                throw new Exception($"Handler não encontrado: {step.Key}");

            try
            {
                // 🔒 não faz nada
                if (step.Status == SagaStepStatus.WaitingResponse)
                    return;

                // ▶ EXECUTA
                if (step.Status == SagaStepStatus.Pending)
                {
                    step.SetInProgress(); 
                    handler.Execute(saga, step);
                }

                // 📥 APLICA
                if (step.Status == SagaStepStatus.PendingApply)
                {
                    handler.ApplyResponse(saga, step, step.Payload);
                    
                    saga.CompleteCurrentStep(step.Payload);
                }
            }
            catch (Exception e)
            {
                HandleFailure(saga, step, e);
            }
        }

        public void ExecuteUntilWait(SagaBase saga, ISagaHandlerResolver resolver, int maxSteps = 25)
        {
            if (saga == null)
                throw new ArgumentNullException(nameof(saga));

            if (resolver == null)
                throw new ArgumentNullException(nameof(resolver));

            if (maxSteps <= 0)
                maxSteps = 25;

            for (var i = 0; i < maxSteps; i++)
            {
                var step = saga.GetCurrent();

                if (step == null || step.Status == SagaStepStatus.WaitingResponse)
                    return;

                var previousStep = step;
                var previousStatus = step.Status;

                Execute(saga, resolver);

                if (saga.Status != SagaStatus.InProgress)
                    return;

                var current = saga.GetCurrent();

                if (current == null || current.Status == SagaStepStatus.WaitingResponse)
                    return;

                if (ReferenceEquals(previousStep, current) && previousStatus == current.Status)
                    return;
            }
        }

        private void HandleFailure(SagaBase saga, SagaStepBase step, Exception e)
        {
            step.IncrementRetry();

            if (step.CanRetry())
            {
                var delay = TimeSpan.FromSeconds(5 * step.RetryCount);
                step.SetPending(DateTime.UtcNow.Add(delay));
            }
            else
            {
                step.SetFailed(e.Message);
                saga.MarkFailed(e.Message);
            }
        }
    }
}
