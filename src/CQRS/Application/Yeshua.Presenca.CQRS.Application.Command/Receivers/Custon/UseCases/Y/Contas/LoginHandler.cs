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
    public partial class LoginHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IyUserReadRepository _repReadyUser = default!;
        private readonly IyUserWriteRepository _repWriteyUser = default!;
        private readonly IyTenantModuleReadRepository _repReadyTenantModule = default!;
        private readonly IyTenantModuleWriteRepository _repWriteyTenantModule = default!;
        private readonly IyUserModuleReadRepository _repReadyUserModule = default!;
        private readonly IyUserModuleWriteRepository _repWriteyUserModule = default!;
        public LoginHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IyUserReadRepository repReadyUser, IyUserWriteRepository repWriteyUser,IyTenantModuleReadRepository repReadyTenantModule, IyTenantModuleWriteRepository repWriteyTenantModule,IyUserModuleReadRepository repReadyUserModule, IyUserModuleWriteRepository repWriteyUserModule)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadyUser = repReadyUser;
            _repWriteyUser = repWriteyUser;
            _repReadyTenantModule = repReadyTenantModule;
            _repWriteyTenantModule = repWriteyTenantModule;
            _repReadyUserModule = repReadyUserModule;
            _repWriteyUserModule = repWriteyUserModule;
        }
protected partial Task<State<LoginOutputCommand>> CustomActionHookAsync(State<LoginOutputCommand> state, LoginInputCommand comand, CancellationToken cancellationToken)
{
    return Task.FromResult(state);
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers