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
    public partial class PublicarCTeAutorizadoParaMDFeHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly ICTeSaidaMDFeReadRepository _repReadCTeSaidaMDFe = default!;
        private readonly ICTeSaidaMDFeWriteRepository _repWriteCTeSaidaMDFe = default!;
        public PublicarCTeAutorizadoParaMDFeHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,ICTeSaidaMDFeReadRepository repReadCTeSaidaMDFe, ICTeSaidaMDFeWriteRepository repWriteCTeSaidaMDFe)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadCTeSaidaMDFe = repReadCTeSaidaMDFe;
            _repWriteCTeSaidaMDFe = repWriteCTeSaidaMDFe;
        }
protected partial async Task<State<PublicarCTeAutorizadoParaMDFeOutputCommand>> CustomActionHookAsync(State<PublicarCTeAutorizadoParaMDFeOutputCommand> state, PublicarCTeAutorizadoParaMDFeInputCommand comand, CancellationToken cancellationToken)
{
    return state;
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers