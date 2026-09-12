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
    public partial class ReceberRomaneioConsolidadoParaCTeHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly ICTeRomaneioConsolidadoReadRepository _repReadCTeRomaneioConsolidado = default!;
        private readonly ICTeRomaneioConsolidadoWriteRepository _repWriteCTeRomaneioConsolidado = default!;
        public ReceberRomaneioConsolidadoParaCTeHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,ICTeRomaneioConsolidadoReadRepository repReadCTeRomaneioConsolidado, ICTeRomaneioConsolidadoWriteRepository repWriteCTeRomaneioConsolidado)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadCTeRomaneioConsolidado = repReadCTeRomaneioConsolidado;
            _repWriteCTeRomaneioConsolidado = repWriteCTeRomaneioConsolidado;
        }
protected partial async Task<State<ReceberRomaneioConsolidadoParaCTeOutputCommand>> CustomActionHookAsync(State<ReceberRomaneioConsolidadoParaCTeOutputCommand> state, ReceberRomaneioConsolidadoParaCTeInputCommand comand, CancellationToken cancellationToken)
{
    return state;
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers