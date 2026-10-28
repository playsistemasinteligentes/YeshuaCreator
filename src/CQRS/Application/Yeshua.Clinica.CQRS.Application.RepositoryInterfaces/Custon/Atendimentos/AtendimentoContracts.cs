namespace Clinica.Atendimentos;
public sealed record ConsultaPainelInput(string Data = "", int SessaoId = 0);
public sealed record AgendaInput(int PacienteId = 0, string DataInicio = "", string DataFim = "", int ServicoId = 0, int ModeloConsulta = 0, int VersaoModeloConsulta = 0);
public sealed record VersaoInput(int SessaoId = 0, int Versao = 0);
public sealed record VinculoInput(int ProfissionalId = 0, int UsuarioId = 0);
public sealed record AlteracaoOutput(int SessaoId = 0, int Versao = 0);
public sealed record RegistroInput(int SessaoId = 0, int Versao = 0, string Prontuario = "", string QueixaPrincipal = "",
    string RegistroDocumental = "", string ObjetivosCurtoPrazo = "", string ObjetivosLongoPrazo = "",
    string ExerciciosTarefasSugeridas = "", string EncaminhamentoOutrosProfissionais = "",
    string FrequenciaSugeridaSessooes = "", string InformacoesRelevantesFuturasConsultas = "",
    bool Revisado = false, string Motivo = "", int IncorporarSagaId = 0);
public sealed class PainelOutput
{
    public int ProfissionalId { get; set; }
    public string ProfissionalNome { get; set; } = "";
    public int ServicoHabitualId { get; set; }
    public string ServicoHabitualNome { get; set; } = "";
    public int ModeloConsultaHabitual { get; set; }
    public int VersaoModeloConsultaHabitual { get; set; }
    public List<AgendaAtendimentoInfo> Agenda { get; set; } = [];
    public List<PacienteAtendimentoInfo> Pacientes { get; set; } = [];
    public List<RegistroAtendimentoInfo> Atual { get; set; } = [];
    public List<RegistroAtendimentoInfo> Historico { get; set; } = [];
    public List<AudioAtendimentoInfo> Audios { get; set; } = [];
}
public sealed record PacienteAtendimentoInfo(int Id = 0, string Nome = "");
public sealed record AgendaAtendimentoInfo(int Id = 0, string Paciente = "", string DataInicio = "", string DataFim = "",
    int StatusAgendamento = 0, int StatusProntuario = 0, bool Pendente = false);
public sealed record RegistroAtendimentoInfo(int Id = 0, int PacienteId = 0, string Paciente = "", string DataNascimento = "",
    string DataInicio = "", string DataFim = "", int StatusAgendamento = 0, int StatusProntuario = 0, int Versao = 0,
    string AtendimentoIniciadoEm = "", string AtendimentoEncerradoEm = "", string RegistroFinalizadoEm = "",
    string Prontuario = "", string QueixaPrincipal = "", string RegistroDocumental = "", string ObjetivosCurtoPrazo = "",
    string ObjetivosLongoPrazo = "", string ExerciciosTarefasSugeridas = "", string EncaminhamentoOutrosProfissionais = "",
    string FrequenciaSugeridaSessooes = "", string InformacoesRelevantesFuturasConsultas = "", string SugestoesIncorporadas = "",
    int ServicoId = 0, string ServicoNome = "", int ModeloConsulta = 1, int VersaoModeloConsulta = 1);
public sealed record AudioAtendimentoInfo(int SagaId = 0, string Data = "", string Status = "", string Transcricao = "",
    string Prontuario = "", string QueixaPrincipal = "", string RegistroDocumental = "", int StepFalhouId = 0);

public sealed record ServicoAgendamentoInfo(int Id = 0, string Nome = "", int ModeloConsulta = 1, int VersaoModeloConsulta = 1);
public sealed class ServicosAgendamentoOutput
{
    public List<ServicoAgendamentoInfo> Servicos { get; set; } = [];
}

public sealed class AtendimentoException(string message, int status = 400) : Exception(message)
{ public int Status { get; } = status; }
