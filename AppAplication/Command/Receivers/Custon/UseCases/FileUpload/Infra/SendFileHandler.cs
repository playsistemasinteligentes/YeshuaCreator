using Aplication.Interfaces.Services;
using Command.Interfaces;
using Command.Interfaces.Patterns.FileStore;
using Command.Patterns.OutBox;
using Command.Receivers.Custon.UseCases.FileUpload.Infra;
using Command.UseCase;
using Dominio.Entitys;
using Dominio.Interfaces;
using Dominio.Saga;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Command.Receivers.UseCase
{
    public partial class SendFileHandler
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IyFileUploadReadRepository _repReadyFileUpload;
        private readonly IyFileUploadWriteRepository _repWriteyFileUpload;
        private readonly IFileStorage _fileStorage;
        private readonly ICurrentUser _CurrentUser;
        private readonly IyOutboxWriteRepository _yOutboxWriteRepository;
        private readonly IySagaWriteRepository _ySagaWriteRepository;
        private readonly PsychologySessionInsightSaga _psychologySessionInsightSaga;
        private readonly ISagaExecutor _sagaExecutor;
        //private readonly PsychologySessionInsightSagaHandlerResolver _psychologySagaHandlerResolver;
        



        public SendFileHandler(IUnitOfWork unitOfWork, ILogger logger, IyFileUploadReadRepository repReadyFileUpload, IyFileUploadWriteRepository repWriteyFileUpload, IFileStorage fileStorage, ICurrentUser currentUser, IyOutboxWriteRepository yOutboxWriteRepository, IySagaWriteRepository ySagaWriteRepository, PsychologySessionInsightSaga psychologySessionInsightSaga,ISagaExecutor sagaExecutor)//, PsychologySessionInsightSagaHandlerResolver psychologySagaHandlerResolver)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _repReadyFileUpload = repReadyFileUpload;
            _repWriteyFileUpload = repWriteyFileUpload;
            _fileStorage = fileStorage;
            _CurrentUser = currentUser;
            _yOutboxWriteRepository = yOutboxWriteRepository;
            _ySagaWriteRepository = ySagaWriteRepository;
            _psychologySessionInsightSaga = psychologySessionInsightSaga;
            _sagaExecutor = sagaExecutor;
            //_psychologySagaHandlerResolver = psychologySagaHandlerResolver;
        }



partial void CustomActionHook(ref State<SendFileOutputCommand> state, SendFileInputCommand comand)
{

            try
            {
                if (comand.FileStream == null)
                    throw new ReceiverException<SendFileOutputCommand>(
                        Error("FileStream é obrigatório.", default));

                if (string.IsNullOrWhiteSpace(comand.token))
                    throw new ReceiverException<SendFileOutputCommand>(
                        Error("Token é obrigatório.", default));

                // 🔐 valida token
                var tokenData = UploadTokenHelper.ValidateAndExtract(comand.token);

                var uploadId = tokenData.uploadId;
                var userId = tokenData.userId;
                var tenantId = tokenData.tenantId;
                string idEntity = Path.Combine(uploadId.ToString(), "pending_merge");

                // segurança
                if (tenantId != _CurrentUser.TenantID)
                    throw new ReceiverException<SendFileOutputCommand>(
                        Error("Token inválido para o tenant atual.", default));


                // 📁 nome do chunk
                var chunkFileName = $"chunk_{comand.ChunkIndex}.part";

                StoragePath path = StoragePathBuilder.Build(
                    StorageLocation.Volatile.TranscriptionsInput,
                    tenantId.ToString(),
                    idEntity,
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
                    new SendFileOutputCommand
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
                //    throw new ReceiverException<SendFileOutputCommand>(
                //        Error("Upload não encontrado.", default));

                StoragePath finalPath = StoragePathBuilder.Build(
                    StorageLocation.Volatile.TranscriptionsInput,
                    tenantId.ToString(),
                    uploadId.ToString(),
                    $"{Guid.NewGuid():N}.webm",
                    false
                );

                // 🧩 aqui você pode juntar os chunks se necessário
                // ex: CombineChunks(uploadId)

                // atualiza registro criado no StartUpload
                yFileUploadEntity upload = new yFileUploadEntity().getProxy(uploadId);
                upload.FilePath = finalPath.Value;
                upload.FileSize = result.Size;
                upload.Status = 1;
                upload.CreatedAt = DateTime.UtcNow;
                upload.Type = "audio.transcribe";


                if (!upload.isValidData())
                    throw new ReceiverException<SendFileOutputCommand>(
                    Error(string.Join("; ", upload.getErroMensagens()), default));

                var payload = new UploadCompletedEvent($"{_fileStorage.GetBaseUrl(finalPath)}");

                _psychologySessionInsightSaga.Start(comand.EntityId, comand.EntityType);
                //_sagaExecutor.Execute(_psychologySessionInsightSaga, _psychologySagaHandlerResolver);

                _unitOfWork.BeginTran();
                _repWriteyFileUpload.UpdateFilePath(uploadId, upload.FilePath);
                _ySagaWriteRepository.Save(_psychologySessionInsightSaga);
                _unitOfWork.Commit();

                state = Success("Upload finalizado com sucesso.",
                    new SendFileOutputCommand
                    {
                        Success = true,
                        ChunkIndex = comand.ChunkIndex,
                        IsFinalized = true
                    });
            }
            catch (ReceiverException<SendFileOutputCommand>)
            {
                _unitOfWork.Rollback();
                throw;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new ReceiverException<SendFileOutputCommand>(
                    Error(ex, default));
            }

    }
    }
    public record UploadCompletedEvent(string FilePath);
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase