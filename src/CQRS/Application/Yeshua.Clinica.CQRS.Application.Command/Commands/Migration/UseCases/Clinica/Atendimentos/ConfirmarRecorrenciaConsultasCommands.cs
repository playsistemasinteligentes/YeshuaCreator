// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup
// </yeshua>

using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
using Dominio.Enum.Strategy;
using Command.Interfaces;
using Microsoft.AspNetCore.Http;
namespace Command.UseCase
{
public partial record ConfirmarRecorrenciaConsultasInputCommand : ICommand
{
    public string PlanoId { get; set; } = string.Empty;
    public bool Revisado { get; set; }
    public List<EscolhaRecorrenciaInfo> Ocorrencias { get; set; } = default!;
}

public partial record ConfirmarRecorrenciaConsultasOutputCommand : ICommand
{
    public string PlanoId { get; set; } = string.Empty;
    public bool Confirmado { get; set; }
    public List<OcorrenciaRecorrenciaInfo> Ocorrencias { get; set; } = default!;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup