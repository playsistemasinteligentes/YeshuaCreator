using Command.Interfaces.Patterns.Queue;
using Migrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
DependencInjection.MapDependencInjection(builder);
WorkerInfrastructure.MapWorkerInfrastructure(builder);
Worker.Custon.CustonDependenceInjection.MapCustonDependenceInjection(builder);
if(builder.Configuration.GetValue<bool>("Presenca:Enabled"))WorkersBuilder.MapWorkersBuilder(builder);

var app = builder.Build();
if(args.Contains("--bootstrap-presenca",StringComparer.Ordinal))
{
 using var scope=app.Services.CreateScope();
 var context=scope.ServiceProvider.GetRequiredService<Aplication.Interfaces.Services.IExecutionContext>();
 context.SetTenantId(builder.Configuration.GetValue<int>("Presenca:Bootstrap:TenantId"));
 context.SetUserId(builder.Configuration.GetValue<int>("Presenca:Bootstrap:UserId"));
 var input=new Command.UseCase.ExecutarEditorialInputCommand{Operacao="ProvisionarInicial",IdentidadeId=builder.Configuration["Presenca:Bootstrap:IdentidadeId"]??"",Dados=System.Text.Json.JsonSerializer.Serialize(new Presenca.Editorial.DadosEditorial{Nome=builder.Configuration["Presenca:Bootstrap:Nome"]??""},Presenca.Editorial.EditorialJson.Default.DadosEditorial)};
 var result=await scope.ServiceProvider.GetRequiredService<Command.Receivers.UseCase.ExecutarEditorialHandler>().ExecuteAsync(input);
 if(result.StatusCode>=400)throw new InvalidOperationException(result.Message);
 Console.WriteLine("Identidade e vínculo inicial provisionados explicitamente.");return;
}
var topology = DependencInjection.GetQueueTopology();

if (topology.Exchanges.Count > 0)
{
    var initializer = app.Services.GetRequiredService<IQueueTopologyInitializer>();
    await initializer.InitializeAsync(topology);
}

await app.RunAsync();