using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;
using Command.Interfaces.Patterns.FileStore;
using Dominio.Entitys;
using System.Threading;
using Repositorio.Outputs;

namespace Command.Receivers.UseCase
{
    public partial class InfraSendFileUseCaseReceiver
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IyFileUploadReadRepository _repReadyFileUpload;
        private readonly IyFileUploadWriteRepository _repWriteyFileUpload;
        private readonly IFileStorage _fileStorage;

        public InfraSendFileUseCaseReceiver(IUnitOfWork unitOfWork, ILogger logger, IyFileUploadReadRepository repReadyFileUpload, IyFileUploadWriteRepository repWriteyFileUpload, IFileStorage fileStorage)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _repReadyFileUpload = repReadyFileUpload;
            _repWriteyFileUpload = repWriteyFileUpload;
            _fileStorage = fileStorage;
        }
        partial void CustomActionHook(
            ref State<InfraSendFileUseCaseOutputCommand> state,
            InfraSendFileUseCaseInputCommand comand)
        {
            try
            {
                // 🔎 Validações básicas
                if (string.IsNullOrWhiteSpace(comand.IdempotencyKey))
                    throw new ReceiverException<InfraSendFileUseCaseOutputCommand>(
                        Error("IdempotencyKey é obrigatório.", default));

                //if (comand.FileStream == null)
                //    throw new ReceiverException<InfraSendFileUseCaseOutputCommand>(
                //        Error("FileStream é obrigatório.", default));

                // 🔁 Idempotência
                var existing = _repReadyFileUpload
                    .FirstByIdempotencyKey(comand.IdempotencyKey);

                if (existing != null && existing.completedat != default(DateTime))
                {
                    state = Success("Upload já finalizado.",
                        new InfraSendFileUseCaseOutputCommand
                        {
                            Success = true,
                            ChunkIndex = comand.ChunkIndex,
                            IsFinalized = true
                        });

                    return;
                }

                //// 📁 Salva o chunk físico
                var fileName = $"{comand.IdempotencyKey}_{comand.ChunkIndex}";

                var result = _fileStorage.SaveAsync(
               comand.FileStream, fileName,
               new FileSaveOptions
               {
                   Tenant = "",
                   Storage = StorageKeys.Images.Root,
                   Prefix = "profile"
               },
               CancellationToken.None).GetAwaiter().GetResult();





                // 🧩 Se não for último chunk → apenas confirma
                if (!comand.IsFinalChunk)
                {
                    state = Success("Chunk recebido com sucesso.",
                        new InfraSendFileUseCaseOutputCommand
                        {
                            Success = true,
                            ChunkIndex = comand.ChunkIndex,
                            IsFinalized = false
                        });

                    return;
                }

                // 🏁 Último chunk → cria entidade via Factory
                _unitOfWork.BeginTran();

                var upload = new yFileUploadFactory(_logger).Create(
                    0,
                    comand.IdempotencyKey,
                    "Audio",                 // ou comand.Type se existir
                    1,                       // Status Finalizado
                    result.Path,
                    result.Size,
                    comand.ContentType,
                    DateTime.UtcNow,
                    DateTime.UtcNow
                );

                if (!upload.isValidInsert())
                    throw new ReceiverException<InfraSendFileUseCaseOutputCommand>(
                        Error(string.Join("; ", upload.getErroMensagens()), default));

                _repWriteyFileUpload.Insert(upload);

                _unitOfWork.Commit();

                state = Success("Upload finalizado com sucesso.",
                    new InfraSendFileUseCaseOutputCommand
                    {
                        Success = true,
                        ChunkIndex = comand.ChunkIndex,
                        IsFinalized = true
                    });
            }
            catch (ReceiverException<InfraSendFileUseCaseOutputCommand>)
            {
                _unitOfWork.Rollback();
                throw;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new ReceiverException<InfraSendFileUseCaseOutputCommand>(
                    Error(ex, default));
            }
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase