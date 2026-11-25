using Aplication.Interfaces.Services;
using Dominio.Patterns.Saga;
using IRepository.Write;
using Presenca.Editorial;
using System.Text.Json;
namespace Command.Receivers;
public partial class RegistrarPautaDeOrigemHandler
{
 private readonly IIdentidadePublicadoraWriteRepository _repository;
 private readonly IExecutionContext _context;
 public RegistrarPautaDeOrigemHandler(IIdentidadePublicadoraWriteRepository repository,IExecutionContext context){_repository=repository;_context=context;}
 partial void CustomExecute(SagaBase saga,SagaStepBase step)
 {
  var input=JsonSerializer.Deserialize(step.Payload,IntegracaoJson.Default.EntradaSagaV1)!;
  try {var result=_repository.RegistrarOrigem(_context.TenantID,_context.UserId,input.Contrato,input.Json,_context.ProcessingScope);step.SetPayload(JsonSerializer.Serialize(result,EditorialJson.Default.ResultadoEditorial));}
  catch(EditorialException e){throw new SagaStepExecutionException(e.Message,false,stableCode:e.Message);}
 }
 partial void CustomApplyResponse(SagaBase saga,SagaStepBase step,string payload) { }
}
