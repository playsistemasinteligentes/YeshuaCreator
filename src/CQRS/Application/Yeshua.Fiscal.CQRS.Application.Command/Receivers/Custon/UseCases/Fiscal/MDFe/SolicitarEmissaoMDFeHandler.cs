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
    public partial class SolicitarEmissaoMDFeHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IMDFeSolicitacaoFiscalReadRepository _repReadMDFeSolicitacaoFiscal = default!;
        private readonly IMDFeSolicitacaoFiscalWriteRepository _repWriteMDFeSolicitacaoFiscal = default!;
        public SolicitarEmissaoMDFeHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IMDFeSolicitacaoFiscalReadRepository repReadMDFeSolicitacaoFiscal, IMDFeSolicitacaoFiscalWriteRepository repWriteMDFeSolicitacaoFiscal)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadMDFeSolicitacaoFiscal = repReadMDFeSolicitacaoFiscal;
            _repWriteMDFeSolicitacaoFiscal = repWriteMDFeSolicitacaoFiscal;
        }
protected partial async Task<State<SolicitarEmissaoMDFeOutputCommand>> CustomActionHookAsync(State<SolicitarEmissaoMDFeOutputCommand> state, SolicitarEmissaoMDFeInputCommand comand, CancellationToken cancellationToken)
{
    return state;
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers