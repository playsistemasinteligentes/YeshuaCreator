using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Dominio.Migration;
using Input.Repository.IdentidadePublicadora;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Presenca.Editorial;
using Shered.DB.Connection;

namespace Presenca.Tests;

public sealed class ExistingDatabaseFactAttribute : FactAttribute
{
 public ExistingDatabaseFactAttribute()
 {
  if(string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("YESHUA_PRESENCA_HOMOLOGATION")))
   Skip="Existing Presenca database binding unavailable: no preflight or writes executed. Use scripts/presenca/homologate.py with the unified private file.";
 }
}

// Test infrastructure only. Never called by production API/Worker or the disposable fixtures.
public sealed class ExistingDatabaseBinding
{
 public string Read {get;set;}=""; public string Write {get;set;}="";
 public string[] Peers {get;set;}=[];
 public string Database {get;set;}=""; public string Server {get;set;}="";
 public string Marker {get;set;}=""; public int Tenant {get;set;} public int Author {get;set;} public int Approver {get;set;}
 public bool Exercise {get;set;}
 public bool Browser {get;set;}
 public void Validate()
 {
  if(!Database.Contains("presenca",StringComparison.OrdinalIgnoreCase)||string.IsNullOrWhiteSpace(Server)
    ||!System.Text.RegularExpressions.Regex.IsMatch(Marker,@"\APRESENCA_HOMOLOG_[A-Za-z0-9_-]{1,40}\z")
    ||Tenant<=0||Author<=0||Approver<=0||Author==Approver)throw new InvalidOperationException("PRESENCA_HOMOLOGATION_BINDING_INVALID");
  foreach(var text in new[]{Read,Write})
  {
   var c=new SqlConnectionStringBuilder(text);
   if(!string.Equals(c.InitialCatalog,Database,StringComparison.OrdinalIgnoreCase)||string.IsNullOrWhiteSpace(c.DataSource)
     ||!string.IsNullOrEmpty(c.AttachDBFilename))throw new InvalidOperationException("PRESENCA_HOMOLOGATION_DATABASE_MISMATCH");
  }
  // Conservatively refuse a database name used by any other configured app, even through a server alias.
  if(Peers.Any(p=>string.Equals(new SqlConnectionStringBuilder(p).InitialCatalog,Database,StringComparison.OrdinalIgnoreCase)))
   throw new InvalidOperationException("PRESENCA_HOMOLOGATION_SHARED_DATABASE");
 }
 public void ConfirmIdentity(string database,string server)
 {
  if(!string.Equals(database,Database,StringComparison.OrdinalIgnoreCase)||!string.Equals(server,Server,StringComparison.OrdinalIgnoreCase))
   throw new InvalidOperationException("PRESENCA_HOMOLOGATION_SERVER_IDENTITY_MISMATCH");
 }
}

