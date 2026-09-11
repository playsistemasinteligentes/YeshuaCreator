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
    public string CorrelationId { get; set; }
    public int TenantId { get; set; }
    public string SourceApplication { get; set; }
    public string SourceModule { get; set; }
    public string SourceMessageId { get; set; }
    public string RomaneioId { get; set; }
    public string CargaId { get; set; }
    public string UFInicio { get; set; }
    public string UFFim { get; set; }
    public string MunicipioInicioCodigoIbge { get; set; }
    public string MunicipioFimCodigoIbge { get; set; }
    public string EmitenteDocumento { get; set; }
    public string TomadorDocumento { get; set; }
    public string RotaSnapshotJson { get; set; }
    public string CargaSnapshotJson { get; set; }
    public string PreferenciasFiscaisJson { get; set; }
    public string PayloadHash { get; set; }
    public string PayloadStorageKey { get; set; }
}

public partial record ReceberRomaneioConsolidadoParaCTeOutputCommand : ICommand
{
    public string CorrelationId { get; set; }
    public bool Accepted { get; set; }
    public string Mensagem { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup