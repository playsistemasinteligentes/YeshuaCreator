using System.Globalization;
using System.Text.Json;
using Dominio.Migration;
using Dominio.Schemas;
using Input.Repository.IdentidadePublicadora;
using Microsoft.Data.SqlClient;
using Presenca.Editorial;
using Shered.DB.Connection;
using Yeshua.Studio.Presenca;
namespace Presenca.Tests;

public sealed class DisposableSqlFactAttribute : FactAttribute
{
 public DisposableSqlFactAttribute()
 {if(string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("YESHUA_TEST_SQL")))Skip="YESHUA_TEST_SQL not configured: disposable SQL integration was NOT executed.";}
}
public class EditorialSqlTests
{
 [DisposableSqlFact]
 [Trait("Category","SqlIntegration")]
 public async Task Durable_receipts_authorization_versions_concurrency_and_rollback_use_a_disposable_database()
 {
  var settings=new SqlConnectionStringBuilder(Environment.GetEnvironmentVariable("YESHUA_TEST_SQL")){InitialCatalog="master"};
  var password=Environment.GetEnvironmentVariable("YESHUA_TEST_SQL_PASSWORD");if(!string.IsNullOrEmpty(password))settings.Password=password;
  var database="YESHUA_PRESENCA_TEST_"+Guid.NewGuid().ToString("N");
  await using var admin=new SqlConnection(settings.ConnectionString);await admin.OpenAsync();
  await new SqlCommand($"CREATE DATABASE [{database}]",admin).ExecuteNonQueryAsync();
  var connection=new SqlConnectionStringBuilder(settings.ConnectionString){InitialCatalog=database}.ConnectionString;
  UnitOfWork Work()=>new(new SqlFactory(EnumSqlConections.SqlServer,connection));
  var publisher=RegrasEditoriais.Id("explicit-test-publisher");
  var other=RegrasEditoriais.Id("other-explicit-publisher");
  PedidoEditorial Pedido(string operation,string key,DadosEditorial data,string record="",int version=0)=>new(operation,publisher,record,key,version,JsonSerializer.Serialize(data,EditorialJson.Default.DadosEditorial));
  ResultadoEditorial Run(int tenant,int actor,PedidoEditorial request)
  {
   using var work=Work();work.BeginTran();
   try{var result=new IdentidadePublicadoraWriteRepository(work).Executar(tenant,actor,request);work.Commit();return result;}
   catch{work.Rollback();throw;}
  }
  try
  {
   using(var work=Work())
   {
    work.Execute("CREATE TABLE yTenant(Id int PRIMARY KEY,UserId int,Deleted bit); CREATE TABLE yUser(Id int PRIMARY KEY,TenantID int,Deleted bit); INSERT INTO yTenant VALUES(1,999,0),(2,999,0); INSERT INTO yUser VALUES(10,1,0),(20,1,0),(30,1,0),(40,2,0);");
    var standard=new global::Migration.Dominio.Migration.S000001();standard.Up();
    var migration=new M000001();migration.Up();MigrationBuilder.ValidateInternalEntities([migration]);MigrationBuilder.ApplyStandardFields([standard,migration]);
    var schema=new SqlServerSchema(null!,"Presenca");
    foreach(var entity in migration.Entitys)work.Execute(schema.CreateTable(entity).Query);
    foreach(var identity in new[]{publisher,other})
     work.Execute("INSERT INTO IdentidadePublicadora(Id,Nome,Ativa,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@identity,'Explicit test publisher',1,1,10,0,SYSUTCDATETIME(),LEFT(@identity,32))",new {identity});
    foreach(var actor in new[]{10,20})
    {
     var id=RegrasEditoriais.Id("1",publisher,actor.ToString(CultureInfo.InvariantCulture));
     work.Execute("INSERT INTO VinculoIdentidadePublicadora(Id,IdentidadeId,UsuarioId,Permissoes,Versao,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@id,@publisher,@actor,127,1,1,10,0,SYSUTCDATETIME(),LEFT(@id,32))",new {id,publisher,actor});
    }
   }
   var data=EditorialTests.Example();var create=Pedido("CriarPautaManual","manual-1",data);
   var results=await Task.WhenAll(Enumerable.Range(0,12).Select(_=>Task.Run(()=>Run(1,10,create))));
   Assert.Single(results.Select(r=>r.Id).Distinct());var pauta=results[0].Id;
   using(var work=Work())
   {
    Assert.Equal(1,work.ExecuteScalar<int>("SELECT COUNT(*) FROM Pauta"));
    Assert.Equal(1,work.ExecuteScalar<int>("SELECT COUNT(*) FROM ConteudoVersao"));
    Assert.Equal(1,work.ExecuteScalar<int>("SELECT COUNT(*) FROM ReciboEntrada"));
    Assert.Equal(1,work.ExecuteScalar<int>("SELECT COUNT(*) FROM AuditoriaEditorial"));
   }
   Assert.Equal(403,Assert.Throws<EditorialException>(()=>Run(1,20,create)).Status);
   Assert.Equal(403,Assert.Throws<EditorialException>(()=>Run(2,40,create)).Status);
   Assert.Equal(403,Assert.Throws<EditorialException>(()=>Run(1,10,create with {IdentidadeId=other})).Status);
   var changed=EditorialTests.Example();changed.Manchete="Another input";
   Assert.Equal(409,Assert.Throws<EditorialException>(()=>Run(1,10,Pedido("CriarPautaManual","manual-1",changed))).Status);
   using(var work=Work())
   {
    work.BeginTran();new IdentidadePublicadoraWriteRepository(work).Executar(1,10,Pedido("CriarPautaManual","rollback",data));work.Rollback();
    Assert.Equal(1,work.ExecuteScalar<int>("SELECT COUNT(*) FROM Pauta"));
   }
   var channel=Run(1,10,Pedido("ConfigurarCanal","portal",new(){Plataforma="Portal",Destino="portal-test",Conexao="explicit-test-profile"}));
   Run(1,10,Pedido("SubmeterRevisao","review",new(),pauta,1));
   var approval=new DadosEditorial{Publicavel=true,Canais=[channel.Id]};
   Assert.Equal(409,Assert.Throws<EditorialException>(()=>Run(1,10,Pedido("AprovarVersao","self",approval,pauta,1))).Status);
   Run(1,20,Pedido("AprovarVersao","approve",approval,pauta,1));
   Run(1,10,Pedido("SolicitarPublicacao","publish",new(){Canais=[channel.Id]},pauta,1));
   Run(1,10,Pedido("SolicitarPublicacao","publish-again",new(){Canais=[channel.Id]},pauta,1));
   using(var work=Work())Assert.Equal(1,work.ExecuteScalar<int>("SELECT COUNT(*) FROM PublicacaoDestino"));
   Run(1,10,Pedido("SalvarRascunho","edit",changed,pauta,1));
   Assert.Equal(409,Assert.Throws<EditorialException>(()=>Run(1,10,Pedido("SalvarRascunho","stale",data,pauta,1))).Status);
   Assert.Equal(409,Assert.Throws<EditorialException>(()=>Run(1,10,Pedido("SolicitarPublicacao","unapproved",new(){Canais=[channel.Id]},pauta,2))).Status);
   Run(1,10,Pedido("DefinirVinculo","revoke",new(){UsuarioId=20,Permissoes=0},version:1));
   Assert.Equal(403,Assert.Throws<EditorialException>(()=>Run(1,20,Pedido("AprovarVersao","approve",approval,pauta,1))).Status);
  }
  finally
  {
   if(!database.StartsWith("YESHUA_PRESENCA_TEST_",StringComparison.Ordinal))throw new InvalidOperationException("Disposable database boundary invalid.");
   SqlConnection.ClearAllPools();
   await new SqlCommand($"ALTER DATABASE [{database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [{database}];",admin).ExecuteNonQueryAsync();
  }
 }
}
