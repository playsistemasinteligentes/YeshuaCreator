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
public partial record CancelarCTeExternoInputCommand : ICommand, IOperationalTelemetryCommand
{
    public string ChaveAcesso { get; set; } = string.Empty;
    public string ProtocoloAutorizacao { get; set; } = string.Empty;
    public int Ambiente { get; set; }
    public string Justificativa { get; set; } = string.Empty;
    public int SequenciaEvento { get; set; }

    public string OperationalEntity => "CertificadoDigital";
    public string? OperationalRecordId => null;
}

public partial record CancelarCTeExternoOutputCommand : ICommand
{
    public string ChaveAcesso { get; set; } = string.Empty;
    public bool Registrado { get; set; }
    public int CodigoRetorno { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public string ProtocoloEvento { get; set; } = string.Empty;
    public int HttpStatusCode { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup