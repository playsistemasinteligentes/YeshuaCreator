namespace Command.UseCase;
public partial record ProcessarPresencaOutputCommand:RepositoryInterfaces.Patterns.Worker.IWorkerCycleResult
{ public int BatchLimit=>10; }
