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
    public string CorrelationId { get; set; }
    public string CargaId { get; set; }
    public int Ambiente { get; set; }
    public string UFCarregamento { get; set; }
    public string UFDescarregamento { get; set; }
    public string PlacaVeiculo { get; set; }
    public string DocumentosOriginariosJson { get; set; }
}

public partial record SolicitarEmissaoMDFeOutputCommand : ICommand
{
    public int SolicitacaoId { get; set; }
    public string CorrelationId { get; set; }
    public string Status { get; set; }
    public bool ProntoParaAutorizar { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup