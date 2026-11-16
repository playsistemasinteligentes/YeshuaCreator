using Dominio;
using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace AppClinicas;

[Migration(000009)]
public sealed class M000009 : MigrationBase
{
    public override void Up()
    {
        AlterEntity("Sesoes")
            .AddColumn("RecorrenciaId", "Série de consultas").Varchar(32).Immutable().EditFront(false).VisivelFront(false);
        // Tenant-scoped, internal persistence: no CRUD, lookup, menu or public metadata.
        AddEntity("PlanoRecorrenciaConsulta")
            .InternalToUseCase("Clinica", "Atendimentos", "ExecutarRecorrenciaConsultas")
            .AddColumn("Id", "ID").Varchar(32).Key()
            .AddColumn("ProfissionalId", "Profissional").Int().NotNull()
            .AddColumn("Plano", "Prévia").VarcharMax().NotNull().ClassifyOperationalData(OperationalDataClassification.NeverCapture)
            .AddColumn("ConfirmacaoHash", "Confirmação").Varchar(64)
            .AddColumn("Resultado", "Resultado").VarcharMax().ClassifyOperationalData(OperationalDataClassification.NeverCapture)
            .AddColumn("ExpiraEmUtc", "Validade da prévia").DateTime().NotNull();
        var commands = AddUsecaseGroup("Clinica").AddUseCaseSubGrup("Atendimentos");
        commands.AddCommand("PreverRecorrenciaConsultas", new RecorrenciaInput(), new RecorrenciaOutput())
            .Authorization(Authorization.User).AddScope("clinica.atendimentos");
        commands.AddCommand("ConfirmarRecorrenciaConsultas", new ConfirmacaoRecorrenciaInput(), new RecorrenciaOutput())
            .Authorization(Authorization.User).AddScope("clinica.atendimentos");
        commands.AddCommand("ExecutarRecorrenciaConsultas", new ExecucaoRecorrenciaInput(), new RecorrenciaOutput()).Internal();
    }
}

// Dates without an offset are wall-clock values in America/Sao_Paulo, never browser-local.
public sealed record RecorrenciaInput(int PacienteId = 0, int ServicoId = 0, int ModeloConsulta = 0,
    int VersaoModeloConsulta = 0, string DataInicio = "", string DataFim = "", int IntervaloDias = 7,
    string DataFinal = "", int SessaoId = 0, bool SerieFutura = false);
public sealed class ConfirmacaoRecorrenciaInput
{
    public string PlanoId { get; set; } = "";
    public bool Revisado { get; set; }
    public List<EscolhaRecorrenciaInfo> Ocorrencias { get; set; } = [];
}
public sealed class ExecucaoRecorrenciaInput
{
    public bool Confirmar { get; set; }
    public RecorrenciaInput Pedido { get; set; } = new();
    public ConfirmacaoRecorrenciaInput Confirmacao { get; set; } = new();
}
public sealed class RecorrenciaOutput
{
    public string PlanoId { get; set; } = "";
    public bool Confirmado { get; set; }
    public List<OcorrenciaRecorrenciaInfo> Ocorrencias { get; set; } = [];
}
public sealed record EscolhaRecorrenciaInfo(int Ordem = 0, string DataInicio = "", string DataFim = "", bool Agendar = true);
public sealed record OcorrenciaRecorrenciaInfo(int Ordem = 0, int SessaoId = 0, string DataInicio = "", string DataFim = "", bool Agendar = true, bool Conflito = false);
