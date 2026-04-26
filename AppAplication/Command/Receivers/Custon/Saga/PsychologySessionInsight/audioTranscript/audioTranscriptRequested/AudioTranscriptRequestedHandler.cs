using Command.Interfaces.Patterns.FileStore;
using Command.Patterns.OutBox;
using Command.Receivers.UseCase;
using Dominio.Entitys;
using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using IRepository.Read;
using Repositorio.Outputs;
using System;
using System.IO;
using System.Linq;

namespace Command.Receivers
{
    public partial class AudioTranscriptRequestedHandler
    {
        private readonly IyFileUploadReadRepository _repReadyUpload;
        private readonly IFileStorage _fileStorage;
        private readonly OutboxService _outboxService;
        private readonly ILogger _logger;

        public AudioTranscriptRequestedHandler(
            IyFileUploadReadRepository repReadyUpload,
            IFileStorage fileStorage,
            OutboxService outboxService,
            ILogger logger)
        {
            _repReadyUpload = repReadyUpload;
            _fileStorage = fileStorage;
            _outboxService = outboxService;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            try
            {
                step.SetInProgress();

                // =========================================================
                // 1. RECUPERA UPLOAD VIA STEP (entityId vindo da saga)
                // =========================================================
                var uploadId = int.Parse(saga.EntityId);
                yFileUploadDTO upload = _repReadyUpload.FirstById(uploadId, true);

                // =========================================================
                // 2. MONTA PATHS
                // =========================================================
                StoragePath finalPath =
                    StoragePathBuilder.BuildFromFullPath(
                        StorageLocation.Volatile.TranscriptionsInput,
                        upload.filepath);

                StoragePath pendingMergePath =
                    StoragePathBuilder.AppendDirectory(
                        StorageLocation.Volatile.TranscriptionsInput,
                        finalPath,
                        "pending_merge");

                // =========================================================
                // 3. SE NÃO EXISTE FINAL → JUNTA CHUNKS
                // =========================================================
                if (!_fileStorage.HasFilesInDirectoryAsync(finalPath, CancellationToken.None)
                        .GetAwaiter().GetResult())
                {
                    var merged = MergeChunksFromStorage(pendingMergePath, finalPath);

                    if (!merged)
                        throw new Exception("Falha ao reconstruir arquivo a partir dos chunks.");
                }

                // =========================================================
                // 4. CRIA PAYLOAD FINAL PARA OUTBOX
                // =========================================================
                
                //var payload = new
                //{
                //    uploadId = upload.id,
                //    filePath = upload.filepath,
                //    finalPath = finalPath.Directory,
                //    status = "ready_for_transcription"
                //};

                var payload = new UploadCompletedEvent($"{_fileStorage.GetBaseUrl(finalPath)}");


                // =========================================================
                // 5. GRAVA OUTBOX (AGORA SÓ EVENTO)
                // =========================================================
                _outboxService.AddOutBoxEvent(
                            type: "audio.transcribe",
                            payload: payload,
                            entityType: nameof(yFileUploadDTO),
                            entityID: upload.id.ToString(),
                            messageId: Guid.NewGuid().ToString(),
                            correlationId:step.CorrelationId,
                            transportType: 1, // Queue
                            transportData: new
                            {
                                Exchange = "ai.tasks",
                                Queue = "audio.transcribe.outbox",
                                RoutingKey = "audio.transcribe"
                            },
                            sagaId: saga.Id,
                            sagaStepID: step.Id
                        );

                step.SetPendingApply();
            }
            catch (Exception ex)
            {
                saga.MarkFailed(ex.Message);
                throw;
            }
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            step.SetCompleted();
            saga.CompleteCurrentStep();
        }

        // =========================================================
        // CHUNK MERGE (continua igual sua lógica atual)
        // =========================================================
        private bool MergeChunksFromStorage(StoragePath pendingPath, StoragePath finalPath)
        {
            var chunks = _fileStorage
                .ListFiles(pendingPath)
                .Where(f => Path.GetFileName(f.Value).StartsWith("chunk_"))
                .OrderBy(f =>
                {
                    var fileName = Path.GetFileName(f.Value);
                    var numberPart = fileName.Split('_')[1];
                    return int.Parse(numberPart.Split('.')[0]);
                })
                .ToList();

            if (!chunks.Any())
                return false;

            using var output = _fileStorage.OpenWrite(finalPath);

            foreach (var chunk in chunks)
            {
                using var input = _fileStorage.OpenRead(chunk);
                input.CopyTo(output);
            }

            return true;
        }
    }
}