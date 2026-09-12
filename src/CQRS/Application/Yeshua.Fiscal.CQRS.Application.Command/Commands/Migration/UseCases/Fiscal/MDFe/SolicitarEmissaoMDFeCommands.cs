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
public partial record SolicitarEmissaoMDFeInputCommand : ICommand
{
    public string CorrelationId { get; set; } = string.Empty;
    public string CargaId { get; set; } = string.Empty;
    public int Ambiente { get; set; }
    public string UFCarregamento { get; set; } = string.Empty;
    public string UFDescarregamento { get; set; } = string.Empty;
    public string PlacaVeiculo { get; set; } = string.Empty;
    public string DocumentosOriginariosJson { get; set; } = string.Empty;
}

public partial record SolicitarEmissaoMDFeOutputCommand : ICommand
{
    public int SolicitacaoId { get; set; }
    public string CorrelationId { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public bool ProntoParaAutorizar { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup