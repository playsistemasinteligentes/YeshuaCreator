using Aplication.Interfaces.Services;
using Command.UseCase;
using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Receivers.UseCase;
public partial class ConsultarAuditoriaHandler
{
 private readonly ExecutarEditorialHandler _executor;
 public ConsultarAuditoriaHandler(ILogger logger,IExecutionContext context,ExecutarEditorialHandler executor):this(logger,context) {_executor=executor;}
 protected partial async Task<State<ConsultarAuditoriaOutputCommand>> CustomActionHookAsync(State<ConsultarAuditoriaOutputCommand> state,ConsultarAuditoriaInputCommand comand,CancellationToken cancellationToken)
 {
  var result=await _executor.ExecuteAsync(new ExecutarEditorialInputCommand {Operacao="ConsultarAuditoria",IdentidadeId=comand.IdentidadeId,RegistroId=comand.RegistroId,Chave=comand.Chave,VersaoEsperada=comand.VersaoEsperada,Dados=comand.Dados},cancellationToken);
  return new State<ConsultarAuditoriaOutputCommand>(result.StatusCode,result.Message,new(){Resultado=result.Data?.Resultado??""},false);
 }
}
