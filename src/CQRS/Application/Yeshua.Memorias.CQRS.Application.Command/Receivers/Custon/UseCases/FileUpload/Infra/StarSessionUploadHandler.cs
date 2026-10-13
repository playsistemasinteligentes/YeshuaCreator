// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Dominio.Interfaces;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;
using Dominio.Entitys;
using Dominio.Behaviors;
using Dominio.Patterns.Domain;

namespace Command.Receivers.UseCase
{
    public partial class StarSessionUploadHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IyFileUploadWriteRepository _repWriteyFileUpload = default!;
        private readonly IAlbumReadRepository _albumReadRepository = default!;
        public StarSessionUploadHandler(
            IUnitOfWork unitOfWork,
            ILogger logger,
            IExecutionContext executionContext,
            IDomainTrackingPolicy domainTrackingPolicy,
            IyFileUploadWriteRepository repWriteyFileUpload,
            IAlbumReadRepository albumReadRepository)
            : base(logger, executionContext)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _executionContext = executionContext;
            _domainTrackingPolicy = domainTrackingPolicy;
            _repWriteyFileUpload = repWriteyFileUpload;
            _albumReadRepository = albumReadRepository;
        }
        protected partial Task<State<StarSessionUploadOutputCommand>> CustomActionHookAsync(State<StarSessionUploadOutputCommand> state, StarSessionUploadInputCommand comand, CancellationToken cancellationToken)
        {
            try
            {
                if (!string.Equals(comand.entityType, "Album", StringComparison.OrdinalIgnoreCase)
                    || !int.TryParse(comand.entityId, out var albumId)
                    || albumId <= 0)
                {
                    throw new ReceiverException<StarSessionUploadOutputCommand>(
                        ValidationError("Informe um album valido para iniciar o upload."));
                }

                var album = _albumReadRepository.FirstById(albumId);
                if (album is null || album.userid != _executionContext.UserId)
                {
                    throw new ReceiverException<StarSessionUploadOutputCommand>(
                        ValidationError("Album nao encontrado para o usuario atual."));
                }

                _executionContext.TryGetOperationalIdentity(out var executionIdentity);
                var context = DomainOperationContext.Create(
                    DomainOperation.Registro, DomainEntryPoint.UseCase, "IniciarUploadFotoAlbum",
                    _executionContext.TenantID, _executionContext.UserId,
                    traceId: _executionContext.TraceId,
                    receiverName: nameof(StarSessionUploadHandler),
                    commandName: "Command.UseCase.StarSessionUploadInputCommand",
                    rootOperationId: executionIdentity.RootOperationId,
                    operationId: executionIdentity.OperationId,
                    executionId: executionIdentity.ExecutionId,
                    causationId: executionIdentity.CausationId);

                var upload = new yFileUploadFactory(_logger, _domainTrackingPolicy).Create(
                    context: context,
                    id: null,
                    type: "memorias.photo",
                    status: 0,
                    filepath: null,
                    filesize: null,
                    entitytype: "Album",
                    entityid: albumId.ToString(System.Globalization.CultureInfo.InvariantCulture),
                    createdat: DateTime.UtcNow,
                    completedat: null);

                var validation = yFileUploadDomainBehavior.Apply(upload, context);
                if (!validation.IsValid)
                {
                    throw new ReceiverException<StarSessionUploadOutputCommand>(
                        ValidationError(string.Join("; ", validation.Errors)));
                }

                _unitOfWork.BeginTran();
                _repWriteyFileUpload.Insert(upload);
                _unitOfWork.Commit();

                return Task.FromResult(Success(
                    "Sessao de upload criada.",
                    new StarSessionUploadOutputCommand
                    {
                        uploadToken = upload.OperationalEntityId
                    }));
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
