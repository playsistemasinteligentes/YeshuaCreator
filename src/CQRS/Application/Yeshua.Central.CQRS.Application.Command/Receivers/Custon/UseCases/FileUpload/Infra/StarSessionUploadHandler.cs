using Aplication.Interfaces.Services;
using Command.Patterns.FileUpload;
using Command.UseCase;
using Dominio.Entitys;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Receivers.UseCase;

public partial class StarSessionUploadHandler
{
    private readonly IyFileUploadWriteRepository _uploads;
    private readonly UploadTokenHelper _tokens;
    private readonly ExecutarChamadoSuporteHandler _tickets;
    public StarSessionUploadHandler(Dominio.Interfaces.ILogger logger, IExecutionContext context,
        IyFileUploadWriteRepository uploads, UploadTokenHelper tokens, ExecutarChamadoSuporteHandler tickets) : base(logger, context)
    { _logger = logger; _executionContext = context; _uploads = uploads; _tokens = tokens; _tickets = tickets; }
    protected partial async Task<State<StarSessionUploadOutputCommand>> CustomActionHookAsync(
        State<StarSessionUploadOutputCommand> state, StarSessionUploadInputCommand comand, CancellationToken cancellationToken)
    {
        if (comand.entityType != "ChamadoSuporte" || !Guid.TryParse(comand.entityId, out var id))
            return ValidationError("Chamado invalido para gravacao.", new StarSessionUploadOutputCommand());
        var ticket = await _tickets.ExecuteAsync(new ExecutarChamadoSuporteInputCommand {
            ChamadoId = id.ToString("N"), Operacao = "AutorizarGravacao"
        }, cancellationToken);
        if (ticket.StatusCode >= 400) return ValidationError("Rascunho nao encontrado para o usuario atual.", new StarSessionUploadOutputCommand());
        var upload = new yFileUploadFactory(_logger).Create(0, "audio.transcribe.support", 0, "", 0,
            "ChamadoSuporte", id.ToString("N"), DateTime.UtcNow, null);
        if (!upload.isValidInsert()) return ValidationError("Nao foi possivel preparar o audio.", new StarSessionUploadOutputCommand());
        _uploads.Insert(upload);
        return Success("Gravacao preparada.", new StarSessionUploadOutputCommand {
            uploadToken = _tokens.Generate(upload.Id.Value, _executionContext.UserId, _executionContext.TenantID)
        });
    }
}
