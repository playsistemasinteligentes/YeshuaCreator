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

//scope;
using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;
using Aplication.Interfaces.Services;

namespace Command.Receivers.UseCase
{
    public partial class CreateContaHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IyTenantReadRepository _repReadyTenant;
        private readonly IyTenantWriteRepository _repWriteyTenant;
        private readonly IyUserReadRepository _repReadyUser;
        private readonly IyUserWriteRepository _repWriteyUser;
        public CreateContaHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IyTenantReadRepository repReadyTenant, IyTenantWriteRepository repWriteyTenant,IyUserReadRepository repReadyUser, IyUserWriteRepository repWriteyUser)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
            _repReadyTenant = repReadyTenant;
            _repWriteyTenant = repWriteyTenant;
            _repReadyUser = repReadyUser;
            _repWriteyUser = repWriteyUser;
        }
protected partial async Task<State<CreateContaOutputCommand>> CustomActionHookAsync(State<CreateContaOutputCommand> state, CreateContaInputCommand comand, CancellationToken cancellationToken)
{
            return state;
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
