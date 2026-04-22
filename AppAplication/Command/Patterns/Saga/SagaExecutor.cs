using Command.Interfaces;
using Dominio.Patterns.Saga;
using RepositoryInterfaces.Patterns.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Patterns
{
    public class SagaExecutor : ISagaExecutor
    {
        public void Execute(SagaBase saga, ISagaHandlerResolver resolver)
        {
            var step = saga.GetCurrent();
            if (step == null) return;

            // 1. Se está esperando resposta externa → não faz nada
            if (step.Status == SagaStepStatus.WaitingResponse)
                return;

            // 2. Se tem agendamento futuro → respeita
            if (step.Status == SagaStepStatus.Pending &&
                step.NextExecutionAt.HasValue &&
                step.NextExecutionAt.Value > DateTime.UtcNow)
                return;

            var handlers = resolver.GetHandlers();

            if (!handlers.ContainsKey(step.Key))
                throw new Exception($"Handler não encontrado: {step.Key}");

            var handler = handlers[step.Key];

            // 3. Decide se vai para worker (defer)
            if (handler.IsAsync && step.Status == SagaStepStatus.Pending && step.RetryCount == 0)
            {
                // primeira execução → deixa para worker
                //return;
            }

            try
            {
                handler.Execute(saga, step);
            }
            catch (Exception e)
            {
                step.IncrementRetry();

                if (step.CanRetry())
                {
                    // backoff simples (pode evoluir)
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
}
