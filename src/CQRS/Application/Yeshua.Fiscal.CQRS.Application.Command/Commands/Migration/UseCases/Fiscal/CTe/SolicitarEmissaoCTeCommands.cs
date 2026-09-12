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
public partial record SolicitarEmissaoCTeInputCommand : ICommand
{
    public int RomaneioConsolidadoId { get; set; }
    public string UFEmitente { get; set; } = string.Empty;
    public string EmitenteDocumento { get; set; } = string.Empty;
    public int Ambiente { get; set; }
    public int ProdutoFiscal { get; set; }
    public int TipoCTe { get; set; }
    public int TipoServico { get; set; }
    public int Modal { get; set; }
}

public partial record SolicitarEmissaoCTeOutputCommand : ICommand
{
    public int SolicitacaoId { get; set; }
    public string CorrelationId { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public bool ProntoParaAutorizar { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup