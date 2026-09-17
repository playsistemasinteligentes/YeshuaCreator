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
public partial record ConsultarProcessamentoContingenciaFiscalInputCommand : ICommand
{
    public int EntradaFiscalContingenciaId { get; set; }
}

public partial record ConsultarProcessamentoContingenciaFiscalOutputCommand : ICommand
{
    public int EntradaFiscalContingenciaId { get; set; }
    public string CorrelationId { get; set; } = string.Empty;
    public string CargaId { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string EtapaAtual { get; set; } = string.Empty;
    public bool Concluida { get; set; }
    public bool DownloadDisponivel { get; set; }
    public string Mensagem { get; set; } = string.Empty;
    public string SagasJson { get; set; } = string.Empty;
    public string DocumentosJson { get; set; } = string.Empty;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup