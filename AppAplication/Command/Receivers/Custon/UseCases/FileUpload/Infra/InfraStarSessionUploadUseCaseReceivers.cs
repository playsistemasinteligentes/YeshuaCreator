using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;
using Command.Receivers.Custon.UseCases.FileUpload.Infra;
using Dominio.Entitys;
using Aplication.Interfaces.Services;

namespace Command.Receivers.UseCase
{
    public partial class InfraStarSessionUploadUseCaseReceiver
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IyFileUploadReadRepository _repReadyFileUpload;
        private readonly IyFileUploadWriteRepository _repWriteyFileUpload;
        private readonly ICurrentUser _CurrentUser;

        public InfraStarSessionUploadUseCaseReceiver(IUnitOfWork unitOfWork, ILogger logger, IyFileUploadReadRepository repReadyFileUpload, IyFileUploadWriteRepository repWriteyFileUpload, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _repReadyFileUpload = repReadyFileUpload;
            _repWriteyFileUpload = repWriteyFileUpload;
            _CurrentUser = currentUser;
        }

        partial void CustomActionHook(ref State<InfraStarSessionUploadUseCaseOutputCommand> state,
    InfraStarSessionUploadUseCaseInputCommand comand)
        {
            try
            {

                // Criar entidade
                var upload = new yFileUploadFactory(_logger).Create(
                  0,
                  "Audio",                 // ou comand.Type se existir
                  1,                       // Status Finalizado
                  "",
                  0,
                  DateTime.UtcNow,
                  DateTime.UtcNow
              );

                if (!upload.isValidInsert())
                    throw new ReceiverException<InfraStarSessionUploadUseCaseOutputCommand>(
                        Error(string.Join("; ", upload.getErroMensagens()), default));

                // inserir
                _repWriteyFileUpload.Insert(upload);



                // gerar token
                var token = UploadTokenHelper.Generate(
                    upload.Id.Value,
                    _CurrentUser.UserId,
                    _CurrentUser.TenantID
                );


                state = Success("Upload session criada.",
                    new InfraStarSessionUploadUseCaseOutputCommand
                    {
                        uploadToken = token
                    });
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }


    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase