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
public partial record ConsultarChamadoSuporteInputCommand : ICommand
{
    public string ChamadoId { get; set; } = string.Empty;
    public string Aplicativo { get; set; } = string.Empty;
    public string Modulo { get; set; } = string.Empty;
    public string Tela { get; set; } = string.Empty;
    public string TituloTela { get; set; } = string.Empty;
    public string Rota { get; set; } = string.Empty;
    public string Caminho { get; set; } = string.Empty;
    public string FusoHorario { get; set; } = string.Empty;
    public string MomentoClienteUtc { get; set; } = string.Empty;
    public string Assunto { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
}

public partial record ConsultarChamadoSuporteOutputCommand : ICommand
{
    public string ChamadoId { get; set; } = string.Empty;
    public bool Aberto { get; set; }
    public string Assunto { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Aplicativo { get; set; } = string.Empty;
    public string Modulo { get; set; } = string.Empty;
    public string Tela { get; set; } = string.Empty;
    public string Versao { get; set; } = string.Empty;
    public string TranscricaoStatus { get; set; } = string.Empty;
    public string Transcricao { get; set; } = string.Empty;
    public string ErroTranscricao { get; set; } = string.Empty;
    public int SagaId { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup