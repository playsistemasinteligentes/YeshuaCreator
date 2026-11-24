using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Command.Patterns.OutBox;
using Presenca.Editorial;
using Shared.ModuleTransport;
namespace Presenca.Distribution;
public sealed class StatusCallbackStrategy(PresencaOptions options,HttpClient client):IOutboxDeliveryStrategy
{
 public int TransportType=>2;
 public async Task<ExternalExecutionResult?> DeliverAsync(OutboxDeliveryRequest request,CancellationToken token)
 {
  if(!Uri.TryCreate(options.AcademiaBaseUrl,UriKind.Absolute,out var origin)||origin.Scheme is not ("http" or "https")||origin.UserInfo.Length>0)throw new OutboxDeliveryException("PRESENCA_ACADEMIA_NOT_CONFIGURED","Retorno à Academia indisponível.",true,TimeSpan.FromMinutes(5));
  var message=request.Message;
  var envelope=new ModuleStatusEnvelope(request.TenantId,message.MenssageId!,"PublicacaoEducacionalAtualizada.v1","PublicacaoEducacional",message.CorrelationId??"",message.CorrelationId??"",JsonSerializer.Serialize((StatusEducacionalV1)message.Payload,IntegracaoJson.Default.StatusEducacionalV1),"Presenca","YeshuaApi",message.RootOperationId,message.OperationId,message.ExecutionId,message.CausationId);
  using var http=new HttpRequestMessage(HttpMethod.Post,new Uri(origin,"/yapi/Academia/Inbox/YeshuaModuleEvent")){Content=new StringContent(JsonSerializer.Serialize(envelope,CallbackJson.Default.ModuleStatusEnvelope),Encoding.UTF8,"application/json")};
  http.Headers.TryAddWithoutValidation(YeshuaModuleAuthenticationHeaders.MessageId,message.MenssageId);
  try
  {
   using var result=await client.SendAsync(http,token);
   if(!result.IsSuccessStatusCode)throw new OutboxDeliveryException("PRESENCA_CALLBACK_REJECTED","Retorno não confirmado.",(int)result.StatusCode>=500||(int)result.StatusCode is 408 or 429,result.Headers.RetryAfter?.Delta);
   return PresencaDeliveryFactory.Sucesso(request,new(message.MenssageId!,""));
  }
  catch(HttpRequestException){throw new OutboxDeliveryException("PRESENCA_CALLBACK_UNAVAILABLE","Retorno indisponível.",true);}
  catch(OperationCanceledException){throw new OutboxDeliveryException("PRESENCA_CALLBACK_UNAVAILABLE","Retorno indisponível.",true);}
 }
}
public sealed record ModuleStatusEnvelope(int TenantId,string MessageId,string Type,string EntityType,string EntityId,string CorrelationId,string Payload,string Source,string Transport,string? RootOperationId,string? OperationId,string? ExecutionId,string? CausationId);
[JsonSerializable(typeof(ModuleStatusEnvelope))]
internal partial class CallbackJson:JsonSerializerContext;
