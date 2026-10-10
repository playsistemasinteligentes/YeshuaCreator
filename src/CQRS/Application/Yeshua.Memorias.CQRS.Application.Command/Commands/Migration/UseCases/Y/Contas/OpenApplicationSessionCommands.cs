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
public partial record OpenApplicationSessionInputCommand : ICommand, IOperationalTelemetryCommand
{
    public string TenantIdentity { get; set; } = string.Empty;
    public string TenantDocument { get; set; } = string.Empty;
    public string TenantName { get; set; } = string.Empty;
    public string UserIdentity { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string OperationalEntity => "yTenant";
    public string? OperationalRecordId => null;
}

public partial record OpenApplicationSessionOutputCommand : ICommand
{
    public int TenantId { get; set; }
    public int UserId { get; set; }
    public string Email { get; set; } = string.Empty;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup