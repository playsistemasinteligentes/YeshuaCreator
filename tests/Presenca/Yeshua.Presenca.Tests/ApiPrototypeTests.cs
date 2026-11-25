using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Command.Patterns.OutBox;
using Command.Receivers.UseCase;
using Command.UseCase;
using IRepository.Read;
using IRepository.Write;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Moq;
using Presenca.Distribution;
using Presenca.Editorial;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shared.ModuleTransport;
namespace Presenca.Tests;
// Actual API host/authentication/endpoints/receivers/worker/strategies; ONLY storage and HTTP targets are simulated.
public sealed class ApiPrototypeTests
{
 private const string Key="private-test-only-api-jwt-signing-key-000000000000000000000000";
 [BrowserJourneyFact]
 public async Task Browser_reads_real_api_health_after_simulated_channel_partial_failure()
 {
  var store=new Store();await using var app=new Factory(store);using var client=app.CreateClient();
  client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer",Token(1));
  var response=await client.PostAsJsonAsync("/yapi/Presenca/EditorialSolicitarPublicacaoUseCase",new{IdentidadeId=store.Publisher,RegistroId=RegrasEditoriais.Id("pauta"),Chave="browser-publication",VersaoEsperada=1,Dados="{}"});
  Assert.Equal(HttpStatusCode.OK,response.StatusCode);
  using(var scope=app.Services.CreateScope())await scope.ServiceProvider.GetRequiredService<ProcessarPresencaHandler>().ExecuteAsync(new ProcessarPresencaInputCommand());
  await BrowserApiJourney.Run(client,store.Publisher,"PRESENCA_HOMOLOG_memory",1,false);
  Assert.Equal(2,store.HttpCalls.Count);
 }
 [Fact] public async Task Real_api_and_worker_preserve_partial_failure_with_simulated_storage_and_channels()
 {
  var store=new Store();await using var app=new Factory(store);using var client=app.CreateClient();
  var input=new {IdentidadeId=store.Publisher,RegistroId=RegrasEditoriais.Id("pauta"),Chave="publication-1",VersaoEsperada=1,Dados="{}"};
  const string publish="/yapi/Presenca/EditorialSolicitarPublicacaoUseCase",health="/yapi/Presenca/EditorialConsultarOperacaoUseCase";
  Assert.Equal(HttpStatusCode.Unauthorized,(await client.PostAsJsonAsync(publish,input)).StatusCode);
  client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer",Token(2));
  Assert.Equal(HttpStatusCode.Forbidden,(await client.PostAsJsonAsync(publish,input)).StatusCode);
  client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer",Token(1));
  var accepted=await client.PostAsJsonAsync(publish,input);Assert.Equal(HttpStatusCode.OK,accepted.StatusCode);
  Assert.Equal(HttpStatusCode.OK,(await client.PostAsJsonAsync(publish,input)).StatusCode);Assert.Equal(2,store.Pending.Count);
  // The processor is internal: normal clients cannot invoke it through a parallel HTTP route.
  Assert.Equal(HttpStatusCode.NotFound,(await client.PostAsJsonAsync("/yapi/Presenca/EditorialProcessarPresencaUseCase",new{})).StatusCode);
  using(var scope=app.Services.CreateScope())
  {
   var result=await scope.ServiceProvider.GetRequiredService<ProcessarPresencaHandler>().ExecuteAsync(new ProcessarPresencaInputCommand());
   Assert.Equal(200,result.StatusCode);Assert.Equal(1,result.Data!.Processed);Assert.Equal(1,result.Data.Failed);
  }
  Assert.Equal(2,store.HttpCalls.Count);Assert.Equal("api.github.com",store.HttpCalls[0]);Assert.Equal("api.telegram.org",store.HttpCalls[1]);
  var response=await client.PostAsJsonAsync(health,input);Assert.Equal(HttpStatusCode.OK,response.StatusCode);
  using var dto=JsonDocument.Parse(await response.Content.ReadAsStringAsync());
  var state=JsonSerializer.Deserialize(dto.RootElement.GetProperty("resultado").GetString()!,EditorialJson.Default.ResultadoEditorial)!;
  Assert.Single(state.Entregas,e=>e.Estado=="Publicada");Assert.Single(state.Entregas,e=>e.Estado=="ResultadoIncerto");
  Assert.Equal(1,state.SaudeFilas.Single().ResultadosIncertos);Assert.Empty(store.Pending);
  // A second worker cycle makes no blind retry of the uncertain external POST.
  using(var scope=app.Services.CreateScope())await scope.ServiceProvider.GetRequiredService<ProcessarPresencaHandler>().ExecuteAsync(new ProcessarPresencaInputCommand());
  Assert.Equal(2,store.HttpCalls.Count);
  var recovery=new {IdentidadeId=store.Publisher,RegistroId=RegrasEditoriais.Id("callback"),Chave="recover-callback-1",VersaoEsperada=5,Dados="{\"Motivo\":\"Academia simulada disponivel\"}"};
  const string recover="/yapi/Presenca/EditorialReprocessarStatusEducacionalUseCase";
  Assert.Equal(HttpStatusCode.OK,(await client.PostAsJsonAsync(recover,recovery)).StatusCode);
  Assert.Equal(HttpStatusCode.OK,(await client.PostAsJsonAsync(recover,recovery)).StatusCode);Assert.Single(store.Pending);
  using(var scope=app.Services.CreateScope())
  {
   var result=await scope.ServiceProvider.GetRequiredService<ProcessarPresencaHandler>().ExecuteAsync(new ProcessarPresencaInputCommand());
   Assert.Equal(1,result.Data!.Processed);Assert.Equal(0,result.Data.Failed);
  }
  Assert.Single(store.CallbackBodies);using var callback=JsonDocument.Parse(store.CallbackBodies[0]);
  Assert.Equal("status:"+RegrasEditoriais.Id("callback"),callback.RootElement.GetProperty("MessageId").GetString());
  using var originalVersion=JsonDocument.Parse(callback.RootElement.GetProperty("Payload").GetString()!);
  Assert.Equal(2,originalVersion.RootElement.GetProperty("Revisao").GetInt32());Assert.True(store.CallbackSignatureVerified);
 }
 [DisposableSqlFact][Trait("Category","SqlIntegration")]
 public async Task Real_api_sql_and_worker_use_only_a_new_disposable_database_and_simulated_channels()
 {
  var settings=new Microsoft.Data.SqlClient.SqlConnectionStringBuilder(Environment.GetEnvironmentVariable("YESHUA_TEST_SQL")){InitialCatalog="master"};
  var password=Environment.GetEnvironmentVariable("YESHUA_TEST_SQL_PASSWORD");if(!string.IsNullOrEmpty(password))settings.Password=password;
  var database="YESHUA_PRESENCA_TEST_"+Guid.NewGuid().ToString("N");
  await using var admin=new Microsoft.Data.SqlClient.SqlConnection(settings.ConnectionString);await admin.OpenAsync();
  await new Microsoft.Data.SqlClient.SqlCommand($"CREATE DATABASE [{database}]",admin).ExecuteNonQueryAsync();
  var connection=new Microsoft.Data.SqlClient.SqlConnectionStringBuilder(settings.ConnectionString){InitialCatalog=database}.ConnectionString;
  var store=new Store();
  try
  {
   using(var work=new Shered.DB.Connection.UnitOfWork(new Shered.DB.Connection.SqlFactory(Shered.DB.Connection.EnumSqlConections.SqlServer,connection)))
   {
    work.Execute("CREATE TABLE yTenant(Id int PRIMARY KEY,UserId int,Deleted bit); CREATE TABLE yUser(Id int PRIMARY KEY,TenantID int,Deleted bit); INSERT INTO yTenant VALUES(1,999,0); INSERT INTO yUser VALUES(10,1,0),(20,1,0);");
    foreach(var query in EditorialSqlTests.DisposableSchema())work.Execute(query);
    work.Execute("INSERT INTO IdentidadePublicadora(Id,Nome,Ativa,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@id,'Explicit API test publisher',1,1,10,0,SYSUTCDATETIME(),LEFT(@id,32))",new{id=store.Publisher});
    foreach(var actor in new[]{10,20})work.Execute("INSERT INTO VinculoIdentidadePublicadora(Id,IdentidadeId,UsuarioId,Permissoes,Versao,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@id,@publisher,@actor,127,1,1,10,0,SYSUTCDATETIME(),LEFT(@id,32))",new{id=RegrasEditoriais.Id("1",store.Publisher,actor.ToString()),publisher=store.Publisher,actor});
   }
   await using var app=new Factory(store,connection);using var client=app.CreateClient();
   client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer",Token(1));
   async Task<ResultadoEditorial> Call(string operation,DadosEditorial data,string record="",int version=0)
   {
    var response=await client.PostAsJsonAsync("/yapi/Presenca/Editorial"+operation+"UseCase",new{IdentidadeId=store.Publisher,RegistroId=record,Chave=Guid.NewGuid().ToString("N"),VersaoEsperada=version,Dados=JsonSerializer.Serialize(data,EditorialJson.Default.DadosEditorial)});
    Assert.Equal(HttpStatusCode.OK,response.StatusCode);using var json=JsonDocument.Parse(await response.Content.ReadAsStringAsync());return JsonSerializer.Deserialize(json.RootElement.GetProperty("resultado").GetString()!,EditorialJson.Default.ResultadoEditorial)!;
   }
   var channels=new List<string>();
   foreach(var platform in new[]{"GitHubDiscussions","Telegram"})
   {
    var channel=await Call("ConfigurarCanal",new(){Plataforma=platform,Destino="@canal",Conexao=platform});channels.Add(channel.Id);
    store.Options.Canais[platform]=new(){TenantId=1,IdentidadeId=store.Publisher,Plataforma=platform,Destino="@canal",Token="test-only-token",RepositoryId="repo-node",CategoryId="category-node"};
   }
   var draft=await Call("CriarPautaManual",EditorialTests.Example());
   await Call("SubmeterRevisao",new(),draft.Id,1);
   client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer",Token(1,20));
   await Call("AprovarVersao",new(){Publicavel=true,Canais=channels.ToArray()},draft.Id,1);
   client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer",Token(1));
   await Call("SolicitarPublicacao",new(){Canais=channels.ToArray()},draft.Id,1);
   var before=await Call("ConsultarOperacao",new());Assert.Equal(2,before.SaudeFilas.Single(q=>q.Fila=="Distribuicao").Prontas);
   using(var scope=app.Services.CreateScope())
   {
    var cycle=await scope.ServiceProvider.GetRequiredService<ProcessarPresencaHandler>().ExecuteAsync(new ProcessarPresencaInputCommand());Assert.Equal(1,cycle.Data!.Processed);Assert.Equal(1,cycle.Data.Failed);
   }
   var after=await Call("ConsultarOperacao",new());Assert.Equal(3,after.SaudeFilas.Count);
   Assert.Single(after.Entregas,e=>e.Estado=="Publicada");Assert.Single(after.Entregas,e=>e.Estado=="ResultadoIncerto");
   Assert.Equal(1,after.SaudeFilas.Single(q=>q.Fila=="Distribuicao").ResultadosIncertos);Assert.Equal(2,store.HttpCalls.Count);
  }
  finally
  {
   if(!database.StartsWith("YESHUA_PRESENCA_TEST_",StringComparison.Ordinal))throw new InvalidOperationException("Disposable database boundary invalid.");
   Microsoft.Data.SqlClient.SqlConnection.ClearAllPools();
   await new Microsoft.Data.SqlClient.SqlCommand($"ALTER DATABASE [{database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [{database}];",admin).ExecuteNonQueryAsync();
  }
 }
 internal static string Token(int tenant,int actor=10)=>new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(claims:[new Claim(ClaimTypes.NameIdentifier,actor.ToString()),new Claim("tenantId",tenant.ToString()),new Claim("tokenOrigin","Application"),new Claim("application","Presenca")],expires:DateTime.UtcNow.AddMinutes(10),signingCredentials:new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key)),SecurityAlgorithms.HmacSha256)));
 internal sealed class Factory(Store store,string? sqlConnection=null,string processingScope="prototype-tests"):WebApplicationFactory<global::Program>
 {
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
   builder.UseEnvironment("Testing");
   builder.ConfigureAppConfiguration((_,configuration)=>configuration.AddInMemoryCollection(new Dictionary<string,string?>{{"JwtSettings:SecretKey",Key},{"YeshuaProcessing:Scope",processingScope},{"Presenca:Enabled","true"},{"OperationalLogging:Level","Off"}}));
   builder.ConfigureServices(services=>
   {
    // Minimal host captured this settings instance before WAF applied its late configuration.
    var captured=(JwtSettings)services.Last(d=>d.ServiceType==typeof(JwtSettings)).ImplementationInstance!;
    captured.SecretKey=Key;

    var writer=new Mock<IIdentidadePublicadoraWriteRepository>(MockBehavior.Strict);
    writer.Setup(r=>r.Executar(It.IsAny<int>(),It.IsAny<int>(),It.IsAny<PedidoEditorial>(),It.IsAny<string>())).Returns((int t,int a,PedidoEditorial p,string s)=>store.Publish(t,a,p,s));
    writer.Setup(r=>r.Entradas(It.IsAny<string>())).Returns(Array.Empty<TrabalhoEditorial>());
    writer.Setup(r=>r.RetirarSaida(It.IsAny<string>())).Returns((string s)=>store.Pending.TryDequeue(out var item)?item:null);
    writer.Setup(r=>r.PersistirExecucao(It.IsAny<TrabalhoEditorial>(),It.IsAny<string>()));
    writer.Setup(r=>r.ConcluirSaida(It.IsAny<TrabalhoEditorial>(),It.IsAny<string>(),It.IsAny<string>(),It.IsAny<string>(),It.IsAny<ReciboDistribuicao?>(),It.IsAny<TimeSpan?>(),It.IsAny<string>())).Callback((TrabalhoEditorial item,string s,string status,string code,ReciboDistribuicao? receipt,TimeSpan? delay,string nature)=>store.States[item.Id]=status);
    var reader=new Mock<IIdentidadePublicadoraReadRepository>(MockBehavior.Strict);
    reader.Setup(r=>r.Consultar(It.IsAny<int>(),It.IsAny<int>(),It.IsAny<PedidoEditorial>())).Returns((int t,int a,PedidoEditorial p)=>store.Read(t,p));
    var work=new Mock<IUnitOfWork>(MockBehavior.Strict);work.Setup(w=>w.BeginTran());work.Setup(w=>w.Commit());work.Setup(w=>w.Rollback());work.Setup(w=>w.Dispose());
    services.RemoveAll<IUnitOfWork>();
    if(sqlConnection is null)
    {
     services.RemoveAll<IIdentidadePublicadoraWriteRepository>();services.AddSingleton(writer.Object);
     services.RemoveAll<IIdentidadePublicadoraReadRepository>();services.AddSingleton(reader.Object);
     services.AddScoped(_=>work.Object);
     services.RemoveAll<IySagaWriteRepository>();services.AddSingleton(new Mock<IySagaWriteRepository>(MockBehavior.Strict).Object);
    }
    else services.AddScoped<IUnitOfWork>(_=>new Shered.DB.Connection.UnitOfWork(new Shered.DB.Connection.SqlFactory(Shered.DB.Connection.EnumSqlConections.SqlServer,sqlConnection)));
    services.RemoveAll<IHttpClientFactory>();services.AddSingleton<IHttpClientFactory>(store);
    services.RemoveAll<PresencaOptions>();services.AddSingleton(store.Options);
   });
  }
 }
 internal sealed class Store:IHttpClientFactory
 {
  public string Publisher {get;init;}=RegrasEditoriais.Id("publisher");
  public Queue<TrabalhoEditorial> Pending {get;}=new();public Dictionary<int,string> States {get;}=[];public List<string> HttpCalls {get;}=[];public List<string> CallbackBodies {get;}=[];public bool CallbackSignatureVerified {get;private set;}
  public PresencaOptions Options {get;}=new(){Enabled=true,AcademiaBaseUrl="https://academia.example.org/"};private bool queued,callbackQueued;
  private static readonly YeshuaModuleAuthenticationSettings ModuleSettings=new("Presenca",new string('k',64),300,22);
  public ResultadoEditorial Publish(int tenant,int actor,PedidoEditorial p,string scope)
  {
   if(tenant!=1||actor!=10||p.IdentidadeId!=Publisher)throw new EditorialException("PRESENCA_FORBIDDEN",403);
   Assert.Equal("prototype-tests",scope);
   if(p.Operacao=="ReprocessarStatusEducacional")
   {
    Assert.Equal(RegrasEditoriais.Id("callback"),p.RegistroId);RegrasEditoriais.Concorrencia(5,p.VersaoEsperada);
    if(!callbackQueued)
    {
     Pending.Enqueue(new(){Id=3,TenantID=1,UserId=10,EntityId=RegrasEditoriais.Id("aula"),MessageId="status:"+p.RegistroId,Type="PublicacaoEducacionalAtualizada.v1",Payload=JsonSerializer.Serialize(new StatusEducacionalV1("aula-1",2,"Publicada","https://public.example.org/aula/1/",""),IntegracaoJson.Default.StatusEducacionalV1),RetryCount=6,ManualRetryBase=5,ProcessingAt=DateTime.UtcNow});callbackQueued=true;
    }
    return new(){Id=p.RegistroId,Estado="Pendente"};
   }
   Assert.Equal("SolicitarPublicacao",p.Operacao);
   if(!queued)
   {
    foreach(var platform in new[]{"GitHubDiscussions","Telegram"})
    {
     var delivery=DistributionTests.Delivery(platform,platform) with {Conexao=platform};
     Options.Canais[platform]=new(){TenantId=1,IdentidadeId=Publisher,Plataforma=platform,Destino=delivery.Destino,Token="test-only-token",RepositoryId="repo-node",CategoryId="category-node"};
     var id=Pending.Count+1;Pending.Enqueue(new(){Id=id,TenantID=1,UserId=10,EntityId=delivery.Id,MessageId="presenca:"+delivery.Id,Type="Presenca.Publicacao.v1",Payload=JsonSerializer.Serialize(delivery,IntegracaoJson.Default.EntregaPublica),RetryCount=1,ProcessingAt=DateTime.UtcNow});States[id]="Pendente";
    }
    queued=true;
   }
   return new(){Id=p.RegistroId,Estado="Pendente",Versao=1};
  }
  public ResultadoEditorial Read(int tenant,PedidoEditorial p)
  {
   if(tenant==1&&p.Operacao=="ConsultarIdentidades")return new(){Identidades=[new(){Id=Publisher,Nome="PRESENCA_HOMOLOG_memory"}]};
   if(tenant!=1||p.IdentidadeId!=Publisher)throw new EditorialException("PRESENCA_FORBIDDEN",403);
   if(p.Operacao=="ConsultarRedacao")return new();
   return new(){Entregas=States.Select(s=>new EntregaEditorial{Id=s.Key.ToString(),Estado=s.Value}).ToList(),SaudeConsultadaEmUtc=DateTimeOffset.UtcNow,SaudeFilas=[new(){Fila="Distribuicao",Concluidas=States.Values.Count(s=>s=="Publicada"),ResultadosIncertos=States.Values.Count(s=>s=="ResultadoIncerto")}]};
  }
  public HttpClient CreateClient(string name)
  {
   var handler=new DistributionTests.Handler(async request=>
   {
    HttpCalls.Add(request.RequestUri!.Host);
    if(request.RequestUri.Host=="academia.example.org")
    {
     var body=await request.Content!.ReadAsStringAsync();CallbackBodies.Add(body);
     string Header(string key)=>request.Headers.GetValues(key).Single();
     var verified=new YeshuaModuleRequestAuthenticator(ModuleSettings,TimeProvider.System).Authenticate("POST",request.RequestUri.PathAndQuery,Header(YeshuaModuleAuthenticationHeaders.SourceModule),Header(YeshuaModuleAuthenticationHeaders.MessageId),Header(YeshuaModuleAuthenticationHeaders.Timestamp),Header(YeshuaModuleAuthenticationHeaders.Signature),body);
     CallbackSignatureVerified=verified.Succeeded;Assert.True(verified.Succeeded);return new HttpResponseMessage(HttpStatusCode.Accepted);
    }
    return request.RequestUri.Host switch {"api.github.com"=>new HttpResponseMessage(HttpStatusCode.InternalServerError){Content=new StringContent("{}")},"api.telegram.org"=>new HttpResponseMessage(HttpStatusCode.OK){Content=new StringContent("{\"ok\":true,\"result\":{\"message_id\":123}}")},_=>throw new InvalidOperationException("External destination not simulated")};
   });
   return new HttpClient(name=="Presenca.Modules"?new YeshuaModuleAuthenticationHandler(ModuleSettings,TimeProvider.System){InnerHandler=handler}:handler);
  }
 }
}
