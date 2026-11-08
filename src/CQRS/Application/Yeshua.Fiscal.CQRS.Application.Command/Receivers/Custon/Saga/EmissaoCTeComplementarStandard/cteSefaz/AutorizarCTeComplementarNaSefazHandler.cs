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
    public partial class AutorizarCTeComplementarNaSefazHandler
    {
        private readonly AutorizarCTeNaSefazHandler _autorizarCTeNaSefazHandler;

        public AutorizarCTeComplementarNaSefazHandler(AutorizarCTeNaSefazHandler autorizarCTeNaSefazHandler)
        {
            _autorizarCTeNaSefazHandler = autorizarCTeNaSefazHandler;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            _autorizarCTeNaSefazHandler.Execute(saga, step);
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _autorizarCTeNaSefazHandler.ApplyResponse(saga, step, payload);
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
