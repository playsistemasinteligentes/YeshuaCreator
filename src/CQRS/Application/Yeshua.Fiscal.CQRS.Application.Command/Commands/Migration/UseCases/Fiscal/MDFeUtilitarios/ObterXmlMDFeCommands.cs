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
public partial record ObterXmlMDFeInputCommand : ICommand, IOperationalTelemetryCommand
{
    public string ChaveAcesso { get; set; } = string.Empty;

    public string OperationalEntity => "MDFeTentativaEmissao";
    public string? OperationalRecordId => null;
}

public partial record ObterXmlMDFeOutputCommand : ICommand
{
    public string ChaveAcesso { get; set; } = string.Empty;
    public string NomeArquivo { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public string ArquivoBase64 { get; set; } = string.Empty;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup