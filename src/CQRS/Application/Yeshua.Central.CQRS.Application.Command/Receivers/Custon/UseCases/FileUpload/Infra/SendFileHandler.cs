using Aplication.Interfaces.Services;
using Command.Interfaces.Patterns.FileStore;
using Command.Patterns.FileUpload;
using Command.UseCase;
using Dominio.Saga;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
namespace Command.Receivers.UseCase;

public partial class SendFileHandler
{
    private readonly IUnitOfWork _work;
    private readonly IyFileUploadReadRepository _uploads;
    private readonly IyFileUploadWriteRepository _uploadsWrite;
    private readonly IySagaReadRepository _sagas;
    private readonly IySagaWriteRepository _sagasWrite;
    private readonly UploadTokenHelper _tokens;
    private readonly IFileStorage _storage;
    private readonly ExecutarChamadoSuporteHandler _tickets;
    public SendFileHandler(Dominio.Interfaces.ILogger logger, IExecutionContext context, IUnitOfWork work,
        IyFileUploadReadRepository uploads, IyFileUploadWriteRepository uploadsWrite,
        IySagaReadRepository sagas, IySagaWriteRepository sagasWrite, UploadTokenHelper tokens,
        IFileStorage storage, ExecutarChamadoSuporteHandler tickets) : base(logger, context)
    {
        _logger = logger; _executionContext = context; _work = work; _uploads = uploads; _uploadsWrite = uploadsWrite;
        _sagas = sagas; _sagasWrite = sagasWrite; _tokens = tokens; _storage = storage; _tickets = tickets;
    }
    protected partial async Task<State<SendFileOutputCommand>> CustomActionHookAsync(
        State<SendFileOutputCommand> state, SendFileInputCommand comand, CancellationToken cancellationToken)
    {
        if (comand.FileStream is null || comand.FileStream.Length > 25_000_000)
            return ValidationError("Parte de audio invalida.", new SendFileOutputCommand());
        var token = _tokens.ValidateAndExtract(comand.token);
        if (token.tenantId != _executionContext.TenantID || token.userId != _executionContext.UserId)
            return ValidationError("Audio nao pertence ao usuario atual.", new SendFileOutputCommand());
        var upload = _uploads.FirstById(token.uploadId);
        if (upload is null || upload.entitytype != "ChamadoSuporte" || !Guid.TryParse(upload.entityid, out var ticketId)
            || !Guid.TryParse(upload.operationalentityid, out var correlation))
            return ValidationError("Audio sem chamado valido.", new SendFileOutputCommand());
        var ticket = await _tickets.ExecuteAsync(new ExecutarChamadoSuporteInputCommand {
            ChamadoId = ticketId.ToString("N"), Operacao = "AutorizarGravacao"
        }, cancellationToken);
        if (ticket.StatusCode >= 400) return ValidationError("Rascunho nao encontrado para o usuario atual.", new SendFileOutputCommand());
        _work.BeginTran();
        try
        {
            if (!_uploadsWrite.LockUploadForCurrentActor(token.uploadId, token.tenantId, token.userId))
                throw new InvalidOperationException("Audio nao encontrado para o usuario atual.");
            upload = _uploads.FirstById(token.uploadId);
            if (upload.status == 1)
            {
                var existing = _sagas.FirstByCorrelationId(correlation.ToString("D"));
                if (existing is null) throw new InvalidOperationException("Audio finalizado sem processamento associado.");
                _work.Commit();
                return Success("Audio ja recebido.", new SendFileOutputCommand {
                    Success = true, IsFinalized = true, ChunkIndex = comand.ChunkIndex, SagaId = existing.id, SagaCorrelationId = existing.correlationid
                });
            }
            if (upload.status != 0) throw new InvalidOperationException("Audio nao aceita novas partes.");
            var final = await AudioChunkStorage.SaveAsync(_storage, token.tenantId, token.uploadId,
                comand.FileStream, comand.ChunkIndex, comand.IsFinalChunk, cancellationToken, "central");
            if (final is null)
            {
                _work.Commit();
                return Success("Parte recebida.", new SendFileOutputCommand { Success = true, ChunkIndex = comand.ChunkIndex });
            }
            var saga = new TranscreverAudioSuporteSaga();
            saga.Start(ticketId.ToString("N"), "ChamadoSuporte"); saga.SetCorrelationId(correlation.ToString("D"));
            if (_executionContext.TryGetOperationalIdentity(out var identity))
                saga.SetOperationalIdentity(identity.RootOperationId, identity.OperationId, identity.ExecutionId, identity.CausationId);
            _uploadsWrite.UpdateFilePath(upload.id, final); _uploadsWrite.UpdateStatus(upload.id, 1);
            _uploadsWrite.UpdateCompletedAt(upload.id, DateTime.UtcNow); _sagasWrite.Save(saga);
            _work.Commit();
            return Success("Audio pronto para transcricao.", new SendFileOutputCommand {
                Success = true, IsFinalized = true, ChunkIndex = comand.ChunkIndex, SagaId = saga.Id, SagaCorrelationId = saga.CorrelationId.ToString("D")
            });
        }
        catch { _work.Rollback(); throw; }
    }
}
