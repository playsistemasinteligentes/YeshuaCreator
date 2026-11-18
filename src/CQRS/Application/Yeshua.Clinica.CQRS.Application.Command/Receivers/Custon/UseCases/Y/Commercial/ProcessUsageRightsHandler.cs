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
    public partial class ProcessUsageRightsHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IyUsageRightReadRepository _repReadyUsageRight = default!;
        private readonly IyUsageRightWriteRepository _repWriteyUsageRight = default!;
        private readonly IyUsageConsumptionReadRepository _repReadyUsageConsumption = default!;
        private readonly IyUsageConsumptionWriteRepository _repWriteyUsageConsumption = default!;
        public ProcessUsageRightsHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IyUsageRightReadRepository repReadyUsageRight, IyUsageRightWriteRepository repWriteyUsageRight,IyUsageConsumptionReadRepository repReadyUsageConsumption, IyUsageConsumptionWriteRepository repWriteyUsageConsumption)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadyUsageRight = repReadyUsageRight;
            _repWriteyUsageRight = repWriteyUsageRight;
            _repReadyUsageConsumption = repReadyUsageConsumption;
            _repWriteyUsageConsumption = repWriteyUsageConsumption;
        }
protected partial Task<State<ProcessUsageRightsOutputCommand>> CustomActionHookAsync(State<ProcessUsageRightsOutputCommand> state, ProcessUsageRightsInputCommand comand, CancellationToken cancellationToken)
{
    return Task.FromResult(state);
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers