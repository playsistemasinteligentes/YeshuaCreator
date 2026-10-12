using Aplication.Interfaces.Services;
using Command.Patterns.Command;
using Command.Patterns.OutBox;
using Command.Receivers;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Worker;

namespace Worker.Custon;

public sealed class MediaRenderResultInboxWorker
    : ReciverBase<RenderAlbumResultMessage, MediaRenderResultOutputCommand>
{
    private readonly OutboxService _outboxService;

    public MediaRenderResultInboxWorker(
        OutboxService outboxService,
        Dominio.Interfaces.ILogger logger,
        IExecutionContext context)
        : base(logger, context)
    {
        _outboxService = outboxService;
    }

    protected override Task<State<MediaRenderResultOutputCommand>> ActionAsync(
        RenderAlbumResultMessage command,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(command.CorrelationId))
            return Task.FromResult(ValidationError("Resultado de renderizacao sem correlationId.", new MediaRenderResultOutputCommand { Failed = 1 }));

        _outboxService.AddInboxEvent(
            command.Status,
            command,
            "PublicacaoAlbum",
            string.Empty,
            string.IsNullOrWhiteSpace(command.MessageId) ? Guid.NewGuid().ToString("D") : command.MessageId,
            command.CorrelationId);

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
