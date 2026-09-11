// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup
// </yeshua>

namespace Command.UseCase
{
    public partial record CriarCargaDaSelecaoPlanejamentoTransporteInputCommand
    {
        public string TransportadoraId { get; set; }
        public string VeiculoPlaca { get; set; }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup
