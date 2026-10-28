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
public partial record ConsultarAtendimentosInputCommand : ICommand
{
    public string Data { get; set; } = string.Empty;
    public int SessaoId { get; set; }
}

public partial record ConsultarAtendimentosOutputCommand : ICommand
{
    public int ProfissionalId { get; set; }
    public string ProfissionalNome { get; set; } = string.Empty;
    public int ServicoHabitualId { get; set; }
    public string ServicoHabitualNome { get; set; } = string.Empty;
    public int ModeloConsultaHabitual { get; set; }
    public int VersaoModeloConsultaHabitual { get; set; }
    public List<AgendaAtendimentoInfo> Agenda { get; set; } = default!;
    public List<PacienteAtendimentoInfo> Pacientes { get; set; } = default!;
    public List<RegistroAtendimentoInfo> Atual { get; set; } = default!;
    public List<RegistroAtendimentoInfo> Historico { get; set; } = default!;
    public List<AudioAtendimentoInfo> Audios { get; set; } = default!;
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup