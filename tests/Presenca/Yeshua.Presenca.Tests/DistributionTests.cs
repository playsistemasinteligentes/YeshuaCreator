using System.Net;
using System.Text.Json;
using Command.Patterns.OutBox;
using Command.Patterns.Queue;
using Presenca.Editorial;
using Presenca.Distribution;
using Shared.ModuleTransport;
namespace Presenca.Tests;
public class DistributionTests
{
 internal static EntregaPublica Delivery(string platform,string id="delivery")
 {var c=RegrasEditoriais.Conteudo(EditorialTests.Example());return new(RegrasEditoriais.Id(id),RegrasEditoriais.Id("publisher"),RegrasEditoriais.Id(id+"pauta"),1,RegrasEditoriais.Id(id+"version"),RegrasEditoriais.Hash(JsonSerializer.Serialize(c,EditorialJson.Default.ConteudoPublico)),platform,"@canal","profile",c,DateTimeOffset.Parse("2026-11-24T10:00:00Z"));}
 internal static PresencaOptions Options(EntregaPublica e)=>new(){Enabled=true,Canais=new(){{"profile",new(){TenantId=1,IdentidadeId=e.IdentidadeId,Plataforma=e.Plataforma,Destino=e.Destino,Token="TOKEN-FIXTURE",RepositoryId="repo-node",CategoryId="category-node"}}}};
 internal static OutboxDeliveryRequest Request(EntregaPublica e)=>new(new QueueMessage("Presenca.Publicacao.v1",e){MenssageId=e.Id,ProcessingScope="tests"},"",2,1,"");
 [Theory][InlineData("Telegram","{\"ok\":true,\"result\":{\"message_id\":123}}","123")][InlineData("GitHubDiscussions","{\"data\":{\"createDiscussion\":{\"discussion\":{\"id\":\"D_123\",\"url\":\"https://github.com/example/repo/discussions/1\"}}}}","D_123")]
 public async Task Official_request_formats_return_provider_receipts(string platform,string response,string external)
 {
  var e=Delivery(platform);var body="";var requests=0;
  using var client=new HttpClient(new Handler(async m=>{requests++;body=await m.Content!.ReadAsStringAsync();return new(HttpStatusCode.OK){Content=new StringContent(response)};}));
  var strategy=new CanalHttpStrategy(platform,Options(e),client);
  var result=await strategy.DeliverAsync(Request(e),default);Assert.Equal(external,result!.result.Deserialize(IntegracaoJson.Default.ReciboDistribuicao)!.IdExterno);Assert.Equal(1,requests);
  Assert.DoesNotContain("TOKEN-FIXTURE",body);Assert.DoesNotContain("IdentidadeId",body);
  if(platform=="GitHubDiscussions"){Assert.Contains("clientMutationId",body);Assert.Contains(e.Id,body);Assert.Contains("createDiscussion",body);}else Assert.Contains("chat_id",body);
 }
 [Fact] public async Task Rate_limit_is_a_definitive_rejection_with_a_minimum_retry_delay()
 {
  var e=Delivery("Telegram");using var client=new HttpClient(new Handler(_=>Task.FromResult(new HttpResponseMessage(HttpStatusCode.TooManyRequests){Content=new StringContent("{\"parameters\":{\"retry_after\":123}}") } )));
  var error=await Assert.ThrowsAsync<OutboxDeliveryException>(()=>new CanalHttpStrategy("Telegram",Options(e),client).DeliverAsync(Request(e),default));Assert.True(error.Retryable);Assert.Equal(TimeSpan.FromSeconds(123),error.RetryAfter);Assert.True(ContratosEditoriais.Backoff(1,error.RetryAfter)>=error.RetryAfter);
 }
 [Theory][InlineData(500,"{}")] [InlineData(200,"not-json")][InlineData(200,"{}")]
 public async Task Ambiguous_outcomes_are_not_automatically_retried(int status,string body)
 {
  var e=Delivery("Telegram");var calls=0;using var client=new HttpClient(new Handler(_=>{calls++;return Task.FromResult(new HttpResponseMessage((HttpStatusCode)status){Content=new StringContent(body)});}));
  var error=await Assert.ThrowsAsync<OutboxDeliveryException>(()=>new CanalHttpStrategy("Telegram",Options(e),client).DeliverAsync(Request(e),default));Assert.False(error.Retryable);Assert.Equal("PRESENCA_RESULT_UNCERTAIN",error.Code);Assert.Equal(1,calls);
 }
 [Fact] public async Task Timeout_after_provider_acceptance_requires_reconciliation()
 {
  var e=Delivery("GitHubDiscussions");using var client=new HttpClient(new Handler(_=>throw new TaskCanceledException("fixture network uncertainty")));
  var error=await Assert.ThrowsAsync<OutboxDeliveryException>(()=>new CanalHttpStrategy(e.Plataforma,Options(e),client).DeliverAsync(Request(e),default));Assert.Equal("PRESENCA_RESULT_UNCERTAIN",error.Code);Assert.DoesNotContain("fixture",error.Message);
 }
 [Fact] public async Task Profiles_are_bound_to_tenant_publisher_and_destination_before_any_http()
 {
  var e=Delivery("Telegram");var options=Options(e);options.Canais["profile"].TenantId=2;var calls=0;using var client=new HttpClient(new Handler(_=>{calls++;throw new InvalidOperationException();}));
  await Assert.ThrowsAsync<OutboxDeliveryException>(()=>new CanalHttpStrategy("Telegram",options,client).DeliverAsync(Request(e),default));Assert.Equal(0,calls);
 }
 [Fact] public async Task Academia_status_uses_the_existing_signed_module_envelope_and_stable_message_id()
 {
  var options=new PresencaOptions{AcademiaBaseUrl="https://academia.example.org/"};
  var settings=new YeshuaModuleAuthenticationSettings("Presenca",new string('k',64),300,22);
  var captured="";
  var fake=new Handler(async m=>{
   captured=await m.Content!.ReadAsStringAsync();string Header(string key)=>m.Headers.GetValues(key).Single();
   var verified=new YeshuaModuleRequestAuthenticator(settings,TimeProvider.System).Authenticate("POST",m.RequestUri!.PathAndQuery,Header(YeshuaModuleAuthenticationHeaders.SourceModule),Header(YeshuaModuleAuthenticationHeaders.MessageId),Header(YeshuaModuleAuthenticationHeaders.Timestamp),Header(YeshuaModuleAuthenticationHeaders.Signature),captured);
   Assert.True(verified.Succeeded);Assert.Equal("/yapi/Academia/Inbox/YeshuaModuleEvent",m.RequestUri.AbsolutePath);return new(HttpStatusCode.Accepted);
  });
  using var client=new HttpClient(new YeshuaModuleAuthenticationHandler(settings,TimeProvider.System){InnerHandler=fake});
  var message=new QueueMessage("PublicacaoEducacionalAtualizada.v1",new StatusEducacionalV1("aula-1",2,"Publicada","https://public.example.org/noticias/1/","")){MenssageId="stable-status-id",CorrelationId="publicacao"};
  await new StatusCallbackStrategy(options,client).DeliverAsync(new(message,"",2,1,""),default);
  Assert.Contains("stable-status-id",captured);Assert.Contains("PublicacaoEducacionalAtualizada.v1",captured);Assert.DoesNotContain("Aluno",captured);
 }
 [Theory][InlineData("not-json")][InlineData("[]")][InlineData("{\"parameters\":{\"retry_after\":1}}")]
 public async Task Confirmed_rate_limit_remains_retryable_with_malformed_or_smaller_optional_body(string body)
 {
  var e=Delivery("Telegram");using var client=new HttpClient(new Handler(_=>
  {
   var response=new HttpResponseMessage(HttpStatusCode.TooManyRequests){Content=new StringContent(body)};
   response.Headers.RetryAfter=new System.Net.Http.Headers.RetryConditionHeaderValue(TimeSpan.FromSeconds(120));return Task.FromResult(response);
  }));
  var error=await Assert.ThrowsAsync<OutboxDeliveryException>(()=>new CanalHttpStrategy("Telegram",Options(e),client).DeliverAsync(Request(e),default));
  Assert.Equal("PRESENCA_RATE_LIMIT",error.Code);Assert.True(error.Retryable);Assert.Equal(TimeSpan.FromSeconds(120),error.RetryAfter);
 }
 [Fact] public async Task Callback_retry_preserves_the_educational_version_and_message_identity()
 {
  var bodies=new List<string>();var attempts=0;
  using var client=new HttpClient(new Handler(async m=>
  {
   bodies.Add(await m.Content!.ReadAsStringAsync());attempts++;
   return new(attempts==1?HttpStatusCode.ServiceUnavailable:HttpStatusCode.Accepted);
  }));
  var strategy=new StatusCallbackStrategy(new(){AcademiaBaseUrl="https://academia.example.org/"},client);
  var status=new StatusEducacionalV1("lesson-1",2,"Publicada","https://public.example.org/lesson/1/","");
  var message=new QueueMessage("PublicacaoEducacionalAtualizada.v1",status){MenssageId="status:"+RegrasEditoriais.Id("stable"),CorrelationId="lesson-1"};
  var request=new OutboxDeliveryRequest(message,"",2,1,"");
  var failed=await Assert.ThrowsAsync<OutboxDeliveryException>(()=>strategy.DeliverAsync(request,default));Assert.True(failed.Retryable);
  Assert.NotNull(await strategy.DeliverAsync(request,default));Assert.Equal(2,bodies.Count);Assert.Equal(bodies[0],bodies[1]);
  using var envelope=JsonDocument.Parse(bodies[1]);using var payload=JsonDocument.Parse(envelope.RootElement.GetProperty("Payload").GetString()!);
  Assert.Equal(2,payload.RootElement.GetProperty("Revisao").GetInt32());Assert.Equal(message.MenssageId,envelope.RootElement.GetProperty("MessageId").GetString());
 }
 [Theory][InlineData("ReprocessarStatusEducacional")][InlineData("ReprocessarEntrega")]
 public void Recovery_is_an_operator_permission_and_never_a_writer_privilege(string operation)
 {
  Assert.Equal(PermissaoEditorial.Operar,RegrasEditoriais.Permissao(operation));
  Assert.Throws<EditorialException>(()=>RegrasEditoriais.Autorizar(1,10,(int)PermissaoEditorial.Redigir,RegrasEditoriais.Permissao(operation)));
 }
 internal sealed class Handler(Func<HttpRequestMessage,Task<HttpResponseMessage>> action):HttpMessageHandler
 {protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,CancellationToken cancellationToken)=>action(request);}
}
