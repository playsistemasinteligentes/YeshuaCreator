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
        public int StepStatus { get; set; }
        public int SagaStatus { get; set; }
        public string SugestaoRemetenteDocumento { get; set; } = string.Empty;
        public string SugestaoDestinatarioDocumento { get; set; } = string.Empty;
        public string SugestaoUFInicio { get; set; } = string.Empty;
        public string SugestaoUFFim { get; set; } = string.Empty;
        public string SugestaoMunicipioInicioCodigoIbge { get; set; } = string.Empty;
        public string SugestaoMunicipioFimCodigoIbge { get; set; } = string.Empty;
        public string DocumentosOriginariosJson { get; set; } = string.Empty;
    }

}

//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup
