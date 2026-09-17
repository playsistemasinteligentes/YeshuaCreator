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

builder.Services.AddHostedService(sp =>
    new PollingWorker<Command.Patterns.SagaWorkerCommandHandler, Command.Patterns.InputCommand, Command.Patterns.OutputCommand>(
        sp,
        sp.GetRequiredService<ILogger<PollingWorker<Command.Patterns.SagaWorkerCommandHandler, Command.Patterns.InputCommand, Command.Patterns.OutputCommand>>>(),
        TimeSpan.FromSeconds(2)));

builder.Services.AddHostedService(sp =>
    new PollingWorker<Command.Patterns.SagaInboxWorkerCommandHandler, Command.Patterns.InputCommand, Command.Patterns.InboxOutputCommand>(
        sp,
        sp.GetRequiredService<ILogger<PollingWorker<Command.Patterns.SagaInboxWorkerCommandHandler, Command.Patterns.InputCommand, Command.Patterns.InboxOutputCommand>>>(),
        TimeSpan.FromSeconds(2)));

}
}
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWorker