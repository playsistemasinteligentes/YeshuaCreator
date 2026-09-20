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
public partial record StarSessionUploadInputCommand : ICommand, IOperationalTelemetryCommand
{
    public string token { get; set; } = string.Empty;
    public string entityType { get; set; } = string.Empty;
    public string entityId { get; set; } = string.Empty;

    public string OperationalEntity => "yFileUpload";
    public string? OperationalRecordId => null;
}

public partial record StarSessionUploadOutputCommand : ICommand
{
    public string uploadToken { get; set; } = string.Empty;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup