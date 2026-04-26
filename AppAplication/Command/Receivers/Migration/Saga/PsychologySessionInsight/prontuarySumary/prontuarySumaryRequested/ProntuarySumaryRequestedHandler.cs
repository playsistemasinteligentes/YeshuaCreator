using Command.Saga;
using Dominio.Saga;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Saga;
using Dominio.Patterns.Saga;
using System;

namespace Command.Receivers
{
    public partial class ProntuarySumaryRequestedHandler : ISagaStepHandler
    {
        public string Key => PsychologySessionInsightSaga.STEP_3;

        public bool IsAsync => true;

        public void Execute(SagaBase saga, SagaStepBase step)
        {
            try
            {
                // marca execução
                step.SetInProgress();

                // lógica de domínio
                CustomExecute(saga, step);

                // define próximo estado
                if (IsAsync)
                {
                    var correlationId = Guid.NewGuid().ToString();
                    step.SetWaiting(correlationId);
                }
                else
                {
                    step.SetPendingApply();
                }
            }
            catch (Exception ex)
            {
                saga.MarkFailed(ex.Message);
                throw;
            }
        }

        public void ApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            try
            {
                // aplica no domínio
                CustomApplyResponse(saga, step, payload);

                // finaliza step
                saga.CompleteCurrentStep();
            }
            catch (Exception ex)
            {
                saga.MarkFailed(ex.Message);
                throw;
            }
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step);
        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers