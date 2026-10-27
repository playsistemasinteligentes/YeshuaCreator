using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace AppClinicas;

[Migration(000005)]
public sealed class M000005 : MigrationBase
{
    public override void Up()
    {
        AlterEntity("Profissional")
            .AddColumn("UsuarioAcessoId", "Usuário de acesso").Int().FK("yUser", "Id").Immutable().EditFront(false).VisivelFront(false);
        AlterEntity("Sesoes").AlterColumn("StatusAgendamento", "Status do Agendamento").Int().Group("Agenda")
            .Enumerable(0, "EmConciliacaoDeHorarios").Enumerable(1, "Confirmada")
            .Enumerable(2, "Realizada").Enumerable(3, "Cancelada").Enumerable(4, "NaoCompareceu");
        AlterEntity("Sesoes")
            .AddColumn("AtendimentoIniciadoEm", "Início real").DateTime().EditFront(false)
            .AddColumn("AtendimentoEncerradoEm", "Fim real").DateTime().EditFront(false)
            .AddColumn("VersaoAtendimento", "Versão").Int().NotNull().DefaultValue("0").EditFront(false)
            .AddColumn("RegistroFinalizadoEm", "Registro finalizado em").DateTime().EditFront(false)
            .AddColumn("RegistroFinalizadoPorUserId", "Revisado por").Int().FK("yUser", "Id").EditFront(false)
            .AddColumn("SugestoesIncorporadas", "Origem das sugestões").VarcharMax().EditFront(false);
        AddEntity("RevisaoRegistroSessao").AddModule("PSI")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("SessaoId", "Sessão").Int().FK("Sesoes", "Id").NotNull()
            .AddColumn("Versao", "Versão").Int().NotNull()
            .AddColumn("AutorUserId", "Autor").Int().FK("yUser", "Id").NotNull()
            .AddColumn("RevisadoEm", "Revisado em").DateTime().NotNull()
            .AddColumn("Motivo", "Motivo da correção").Varchar(1000)
            .AddColumn("Registro", "Registro revisado").VarcharMax().NotNull();

        AddCustomPage("PSI", "Atendimentos", "clinica-atendimentos", "clinica.atendimentos", "Atendimento");
        var commands = AddUsecaseGroup("Clinica").AddUseCaseSubGrup("Atendimentos");
        commands.AddCommand("ConsultarAtendimentos", new ConsultaPainelInput(), new PainelOutput()).Authorization(Authorization.User).AddScope("clinica.atendimentos");
        commands.AddCommand("AgendarAtendimento", new AgendaInput(), new AlteracaoOutput()).Authorization(Authorization.User).AddScope("clinica.atendimentos");
        foreach (var name in new[] { "IniciarAtendimento", "EncerrarAtendimento", "CancelarAtendimento", "RegistrarFalta" })
            commands.AddCommand(name, new VersaoInput(), new AlteracaoOutput()).Authorization(Authorization.User).AddScope("clinica.atendimentos");
        foreach (var name in new[] { "SalvarRegistro", "FinalizarRegistro", "CorrigirRegistro" })
            commands.AddCommand(name, new RegistroInput(), new AlteracaoOutput()).Authorization(Authorization.User).AddScope("clinica.atendimentos");
        commands.AddCommand("VincularProfissional", new VinculoInput(), new AlteracaoOutput()).Authorization(Authorization.User).AddScope("clinica.atendimentos.configurar");
    }
}

public sealed record ConsultaPainelInput(string Data = "", int SessaoId = 0);
public sealed record AgendaInput(int PacienteId = 0, string DataInicio = "", string DataFim = "");
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
    string FrequenciaSugeridaSessooes = "", string InformacoesRelevantesFuturasConsultas = "", string SugestoesIncorporadas = "");
public sealed record AudioAtendimentoInfo(int SagaId = 0, string Data = "", string Status = "", string Transcricao = "",
    string Prontuario = "", string QueixaPrincipal = "", string RegistroDocumental = "", int StepFalhouId = 0);