public sealed class ExistingDatabaseHomologationTests
{
 internal static ExistingDatabaseBinding ExampleBinding()=>new(){Read="Server=sql;Database=PRESENCA;Integrated Security=true",Write="Server=sql;Database=PRESENCA;Integrated Security=true",Database="PRESENCA",Server="sql",Tenant=90,Author=91,Approver=92,Marker="PRESENCA_HOMOLOG_fixture"};
 [Theory]
 [InlineData("catalog")][InlineData("peer")][InlineData("actor")][InlineData("marker")][InlineData("server")]
 public void Existing_database_guard_refuses_ambiguous_or_shared_identity_before_connecting(string mismatch)
 {
  var p=ExampleBinding();
  switch(mismatch)
  {
   case "catalog":p.Write="Server=sql;Database=CLINICA;Integrated Security=true";break;
   case "peer":p.Peers=["Server=another-alias;Database=PRESENCA;Integrated Security=true"];break;
   case "actor":p.Approver=p.Author;break;
   case "marker":p.Marker="customer";break;
   case "server":p.Server="";break;
  }
  Assert.Throws<InvalidOperationException>(p.Validate);
 }
 [Fact] public void Existing_database_guard_requires_actual_read_and_write_server_identity()
 {
  var p=ExampleBinding();p.Validate();p.ConfirmIdentity("PRESENCA","sql");
  Assert.Throws<InvalidOperationException>(()=>p.ConfirmIdentity("CENTRAL","sql"));
  Assert.Throws<InvalidOperationException>(()=>p.ConfirmIdentity("PRESENCA","unexpected-instance"));
 }
 [ExistingDatabaseFact][Trait("Category","ExistingDatabase")]
 public async Task Preflight_then_optional_additive_api_sql_concurrency_and_simulated_channels()
 {
  var p=JsonSerializer.Deserialize<ExistingDatabaseBinding>(Environment.GetEnvironmentVariable("YESHUA_PRESENCA_HOMOLOGATION")!)!;
  p.Validate();
  UnitOfWork Work()=>new(new SqlFactory(EnumSqlConections.SqlServer,p.Write));
  // Both connections must resolve to the expected actual database/instance BEFORE any mutation.
  foreach(var text in new[]{p.Read,p.Write})
  {
   using var work=new UnitOfWork(new SqlFactory(EnumSqlConections.SqlServer,text));
   var identity=work.Query<IdentityRow>("SELECT DB_NAME() DatabaseName,CONVERT(nvarchar(128),SERVERPROPERTY('ServerName')) ServerName").Single();
   p.ConfirmIdentity(identity.DatabaseName,identity.ServerName);
   var modules=work.Query<string>("SELECT Id FROM yModule").ToArray();
   Assert.Contains("PRESENCA",modules);Assert.All(modules,m=>Assert.Contains(m,new[]{"ADM","PRESENCA"}));
   // Full metadata visibility is required: an invisible foreign table is not evidence of isolation.
   Assert.Equal(1,work.ExecuteScalar<int>("SELECT HAS_PERMS_BY_NAME(DB_NAME(),'DATABASE','VIEW DEFINITION')"));
   MigrationBase[] migrations=[new global::Migration.Dominio.Migration.S000001(),new global::Migration.Dominio.Migration.S000003(),new global::Migration.Dominio.Migration.S000004(),new global::Migration.Dominio.Migration.S000008(),new Yeshua.Studio.Presenca.M000001()];
   foreach(var m in migrations)m.Up();
   var allowed=migrations.SelectMany(m=>m.Entitys).Select(e=>e.EntityName).Append("MigrationVersion").ToHashSet(StringComparer.OrdinalIgnoreCase);
   var tables=work.Query<string>("SELECT name FROM sys.tables WHERE is_ms_shipped=0").ToHashSet(StringComparer.OrdinalIgnoreCase);
   Assert.All(tables,t=>Assert.Contains(t,allowed));
   Assert.All(migrations.Last().Entitys.Select(e=>e.EntityName).Concat(new[]{"yTenant","yUser","yModule","yInbox","yOutbox","ySaga","ySagaStep"}),t=>Assert.Contains(t,tables));
   foreach(var column in new[]{("OrigemPauta","Contrato"),("ConteudoVersao","OrigemRevisao"),("PublicacaoDestino","NaturezaFalha"),("PublicacaoDestino","RetryPossivel"),("ySagaStep","FailureRetryable"),("yOutbox","TransportData"),("yOutbox","ProcessingScope"),("yInbox","ProcessingScope"),("ySaga","ProcessingScope")})
    Assert.NotNull(work.ExecuteScalar<int?>("SELECT COL_LENGTH(@table,@column)",new{table=column.Item1,column=column.Item2}));
   Assert.Equal(0,work.ExecuteScalar<int>("SELECT COUNT(*) FROM sys.synonyms"));
   Assert.Equal(0,work.ExecuteScalar<int>("SELECT COUNT(*) FROM sys.triggers WHERE is_ms_shipped=0 AND is_disabled=0"));
   Assert.Equal(0,work.ExecuteScalar<int>("SELECT COUNT(*) FROM sys.security_policies WHERE is_enabled=1"));
   Assert.Equal(1,work.ExecuteScalar<int>("SELECT COUNT(*) FROM yTenant WHERE Id=@Tenant AND Nome=@Marker AND Deleted=0",p));
   foreach(var actor in new[]{(Id:p.Author,Name:p.Marker+"_autor"),(Id:p.Approver,Name:p.Marker+"_aprovador")})
    Assert.Equal(1,work.ExecuteScalar<int>("SELECT COUNT(*) FROM yUser WHERE Id=@Id AND TenantID=@tenant AND Nome=@Name AND Deleted=0",new{actor.Id,tenant=p.Tenant,actor.Name}));
  }
  void Checkpoint(string status,string runId="",string publisherId="",string processingScope="")
  {
   var path=Environment.GetEnvironmentVariable("YESHUA_PRESENCA_HOMOLOGATION_EVIDENCE");
   if(string.IsNullOrWhiteSpace(path))return;
   File.WriteAllText(path,JsonSerializer.Serialize(new{recordedAtUtc=DateTimeOffset.UtcNow,status,exercise=p.Exercise,browser=p.Browser,tenant=p.Tenant,runId,publisherId,processingScope,externalSends=false,databaseReset=false,recordsRetained=true}));
  }
  Checkpoint("preflight-passed-no-writes");
  if(!p.Exercise)return; // Default preflight is SELECT only. No schema/provision/reset fallback.
  var run=Guid.NewGuid().ToString("N");var scope="presenca-homolog-"+run;
  var publisher=RegrasEditoriais.Id(p.Marker,run);
  using(var work=Work())
  {
   work.BeginTran();
   try
   {
    foreach(var table in new[]{"yInbox","ySaga","yOutbox"})
     Assert.Equal(0,work.ExecuteScalar<int>("SELECT COUNT(*) FROM "+table+" WHERE ProcessingScope=@scope",new{scope}));
    work.Execute("INSERT INTO IdentidadePublicadora(Id,Nome,Ativa,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@publisher,@name,1,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@publisher,32))",new{publisher,name=p.Marker+"_"+run,tenant=p.Tenant,actor=p.Author});
    foreach(var actor in new[]{p.Author,p.Approver})
     work.Execute("INSERT INTO VinculoIdentidadePublicadora(Id,IdentidadeId,UsuarioId,Permissoes,Versao,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@id,@publisher,@actor,127,1,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@id,32))",new{id=RegrasEditoriais.Id(p.Tenant.ToString(System.Globalization.CultureInfo.InvariantCulture),publisher,actor.ToString(System.Globalization.CultureInfo.InvariantCulture)),publisher,actor,tenant=p.Tenant});
    work.Commit();
   }
   catch{work.Rollback();throw;}
  }
  Checkpoint("fixture-persisted",run,publisher,scope);
  // Only the two new grants/publisher above are direct fixture inserts. All business writes use actual API/repositories.
  var store=new ApiPrototypeTests.Store{Publisher=publisher};
  await using var app=new ApiPrototypeTests.Factory(store,p.Write,scope);using var client=app.CreateClient();
  client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer",ApiPrototypeTests.Token(p.Tenant,p.Author));
  async Task<ResultadoEditorial> Call(string op,DadosEditorial data,string record="",int version=0,string? key=null)
  {
   var response=await client.PostAsJsonAsync("/yapi/Presenca/Editorial"+op+"UseCase",new{IdentidadeId=publisher,RegistroId=record,Chave=key??Guid.NewGuid().ToString("N"),VersaoEsperada=version,Dados=JsonSerializer.Serialize(data,EditorialJson.Default.DadosEditorial)});
   Assert.Equal(HttpStatusCode.OK,response.StatusCode);using var json=JsonDocument.Parse(await response.Content.ReadAsStringAsync());
   return JsonSerializer.Deserialize(json.RootElement.GetProperty("resultado").GetString()!,EditorialJson.Default.ResultadoEditorial)!;
  }
  var channels=new List<string>();
  foreach(var platform in new[]{"GitHubDiscussions","Telegram"})
  {
   var channel=await Call("ConfigurarCanal",new(){Plataforma=platform,Destino="@homolog_"+run,Conexao=platform});channels.Add(channel.Id);
   store.Options.Canais[platform]=new(){TenantId=p.Tenant,IdentidadeId=publisher,Plataforma=platform,Destino="@homolog_"+run,Token="synthetic-token-no-external-send",RepositoryId="synthetic-repo",CategoryId="synthetic-category"};
  }
  var data=EditorialTests.Example();data.Manchete=p.Marker+" "+run;
  var replay=await Task.WhenAll(Enumerable.Range(0,8).Select(_=>Call("CriarPautaManual",data,key:run)));
  Assert.Single(replay.Select(r=>r.Id).Distinct());var draft=replay[0];
  using(var work=Work())
  {
   Assert.Equal(1,work.ExecuteScalar<int>("SELECT COUNT(*) FROM Pauta WHERE TenantID=@tenant AND IdentidadeId=@publisher",new{tenant=p.Tenant,publisher}));
   Assert.Equal(1,work.ExecuteScalar<int>("SELECT COUNT(*) FROM ReciboEntrada WHERE TenantID=@tenant AND IdentidadeId=@publisher AND Operacao='CriarPautaManual'",new{tenant=p.Tenant,publisher}));
  }
  await Call("SubmeterRevisao",new(),draft.Id,1);
  client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer",ApiPrototypeTests.Token(p.Tenant,p.Approver));
  await Call("AprovarVersao",new(){Publicavel=true,Canais=channels.ToArray()},draft.Id,1);
  client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer",ApiPrototypeTests.Token(p.Tenant,p.Author));
  await Call("SolicitarPublicacao",new(){Canais=channels.ToArray()},draft.Id,1);
  var before=await Call("ConsultarOperacao",new());Assert.Equal(2,before.SaudeFilas.Single(q=>q.Fila=="Distribuicao").Prontas);
  // Separate transactions/connections race the actual claim. Hold claims until both tasks finish: no external HTTP here.
  var claims=await Task.WhenAll(Enumerable.Range(0,3).Select(_=>Task.Run(()=>
  {
   using var work=Work();work.BeginTran();
   try{var item=new IdentidadePublicadoraWriteRepository(work).RetirarSaida(scope);work.Commit();return item;}
   catch{work.Rollback();throw;}
  })));
  var leased=claims.Where(c=>c!=null).Select(c=>c!).ToArray();Assert.Equal(2,leased.Length);Assert.Equal(2,leased.Select(c=>c.Id).Distinct().Count());
  // A different scope and a stale attempt cannot acknowledge these claims.
  using(var work=Work())
  {
   var repository=new IdentidadePublicadoraWriteRepository(work);var item=leased[0];
   work.BeginTran();
   try{Assert.Equal("PRESENCA_LEASE_LOST",Assert.Throws<EditorialException>(()=>repository.ConcluirSaida(item,scope+"-other","Publicada","",null)).Message);}
   finally{work.Rollback();}
   var attempt=item.RetryCount;item.RetryCount++;
   work.BeginTran();
   try{Assert.Equal("PRESENCA_LEASE_LOST",Assert.Throws<EditorialException>(()=>repository.ConcluirSaida(item,scope,"Publicada","",null)).Message);}
   finally{work.Rollback();item.RetryCount=attempt;}
  }
  // Release ONLY these newly owned claims via normal completion/retry policy. Never reset existing queue rows.
  foreach(var item in leased)
  {
   using var work=Work();work.BeginTran();
   try{new IdentidadePublicadoraWriteRepository(work).ConcluirSaida(item,scope,"FalhaRetentavel","PRESENCA_HOMOLOGATION_CLAIM_CHECK",null,TimeSpan.Zero);work.Commit();}
   catch{work.Rollback();throw;}
  }
  using(var worker=app.Services.CreateScope())
  {
   var cycle=await worker.ServiceProvider.GetRequiredService<Command.Receivers.UseCase.ProcessarPresencaHandler>().ExecuteAsync(new Command.UseCase.ProcessarPresencaInputCommand());
   Assert.Equal(1,cycle.Data!.Processed);Assert.Equal(1,cycle.Data.Failed);
  }
  var after=await Call("ConsultarOperacao",new());Assert.Single(after.Entregas,e=>e.Estado=="Publicada");Assert.Single(after.Entregas,e=>e.Estado=="ResultadoIncerto");
  Assert.Equal(1,after.SaudeFilas.Single(q=>q.Fila=="Distribuicao").ResultadosIncertos);Assert.Equal(2,store.HttpCalls.Count);
  if(p.Browser)
  {
   await BrowserApiJourney.Run(client,publisher,p.Marker+"_"+run,3,true);
   using var work=Work();
   Assert.Equal(2,work.ExecuteScalar<int>("SELECT COUNT(*) FROM Pauta WHERE TenantID=@tenant AND IdentidadeId=@publisher",new{tenant=p.Tenant,publisher}));
  }
  Checkpoint("api-sql-concurrency-channels-passed",run,publisher,scope);
  // No finally cleanup: receipts, audit, drafts, grants and simulated delivery records remain identified and inspectable.
 }
 public sealed class IdentityRow{public string DatabaseName{get;set;}="";public string ServerName{get;set;}="";}
}
