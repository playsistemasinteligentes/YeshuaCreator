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
    public partial class ClinicaHubCommand : ICommand
    {
    }

public partial record AgendaAtendimentoInfo : ICommand
{
    public int Id { get; set; }
    public string Paciente { get; set; } = string.Empty;
    public string DataInicio { get; set; } = string.Empty;
    public string DataFim { get; set; } = string.Empty;
    public int StatusAgendamento { get; set; }
    public int StatusProntuario { get; set; }
    public bool Pendente { get; set; }
}

public partial record PacienteAtendimentoInfo : ICommand
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
}

public partial record RegistroAtendimentoInfo : ICommand
{
    public int Id { get; set; }
    public int PacienteId { get; set; }
    public string Paciente { get; set; } = string.Empty;
    public string DataNascimento { get; set; } = string.Empty;
    public string DataInicio { get; set; } = string.Empty;
    public string DataFim { get; set; } = string.Empty;
    public int StatusAgendamento { get; set; }
    public int StatusProntuario { get; set; }
    public int Versao { get; set; }
    public string AtendimentoIniciadoEm { get; set; } = string.Empty;
    public string AtendimentoEncerradoEm { get; set; } = string.Empty;
    public string RegistroFinalizadoEm { get; set; } = string.Empty;
    public string Prontuario { get; set; } = string.Empty;
    public string QueixaPrincipal { get; set; } = string.Empty;
    public string RegistroDocumental { get; set; } = string.Empty;
    public string ObjetivosCurtoPrazo { get; set; } = string.Empty;
    public string ObjetivosLongoPrazo { get; set; } = string.Empty;
    public string ExerciciosTarefasSugeridas { get; set; } = string.Empty;
    public string EncaminhamentoOutrosProfissionais { get; set; } = string.Empty;
    public string FrequenciaSugeridaSessooes { get; set; } = string.Empty;
    public string InformacoesRelevantesFuturasConsultas { get; set; } = string.Empty;
    public string SugestoesIncorporadas { get; set; } = string.Empty;
    public int ServicoId { get; set; }
    public string ServicoNome { get; set; } = string.Empty;
    public int ModeloConsulta { get; set; }
    public int VersaoModeloConsulta { get; set; }
}

public partial record AudioAtendimentoInfo : ICommand
{
    public int SagaId { get; set; }
    public string Data { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Transcricao { get; set; } = string.Empty;
    public string Prontuario { get; set; } = string.Empty;
    public string QueixaPrincipal { get; set; } = string.Empty;
    public string RegistroDocumental { get; set; } = string.Empty;
    public int StepFalhouId { get; set; }
}

public partial record ServicoAgendamentoInfo : ICommand
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int ModeloConsulta { get; set; }
    public int VersaoModeloConsulta { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup