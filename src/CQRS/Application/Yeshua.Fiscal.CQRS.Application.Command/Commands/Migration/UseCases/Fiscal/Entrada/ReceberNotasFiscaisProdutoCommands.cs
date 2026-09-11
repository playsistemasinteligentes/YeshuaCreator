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
public partial record ReceberNotasFiscaisProdutoInputCommand : ICommand
{
    public string CorrelationId { get; set; }
    public int TenantId { get; set; }
    public string SourceApplication { get; set; }
    public string SourceModule { get; set; }
    public string SourceMessageId { get; set; }
    public string CargaId { get; set; }
    public string NotasFiscaisJson { get; set; }
    public string PayloadHash { get; set; }
    public string PayloadStorageKey { get; set; }
}

public partial record ReceberNotasFiscaisProdutoOutputCommand : ICommand
{
    public string CorrelationId { get; set; }
    public bool Accepted { get; set; }
    public int QuantidadeNotas { get; set; }
    public string Mensagem { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup