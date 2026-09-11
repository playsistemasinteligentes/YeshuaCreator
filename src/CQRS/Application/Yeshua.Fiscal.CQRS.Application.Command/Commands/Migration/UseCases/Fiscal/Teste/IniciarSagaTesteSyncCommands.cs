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
public partial record IniciarSagaTesteSyncInputCommand : ICommand
{
    public string CorrelationId { get; set; }
    public int TenantId { get; set; }
    public string EntityId { get; set; }
}

public partial record IniciarSagaTesteSyncOutputCommand : ICommand
{
    public string CorrelationId { get; set; }
    public int SagaId { get; set; }
    public string EntityId { get; set; }
    public string Status { get; set; }
    public string Mensagem { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup