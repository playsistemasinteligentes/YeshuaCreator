using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace AppClinicas;

[Migration(000006)]
public sealed class M000006 : MigrationBase
{
    public override void Up()
    {
        // Nullable for legacy rows; the domain defaults new services to 1.
        // DSL DefaultValue is constructor-owned and would override a selected model.
        AlterEntity("Servico")
            .AddColumn("ModeloConsulta", "Modelo da consulta").Int()
            .Enumerable(1, "Psicologia completa").Enumerable(2, "Registro simplificado");
        AlterEntity("Profissional")
            .AddColumn("ServicoHabitualId", "Serviço habitual").Int().FK("Servico", "Id").Immutable().EditFront(false);
        AlterEntity("Sesoes")
            .AddColumn("ServicoNome", "Serviço no agendamento").Varchar(150).Immutable().EditFront(false)
            .AddColumn("ModeloConsulta", "Modelo da consulta").Int().Immutable().EditFront(false)
            .AddColumn("VersaoModeloConsulta", "Versão do modelo").Int().Immutable().EditFront(false);

        var commands = AddUsecaseGroup("Clinica").AddUseCaseSubGrup("Atendimentos");
        commands.AddCommand("ConsultarServicosAgendamento", new ServicosAgendamentoInput(), new ServicosAgendamentoOutput())
            .Authorization(Authorization.User).AddScope("clinica.atendimentos");
        commands.AddCommand("DefinirServicoHabitual", new ServicoHabitualInput(), new ServicoAgendamentoInfo())
            .Authorization(Authorization.User).AddScope("clinica.atendimentos");
    }
}

public sealed record ServicosAgendamentoInput();
public sealed record ServicoHabitualInput(int ServicoId = 0);
public sealed record ServicoAgendamentoInfo(int Id = 0, string Nome = "", int ModeloConsulta = 1, int VersaoModeloConsulta = 1);
public sealed class ServicosAgendamentoOutput
{
    public List<ServicoAgendamentoInfo> Servicos { get; set; } = [];
}
