using Aplication.Interfaces.Services;
using Command.UseCase;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Presenca.Editorial;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using System.Text.Json;
namespace Command.Receivers.UseCase;
public partial class ExecutarEditorialHandler
{
 private readonly IIdentidadePublicadoraWriteRepository _write;
 private readonly IIdentidadePublicadoraReadRepository _read;
 private readonly IUnitOfWork _work;
 public ExecutarEditorialHandler(ILogger logger,IExecutionContext context,IIdentidadePublicadoraWriteRepository write,IIdentidadePublicadoraReadRepository read,IUnitOfWork work):this(logger,context)
 {_write=write;_read=read;_work=work;}
 protected partial Task<State<ExecutarEditorialOutputCommand>> CustomActionHookAsync(State<ExecutarEditorialOutputCommand> state,ExecutarEditorialInputCommand comand,CancellationToken cancellationToken)
 {
  var transaction=false;
  try
  {
   cancellationToken.ThrowIfCancellationRequested();
   var pedido=new PedidoEditorial(comand.Operacao,comand.IdentidadeId??"",comand.RegistroId??"",comand.Chave??"",comand.VersaoEsperada,comand.Dados??"");
   _work.BeginTran();transaction=true;
   ResultadoEditorial result;
   if(pedido.Operacao is "ConsultarIdentidades" or "ConsultarRedacao" or "ConsultarOperacao")result=_read.Consultar(_executionContext.TenantID,_executionContext.UserId,pedido);
   else
   {
    result=_write.Executar(_executionContext.TenantID,_executionContext.UserId,pedido);

   }
   cancellationToken.ThrowIfCancellationRequested();_work.Commit();transaction=false;
   return Task.FromResult(Success("OK",new ExecutarEditorialOutputCommand {Resultado=JsonSerializer.Serialize(result,EditorialJson.Default.ResultadoEditorial)}));
  }
  catch(EditorialException e)
  {
   if(transaction)_work.Rollback();
   return Task.FromResult(new State<ExecutarEditorialOutputCommand>(e.Status,e.Message,new(),false));
  }
  catch {if(transaction)_work.Rollback();throw;}
 }
}
