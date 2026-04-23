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
            Process(saga, resolver, payload: null, isResponse: false);
        }

        public void ApplyResponse(SagaBase saga, ISagaHandlerResolver resolver, string payload)
        {
            Process(saga, resolver, payload, isResponse: true);
        }

        private void Process(
            SagaBase saga,
            ISagaHandlerResolver resolver,
            string payload,
            bool isResponse)
        {
            var step = isResponse
                ? saga.GetWaitingResponseStep() // 🔥 importante
                : saga.GetCurrent();

            if (step == null)
                return;

            // =============================
            // 🔒 VALIDAÇÕES DE ESTADO
            // =============================

            if (isResponse)
            {
                // só processa se estiver esperando resposta
                if (step.Status != SagaStepStatus.WaitingResponse)
                    return;
            }
            else
            {
                // não executa se está aguardando resposta
                if (step.Status == SagaStepStatus.WaitingResponse)
                    return;

                // respeita agendamento
                if (step.Status == SagaStepStatus.Pending &&
                    step.NextExecutionAt.HasValue &&
                    step.NextExecutionAt.Value > DateTime.UtcNow)
                    return;
            }

            var handlers = resolver.GetHandlers();

            if (!handlers.ContainsKey(step.Key))
                throw new Exception($"Handler não encontrado: {step.Key}");

            var handler = handlers[step.Key];

            try
            {
                if (isResponse)
                {
                    // =============================
                    // 📥 PROCESSA RESPOSTA (INBOX)
                    // =============================

                    handler.ApplyResponse(saga, step, payload);

                    step.MarkAsCompleted();

                    var next = saga.GetNext();
                    next?.SetPending();
                }
                else
                {
                    // =============================
                    // 📤 EXECUTA STEP (OUTGOING)
                    // =============================

                    // defer opcional
                    if (handler.IsAsync &&
                        step.Status == SagaStepStatus.Pending &&
                        step.RetryCount == 0)
                    {
                        // se quiser reativar:
                        // return;
                    }

                    handler.Execute(saga, step);
                }
            }
            catch (Exception e)
            {
                HandleFailure(saga, step, e);
            }
        }

        private void HandleFailure(SagaBase saga, SagaStep step, Exception e)
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