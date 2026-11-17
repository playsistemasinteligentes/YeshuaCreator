using Aplication.Interfaces.Services;
using Command.UseCase;
using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Receivers.UseCase;

public partial class AbrirChamadoSuporteHandler
{
    private readonly ExecutarChamadoSuporteHandler _executor;
    public AbrirChamadoSuporteHandler(ILogger logger, IExecutionContext context, ExecutarChamadoSuporteHandler executor) : base(logger, context)
    { _logger = logger; _executionContext = context; _executor = executor; }
    protected partial async Task<State<AbrirChamadoSuporteOutputCommand>> CustomActionHookAsync(
        State<AbrirChamadoSuporteOutputCommand> state, AbrirChamadoSuporteInputCommand comand, CancellationToken cancellationToken)
    {
        var result = await _executor.ExecuteAsync(new ExecutarChamadoSuporteInputCommand {
            Operacao = "Abrir", ChamadoId = comand.ChamadoId, Aplicativo = comand.Aplicativo, Modulo = comand.Modulo, Tela = comand.Tela, TituloTela = comand.TituloTela, Rota = comand.Rota, Caminho = comand.Caminho, FusoHorario = comand.FusoHorario, MomentoClienteUtc = comand.MomentoClienteUtc, Assunto = comand.Assunto, Descricao = comand.Descricao
        }, cancellationToken);
        if (result.StatusCode >= 400 || result.Data is null)
            return new State<AbrirChamadoSuporteOutputCommand>(result.StatusCode, result.Message, new(), false);
        return new State<AbrirChamadoSuporteOutputCommand>(result.StatusCode, result.Message, new() {
            ChamadoId = result.Data.ChamadoId, Aberto = result.Data.Aberto, Assunto = result.Data.Assunto, Descricao = result.Data.Descricao, Aplicativo = result.Data.Aplicativo, Modulo = result.Data.Modulo, Tela = result.Data.Tela, Versao = result.Data.Versao, TranscricaoStatus = result.Data.TranscricaoStatus, Transcricao = result.Data.Transcricao, ErroTranscricao = result.Data.ErroTranscricao, SagaId = result.Data.SagaId
        }, false);
    }
}
