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

namespace Command.Receivers.UseCase
{
    public partial class RetrySagaStepHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IySagaStepReadRepository _repReadySagaStep = default!;
        private readonly IySagaStepWriteRepository _repWriteySagaStep = default!;
        public RetrySagaStepHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IySagaStepReadRepository repReadySagaStep, IySagaStepWriteRepository repWriteySagaStep)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadySagaStep = repReadySagaStep;
            _repWriteySagaStep = repWriteySagaStep;
        }
protected partial Task<State<RetrySagaStepOutputCommand>> CustomActionHookAsync(State<RetrySagaStepOutputCommand> state, RetrySagaStepInputCommand comand, CancellationToken cancellationToken)
{
    return Task.FromResult(state);
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers