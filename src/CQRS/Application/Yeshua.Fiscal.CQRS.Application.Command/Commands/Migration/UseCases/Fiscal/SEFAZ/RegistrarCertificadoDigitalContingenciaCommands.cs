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
public partial record RegistrarCertificadoDigitalContingenciaInputCommand : ICommand
{
    public int EntradaFiscalContingenciaId { get; set; }
    public string DocumentoTitular { get; set; } = string.Empty;
    public string Apelido { get; set; } = string.Empty;
    public string ArquivoPfxBase64 { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}

public partial record RegistrarCertificadoDigitalContingenciaOutputCommand : ICommand
{
    public int CertificadoDigitalId { get; set; }
    public string DocumentoTitular { get; set; } = string.Empty;
    public string Thumbprint { get; set; } = string.Empty;
    public Nullable<DateTime> ValidoDe { get; set; }
    public Nullable<DateTime> ValidoAte { get; set; }
    public bool Reutilizado { get; set; }
    public string Mensagem { get; set; } = string.Empty;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup