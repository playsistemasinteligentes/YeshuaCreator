using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;

namespace Command.Receivers.UseCase
{
    public partial class WorkerInboxUseCaseReceiver
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IyInboxReadRepository _repReadyInbox;
        private readonly IyInboxWriteRepository _repWriteyInbox;




        public WorkerInboxUseCaseReceiver(IUnitOfWork unitOfWork, ILogger logger, IyInboxReadRepository repReadyInbox, IyInboxWriteRepository repWriteyInbox)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _repReadyInbox = repReadyInbox;
            _repWriteyInbox = repWriteyInbox;
        }
        partial void CustomActionHook(ref State<WorkerInboxUseCaseOutputCommand> state, WorkerInboxUseCaseInputCommand comand)
        {
            var teste = _repReadyInbox.FirstByStatus(0);

        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase