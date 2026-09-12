// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Dominio.Saga;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Saga;
using Dominio.Patterns.Saga;
using System;

namespace Command.Receivers
{
    public partial class ValidarPlanoEmissaoFiscalHandler : ISagaStepHandler
    {
        public string Key => ContingenciaFiscalStandardSaga.STEP_8;

        public bool RequiresExternalStimulus => false;

        public void Execute(SagaBase saga, SagaStepBase step)
        {
            try
            {
                // marca execução
                step.SetInProgress();

                // lógica de domínio
                CustomExecute(saga, step);

                // define próximo estado
                if (RequiresExternalStimulus)
                {
                    step.SetWaiting();
                }
                else
                {
                    step.SetPendingApply();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            try
            {
                // aplica no domínio
                CustomApplyResponse(saga, step, payload);

            }
            catch (Exception)
            {
                throw;
            }
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step);
        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers