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
public partial record ReservarCanalStandardInputCommand : ICommand, IOperationalTelemetryCommand
{
    public bool SomenteConsultar { get; set; }

    public string OperationalEntity => "CanalStandard";
    public string? OperationalRecordId => null;
}

public partial record ReservarCanalStandardOutputCommand : ICommand
{
    public bool Disponivel { get; set; }
    public int CanalStandardId { get; set; }
    public string CanalId { get; set; } = string.Empty;
    public string ConexaoYouTubeId { get; set; } = string.Empty;
    public int CredencialTenantId { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup