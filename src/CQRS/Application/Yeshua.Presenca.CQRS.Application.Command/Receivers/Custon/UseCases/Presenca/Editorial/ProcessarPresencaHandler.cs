using Aplication.Interfaces.Services;
using Command.Patterns.OutBox;
using Command.Patterns.Queue;
using Command.UseCase;
using Dominio.Interfaces;
using Dominio.Operational;
using Dominio.Saga;
using IRepository.Write;
using Presenca.Editorial;
using Presenca.Distribution;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using System.Text.Json;
namespace Command.Receivers.UseCase;
public partial class ProcessarPresencaHandler
{
 private readonly IIdentidadePublicadoraWriteRepository _repository;
 private readonly IySagaWriteRepository _sagas;
 private readonly IUnitOfWork _work;
 private readonly IOutboxDeliveryFactory _delivery;
 private readonly PresencaOptions _options;
 public ProcessarPresencaHandler(ILogger logger,IExecutionContext context,IIdentidadePublicadoraWriteRepository repository,IySagaWriteRepository sagas,IUnitOfWork work,IOutboxDeliveryFactory delivery,PresencaOptions options):this(logger,context)
 { _repository=repository;_sagas=sagas;_work=work;_delivery=delivery;_options=options; }
 protected partial async Task<State<ProcessarPresencaOutputCommand>> CustomActionHookAsync(State<ProcessarPresencaOutputCommand> state,ProcessarPresencaInputCommand comand,CancellationToken cancellationToken)
 {
  var result=new ProcessarPresencaOutputCommand();if(!_options.Enabled)return Success("Disabled",result);
  var scope=_executionContext.ProcessingScope;
  if(string.IsNullOrWhiteSpace(scope))throw new EditorialException("PRESENCA_SCOPE_REQUIRED",503);
  // An explicit bridge starts only the DSL-declared saga; no matching by CorrelationId.
  _work.BeginTran();
  try
  {
   foreach(var item in _repository.Entradas(scope))
   {
    result.Claimed++;
    try
    {
     ContratosEditoriais.Validar(item.Type,item.Payload);
     _executionContext.SetTenantId(item.TenantID);_executionContext.SetUserId(item.UserId);
     var saga=new ReceberOrigemEditorialSaga();
     saga.SetCorrelationId((Guid.TryParse(item.CorrelationId,out var causal)?causal:new Guid(Convert.FromHexString(RegrasEditoriais.Id(scope,item.TenantID.ToString(),item.MessageId)[..32]))).ToString());
     saga.Start(item.EntityId,"OrigemEditorial");
     saga.SetOperationalIdentity(item.RootOperationId,item.OperationId,item.ExecutionId,item.CausationId);
     saga.GetCurrent().SetPayload(JsonSerializer.Serialize(new EntradaSagaV1(item.Type,item.Payload),IntegracaoJson.Default.EntradaSagaV1));
     _sagas.Save(saga);_repository.ConfirmarEntrada(item.Id,scope,saga.Id);result.Processed++;
    }
    catch(EditorialException e){_repository.RejeitarEntrada(item.Id,scope,e.Message);result.Failed++;}
   }
   _work.Commit();
  }
  catch{_work.Rollback();throw;}
  for(var i=0;i<5&&!cancellationToken.IsCancellationRequested;i++)
  {
   TrabalhoEditorial? item;
   _work.BeginTran();try{item=_repository.RetirarSaida(scope);_work.Commit();}catch{_work.Rollback();throw;}
   if(item==null)break;
   result.Claimed++;
   _executionContext.SetTenantId(item.TenantID);_executionContext.SetUserId(item.UserId);
   using var record=OutboxRecordScope.Begin(_logger,_executionContext,item.EntityId,item.TenantID,item.UserId,new OperationalExecutionIdentity(item.RootOperationId,item.OperationId,item.ExecutionId,item.CausationId));
   _work.BeginTran();try{_repository.PersistirExecucao(item,scope);_work.Commit();}catch{_work.Rollback();throw;}
   var transaction=false;var platform="";
   try
   {
    object payload;
    if(item.Type=="PublicacaoEducacionalAtualizada.v1")payload=JsonSerializer.Deserialize(item.Payload,IntegracaoJson.Default.StatusEducacionalV1)!;
    else {var e=JsonSerializer.Deserialize(item.Payload,IntegracaoJson.Default.EntregaPublica)!;payload=e;platform=e.Plataforma;}
    if(platform=="Portal"){_work.BeginTran();transaction=true;}
    var message=new QueueMessage(item.Type,payload){MenssageId=item.MessageId,CorrelationId=item.EntityId,ProcessingScope=scope,RootOperationId=item.RootOperationId,OperationId=item.OperationId,ExecutionId=item.ExecutionId,CausationId=item.CausationId};
    var request=new OutboxDeliveryRequest(message,"",2,item.TenantID,"Presenca.Entrega.v1");
    var receipt=await _delivery.GetType(_delivery.SelectProvider(request)).DeliverAsync(request,cancellationToken)??throw new EditorialException("PRESENCA_RECEIPT_REQUIRED");
    var value=receipt.result.Deserialize(IntegracaoJson.Default.ReciboDistribuicao)!;
    if(!transaction){_work.BeginTran();transaction=true;}
    _repository.ConcluirSaida(item,scope,"Publicada","",value);_work.Commit();transaction=false;result.Processed++;
   }
   catch(Exception e)
   {
    if(transaction)_work.Rollback();
    var delivery=e as OutboxDeliveryException;
    var uncertain=delivery?.Code=="PRESENCA_RESULT_UNCERTAIN" || delivery==null&&platform is "Telegram" or "GitHubDiscussions";
    var status=uncertain?"ResultadoIncerto":delivery?.Retryable==true?"FalhaRetentavel":"FalhaFinal";
    _work.BeginTran();try{_repository.ConcluirSaida(item,scope,status,delivery?.Code??(e as EditorialException)?.Message??"PRESENCA_DELIVERY_FAILED",null,ContratosEditoriais.Backoff(item.RetryCount-item.ManualRetryBase,delivery?.RetryAfter),uncertain?"Unknown":e is EditorialException?"Business":"Technical");_work.Commit();}catch{_work.Rollback();throw;}
    result.Failed++;
   }
  }
  return Success("OK",result);
 }
}
