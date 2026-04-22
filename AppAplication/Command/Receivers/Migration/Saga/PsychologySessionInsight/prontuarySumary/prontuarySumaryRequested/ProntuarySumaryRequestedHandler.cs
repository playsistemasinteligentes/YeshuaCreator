using Command.Saga;
using Dominio.Saga;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Saga;
using Dominio.Patterns.Saga;
using System;

namespace Command.Receivers
{
    public partial class prontuarySumaryRequestedHandler : ISagaStepHandler
    {
        public string Key => PsychologySessionInsightSaga.STEP_3;

        public bool IsAsync => true;

        public void Execute(SagaBase saga, SagaStepBase step)
        {
            try
            {
                saga.MarkInProgress();

                CustomExecute(saga, step);

                saga.MarkWaiting(step.CorrelationId);
            }
            catch (Exception ex)
            {
                saga.MarkFailed(ex.Message);
                throw;
            }
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers