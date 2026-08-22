using Command.Interfaces.Patterns.Queue;
using Command.Patterns.Command;
using Command.Patterns.Queue;
using Command.UseCase;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using RepositoryInterfaces.Patterns.Worker;
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
        private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;


        public yOutBoxWorkerHandler(
      IUnitOfWork unitOfWork,
      IyOutboxReadRepository outboxReadRepository,
      IyOutboxWriteRepository outboxWriteRepository,
      IQueuePublisher queuePublisher,
      Dominio.Interfaces.ILogger logger,
      Aplication.Interfaces.Services.IExecutionContext context)
      : base(logger, context)
        {
            _unitOfWork = unitOfWork;
            _outboxReadRepository = outboxReadRepository;
            _outboxWriteRepository = outboxWriteRepository;
            _queuePublisher = queuePublisher;
            _logger = logger;
            _executionContext = context;
        }

        protected override State<yOutboxOutputCommand> Action(yOutboxInputCommand command)
        {
            State<yOutboxOutputCommand> state = Success("OK", null);
            var processed = new List<int>();
            var claimed = 0;
            var failed = 0;

            try
            {
                var events = _outboxReadRepository.ClaimBatch(10);
                claimed = events.Count;

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
                        failed++;
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

                return Success("OK", new yOutboxOutputCommand
                {
                    Claimed = claimed,
                    Processed = processed.Count,
                    Failed = failed
                });
            }
            catch (Exception ex)
            {
                return Error(ex, new yOutboxOutputCommand
                {
                    Claimed = claimed,
                    Processed = processed.Count,
                    Failed = Math.Max(1, failed)
                });
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

    public partial record yOutboxOutputCommand : ICommand, IWorkerCycleResult
    {
        public List<int> lst { get; set; }
        public int BatchLimit => 10;
        public int Claimed { get; init; }
        public int Processed { get; init; }
        public int Failed { get; init; }
    }
}
