using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;
using Command.Interfaces.Patterns.Queue;
using Command.Patterns.Queue;
using Command.Read;
using Repositorio.Outputs;
using Dominio.Entitys;
using Command.Interfaces.Patterns.FileStore;
using System.Threading;

namespace Command.Receivers.UseCase
{
    public partial class WorkerPollingOutBoxUseCaseReceiver
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IyOutboxReadRepository _repReadyOutbox;
        private readonly IyFileUploadReadRepository _repReadyUpload;
        private readonly IyOutboxWriteRepository _repWriteyOutbox;
        private readonly IQueuePublisher _queuePublisher;
        private readonly IFileStorage _fileStorage;
        public WorkerPollingOutBoxUseCaseReceiver(IUnitOfWork unitOfWork, ILogger logger, IyOutboxReadRepository repReadyOutbox, IyOutboxWriteRepository repWriteyOutbox, IQueuePublisher queuePublisher, IyFileUploadReadRepository repReadyUpload, IFileStorage fileStorage)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _repReadyOutbox = repReadyOutbox;
            _repWriteyOutbox = repWriteyOutbox;
            _queuePublisher = queuePublisher;
            _repReadyUpload = repReadyUpload;
            _fileStorage = fileStorage;
        }
        partial void CustomActionHook(ref State<WorkerPollingOutBoxUseCaseOutputCommand> state, WorkerPollingOutBoxUseCaseInputCommand comand)
        {
            try
            {
                /* pendencia
                ✅ Seu UPDATE TOP OUTPUT (já fez)
                🔲 RetryCount
                🔲 ProcessingDate (timeout)
                🔲 Publisher Confirm (muito importante)
                🔲 Idempotência no consumer
                🔲 DeadLetter*/

                var outBoxListJob = _repReadyOutbox.getToWorker("audio.transcribe", 10);

                foreach (int outBoxId in outBoxListJob)
                {
                    yOutboxDTO outBox = _repReadyOutbox.FirstById(outBoxId, true);
                    yFileUploadDTO upload = _repReadyUpload.FirstById(int.Parse(outBox.correlationid), true);

                    StoragePath finalPath = StoragePathBuilder.BuildFromFullPath(StorageLocation.Volatile.TranscriptionsInput,upload.filepath);
                    Console.WriteLine($"finalPath:{finalPath.Directory}");
                    Console.WriteLine($"upload.filepath:{upload.filepath}");
                    
                    StoragePath pendingMergePath = StoragePathBuilder.AppendDirectory(StorageLocation.Volatile.TranscriptionsInput,finalPath ,"pending_merge");
                    
                    Console.WriteLine($"pendingMergePath:{pendingMergePath.Directory}");
                    // 🔎 não existe o arquivo final?
                    if (!_fileStorage.HasFilesInDirectoryAsync(finalPath, CancellationToken.None).GetAwaiter().GetResult())
                    {
                        Console.Write("06");
                        var merged = MergeChunksFromStorage(pendingMergePath, finalPath); // usar FFMpeg.exe

                        if (!merged)
                            throw new Exception("Falha ao reconstruir arquivo a partir dos chunks.");

                        // 🧹 opcional: limpar chunks
                        // TryDeletePending(pendingPath);

                    }
                    Console.Write("07");
                    QueueMessage queueMessage = new QueueMessage(outBox.type, outBox.payload)
                    { CorrelationId = outBox.id.ToString(), Source = "worker-outbox" };
                    Console.Write("08");
                    
                    if (_queuePublisher.PublishCeleryAsync("ai.tasks.audio.transcribe","ai.tasks", "audio.transcribe", queueMessage).GetAwaiter().GetResult())
                    {
                        yOutboxEntity outboxEntity = new yOutboxEntity() { Id = outBox.id, Status = 1 };
                        _repWriteyOutbox.UpdateStatus(outboxEntity);
                    }
                }
            }
            catch (Exception )
            {
                throw;
            }
        }

        private bool MergeChunksFromStorage(StoragePath pendingPath, StoragePath finalPath)
        {
            var chunks = _fileStorage
                .ListFiles(pendingPath)
                .Where(f => Path.GetFileName(f.Value).StartsWith("chunk_"))
                .OrderBy(f =>
                {
                    var fileName = Path.GetFileName(f.Value); // chunk_0.part
                    var numberPart = fileName.Split('_')[1];  // 0.part
                    var index = int.Parse(numberPart.Split('.')[0]); // 0

                    return index;
                })
                .ToList();

            if (!chunks.Any())
                return false;

            using var output = _fileStorage.OpenWrite(finalPath);

            foreach (var chunk in chunks)
            {
                _logger.Info($"Chunks{chunk}");

                using var input = _fileStorage.OpenRead(chunk);
                input.CopyTo(output);
            }

            return true;
        }
    }

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase