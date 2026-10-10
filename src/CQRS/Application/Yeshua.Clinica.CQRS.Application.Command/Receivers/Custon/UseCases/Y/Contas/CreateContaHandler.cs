using System.Threading.Tasks;
using System.Threading;
//scope;
using Aplication.Interfaces.Services;
using Command.UseCase;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Command.Receivers.UseCase
{
    public partial class CreateContaHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IyTenantReadRepository _repReadY_Tenant;
        private readonly IyTenantWriteRepository _repWriteY_Tenant;
        private readonly IyUserReadRepository _repReadY_User;
        private readonly IyUserWriteRepository _repWriteY_User;

        public CreateContaHandler(
    IUnitOfWork unitOfWork,
    IyTenantReadRepository repReadY_Tenant,
    IyTenantWriteRepository repWriteY_Tenant,
    IyUserReadRepository repReadY_User,
    IyUserWriteRepository repWriteY_User,
    Dominio.Interfaces.ILogger logger,
    Aplication.Interfaces.Services.IExecutionContext context)
    : base(logger, context)
        {
            _unitOfWork = unitOfWork;
            _repReadY_Tenant = repReadY_Tenant;
            _repWriteY_Tenant = repWriteY_Tenant;
            _repReadY_User = repReadY_User;
            _repWriteY_User = repWriteY_User;
            _logger = logger;
            _executionContext = context;
        }

        protected partial async Task<State<CreateContaOutputCommand>> CustomActionHookAsync(State<CreateContaOutputCommand> state, CreateContaInputCommand comand, CancellationToken cancellationToken)
{
            await Task.CompletedTask;
            throw new ReceiverException<CreateContaOutputCommand>(
                Error("A criacao de tenants pertence exclusivamente a Central.", default));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase
