using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;
using Command.Interfaces.Patterns.FileStore;

namespace Command.Receivers.UseCase
{
    public partial class InfraSendFileUseCaseReceiver
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IyFileUploadReadRepository _repReadyFileUpload;
        private readonly IyFileUploadWriteRepository _repWriteyFileUpload;
        private readonly IFileStorage _fileStorage;

        public InfraSendFileUseCaseReceiver(IUnitOfWork unitOfWork, ILogger logger, IyFileUploadReadRepository repReadyFileUpload, IyFileUploadWriteRepository repWriteyFileUpload)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _repReadyFileUpload = repReadyFileUpload;
            _repWriteyFileUpload = repWriteyFileUpload;
        }
        partial void CustomActionHook(ref State<InfraSendFileUseCaseOutputCommand> state, InfraSendFileUseCaseInputCommand comand)
        {/*
            try
            {
                var fileName = $"{comand.IdempotencyKey}_{comand.ChunkIndex}.webm";

                // 1️⃣ Salvar arquivo físico

                var result = _fileStorage
                    .SaveAsync(comand.FileStream, fileName, new CancellationToken())
                    .GetAwaiter()
                    .GetResult();

                // 2️⃣ Se for último chunk → cria registro lógico
                if (comand.IsFinalChunk)
                {
                    var upload = new yFileUpload
                    {
                        IdempotencyKey = comand.IdempotencyKey,
                        Type = "Audio",
                        Status = 0, // Pending
                        FilePath = result.Path,
                        FileSize = result.Size,
                        ContentType = comand.ContentType,
                        CreatedAt = DateTime.UtcNow
                    };

                    _repWriteyFileUpload.Add(upload);

                    _unitOfWork.Commit();
                }

                state = Success("Chunk recebido com sucesso",
                    new InfraSendFileUseCaseOutputCommand()
                    {
                        IsFinalized = true,
                        ChunkIndex = comand.ChunkIndex,
                        Success = comand.IsFinalChunk
                    }
                );
            }
            catch (Exception ex)
            {
                _logger.Info(ex.Message);
                state = Error(ex, default);
            }
        */
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase