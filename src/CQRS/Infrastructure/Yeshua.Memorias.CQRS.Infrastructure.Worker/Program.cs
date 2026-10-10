using Command.Interfaces.Patterns.Queue;
using Migrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
DependencInjection.MapDependencInjection(builder);
WorkerInfrastructure.MapWorkerInfrastructure(builder);
Worker.Custon.CustonDependenceInjection.MapCustonDependenceInjection(builder);
WorkersBuilder.MapWorkersBuilder(builder);

var app = builder.Build();
var topology = DependencInjection.GetQueueTopology();

if (topology.Exchanges.Count > 0)
{
    var initializer = app.Services.GetRequiredService<IQueueTopologyInitializer>();
    await initializer.InitializeAsync(topology);
}

await app.RunAsync();