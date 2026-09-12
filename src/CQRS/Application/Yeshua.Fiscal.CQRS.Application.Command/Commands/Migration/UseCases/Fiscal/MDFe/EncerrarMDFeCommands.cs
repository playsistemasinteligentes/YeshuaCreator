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
public partial record EncerrarMDFeInputCommand : ICommand
{
    public string ChaveAcesso { get; set; } = string.Empty;
    public string UfCarregamento { get; set; } = string.Empty;
    public string UfDescarregamento { get; set; } = string.Empty;
    public string PlacaVeiculo { get; set; } = string.Empty;
}

public partial record EncerrarMDFeOutputCommand : ICommand
{
    public string ChaveAcesso { get; set; } = string.Empty;
    public bool Encerrado { get; set; }
    public string Protocolo { get; set; } = string.Empty;
    public string Mensagem { get; set; } = string.Empty;
    public Nullable<DateTime> EncerradoEm { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup