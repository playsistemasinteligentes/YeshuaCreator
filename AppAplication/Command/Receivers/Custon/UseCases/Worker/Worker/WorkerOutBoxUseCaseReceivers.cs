using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;

namespace Command.Receivers.UseCase
{
    public partial class WorkerOutBoxUseCaseReceiver
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IyUserReadRepository _repReadyUser;
        private readonly IyUserWriteRepository _repWriteyUser;
        private readonly IyTenantModuleReadRepository _repReadyTenantModule;
        private readonly IyTenantModuleWriteRepository _repWriteyTenantModule;
        private readonly IyUserModuleReadRepository _repReadyUserModule;
        private readonly IyUserModuleWriteRepository _repWriteyUserModule;
        public WorkerOutBoxUseCaseReceiver(IUnitOfWork unitOfWork,ILogger logger,IyUserReadRepository repReadyUser, IyUserWriteRepository repWriteyUser,IyTenantModuleReadRepository repReadyTenantModule, IyTenantModuleWriteRepository repWriteyTenantModule,IyUserModuleReadRepository repReadyUserModule, IyUserModuleWriteRepository repWriteyUserModule)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
            _repReadyUser = repReadyUser;
            _repWriteyUser = repWriteyUser;
            _repReadyTenantModule = repReadyTenantModule;
            _repWriteyTenantModule = repWriteyTenantModule;
            _repReadyUserModule = repReadyUserModule;
            _repWriteyUserModule = repWriteyUserModule;
        }
partial void CustomActionHook(ref State<WorkerOutBoxUseCaseOutputCommand> state, WorkerOutBoxUseCaseInputCommand comand)
{
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase