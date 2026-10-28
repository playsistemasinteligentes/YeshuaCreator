// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Dominio.Patterns.Saga;

namespace Dominio.Saga
{
    public class ConfiguracaoInicialClinicaSaga : SagaBase
    {
        public const string STEP_1 = "ConfigurarEstabelecimento";
        public const string STEP_2 = "VincularProfissionalInicial";
        public const string STEP_3 = "DefinirServicoInicial";

        public ConfiguracaoInicialClinicaSaga()
        {
            AddStep(new ConfiguracaoInicialClinicaStep(STEP_1, 1));
            AddStep(new ConfiguracaoInicialClinicaStep(STEP_2, 2));
            AddStep(new ConfiguracaoInicialClinicaStep(STEP_3, 3));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers