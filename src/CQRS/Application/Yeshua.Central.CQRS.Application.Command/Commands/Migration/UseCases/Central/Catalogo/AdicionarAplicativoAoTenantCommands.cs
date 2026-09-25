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
public partial record AdicionarAplicativoAoTenantInputCommand : ICommand, IOperationalTelemetryCommand
{
    public string Aplicativo { get; set; } = string.Empty;

    public string OperationalEntity => "yTenant";
    public string? OperationalRecordId => null;
}

public partial record AdicionarAplicativoAoTenantOutputCommand : ICommand
{
    public bool Adicionado { get; set; }
    public string Aplicativo { get; set; } = string.Empty;
    public List<string> Catalogos { get; set; } = default!;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup