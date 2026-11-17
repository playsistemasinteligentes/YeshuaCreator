using Aplication.Interfaces.Services;
using Command.Patterns.Transcription;
using Command.UseCase;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using System.Reflection;

namespace Command.Receivers.UseCase;

public partial class ExecutarChamadoSuporteHandler
{
    private static readonly string InstalledVersion = typeof(ExecutarChamadoSuporteHandler).Assembly
        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion.Split('+')[0] ?? "0.0.0";
    private readonly IUnitOfWork _work;
    private readonly IChamadoSuporteReadRepository _tickets;
    private readonly IChamadoSuporteWriteRepository _write;

    public ExecutarChamadoSuporteHandler(ILogger logger, IExecutionContext context, IUnitOfWork work,
        IChamadoSuporteReadRepository tickets, IChamadoSuporteWriteRepository write) : base(logger, context)
    { _logger = logger; _executionContext = context; _work = work; _tickets = tickets; _write = write; }

    protected partial Task<State<ExecutarChamadoSuporteOutputCommand>> CustomActionHookAsync(
        State<ExecutarChamadoSuporteOutputCommand> state, ExecutarChamadoSuporteInputCommand comand, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (_executionContext.TenantID <= 0 || _executionContext.UserId <= 0
            || !Guid.TryParse(comand.ChamadoId, out var identifier) || identifier == Guid.Empty)
            return Task.FromResult(ValidationError("Chamado invalido.", new ExecutarChamadoSuporteOutputCommand()));
        var id = identifier.ToString("N");
        if (comand.Operacao is "Consultar" or "AutorizarGravacao")
        {
            var ticket = _tickets.BuscarDoUsuario(id);
            if (ticket is null || comand.Operacao == "AutorizarGravacao" && ticket.Status != 0)
                return Task.FromResult(ValidationError("Rascunho nao encontrado para o usuario atual.", new ExecutarChamadoSuporteOutputCommand()));
            return Task.FromResult(Success("OK", Output(ticket)));
        }
        if (comand.Operacao is not ("Preparar" or "Abrir"))
            return Task.FromResult(ValidationError("Operacao invalida.", new ExecutarChamadoSuporteOutputCommand()));
        if (comand.Operacao == "Abrir" && (string.IsNullOrWhiteSpace(comand.Assunto) || comand.Assunto.Length > 200
            || string.IsNullOrWhiteSpace(comand.Descricao) || comand.Descricao.Length > 20000))
            return Task.FromResult(ValidationError("Preencha assunto e descricao. Limites: 200 e 20000 caracteres.", new ExecutarChamadoSuporteOutputCommand()));
        _work.BeginTran();
        try
        {
            _write.Travar(id, _executionContext.TenantID, _executionContext.UserId);
            var ticket = _tickets.BuscarDoUsuario(id);
            if (ticket is null && comand.Operacao == "Preparar")
            {
                ticket = new SupportTicketData {
                    Id = id, Aplicativo = Metadata(comand.Aplicativo, 100), Modulo = Metadata(comand.Modulo, 100),
                    Tela = Metadata(comand.Tela, 100), TituloTela = Metadata(comand.TituloTela, 160),
                    Rota = Metadata(comand.Rota, 150), Caminho = Metadata(comand.Caminho, 300),
                    FusoHorario = Metadata(comand.FusoHorario, 100), MomentoClienteUtc = Metadata(comand.MomentoClienteUtc, 40),
                    Versao = InstalledVersion
                };
                if (ticket.Aplicativo.Length == 0 || !ticket.Caminho.StartsWith('/')
                    || ticket.Caminho.IndexOfAny(['?', '#']) >= 0 || ticket.Rota.Contains('?'))
                    throw new ArgumentException("Contexto de navegacao invalido.");
                _write.InserirRascunho(ticket, _executionContext.TenantID, _executionContext.UserId);
            }
            if (ticket is null)
            {
                _work.Rollback();
                return Task.FromResult(ValidationError("Chamado nao encontrado para o usuario atual.", new ExecutarChamadoSuporteOutputCommand()));
            }
            if (comand.Operacao == "Abrir" && ticket.Status == 0)
            {
                if (!_write.Abrir(id, comand.Assunto.Trim(), comand.Descricao.Trim(), _executionContext.TenantID, _executionContext.UserId))
                    throw new InvalidOperationException("O chamado mudou. Consulte e tente novamente.");
                ticket.Status = 1; ticket.Assunto = comand.Assunto.Trim(); ticket.Descricao = comand.Descricao.Trim();
            }
            _work.Commit();
            return Task.FromResult(Success(ticket.Status == 1 ? "Chamado aberto." : "Rascunho preparado.", Output(ticket)));
        }
        catch { _work.Rollback(); throw; }
    }

    private static string Metadata(string? value, int limit)
    {
        value = (value ?? "").Trim();
        if (value.Length > limit || value.Any(char.IsControl)) throw new ArgumentException("Contexto de navegacao invalido.");
        return value;
    }

    private static ExecutarChamadoSuporteOutputCommand Output(SupportTicketData ticket)
    {
        var output = new ExecutarChamadoSuporteOutputCommand {
            ChamadoId = ticket.Id, Aberto = ticket.Status == 1, Assunto = ticket.Assunto, Descricao = ticket.Descricao,
            Aplicativo = ticket.Aplicativo, Modulo = ticket.Modulo, Tela = ticket.Tela, Versao = ticket.Versao,
            SagaId = ticket.SagaId ?? 0, TranscricaoStatus = ticket.UploadId is null ? "none" : "pending"
        };
        if (ticket.UploadStatus == 0) output.TranscricaoStatus = "uploading";
        else if (ticket.SagaStatus == 3 || ticket.StepStatus == 6)
        {
            output.TranscricaoStatus = "failed";
            output.ErroTranscricao = "A transcricao nao foi concluida. Voce pode escrever o relato ou gravar novamente.";
        }
        else if (ticket.StepStatus == 5 && !string.IsNullOrWhiteSpace(ticket.TranscriptPayload))
        {
            output.Transcricao = AudioTranscriptionResult.ReadText(ticket.TranscriptPayload);
            output.TranscricaoStatus = "completed";
        }
        return output;
    }
}
