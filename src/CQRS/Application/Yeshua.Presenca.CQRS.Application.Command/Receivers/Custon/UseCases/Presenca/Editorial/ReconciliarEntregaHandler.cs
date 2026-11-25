using Aplication.Interfaces.Services;
using Command.UseCase;
using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Receivers.UseCase;
public partial class ReconciliarEntregaHandler
{
 private readonly ExecutarEditorialHandler _executor;
 public ReconciliarEntregaHandler(ILogger logger,IExecutionContext context,ExecutarEditorialHandler executor):this(logger,context) {_executor=executor;}
 protected partial async Task<State<ReconciliarEntregaOutputCommand>> CustomActionHookAsync(State<ReconciliarEntregaOutputCommand> state,ReconciliarEntregaInputCommand comand,CancellationToken cancellationToken)
 {
  var result=await _executor.ExecuteAsync(new ExecutarEditorialInputCommand {Operacao="ReconciliarEntrega",IdentidadeId=comand.IdentidadeId,RegistroId=comand.RegistroId,Chave=comand.Chave,VersaoEsperada=comand.VersaoEsperada,Dados=comand.Dados},cancellationToken);
  return new State<ReconciliarEntregaOutputCommand>(result.StatusCode,result.Message,new(){Resultado=result.Data?.Resultado??""},false);
 }
}
