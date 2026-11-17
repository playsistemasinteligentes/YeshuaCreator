using Dominio;
using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.Central.Migrations;

[Migration(000002)]
public sealed class M000002 : MigrationBase
{
    public override void Up()
    {
        ConfigureSagaWorkers(1000, generateQueueWorkers: true);
        AddEntity("ChamadoSuporte", "Chamado de suporte")
            .InternalToUseCase("Central", "Suporte", "ExecutarChamadoSuporte")
            .AddColumn("Id", "Chamado").Varchar(32).Key()
            .AddColumn("Aplicativo", "Aplicativo").Varchar(100).NotNull()
            .AddColumn("Modulo", "Modulo").Varchar(100)
            .AddColumn("Tela", "Tela").Varchar(100)
            .AddColumn("TituloTela", "Nome da tela").Varchar(160)
            .AddColumn("Rota", "Rota").Varchar(150)
            .AddColumn("Caminho", "Caminho").Varchar(300)
            .AddColumn("Versao", "Versao instalada").Varchar(32).NotNull()
            .AddColumn("FusoHorario", "Fuso horario").Varchar(100)
            .AddColumn("MomentoClienteUtc", "Momento informado").Varchar(40)
            .AddColumn("Assunto", "Assunto").Varchar(200)
            .AddColumn("Descricao", "Descricao").VarcharMax().ClassifyOperationalData(OperationalDataClassification.NeverCapture)
            .AddColumn("Status", "Status").Int().NotNull()
            .AddColumn("CriadoEmUtc", "Criado em UTC").DateTime().NotNull()
            .AddColumn("AbertoEmUtc", "Aberto em UTC").DateTime();

        var commands = AddUsecaseGroup("Central").AddUseCaseSubGrup("Suporte");
        foreach (var name in new[] { "PrepararChamadoSuporte", "AbrirChamadoSuporte", "ConsultarChamadoSuporte" })
            commands.AddCommand(name, new ChamadoSuporteInput(), new ChamadoSuporteOutput())
                .Authorization(Authorization.User);
        commands.AddCommand("ExecutarChamadoSuporte", new ExecucaoChamadoSuporteInput(), new ChamadoSuporteOutput()).Internal();

        AddUsecaseGroup("Central").AddUseCaseSubGrup("Suporte")
            .AddSaga("TranscreverAudioSuporte")
            .AddStepGroup("transcricao")
                .AddStepWait("transcreverAudioChamado")
                    .AddOutBoxPollingWorker("ai.tasks", ExchangeType.topic, "audio.transcribe.outbox", "audio.transcribe")
                    .AddInboxListenerWorker("ai.results", ExchangeType.topic, "central.audio.transcribed.inbox", "central.audio.transcribed");
    }
}

public class ChamadoSuporteInput
{
    public string ChamadoId { get; set; } = "";
    public string Aplicativo { get; set; } = "";
    public string Modulo { get; set; } = "";
    public string Tela { get; set; } = "";
    public string TituloTela { get; set; } = "";
    public string Rota { get; set; } = "";
    public string Caminho { get; set; } = "";
    public string FusoHorario { get; set; } = "";
    public string MomentoClienteUtc { get; set; } = "";
    public string Assunto { get; set; } = "";
    public string Descricao { get; set; } = "";
}

public sealed class ExecucaoChamadoSuporteInput : ChamadoSuporteInput
{
    public string Operacao { get; set; } = "";
}

public sealed class ChamadoSuporteOutput
{
    public string ChamadoId { get; set; } = "";
    public bool Aberto { get; set; }
    public string Assunto { get; set; } = "";
    public string Descricao { get; set; } = "";
    public string Aplicativo { get; set; } = "";
    public string Modulo { get; set; } = "";
    public string Tela { get; set; } = "";
    public string Versao { get; set; } = "";
    public string TranscricaoStatus { get; set; } = "none";
    public string Transcricao { get; set; } = "";
    public string ErroTranscricao { get; set; } = "";
    public int SagaId { get; set; }
}
