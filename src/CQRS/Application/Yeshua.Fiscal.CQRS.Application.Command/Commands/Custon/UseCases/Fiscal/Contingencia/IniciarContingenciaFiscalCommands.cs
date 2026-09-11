// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup
// </yeshua>

using RepositoryInterfaces.Patterns.Command;

namespace Command.UseCase
{
    public partial record IniciarContingenciaFiscalOutputCommand
    {
        public int SagaId { get; set; }
        public string StepKey { get; set; } = string.Empty;
        public int SagaStatus { get; set; }
    }

}

//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup
