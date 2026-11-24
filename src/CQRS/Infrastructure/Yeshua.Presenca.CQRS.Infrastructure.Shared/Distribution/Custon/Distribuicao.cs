using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Command.Patterns.OutBox;
using Presenca.Editorial;
namespace Presenca.Distribution;
public sealed class PresencaDeliveryFactory(PresencaOptions options,IHttpClientFactory clients,IRepository.Write.IIdentidadePublicadoraWriteRepository repository):IOutboxDeliveryFactory
{
 public string SelectProvider(OutboxDeliveryRequest request)=>request.Message.Type=="PublicacaoEducacionalAtualizada.v1"?"Academia":((EntregaPublica)request.Message.Payload).Plataforma;
 public IOutboxDeliveryStrategy GetType(string provider)=>provider switch {
  "Academia"=>new StatusCallbackStrategy(options,clients.CreateClient("Presenca.Modules")),
  "Portal"=>new PortalDeliveryStrategy(options,repository),
  "Telegram" or "GitHubDiscussions"=>new CanalHttpStrategy(provider,options,clients.CreateClient("Presenca.Distribution")),
  _=>throw new OutboxDeliveryException("PRESENCA_PLATFORM_INVALID","Destino inválido.",false)};
 public static CanalProfile Perfil(PresencaOptions options,int tenant,EntregaPublica e)
 {
  if(!options.Enabled||!options.Canais.TryGetValue(e.Conexao,out var p)||p.TenantId!=tenant||p.IdentidadeId!=e.IdentidadeId||p.Plataforma!=e.Plataforma||p.Destino!=e.Destino)
   throw new OutboxDeliveryException("PRESENCA_CHANNEL_NOT_CONFIGURED","Canal indisponível.",false);
  return p;
 }
 internal static ExternalExecutionResult Sucesso(OutboxDeliveryRequest request,ReciboDistribuicao receipt)=>ExternalExecutionResult.Create(request,"Publicada",JsonSerializer.SerializeToElement(receipt,IntegracaoJson.Default.ReciboDistribuicao));
}
public sealed class CanalHttpStrategy(string platform,PresencaOptions options,HttpClient client):IOutboxDeliveryStrategy
{
 public int TransportType=>2;
 public async Task<ExternalExecutionResult?> DeliverAsync(OutboxDeliveryRequest request,CancellationToken cancellationToken)
 {
  var e=(EntregaPublica)request.Message.Payload;var profile=PresencaDeliveryFactory.Perfil(options,request.TenantId,e);
  if(string.IsNullOrWhiteSpace(profile.Token))throw new OutboxDeliveryException("PRESENCA_CREDENTIAL_REQUIRED","Credencial indisponível.",false);
  using var message=new HttpRequestMessage(HttpMethod.Post,platform=="Telegram"?$"https://api.telegram.org/bot{Uri.EscapeDataString(profile.Token)}/sendMessage":"https://api.github.com/graphql");
  if(platform=="Telegram")
  {
   var text=e.Conteudo.Manchete+"\n\n"+e.Conteudo.Corpo;
   if(text.Length>4000)text=text[..4000];
   message.Content=new StringContent(JsonSerializer.Serialize(new TelegramInput(profile.Destino,text),DistributionJson.Default.TelegramInput),Encoding.UTF8,"application/json");
  }
  else
  {
   if(string.IsNullOrWhiteSpace(profile.RepositoryId)||string.IsNullOrWhiteSpace(profile.CategoryId))throw new OutboxDeliveryException("PRESENCA_DISCUSSION_TARGET_REQUIRED","Destino indisponível.",false);
   message.Headers.Authorization=new AuthenticationHeaderValue("Bearer",profile.Token);
   message.Headers.UserAgent.ParseAdd("Yeshua-Presenca/1.0");
   var input=new DiscussionRequest("mutation($input: CreateDiscussionInput!){createDiscussion(input:$input){discussion{id url}}}",new(new(profile.RepositoryId,profile.CategoryId,e.Conteudo.Manchete,e.Conteudo.Corpo+"\n\n<!-- yeshua:"+e.Id+" -->",e.Id)));
   message.Content=new StringContent(JsonSerializer.Serialize(input,DistributionJson.Default.DiscussionRequest),Encoding.UTF8,"application/json");
  }
  try
  {
   using var response=await client.SendAsync(message,HttpCompletionOption.ResponseHeadersRead,cancellationToken);
   // Only explicit rejection is safe to resend. A timeout/5xx/ambiguous 2xx can have committed.
   if(response.StatusCode==HttpStatusCode.TooManyRequests || response.StatusCode==HttpStatusCode.Forbidden&&response.Headers.RetryAfter!=null)
   {
    var delay=response.Headers.RetryAfter?.Delta;
    if(platform=="Telegram")
    {
     using var doc=JsonDocument.Parse(await response.Content.ReadAsStringAsync(cancellationToken));
     if(doc.RootElement.TryGetProperty("parameters",out var par)&&par.TryGetProperty("retry_after",out var seconds)&&seconds.TryGetInt32(out var n))delay=TimeSpan.FromSeconds(Math.Clamp(n,1,86400));
    }
    throw new OutboxDeliveryException("PRESENCA_RATE_LIMIT","Limite de envio.",true,delay??TimeSpan.FromMinutes(1));
   }
   if((int)response.StatusCode>=500)throw Incerto();
   if(!response.IsSuccessStatusCode)throw new OutboxDeliveryException("PRESENCA_PROVIDER_REJECTED","Provedor rejeitou o envio.",false);
   using var result=JsonDocument.Parse(await response.Content.ReadAsStringAsync(cancellationToken));
   if(platform=="Telegram")
   {
    if(!result.RootElement.TryGetProperty("ok",out var ok)||!ok.GetBoolean()||!result.RootElement.TryGetProperty("result",out var data)||!data.TryGetProperty("message_id",out var id))throw Incerto();
    var external=id.GetInt64().ToString(System.Globalization.CultureInfo.InvariantCulture);
    var url=profile.Destino.StartsWith('@')?$"https://t.me/{profile.Destino[1..]}/{external}":"";
    return PresencaDeliveryFactory.Sucesso(request,new(external,url));
   }
   else
   {
    if(!result.RootElement.TryGetProperty("data",out var data)||data.ValueKind!=JsonValueKind.Object||!data.TryGetProperty("createDiscussion",out var created)||created.ValueKind!=JsonValueKind.Object||!created.TryGetProperty("discussion",out var discussion)||discussion.ValueKind!=JsonValueKind.Object)throw Incerto();
    var id=discussion.GetProperty("id").GetString();var url=discussion.GetProperty("url").GetString();
    if(string.IsNullOrWhiteSpace(id)||!RegrasEditoriais.UrlSegura(url??""))throw Incerto();
    return PresencaDeliveryFactory.Sucesso(request,new(id,url!));
   }
  }
  catch(OutboxDeliveryException){throw;}
  catch(Exception ex) when(ex is HttpRequestException or OperationCanceledException or JsonException or InvalidOperationException or KeyNotFoundException){throw Incerto();}
 }
 private static OutboxDeliveryException Incerto()=>new("PRESENCA_RESULT_UNCERTAIN","Resultado exige reconciliação; não reenviar.",false);
}
public sealed record TelegramInput([property:JsonPropertyName("chat_id")]string ChatId,[property:JsonPropertyName("text")]string Text);
public sealed record DiscussionInput(string repositoryId,string categoryId,string title,string body,string clientMutationId);
public sealed record DiscussionVariables(DiscussionInput input);
public sealed record DiscussionRequest(string query,DiscussionVariables variables);
[JsonSerializable(typeof(TelegramInput))]
[JsonSerializable(typeof(DiscussionRequest))]
internal partial class DistributionJson:JsonSerializerContext;
