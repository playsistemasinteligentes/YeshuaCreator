// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup
// </yeshua>

//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup
using RepositoryInterfaces.Patterns.Command;

namespace Command.UseCase
{
    public partial record InformarNotasFiscaisContingenciaOutputCommand
    {
        public string DocumentosOriginariosJson { get; set; } = string.Empty;
    }
}
