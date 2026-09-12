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
public partial record ReceberRomaneioConsolidadoParaCTeInputCommand : ICommand
{
    public string CorrelationId { get; set; } = string.Empty;
    public int TenantId { get; set; }
    public string SourceApplication { get; set; } = string.Empty;
    public string SourceModule { get; set; } = string.Empty;
    public string SourceMessageId { get; set; } = string.Empty;
    public string RomaneioId { get; set; } = string.Empty;
    public string CargaId { get; set; } = string.Empty;
    public string UFInicio { get; set; } = string.Empty;
    public string UFFim { get; set; } = string.Empty;
    public string MunicipioInicioCodigoIbge { get; set; } = string.Empty;
    public string MunicipioFimCodigoIbge { get; set; } = string.Empty;
    public string EmitenteDocumento { get; set; } = string.Empty;
    public string TomadorDocumento { get; set; } = string.Empty;
    public string RotaSnapshotJson { get; set; } = string.Empty;
    public string CargaSnapshotJson { get; set; } = string.Empty;
    public string PreferenciasFiscaisJson { get; set; } = string.Empty;
    public string PayloadHash { get; set; } = string.Empty;
    public string PayloadStorageKey { get; set; } = string.Empty;
}

public partial record ReceberRomaneioConsolidadoParaCTeOutputCommand : ICommand
{
    public string CorrelationId { get; set; } = string.Empty;
    public bool Accepted { get; set; }
    public string Mensagem { get; set; } = string.Empty;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup