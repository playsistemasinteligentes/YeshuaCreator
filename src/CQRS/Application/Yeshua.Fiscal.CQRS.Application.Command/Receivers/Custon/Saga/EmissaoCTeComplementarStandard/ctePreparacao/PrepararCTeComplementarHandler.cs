// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Dominio.Patterns.Saga;

namespace Command.Receivers
{
    public partial class PrepararCTeComplementarHandler
    {
        private readonly PrepararCTeHandler _prepararCTeHandler;

        public PrepararCTeComplementarHandler(PrepararCTeHandler prepararCTeHandler)
        {
            _prepararCTeHandler = prepararCTeHandler;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            _prepararCTeHandler.Execute(saga, step);
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _prepararCTeHandler.ApplyResponse(saga, step, payload);
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
