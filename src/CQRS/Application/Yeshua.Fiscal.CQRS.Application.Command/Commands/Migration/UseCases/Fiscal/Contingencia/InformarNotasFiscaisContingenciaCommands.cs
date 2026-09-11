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
public partial record InformarNotasFiscaisContingenciaInputCommand : ICommand
{
    public string CorrelationId { get; set; }
    public int TenantId { get; set; }
    public string CargaId { get; set; }
    public int EntradaFiscalContingenciaId { get; set; }
    public string UserAction { get; set; }
    public string DocumentosOriginariosJson { get; set; }
    public string DadosComplementaresJson { get; set; }
    public string PayloadHash { get; set; }
    public string PayloadStorageKey { get; set; }
}

public partial record InformarNotasFiscaisContingenciaOutputCommand : ICommand, ISagaStepStimulusOutput
{
    public string CorrelationId { get; set; }
    public string CargaId { get; set; }
    public string StepKey { get; set; }
    public int SagaId { get; set; }
    public int SagaStepId { get; set; }
    public int InboxId { get; set; }
    public bool Accepted { get; set; }
    public string Mensagem { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup