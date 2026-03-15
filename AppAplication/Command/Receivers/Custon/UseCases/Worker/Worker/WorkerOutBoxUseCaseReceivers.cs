using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;
using Dominio.Entitys;
using Command.Patterns.Queue;
using Command.Interfaces.Patterns.Queue;

namespace Command.Receivers.UseCase
{
    public partial class WorkerOutBoxUseCaseReceiver
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IyOutboxReadRepository _repReadyOutbox;
        private readonly IyOutboxWriteRepository _repWriteyOutbox;
        private readonly IQueuePublisher _queuePublisher;
        public WorkerOutBoxUseCaseReceiver(IUnitOfWork unitOfWork, ILogger logger, IyOutboxReadRepository repReadyOutbox, IyOutboxWriteRepository repWriteyOutbox, IQueuePublisher queuePublisher)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _repReadyOutbox = repReadyOutbox;
            _repWriteyOutbox = repWriteyOutbox;
            _queuePublisher = queuePublisher;
        }
        partial void CustomActionHook(ref State<WorkerOutBoxUseCaseOutputCommand> state, WorkerOutBoxUseCaseInputCommand comand)
        {
            try
            {
                var outBox = _repReadyOutbox.FirstByStatus(0);
                if (outBox == null) return;

                QueueMessage queueMessage = new QueueMessage(outBox.type, outBox.payload)
                { CorrelationId = outBox.id.ToString(), Source = "worker-outbox" };

                _queuePublisher.PublishAsync("ai.tasks", "audio.transcribe", queueMessage).GetAwaiter().GetResult();
            }
            catch (Exception)
            {
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase