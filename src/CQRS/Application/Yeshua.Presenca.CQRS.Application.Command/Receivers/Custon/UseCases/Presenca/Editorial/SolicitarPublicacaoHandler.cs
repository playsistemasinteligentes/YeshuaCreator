using Aplication.Interfaces.Services;
using Command.UseCase;
using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Receivers.UseCase;
public partial class SolicitarPublicacaoHandler
{
 private readonly ExecutarEditorialHandler _executor;
 public SolicitarPublicacaoHandler(ILogger logger,IExecutionContext context,ExecutarEditorialHandler executor):this(logger,context) {_executor=executor;}
 protected partial async Task<State<SolicitarPublicacaoOutputCommand>> CustomActionHookAsync(State<SolicitarPublicacaoOutputCommand> state,SolicitarPublicacaoInputCommand comand,CancellationToken cancellationToken)
 {
  var result=await _executor.ExecuteAsync(new ExecutarEditorialInputCommand {Operacao="SolicitarPublicacao",IdentidadeId=comand.IdentidadeId,RegistroId=comand.RegistroId,Chave=comand.Chave,VersaoEsperada=comand.VersaoEsperada,Dados=comand.Dados},cancellationToken);
  return new State<SolicitarPublicacaoOutputCommand>(result.StatusCode,result.Message,new(){Resultado=result.Data?.Resultado??""},false);
 }
}
