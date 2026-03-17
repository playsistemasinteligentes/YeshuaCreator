using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;
using Command.Interfaces.Patterns.Queue;
using Command.Patterns.Queue;
using Command.Read;
using Repositorio.Outputs;
using Dominio.Entitys;

namespace Command.Receivers.UseCase
{
    public partial class WorkerPollingOutBoxUseCaseReceiver
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IyOutboxReadRepository _repReadyOutbox;
        private readonly IyOutboxWriteRepository _repWriteyOutbox;
        private readonly IQueuePublisher _queuePublisher;

        public WorkerPollingOutBoxUseCaseReceiver(IUnitOfWork unitOfWork, ILogger logger, IyOutboxReadRepository repReadyOutbox, IyOutboxWriteRepository repWriteyOutbox, IQueuePublisher queuePublisher)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _repReadyOutbox = repReadyOutbox;
            _repWriteyOutbox = repWriteyOutbox;
            _queuePublisher = queuePublisher;
        }
        partial void CustomActionHook(ref State<WorkerPollingOutBoxUseCaseOutputCommand> state, WorkerPollingOutBoxUseCaseInputCommand comand)
        {
            try
            {
                var command = new yOutboxProximaPendenteCommand
                {
                    Paginacao = new Pagination(1, 10)
                };

                var outBoxData = _repReadyOutbox.GetyOutboxProximaPendente(command);
                foreach (yOutboxStandardDTO outBox in outBoxData.Items)
                {
                    QueueMessage queueMessage = new QueueMessage(outBox.type, outBox.payload)
                    { CorrelationId = outBox.id.ToString(), Source = "worker-outbox" };
                    _queuePublisher.PublishAsync("ai.tasks", "audio.transcribe", queueMessage).GetAwaiter().GetResult();
                    yOutboxEntity outboxEntity = new yOutboxEntity() { Id = outBox.id, Status = 1 };
                    _repWriteyOutbox.UpdateStatus(outboxEntity);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase