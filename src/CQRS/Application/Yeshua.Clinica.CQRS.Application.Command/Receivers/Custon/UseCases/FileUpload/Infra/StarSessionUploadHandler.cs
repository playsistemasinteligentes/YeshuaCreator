using System.Threading.Tasks;
using System.Threading;
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
        private readonly IyFileUploadReadRepository _repReadyFileUpload;
        private readonly IyFileUploadWriteRepository _repWriteyFileUpload;
        private readonly UploadTokenHelper _uploadTokens;
        private readonly ISesoesReadRepository _sessions;
        
        public StarSessionUploadHandler(
    IUnitOfWork unitOfWork,
    UploadTokenHelper uploadTokens,
    ISesoesReadRepository sessions,
    IyFileUploadReadRepository repReadyFileUpload,
    IyFileUploadWriteRepository repWriteyFileUpload,
    Dominio.Interfaces.ILogger logger,
    Aplication.Interfaces.Services.IExecutionContext context)
    : base(logger, context)
        {
            _unitOfWork = unitOfWork;
            _uploadTokens = uploadTokens;
            _sessions = sessions;
            _repReadyFileUpload = repReadyFileUpload;
            _repWriteyFileUpload = repWriteyFileUpload;
            _logger = logger;
            _executionContext = context;
        }


        protected partial async Task<State<StarSessionUploadOutputCommand>> CustomActionHookAsync(State<StarSessionUploadOutputCommand> state, StarSessionUploadInputCommand comand, CancellationToken cancellationToken)
{
            try
            {

                if (comand.entityType != "Sesoes" || !int.TryParse(comand.entityId, out var sessionId)
                    || sessionId <= 0 || _sessions.FirstById(sessionId) is null)
                    return ValidationError("Sessao clinica nao encontrada.", new StarSessionUploadOutputCommand());
                // Criar entidade
                var upload = new yFileUploadFactory(_logger).Create(
                  0,
                  "audio.transcribe",
                  0,                       
                  "",
                  0,
                  comand.entityType,
                  comand.entityId,
                  DateTime.UtcNow,
                  null
              );

                if (!upload.isValidInsert())
                    throw new ReceiverException<StarSessionUploadOutputCommand>(
                        Error(string.Join("; ", upload.getErroMensagens()), default));

                // inserir
                _repWriteyFileUpload.Insert(upload);



                // gerar token
                var token = _uploadTokens.Generate(
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
            return state;
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase
