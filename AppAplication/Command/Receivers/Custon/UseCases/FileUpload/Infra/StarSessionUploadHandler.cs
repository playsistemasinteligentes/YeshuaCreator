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
        private readonly IExecutionContext _executionContext;

        public StarSessionUploadHandler(
    IUnitOfWork unitOfWork,
    IyFileUploadReadRepository repReadyFileUpload,
    IyFileUploadWriteRepository repWriteyFileUpload,
    Dominio.Interfaces.ILogger logger,
    Aplication.Interfaces.Services.IExecutionContext context)
    : base(logger, context)
        {
            _unitOfWork = unitOfWork;
            _repReadyFileUpload = repReadyFileUpload;
            _repWriteyFileUpload = repWriteyFileUpload;
        }


        partial void CustomActionHook(ref State<StarSessionUploadOutputCommand> state, StarSessionUploadInputCommand comand)
{
            try
            {

                // Criar entidade
                var upload = new yFileUploadFactory(_logger).Create(
                  0,
                  "audio.transcribe",
                  0,                       
                  "",
                  0,
                  comand.entityId,
                  comand.entityType,
                  DateTime.UtcNow,
                  DateTime.MinValue
              );

                if (!upload.isValidInsert())
                    throw new ReceiverException<StarSessionUploadOutputCommand>(
                        Error(string.Join("; ", upload.getErroMensagens()), default));

                // inserir
                _repWriteyFileUpload.Insert(upload);



                // gerar token
                var token = UploadTokenHelper.Generate(
                    upload.Id.Value,
                    _executionContext.UserId,
                    _executionContext.TenantID
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