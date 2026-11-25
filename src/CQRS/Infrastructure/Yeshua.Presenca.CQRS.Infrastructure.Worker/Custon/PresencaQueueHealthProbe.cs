using Command.Receivers.UseCase;
using Command.UseCase;
using IRepository.Read;
using RepositoryInterfaces.Patterns.Worker;
namespace Worker.Custon;
public sealed class PresencaQueueHealthProbe(IIdentidadePublicadoraReadRepository repository):IWorkerQueueHealthProbe<ProcessarPresencaHandler,ProcessarPresencaInputCommand>
{
 public string QueueName=>"Presenca.Distribution";
 public WorkerQueueHealthSnapshot Capture()=>repository.SaudeDistribuicao();
 public IReadOnlyList<WorkerQueueSickItem> CaptureSickItems(int limit)=>repository.ItensDoentesDistribuicao(limit);
}
