using Aplication.Interfaces.Services;
using Command.Interfaces.Patterns.Queue;
using Command.Patterns.Command;
using Command.Patterns.Queue;
using Dominio.Operational;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Worker;

namespace Worker.Custon;

public sealed class MediaOutboxTransportWorker
    : ReciverBase<MediaOutboxTransportInputCommand, MediaOutboxTransportOutputCommand>
{
    private const string RenderRequestedType = "media.album.render.requested";
    private readonly IyOutboxReadRepository _outboxReadRepository;
    private readonly IyOutboxWriteRepository _outboxWriteRepository;
    private readonly IQueuePublisher _queuePublisher;
    private readonly IExecutionContext _context;

    public MediaOutboxTransportWorker(
        IyOutboxReadRepository outboxReadRepository,
        IyOutboxWriteRepository outboxWriteRepository,
        IQueuePublisher queuePublisher,
        Dominio.Interfaces.ILogger logger,
        IExecutionContext context)
        : base(logger, context)
    {
        _outboxReadRepository = outboxReadRepository;
        _outboxWriteRepository = outboxWriteRepository;
        _queuePublisher = queuePublisher;
        _context = context;
    }

    protected override async Task<State<MediaOutboxTransportOutputCommand>> ActionAsync(
        MediaOutboxTransportInputCommand command,
        CancellationToken cancellationToken = default)
    {
        var pending = _outboxReadRepository.GetPendingMediaRenderMessages(5);

        var claimed = 0;
        var processed = 0;
        var failed = 0;

        foreach (var outbox in pending)
        {
            if (outbox.id <= 0 || outbox.type != RenderRequestedType)
                continue;

            claimed++;
            _context.SetTenantId(outbox.tenantid);
            _context.SetUserId(outbox.userid);
            using var execution = _context.BeginOperationalExecution(
                new OperationalExecutionIdentity(outbox.rootoperationid, outbox.operationid,
                    outbox.executionid, outbox.causationid), "Memorias.RenderTransport");
            var identity = _context.OperationalIdentity;

            var message = new QueueMessage(outbox.type, outbox.payload)
            {
                MenssageId = outbox.messageid,
                CorrelationId = outbox.correlationid,
                RootOperationId = identity.RootOperationId,
                OperationId = identity.OperationId,
                ExecutionId = identity.ExecutionId,
                CausationId = identity.CausationId,
                Source = "Yeshua.Memorias"
            };

            var sent = await _queuePublisher.PublishCeleryAsync(
                "memorias-media-render",
                "media.tasks",
                "media.album.render",
                "app.tasks.render_album",
                message,
                cancellationToken);

            if (sent)
            {
                _outboxWriteRepository.UpdateStatus(outbox.id, 1);
                _outboxWriteRepository.UpdateSentAt(outbox.id, DateTime.UtcNow);
                processed++;
                continue;
            }

            _outboxWriteRepository.UpdateStatus(outbox.id, 2);
            _outboxWriteRepository.UpdateLastError(outbox.id, "Falha ao publicar tarefa Celery de renderizacao.");
            failed++;
        }

        return Success("OK", new MediaOutboxTransportOutputCommand
        {
            Claimed = claimed,
            Processed = processed,
            Failed = failed
        });
    }
}

public sealed record MediaOutboxTransportInputCommand : ICommand
{
}

public sealed record MediaOutboxTransportOutputCommand : ICommand, IWorkerCycleResult
{
    public int BatchLimit => 5;
    public int Claimed { get; init; }
    public int Processed { get; init; }
    public int Failed { get; init; }
}
