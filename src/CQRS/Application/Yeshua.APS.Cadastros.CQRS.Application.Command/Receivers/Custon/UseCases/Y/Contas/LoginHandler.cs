using System.Threading.Tasks;
using System.Threading;
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
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;
using Aplication.Interfaces.Services;

namespace Command.Receivers.UseCase
{
    public partial class LoginHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IyUserReadRepository _repReadyUser;
        private readonly IyUserWriteRepository _repWriteyUser;
        private readonly IyTenantModuleReadRepository _repReadyTenantModule;
        private readonly IyTenantModuleWriteRepository _repWriteyTenantModule;
        private readonly IyUserModuleReadRepository _repReadyUserModule;
        private readonly IyUserModuleWriteRepository _repWriteyUserModule;
        public LoginHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IyUserReadRepository repReadyUser, IyUserWriteRepository repWriteyUser,IyTenantModuleReadRepository repReadyTenantModule, IyTenantModuleWriteRepository repWriteyTenantModule,IyUserModuleReadRepository repReadyUserModule, IyUserModuleWriteRepository repWriteyUserModule)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
            _repReadyUser = repReadyUser;
            _repWriteyUser = repWriteyUser;
            _repReadyTenantModule = repReadyTenantModule;
            _repWriteyTenantModule = repWriteyTenantModule;
            _repReadyUserModule = repReadyUserModule;
            _repWriteyUserModule = repWriteyUserModule;
        }
protected partial async Task<State<LoginOutputCommand>> CustomActionHookAsync(State<LoginOutputCommand> state, LoginInputCommand comand, CancellationToken cancellationToken)
{
            return state;
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
