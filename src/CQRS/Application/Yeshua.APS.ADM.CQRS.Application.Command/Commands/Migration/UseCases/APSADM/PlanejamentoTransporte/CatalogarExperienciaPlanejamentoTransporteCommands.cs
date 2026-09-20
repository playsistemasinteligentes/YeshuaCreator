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
public partial record CatalogarExperienciaPlanejamentoTransporteInputCommand : ICommand, IOperationalTelemetryCommand
{
    public int Tipo { get; set; }
    public string Referencia { get; set; } = string.Empty;
    public string PedidoId { get; set; } = string.Empty;
    public string ClienteId { get; set; } = string.Empty;
    public string Municipio { get; set; } = string.Empty;
    public string Regiao { get; set; } = string.Empty;
    public string RotaId { get; set; } = string.Empty;
    public string Observacao { get; set; } = string.Empty;

    public string OperationalEntity => "ExperienciaPlanejamentoTransporte";
    public string? OperationalRecordId => null;
}

public partial record CatalogarExperienciaPlanejamentoTransporteOutputCommand : ICommand
{
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; } = string.Empty;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup