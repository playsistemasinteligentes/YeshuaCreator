namespace Worker.Custon;
public static class CustonDependenceInjection
{
 public static void MapCustonDependenceInjection(WebApplicationBuilder builder)
 {
  Presenca.Distribution.PresencaRegistration.AddPresenca(builder.Services,builder.Configuration);
  if(!builder.Configuration.GetValue<bool>("Presenca:Enabled"))return;
  builder.Services.AddScoped<RepositoryInterfaces.Patterns.Worker.IWorkerQueueHealthProbe<Command.Receivers.UseCase.ProcessarPresencaHandler,Command.UseCase.ProcessarPresencaInputCommand>,PresencaQueueHealthProbe>();
  builder.Services.AddHostedService(sp=>new PollingWorker<Command.Receivers.UseCase.ProcessarPresencaHandler,Command.UseCase.ProcessarPresencaInputCommand,Command.UseCase.ProcessarPresencaOutputCommand>(sp,sp.GetRequiredService<ILogger<PollingWorker<Command.Receivers.UseCase.ProcessarPresencaHandler,Command.UseCase.ProcessarPresencaInputCommand,Command.UseCase.ProcessarPresencaOutputCommand>>>(),TimeSpan.FromSeconds(1)));
 }
}
