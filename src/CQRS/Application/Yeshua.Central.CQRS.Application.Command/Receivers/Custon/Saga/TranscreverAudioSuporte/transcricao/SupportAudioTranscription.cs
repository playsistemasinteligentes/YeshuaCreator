using Command.Interfaces.Patterns.FileStore;
using Command.Patterns.OutBox;
using Command.Patterns.Transcription;
using Dominio.Patterns.Saga;
using IRepository.Read;
using System.Text.Json;
using Command.Patterns.FileUpload;

namespace Command.Receivers;

public partial class TranscreverAudioChamadoHandler
{
    private readonly IyFileUploadReadRepository _uploads;
    private readonly IFileStorage _storage;
    private readonly OutboxService _outbox;
    public TranscreverAudioChamadoHandler(IyFileUploadReadRepository uploads, IFileStorage storage, OutboxService outbox)
        => (_uploads, _storage, _outbox) = (uploads, storage, outbox);

    partial void CustomExecute(SagaBase saga, SagaStepBase step)
    {
        var upload = _uploads.FirstByOperationalEntityId(saga.CorrelationId.ToString("N"));
        if (upload is null || upload.entitytype != "ChamadoSuporte" || upload.entityid != saga.EntityId || upload.status != 1)
            throw new SagaStepExecutionException("Audio do chamado nao encontrado.", retryable: false);
        var expected = AudioChunkStorage.AudioKey(upload.tenantid, upload.id, "central");
        var path = StoragePathBuilder.BuildFromFullPath(StorageLocation.Volatile.TranscriptionsInput, expected);
        if (upload.filepath.Replace('\\','/') != expected || !_storage.ExistsAsync(path, CancellationToken.None).GetAwaiter().GetResult())
            throw new SagaStepExecutionException("Audio indisponivel. Reenvie a gravacao.", retryable: false);
        _outbox.AddOutBoxEvent("audio.transcribe", new {
                FilePath = _storage.GetBaseUrl(path), StorageKey = expected, uploadId = upload.id,
                application = "Central", ResultQueue = "central.audio.transcribed.inbox", contractVersion = 1
            }, "yFileUpload", upload.id.ToString(), $"{step.CorrelationId}:{step.ExecutionCount}", step.CorrelationId, 1,
            new { Exchange = "ai.tasks", Queue = "audio.transcribe.outbox", RoutingKey = "audio.transcribe", TaskName = "app.tasks.transcribe_audio" },
            saga.Id, step.Id);
    }

    partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        => step.SetPayload(JsonSerializer.Serialize(new { text = AudioTranscriptionResult.ReadText(payload) }));
}
