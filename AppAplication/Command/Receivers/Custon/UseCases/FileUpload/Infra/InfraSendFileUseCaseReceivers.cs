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
using Aplication.Interfaces.Services;
using Command.Receivers.Custon.UseCases.FileUpload.Infra;
using Command.Patterns.OutBox;

namespace Command.Receivers.UseCase
{
    public partial class InfraSendFileUseCaseReceiver
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IyFileUploadReadRepository _repReadyFileUpload;
        private readonly IyFileUploadWriteRepository _repWriteyFileUpload;
        private readonly IFileStorage _fileStorage;
        private readonly ICurrentUser _CurrentUser;
        private readonly IyOutboxWriteRepository _yOutboxWriteRepository;

        public InfraSendFileUseCaseReceiver(IUnitOfWork unitOfWork, ILogger logger, IyFileUploadReadRepository repReadyFileUpload, IyFileUploadWriteRepository repWriteyFileUpload, IFileStorage fileStorage, ICurrentUser currentUser, IyOutboxWriteRepository yOutboxWriteRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _repReadyFileUpload = repReadyFileUpload;
            _repWriteyFileUpload = repWriteyFileUpload;
            _fileStorage = fileStorage;
            _CurrentUser = currentUser;
            _yOutboxWriteRepository = yOutboxWriteRepository;

        }
        partial void CustomActionHook(
            ref State<InfraSendFileUseCaseOutputCommand> state,
            InfraSendFileUseCaseInputCommand comand)
        {
            try
            {
                if (comand.FileStream == null)
                    throw new ReceiverException<InfraSendFileUseCaseOutputCommand>(
                        Error("FileStream é obrigatório.", default));

                if (string.IsNullOrWhiteSpace(comand.token))
                    throw new ReceiverException<InfraSendFileUseCaseOutputCommand>(
                        Error("Token é obrigatório.", default));

                // 🔐 valida token
                var tokenData = UploadTokenHelper.ValidateAndExtract(comand.token);

                var uploadId = tokenData.uploadId;
                var userId = tokenData.userId;
                var tenantId = tokenData.tenantId;

                // segurança
                if (tenantId != _CurrentUser.TenantID)
                    throw new ReceiverException<InfraSendFileUseCaseOutputCommand>(
                        Error("Token inválido para o tenant atual.", default));


                // 📁 nome do chunk
                var chunkFileName = $"chunk_{comand.ChunkIndex}.part";

                StoragePath path = StoragePathBuilder.Build(
                    tenantId.ToString(),
                    uploadId.ToString(),
                    chunkFileName,
                    false
                );

                // 💾 salva chunk
                var result = _fileStorage
                    .SaveAsync(comand.FileStream, path, CancellationToken.None)
                    .GetAwaiter()
                    .GetResult();

                // 🧩 se não for último chunk
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

                // --------------------------------
                // FINALIZA UPLOAD
                // --------------------------------


                //// 🔎 busca upload criado no StartUpload
                //var upload = _repReadyFileUpload.FirstById(uploadId);

                //if (upload == null)
                //    throw new ReceiverException<InfraSendFileUseCaseOutputCommand>(
                //        Error("Upload não encontrado.", default));

                var finalFileName = comand.FileName;

                StoragePath finalPath = StoragePathBuilder.Build(
                    tenantId.ToString(),
                    uploadId.ToString(),
                    finalFileName,
                    false
                );

                // 🧩 aqui você pode juntar os chunks se necessário
                // ex: CombineChunks(uploadId)

                // atualiza registro criado no StartUpload
                yFileUploadEntity upload = new yFileUploadEntity().getProxy(uploadId);
                upload.FilePath = finalPath.Value;
                upload.FileSize = result.Size;
                upload.Status = 1; // Finalizado
                upload.CompletedAt = DateTime.UtcNow;

                if (!upload.isValidData())
                    throw new ReceiverException<InfraSendFileUseCaseOutputCommand>(
                    Error(string.Join("; ", upload.getErroMensagens()), default));

                var payload = new UploadCompletedEvent(upload.FilePath);

                _unitOfWork.BeginTran();

                _repWriteyFileUpload.UpdateFilePath(upload);

                new OutboxService(_yOutboxWriteRepository, _logger).AddOutBoxEvent("yFileUploadEntity.Status.Completed", "", upload.Id.Value);

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
    public record UploadCompletedEvent(string FilePath);
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase