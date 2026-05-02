using Aplication.Interfaces.Services;
using Command.Receivers.Custon.UseCases.FileUpload.Infra;
using Command.UseCase;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Command.Receivers.UseCase
{
    public partial class StarSessionUploadHandler
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IyFileUploadReadRepository _repReadyFileUpload;
        private readonly IyFileUploadWriteRepository _repWriteyFileUpload;
        private readonly ICurrentUser _CurrentUser;

        public StarSessionUploadHandler(IUnitOfWork unitOfWork, ILogger logger, IyFileUploadReadRepository repReadyFileUpload, IyFileUploadWriteRepository repWriteyFileUpload, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _repReadyFileUpload = repReadyFileUpload;
            _repWriteyFileUpload = repWriteyFileUpload;
            _CurrentUser = currentUser;
        }


        partial void CustomActionHook(ref State<StarSessionUploadOutputCommand> state, StarSessionUploadInputCommand comand)
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
                  string.Empty,
                  string.Empty,
                  DateTime.UtcNow,
                  DateTime.UtcNow
              );

                if (!upload.isValidInsert())
                    throw new ReceiverException<StarSessionUploadOutputCommand>(
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
                    new StarSessionUploadOutputCommand
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