using Command.Interfaces.Patterns.FileStore;
using Command.Receivers.Custon.UseCases.FileUpload.Infra;
using Command.UseCase;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using System.Text.Json;

namespace Command.Receivers.UseCase;

public partial class SendFileHandler
{
    private readonly IUnitOfWork _work;
    private readonly IyFileUploadReadRepository _uploads;
    private readonly IyFileUploadWriteRepository _uploadsWrite;
    private readonly IFileStorage _storage;
    private readonly UploadTokenHelper _tokens;
    private readonly IySagaReadRepository _sagas;
    private readonly IySagaWriteRepository _sagasWrite;
    private readonly ISesoesReadRepository _sessions;
    private readonly ISesoesWriteRepository _sessionsWrite;

    public SendFileHandler(IUnitOfWork work, IyFileUploadReadRepository uploads,
        IyFileUploadWriteRepository uploadsWrite, IFileStorage storage, UploadTokenHelper tokens,
        IySagaReadRepository sagas, IySagaWriteRepository sagasWrite,
        ISesoesReadRepository sessions, ISesoesWriteRepository sessionsWrite,
        Dominio.Interfaces.ILogger logger, Aplication.Interfaces.Services.IExecutionContext context) : base(logger, context)
    {
        _work = work; _uploads = uploads; _uploadsWrite = uploadsWrite; _storage = storage; _tokens = tokens;
        _sagas = sagas; _sagasWrite = sagasWrite; _sessions = sessions; _sessionsWrite = sessionsWrite;
        _logger = logger; _executionContext = context;
    }

    protected partial async Task<State<SendFileOutputCommand>> CustomActionHookAsync(
        State<SendFileOutputCommand> state, SendFileInputCommand command, CancellationToken cancellationToken)
    {
        if (command.FileStream is null || command.FileStream.Length == 0 || command.ChunkIndex < 0 || command.ChunkIndex > 10000)
            return ValidationError("Parte de audio invalida.", new SendFileOutputCommand());
        var token = _tokens.ValidateAndExtract(command.token);
        if (token.tenantId != _executionContext.TenantID || token.userId != _executionContext.UserId)
            return ValidationError("Token de upload invalido para o usuario atual.", new SendFileOutputCommand());
        _work.BeginTran();
        try
        {
            if (!_uploadsWrite.LockUploadForCurrentActor(token.uploadId, token.tenantId, token.userId))
                throw new InvalidOperationException("Upload nao encontrado para o usuario atual.");
            var upload = _uploads.FirstById(token.uploadId);
            if (upload is null || upload.entitytype != "Sesoes" || !int.TryParse(upload.entityid, out var sessionId)
                || _sessions.FirstById(sessionId) is null || !Guid.TryParse(upload.operationalentityid, out _))
                throw new InvalidOperationException("Upload sem sessao clinica valida.");
            if (upload.status == 1)
            {
                var existing = _sagas.FirstByCorrelationId(Guid.Parse(upload.operationalentityid).ToString("D"));
                if (existing is null) throw new InvalidOperationException("Upload concluido sem processamento associado.");
                _work.Commit();
                return Success("Upload ja finalizado.", new SendFileOutputCommand
                { Success = true, IsFinalized = true, ChunkIndex = command.ChunkIndex, SagaId = existing.id, SagaCorrelationId = existing.correlationid });
            }
            if (upload.status != 0) throw new InvalidOperationException("Upload nao aceita novas partes.");
            var pending = StoragePathBuilder.Build(StorageLocation.Volatile.TranscriptionsInput,
                token.tenantId.ToString(), Path.Combine(token.uploadId.ToString(), "pending_merge"),
                $"chunk_{command.ChunkIndex}.part", false);
            await _storage.SaveAsync(command.FileStream, pending, cancellationToken);
            if (!command.IsFinalChunk)
            {
                _work.Commit();
                return Success("Parte recebida.", new SendFileOutputCommand { Success = true, ChunkIndex = command.ChunkIndex });
            }
            var parts = _storage.ListFiles(StoragePathBuilder.BuildFromFullPath(
                StorageLocation.Volatile.TranscriptionsInput, pending.Directory + Path.DirectorySeparatorChar))
                .Where(p => Path.GetFileName(p.Value).StartsWith("chunk_", StringComparison.Ordinal)).ToList();
            if (parts.Count != command.ChunkIndex + 1)
                throw new InvalidOperationException("Ainda faltam partes do audio. Reenvie as partes ausentes.");
            var final = StoragePathBuilder.Build(StorageLocation.Volatile.TranscriptionsInput,
                token.tenantId.ToString(), token.uploadId.ToString(), "audio.webm", false);
            using (var output = _storage.OpenWrite(final))
            {
                for (var index = 0; index <= command.ChunkIndex; index++)
                {
                    var part = parts.SingleOrDefault(p => Path.GetFileName(p.Value) == $"chunk_{index}.part")
                        ?? throw new InvalidOperationException("Sequencia de partes incompleta.");
                    using var input = _storage.OpenRead(part);
                    await input.CopyToAsync(output, cancellationToken);
                }
            }
            var saga = new PsychologySessionInsightSaga();
            saga.Start(sessionId.ToString(), "Sesoes");
            // Explicit, persisted upload-to-processing association and idempotency key.
            saga.SetCorrelationId(upload.operationalentityid);
            saga.GetCurrent()!.SetPayload(JsonSerializer.Serialize(new { uploadId = upload.id }));
            if (_executionContext.TryGetOperationalIdentity(out var identity))
                saga.SetOperationalIdentity(identity.RootOperationId, identity.OperationId, identity.ExecutionId, identity.CausationId);
            _uploadsWrite.UpdateFilePath(upload.id, final.Value);
            _uploadsWrite.UpdateStatus(upload.id, 1);
            _uploadsWrite.UpdateCompletedAt(upload.id, DateTime.UtcNow);
            _sessionsWrite.MarkInsightPending(sessionId);
            _sagasWrite.Save(saga);
            _work.Commit();
            return Success("Audio pronto para processamento.", new SendFileOutputCommand
            { Success = true, ChunkIndex = command.ChunkIndex, IsFinalized = true, SagaId = saga.Id, SagaCorrelationId = saga.CorrelationId.ToString("D") });
        }
        catch
        {
            _work.Rollback();
            throw;
        }
    }
}
public record UploadCompletedEvent(string FilePath);
