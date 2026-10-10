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
using Dominio.Interfaces;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;

namespace Command.Receivers.UseCase
{
    public partial class SolicitarPublicacaoAlbumHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IAlbumReadRepository _repReadAlbum = default!;
        private readonly IAlbumWriteRepository _repWriteAlbum = default!;
        public SolicitarPublicacaoAlbumHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IAlbumReadRepository repReadAlbum, IAlbumWriteRepository repWriteAlbum)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadAlbum = repReadAlbum;
            _repWriteAlbum = repWriteAlbum;
        }
protected partial Task<State<SolicitarPublicacaoAlbumOutputCommand>> CustomActionHookAsync(State<SolicitarPublicacaoAlbumOutputCommand> state, SolicitarPublicacaoAlbumInputCommand comand, CancellationToken cancellationToken)
{
    return Task.FromResult(state);
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers