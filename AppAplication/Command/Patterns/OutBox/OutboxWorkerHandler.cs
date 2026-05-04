using Command.Interfaces.Patterns.Queue;
using Command.Patterns.Command;
using Command.Patterns.Queue;
using Command.UseCase;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using System.Collections.Generic;
using System.Text.Json;

namespace Command.Patterns.OutBox
{
    public class yOutBoxWorkerHandler : ReciverBase<yOutboxInputCommand, yOutboxOutputCommand>
    {
        private readonly IyOutboxReadRepository _outboxReadRepository;
        private readonly IyOutboxWriteRepository _outboxWriteRepository;
        private readonly IQueuePublisher _queuePublisher;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public yOutBoxWorkerHandler(
            IUnitOfWork unitOfWork,
            ILogger logger,
            IyOutboxReadRepository outboxReadRepository,
            IyOutboxWriteRepository outboxWriteRepository,
            IQueuePublisher queuePublisher
        )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _outboxReadRepository = outboxReadRepository;
            _outboxWriteRepository = outboxWriteRepository;
            _queuePublisher = queuePublisher;
        }

        protected override State<yOutboxOutputCommand> Action(yOutboxInputCommand command)
        {
            State<yOutboxOutputCommand> state = Success("OK", null);
            var processed = new List<int>();

            try
            {
                var events = _outboxReadRepository.ClaimBatch(10);

                foreach (var evt in events)
                {
                    try
                    {
                        var message = new QueueMessage(evt.type, evt.payload)
                        {
                            MenssageId = evt.messageid,
                            CorrelationId = evt.correlationid,
                            Source = "outbox-worker"
                        };

                        bool ok = false;

                        if (evt.transporttype == 1) // Queue
                        {
                            //ok = _queuePublisher.PublishCeleryAsync("ai.tasks.audio.transcribe", "ai.tasks", "audio.transcribe", message).GetAwaiter().GetResult();
                            var transport = JsonSerializer.Deserialize<QueueTransport>(evt.transportdata ?? "{}");
                            ok = _queuePublisher.PublishCeleryAsync(
                                transport.Queue,
                                transport.Exchange,
                                transport.RoutingKey,
                                transport.TaskName,
                                message
                            ).GetAwaiter().GetResult();
                        }
                        else
                        {
                            throw new Exception("Transport não suportado");
                        }

                        if (!ok)
                            throw new Exception("Falha publish");

                        _outboxReadRepository.MarkAsDone(evt.id, DateTime.UtcNow);

                        processed.Add(evt.id);
                    }
                    catch (Exception exItem)
                    {
                        var retry = evt.retrycount + 1;
                        var next = DateTime.UtcNow.AddSeconds(Math.Pow(2, retry));

                        if (retry >= 5)
                        {
                            _outboxReadRepository.MarkAsDeadLetter(evt.id, exItem.Message, retry);
                        }
                        else
                        {
                            _outboxReadRepository.MarkAsRetry(evt.id, retry, next, exItem.Message);
                        }
                    }
                }
                _unitOfWork.Commit();

                return Success("OK", default);
            }
            catch (Exception ex)
            {
                return Error(ex, default);
            }
        }
    }

    // 🔥 Classe de transporte (exemplo Queue)
    public class QueueTransport
    {
        public string Queue { get; set; }
        public string Exchange { get; set; }
        public string RoutingKey { get; set; }
        public string TaskName{ get; set; }

    }

    public partial record yOutboxInputCommand : ICommand
    {
        public string CorrelationId { get; set; }
        public string Payload { get; set; }
    }

    public partial record yOutboxOutputCommand : ICommand
    {
        public List<int> lst { get; set; }
    }
}