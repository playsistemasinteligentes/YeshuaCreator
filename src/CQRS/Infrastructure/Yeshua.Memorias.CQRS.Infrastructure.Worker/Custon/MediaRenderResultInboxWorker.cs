using Aplication.Interfaces.Services;
using Command.Patterns.Command;
using Command.Patterns.OutBox;
using Command.Receivers;
using Dominio.Operational;
using IRepository.Read;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Worker;

namespace Worker.Custon;

public sealed class MediaRenderResultInboxWorker
    : ReciverBase<RenderAlbumResultMessage, MediaRenderResultOutputCommand>
{
    private readonly OutboxService _outboxService;
    private readonly IySagaStepReadRepository _steps;
    private readonly IySagaReadRepository _sagas;
    private readonly IExecutionContext _context;

    public MediaRenderResultInboxWorker(
        OutboxService outboxService,
        IySagaStepReadRepository steps,
        IySagaReadRepository sagas,
        Dominio.Interfaces.ILogger logger,
        IExecutionContext context)
        : base(logger, context)
    {
        _outboxService = outboxService;
        _steps = steps;
        _sagas = sagas;
        _context = context;
    }

    protected override Task<State<MediaRenderResultOutputCommand>> ActionAsync(
        RenderAlbumResultMessage command,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(command.CorrelationId))
            return Task.FromResult(ValidationError("Resultado de renderizacao sem correlationId.", new MediaRenderResultOutputCommand { Failed = 1 }));

        var step = _steps.FirstByCorrelationId(command.CorrelationId, TakeOffTenantID: true);
        var saga = step is null ? null : _sagas.FirstById(step.sagaid, TakeOffTenantID: true);
        if (step is null || step.stepkey != "RenderizarVideoAlbum" || saga is null
            || saga.type != "PublicarAlbumYouTubeSaga" || saga.tenantid <= 0 || saga.userid <= 0
            || saga.processingscope != _context.ProcessingScope)
        {
            return Task.FromResult(ValidationError("Resultado sem saga de renderizacao no escopo atual.",
                new MediaRenderResultOutputCommand { Failed = 1 }));
        }

        _context.SetTenantId(saga.tenantid);
        _context.SetUserId(saga.userid);
        using var execution = _context.BeginOperationalExecution(
            new OperationalExecutionIdentity(step.rootoperationid, step.operationid,
                step.executionid, step.causationid), "Memorias.RenderResult");

        _outboxService.AddInboxEvent(
            command.Status,
            command,
            "PublicacaoAlbum",
            saga.entityid,
            string.IsNullOrWhiteSpace(command.MessageId) ? Guid.NewGuid().ToString("D") : command.MessageId,
            command.CorrelationId,
            saga.id,
            step.id);

        return Task.FromResult(Success("OK", new MediaRenderResultOutputCommand
        {
            Claimed = 1,
            Processed = 1
        }));
    }
}

public sealed record MediaRenderResultOutputCommand : ICommand, IWorkerCycleResult
{
    public int BatchLimit => 1;
    public int Claimed { get; init; }
    public int Processed { get; init; }
    public int Failed { get; init; }
}
