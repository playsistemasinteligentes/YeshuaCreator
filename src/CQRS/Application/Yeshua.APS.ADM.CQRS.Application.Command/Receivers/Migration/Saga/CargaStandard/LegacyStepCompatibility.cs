// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Legacy saga compatibility shim
// </yeshua>

using Dominio.Patterns.Saga;

namespace Command.Receivers
{
    public partial class EnviarNotasFiscaisHandler
    {
        partial void CustomExecute(SagaBase saga, SagaStepBase step);
        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload);
    }

    public partial class GerarCTeHandler
    {
        partial void CustomExecute(SagaBase saga, SagaStepBase step);
        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload);
    }

    public partial class GerarMDFeHandler
    {
        partial void CustomExecute(SagaBase saga, SagaStepBase step);
        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload);
    }
}
