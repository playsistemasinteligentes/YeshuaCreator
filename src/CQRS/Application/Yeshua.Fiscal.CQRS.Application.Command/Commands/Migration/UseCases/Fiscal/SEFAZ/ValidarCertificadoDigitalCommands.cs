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
public partial record ValidarCertificadoDigitalInputCommand : ICommand, IOperationalTelemetryCommand
{
    public int CertificadoDigitalId { get; set; }

    public string OperationalEntity => "CertificadoDigital";
    public string? OperationalRecordId => null;
}

public partial record ValidarCertificadoDigitalOutputCommand : ICommand
{
    public bool Valido { get; set; }
    public string Mensagem { get; set; } = string.Empty;
    public Nullable<DateTime> ValidoAte { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup