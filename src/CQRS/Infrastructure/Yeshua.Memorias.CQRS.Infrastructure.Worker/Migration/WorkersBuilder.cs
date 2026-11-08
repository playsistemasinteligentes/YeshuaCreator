// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWorker
// </yeshua>

using Shered.Services;
using Command.Interfaces.Patterns.Queue;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Worker.Custon;
namespace Migrations
{
public static class WorkersBuilder
{
public static void MapWorkersBuilder(WebApplicationBuilder builder)
{

builder.Services.AddTransient<Command.Patterns.SagaWorkerCommandHandler>();
builder.Services.AddTransient<Command.Patterns.SagaInboxWorkerCommandHandler>();
builder.Services.AddScoped<RepositoryInterfaces.Patterns.Worker.IWorkerQueueHealthProbe<
    Command.Patterns.SagaWorkerCommandHandler,
    Command.Patterns.InputCommand>, SagaQueueHealthProbe>();

builder.Services.AddHostedService(sp =>
    new PollingWorker<Command.Patterns.SagaWorkerCommandHandler, Command.Patterns.InputCommand, Command.Patterns.OutputCommand>(
        sp,
        sp.GetRequiredService<ILogger<PollingWorker<Command.Patterns.SagaWorkerCommandHandler, Command.Patterns.InputCommand, Command.Patterns.OutputCommand>>>(),
        TimeSpan.FromMilliseconds(500)));

builder.Services.AddHostedService(sp =>
    new PollingWorker<Command.Patterns.SagaInboxWorkerCommandHandler, Command.Patterns.InputCommand, Command.Patterns.InboxOutputCommand>(
        sp,
        sp.GetRequiredService<ILogger<PollingWorker<Command.Patterns.SagaInboxWorkerCommandHandler, Command.Patterns.InputCommand, Command.Patterns.InboxOutputCommand>>>(),
        TimeSpan.FromMilliseconds(500)));

}
}

internal sealed class SagaQueueHealthProbe
    : RepositoryInterfaces.Patterns.Worker.IWorkerQueueHealthProbe<
        Command.Patterns.SagaWorkerCommandHandler,
        Command.Patterns.InputCommand>
{
    private readonly IRepository.Read.IySagaReadRepository _repository;
    private readonly RepositoryInterfaces.Patterns.Worker.WorkerQueueItemHealthThresholds _thresholds;

    public SagaQueueHealthProbe(
        IRepository.Read.IySagaReadRepository repository,
        Microsoft.Extensions.Configuration.IConfiguration configuration)
    {
        _repository = repository;
        _thresholds = new RepositoryInterfaces.Patterns.Worker.WorkerQueueItemHealthThresholds(
            ExcessiveWaitSeconds: Math.Clamp(
                configuration.GetValue<long?>("YeshuaQueueHealth:Item:ExcessiveWaitSeconds") ?? 900,
                60,
                86_400),
            ProcessingStuckSeconds: Math.Clamp(
                configuration.GetValue<long?>("YeshuaQueueHealth:Item:ProcessingStuckSeconds") ?? 120,
                60,
                3_600),
            RecurrentExecutionCount: Math.Clamp(
                configuration.GetValue<int?>("YeshuaQueueHealth:Item:RecurrentExecutionCount") ?? 3,
                2,
                100),
            RepeatedFailureCount: Math.Clamp(
                configuration.GetValue<int?>("YeshuaQueueHealth:Item:RepeatedFailureCount") ?? 2,
                1,
                100));
    }

    public string QueueName => "Memorias.Saga";

    public RepositoryInterfaces.Patterns.Worker.WorkerQueueHealthSnapshot Capture() =>
        _repository.GetRunnableSagaHealth(_thresholds);

    public IReadOnlyList<RepositoryInterfaces.Patterns.Worker.WorkerQueueSickItem> CaptureSickItems(int limit) =>
        _repository.GetSickSagaItems(_thresholds, limit);
}
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWorker