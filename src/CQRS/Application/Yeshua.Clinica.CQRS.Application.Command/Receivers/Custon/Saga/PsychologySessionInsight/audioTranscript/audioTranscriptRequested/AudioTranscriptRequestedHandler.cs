using Command.Interfaces.Patterns.FileStore;
using Command.Patterns.OutBox;
using Dominio.Patterns.Saga;
using IRepository.Read;
using System.Text.Json;
namespace Command.Receivers;
public partial class AudioTranscriptRequestedHandler
{
    private readonly IyFileUploadReadRepository _uploads;
    private readonly IFileStorage _storage;
    private readonly OutboxService _outbox;
    public AudioTranscriptRequestedHandler(IyFileUploadReadRepository uploads, IFileStorage storage, OutboxService outbox)
        { _uploads = uploads; _storage = storage; _outbox = outbox; }
    partial void CustomExecute(SagaBase saga, SagaStepBase step)
    {
        var upload = saga.EntityType == "yFileUpload"
            ? _uploads.FirstById(int.Parse(saga.EntityId))
            : _uploads.FirstByOperationalEntityId(saga.CorrelationId.ToString("N"));
        if (upload is null)
            throw new SagaStepExecutionException("Upload do audio nao encontrado.", retryable: false);
        var uploadId = upload.id;
        if (upload.entitytype != "Sesoes" || !int.TryParse(upload.entityid, out var sessionId) || sessionId <= 0
            || (saga.EntityType == "Sesoes" && upload.entityid != saga.EntityId))
            throw new SagaStepExecutionException("Upload sem vinculo valido com a sessao.", retryable: false);
        var path = StoragePathBuilder.BuildFromFullPath(StorageLocation.Volatile.TranscriptionsInput, upload.filepath);
        if (!_storage.ExistsAsync(path, CancellationToken.None).GetAwaiter().GetResult())
            throw new SagaStepExecutionException("Audio volatil indisponivel. Reenvie o arquivo.", retryable: false);
        _outbox.AddOutBoxEvent("audio.transcribe",
            new { FilePath = _storage.GetBaseUrl(path), StorageKey = path.Value.Replace('\\', '/'),
                uploadId, sessaoId = sessionId, contractVersion = 1 },
            "yFileUpload", upload.id.ToString(), $"{step.CorrelationId}:{step.ExecutionCount}", step.CorrelationId, 1,
            new { Exchange = "ai.tasks", Queue = "audio.transcribe.outbox", RoutingKey = "audio.transcribe", TaskName = "app.tasks.transcribe_audio" },
            saga.Id, step.Id);
    }
    partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        => step.SetPayload(JsonSerializer.Serialize(new { text = SessionInsightContract.ReadTranscript(payload) }));
}
