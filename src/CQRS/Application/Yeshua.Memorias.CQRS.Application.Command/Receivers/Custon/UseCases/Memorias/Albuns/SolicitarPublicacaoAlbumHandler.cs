// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

//scope;
using Dominio.Entitys;
using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;
using Command.Receivers;

namespace Command.Receivers.UseCase
{
    public partial class SolicitarPublicacaoAlbumHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IAlbumReadRepository _repReadAlbum = default!;
        private readonly IAlbumWriteRepository _repWriteAlbum = default!;
        private readonly IPublicacaoAlbumWriteRepository _repWritePublicacaoAlbum = default!;
        private readonly IySagaWriteRepository _sagaWriteRepository = default!;
        public SolicitarPublicacaoAlbumHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IAlbumReadRepository repReadAlbum, IAlbumWriteRepository repWriteAlbum, IPublicacaoAlbumWriteRepository repWritePublicacaoAlbum, IySagaWriteRepository sagaWriteRepository)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadAlbum = repReadAlbum;
            _repWriteAlbum = repWriteAlbum;
            _repWritePublicacaoAlbum = repWritePublicacaoAlbum;
            _sagaWriteRepository = sagaWriteRepository;
        }
protected partial Task<State<SolicitarPublicacaoAlbumOutputCommand>> CustomActionHookAsync(State<SolicitarPublicacaoAlbumOutputCommand> state, SolicitarPublicacaoAlbumInputCommand comand, CancellationToken cancellationToken)
{
    if (comand.AlbumId <= 0)
        return Task.FromResult(ValidationError("AlbumId deve ser informado.", new SolicitarPublicacaoAlbumOutputCommand()));

    var album = _repReadAlbum.FirstById(comand.AlbumId);
    if (album == null || album.deleted)
        return Task.FromResult(ValidationError("Album nao encontrado.", new SolicitarPublicacaoAlbumOutputCommand()));

    var correlationId = Guid.NewGuid().ToString("D");
    var publicacao = new PublicacaoAlbumFactory(_logger, _domainTrackingPolicy).Create(
        null,
        comand.AlbumId,
        correlationId,
        null,
        null,
        null,
        null,
        "Publicacao solicitada.",
        DateTime.UtcNow,
        null,
        MemoriasPublicationStatus.Solicitada);

    var saga = new PublicarAlbumYouTubeSaga();
    saga.CreatedAt = DateTime.UtcNow;
    saga.NextExecutionAt = DateTime.UtcNow;
    saga.SetCorrelationId(correlationId);

    if (_executionContext.TryGetOperationalIdentity(out var identity))
    {
        saga.SetOperationalIdentity(
            identity.RootOperationId,
            identity.OperationId,
            identity.ExecutionId,
            identity.CausationId);
        saga.GetCurrent()?.SetOperationalIdentity(
            identity.RootOperationId,
            identity.OperationId,
            identity.ExecutionId,
            identity.CausationId);
    }

    _unitOfWork.BeginTran();
    try
    {
        _repWritePublicacaoAlbum.Insert(publicacao);
        saga.Start(publicacao.Id.GetValueOrDefault().ToString(), nameof(PublicacaoAlbumEntity));
        _sagaWriteRepository.Save(saga);
        _unitOfWork.Commit();
    }
    catch
    {
        _unitOfWork.Rollback();
        throw;
    }

    return Task.FromResult(Success("Publicacao solicitada.", new SolicitarPublicacaoAlbumOutputCommand
    {
        PublicacaoAlbumId = publicacao.Id.GetValueOrDefault(),
        CorrelationId = correlationId,
        Status = "Solicitada"
    }));
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
