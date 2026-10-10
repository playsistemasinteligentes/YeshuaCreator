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
public partial record CreateContaInputCommand : ICommand, IOperationalTelemetryCommand
{
    public string CpfCnpj { get; set; } = string.Empty;
    public string nome { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string phone { get; set; } = string.Empty;
    public string password { get; set; } = string.Empty;
    public string confirmpassword { get; set; } = string.Empty;

    public string OperationalEntity => "yTenant";
    public string? OperationalRecordId => null;
}

public partial record CreateContaOutputCommand : ICommand
{
    public int TenantId { get; set; }
    public int UserId { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup