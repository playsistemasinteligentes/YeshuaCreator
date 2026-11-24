using System.Text.Json;
using Presenca.Editorial;
namespace Input.Repository.IdentidadePublicadora;
public partial class IdentidadePublicadoraWriteRepository
{
 private readonly Aplication.Interfaces.Services.IExecutionContext? _context;
 public IdentidadePublicadoraWriteRepository(RepositoryInterfaces.Patterns.UnitOfWork.IUnitOfWork work,Aplication.Interfaces.Services.IExecutionContext context):this(work){_context=context;}

 private static void Escopo(string scope){if(string.IsNullOrWhiteSpace(scope)||scope.Length>100)throw new EditorialException("PRESENCA_SCOPE_REQUIRED",503);}
 private void EnfileirarPublicacao(int tenant,int actor,string identidade,VersaoEditorial version,string channel,string scope,string agendada)
 {
  Escopo(scope);
  DateTime? next=null;
  if(!string.IsNullOrEmpty(agendada))
  {
   if(!DateTimeOffset.TryParse(agendada,System.Globalization.CultureInfo.InvariantCulture,System.Globalization.DateTimeStyles.None,out var schedule)||schedule<=DateTimeOffset.UtcNow||schedule>DateTimeOffset.UtcNow.AddDays(30))throw new EditorialException("PRESENCA_SCHEDULE_INVALID");
   next=schedule.UtcDateTime;
  }
  var c=_UnitOfWork.Query<CanalRow>("SELECT Plataforma,Destino,Conexao FROM Canal WHERE Id=@channel AND TenantID=@tenant AND IdentidadeId=@identidade AND Deleted=0",new {channel,tenant,identidade}).Single();
  var id=RegrasEditoriais.Id(tenant.ToString(System.Globalization.CultureInfo.InvariantCulture),identidade,version.Id,channel);
  var dto=new EntregaPublica(id,identidade,version.PautaId,version.Numero,version.Id,version.Hash,c.Plataforma,c.Destino,c.Conexao,JsonSerializer.Deserialize(version.Snapshot,EditorialJson.Default.ConteudoPublico)!,DateTimeOffset.UtcNow);
  Saida(tenant,actor,"presenca:"+id,"Presenca.Publicacao.v1",id,JsonSerializer.Serialize(dto,IntegracaoJson.Default.EntregaPublica),scope,next);
 }
 private void Saida(int tenant,int actor,string message,string type,string entity,string payload,string scope,DateTime? next=null)
 {
  Escopo(scope);
  if(_UnitOfWork.ExecuteScalar<int>("SELECT COUNT(*) FROM yOutbox WITH(UPDLOCK,HOLDLOCK) WHERE MessageId=@message AND TenantID=@tenant AND ProcessingScope<>@scope",new {message,tenant,scope})!=0)throw new EditorialException("PRESENCA_PROCESSING_SCOPE_CONFLICT",409);
  Dominio.Operational.OperationalExecutionIdentity identity=default;
  _context?.TryGetOperationalIdentity(out identity);
  _UnitOfWork.Execute(@"IF NOT EXISTS(SELECT 1 FROM yOutbox WITH(UPDLOCK,HOLDLOCK) WHERE MessageId=@message AND TenantID=@tenant AND ProcessingScope=@scope)
   INSERT INTO yOutbox(MessageId,Type,EntityId,EntityType,Payload,TransportType,Status,CreatedAt,RetryCount,NextAttemptAt,RootOperationId,OperationId,ExecutionId,CausationId,ProcessingScope,TenantID,UserId,Deleted,Changed,OperationalEntityId)
   VALUES(@message,@type,@entity,'Presenca',@payload,2,0,SYSUTCDATETIME(),0,@next,@RootOperationId,@OperationId,@ExecutionId,@CausationId,@scope,@tenant,@actor,0,SYSUTCDATETIME(),REPLACE(CONVERT(varchar(36),NEWID()),'-',''))",new {tenant,actor,message,type,entity,payload,scope,next,identity.RootOperationId,identity.OperationId,identity.ExecutionId,identity.CausationId});
 }
 public IReadOnlyList<TrabalhoEditorial> Entradas(string scope)
 {
  Escopo(scope);
  return _UnitOfWork.Query<TrabalhoEditorial>(@"SELECT TOP(5) Id,TenantID,UserId,MessageId,Type,Payload,EntityId,CorrelationId,RootOperationId,OperationId,ExecutionId,CausationId FROM yInbox WITH(UPDLOCK,READPAST,ROWLOCK)
   WHERE ProcessingScope=@scope AND Status=0 AND Deleted=0 AND Type IN('MovimentoFabricaDisponivel.v1','SolicitacaoPublicacaoEducacional.v1') ORDER BY Id",new {scope}).ToList();
 }
 public void ConfirmarEntrada(int id,string scope,int sagaId)=>_UnitOfWork.Execute("UPDATE yInbox SET Status=1,SagaId=@sagaId,Changed=SYSUTCDATETIME() WHERE Id=@id AND ProcessingScope=@scope AND Status=0",new {id,scope,sagaId});
 public void RejeitarEntrada(int id,string scope,string code)=>_UnitOfWork.Execute("UPDATE yInbox SET Status=3,LastError=@code,Changed=SYSUTCDATETIME() WHERE Id=@id AND ProcessingScope=@scope AND Status=0",new {id,scope,code});
 public void PersistirExecucao(TrabalhoEditorial item,string scope)
 {
  if(_context==null||!_context.TryGetOperationalIdentity(out var identity))return;
  var count=_UnitOfWork.Execute("UPDATE yOutbox SET RootOperationId=@RootOperationId,OperationId=@OperationId,ExecutionId=@ExecutionId,CausationId=@CausationId WHERE Id=@Id AND TenantID=@TenantID AND ProcessingScope=@scope AND Status=2 AND ProcessingAt=@ProcessingAt AND RetryCount=@RetryCount",new {identity.RootOperationId,identity.OperationId,identity.ExecutionId,identity.CausationId,item.Id,item.TenantID,scope,item.ProcessingAt,item.RetryCount});
  if(count!=1)throw new EditorialException("PRESENCA_LEASE_LOST",409);
  item.RootOperationId=identity.RootOperationId??"";item.OperationId=identity.OperationId??"";item.ExecutionId=identity.ExecutionId??"";item.CausationId=identity.CausationId??"";
 }
 public TrabalhoEditorial? RetirarSaida(string scope)
 {
  Escopo(scope);
  // Abandoned external POSTs are uncertain, never blindly retried. Portal replacement is idempotent.
  _UnitOfWork.Execute(@"UPDATE d SET Estado=CASE WHEN JSON_VALUE(o.Payload,'$.Plataforma')='Portal' THEN 'Pendente' ELSE 'ResultadoIncerto' END,CodigoErro='PRESENCA_LEASE_EXPIRED'
   FROM PublicacaoDestino d JOIN yOutbox o ON o.EntityId=d.Id AND o.TenantID=d.TenantID
   WHERE o.Type='Presenca.Publicacao.v1' AND o.ProcessingScope=@scope AND o.Status=2 AND o.ProcessingAt<DATEADD(minute,-5,SYSUTCDATETIME());
   UPDATE yOutbox SET Status=CASE WHEN Type='PublicacaoEducacionalAtualizada.v1' OR JSON_VALUE(Payload,'$.Plataforma')='Portal' THEN 0 ELSE 3 END,LastError='PRESENCA_LEASE_EXPIRED'
   WHERE ProcessingScope=@scope AND Type IN('Presenca.Publicacao.v1','PublicacaoEducacionalAtualizada.v1') AND Status=2 AND ProcessingAt<DATEADD(minute,-5,SYSUTCDATETIME());",new {scope});
  var item=_UnitOfWork.Query<TrabalhoEditorial>(@"WITH c AS(SELECT TOP(1) * FROM yOutbox WITH(UPDLOCK,READPAST,ROWLOCK)
   WHERE ProcessingScope=@scope AND Deleted=0 AND Status=0 AND Type IN('Presenca.Publicacao.v1','PublicacaoEducacionalAtualizada.v1') AND (NextAttemptAt IS NULL OR NextAttemptAt<=SYSUTCDATETIME()) ORDER BY Id)
   UPDATE c SET Status=2,ProcessingAt=SYSUTCDATETIME(),RetryCount=RetryCount+1 OUTPUT inserted.Id,inserted.TenantID,inserted.UserId,inserted.MessageId,inserted.Type,inserted.Payload,inserted.EntityId,inserted.ProcessingAt,inserted.RetryCount,COALESCE(TRY_CONVERT(int,JSON_VALUE(inserted.TransportData,'$.ManualRetryBase')),0) ManualRetryBase,inserted.RootOperationId,inserted.OperationId,inserted.ExecutionId,inserted.CausationId",new {scope}).SingleOrDefault();
  if(item!=null&&item.Type=="Presenca.Publicacao.v1")_UnitOfWork.Execute("UPDATE PublicacaoDestino SET Estado='Processando',Tentativas=@RetryCount,Changed=SYSUTCDATETIME() WHERE Id=@EntityId AND TenantID=@TenantID",item);
  return item;
 }
 public void ConcluirSaida(TrabalhoEditorial item,string scope,string estado,string codigo,ReciboDistribuicao? recibo,TimeSpan? atraso=null,string natureza="Unknown")
 {
  var retry=estado=="FalhaRetentavel"&&item.RetryCount-item.ManualRetryBase<5;
  if(estado=="FalhaRetentavel"&&!retry)estado="FalhaFinal";
  var changed=_UnitOfWork.Execute(@"UPDATE yOutbox SET Status=@status,LastError=@codigo,NextAttemptAt=@next,SentAt=CASE WHEN @status=1 THEN SYSUTCDATETIME() ELSE NULL END
   WHERE Id=@Id AND TenantID=@TenantID AND ProcessingScope=@scope AND Status=2 AND ProcessingAt=@ProcessingAt AND RetryCount=@RetryCount",new {item.Id,item.TenantID,scope,item.ProcessingAt,item.RetryCount,status=retry?0:estado=="Publicada"?1:3,codigo,next=retry?DateTime.UtcNow.Add(atraso??ContratosEditoriais.Backoff(item.RetryCount)):(DateTime?)null});
  if(changed!=1)throw new EditorialException("PRESENCA_LEASE_LOST",409);
  if(item.Type!="Presenca.Publicacao.v1")return;
  _UnitOfWork.Execute("UPDATE PublicacaoDestino SET Estado=@estado,CodigoErro=@codigo,NaturezaFalha=@natureza,RetryPossivel=@retryPossible,ReciboExterno=@external,UrlPublica=@url,ProximaTentativaUtc=@next,Changed=SYSUTCDATETIME() WHERE Id=@EntityId AND TenantID=@TenantID",new {item.EntityId,item.TenantID,estado,codigo,natureza,retryPossible=estado is "FalhaFinal" or "FalhaRetentavel",external=recibo?.IdExterno??"",url=recibo?.UrlPublica??"",next=retry?DateTime.UtcNow.Add(atraso??ContratosEditoriais.Backoff(item.RetryCount)):(DateTime?)null});
  _UnitOfWork.Execute("INSERT INTO AuditoriaEditorial(Id,IdentidadeId,Operacao,RegistroId,TenantID,UserId,Deleted,Changed,OperationalEntityId) SELECT @audit,IdentidadeId,@estado,Id,TenantID,@actor,0,SYSUTCDATETIME(),LEFT(@audit,32) FROM PublicacaoDestino WHERE Id=@EntityId AND TenantID=@TenantID",new {audit=RegrasEditoriais.Id(item.MessageId,item.RetryCount.ToString(),estado),estado,item.EntityId,item.TenantID,actor=item.UserId});
  if(!retry)Callback(item.TenantID,item.EntityId,scope,estado,recibo?.UrlPublica??"",codigo);
 }
 private void Callback(int tenant,string delivery,string scope,string estado,string url,string codigo)
 {
  var origin=_UnitOfWork.Query<CallbackRow>(@"SELECT o.MovimentoId,v.OrigemRevisao Revisao,d.UserId FROM PublicacaoDestino d
   JOIN ConteudoVersao v ON v.Id=d.VersaoId AND v.TenantID=d.TenantID
   JOIN OrigemPauta o ON o.PautaId=v.PautaId AND o.IdentidadeId=d.IdentidadeId AND o.TenantID=d.TenantID
   WHERE d.Id=@delivery AND d.TenantID=@tenant AND o.Contrato='SolicitacaoPublicacaoEducacional.v1'",new {delivery,tenant}).SingleOrDefault();
  if(origin==null)return;
  var status=new StatusEducacionalV1(origin.MovimentoId,origin.Revisao,estado,url,codigo);
  Saida(tenant,origin.UserId,"status:"+RegrasEditoriais.Id(delivery,estado,url),"PublicacaoEducacionalAtualizada.v1",delivery,JsonSerializer.Serialize(status,IntegracaoJson.Default.StatusEducacionalV1),scope);
 }
 public List<EntregaPublica> ListarPortal(int tenant,EntregaPublica atual,string scope)
 {
  // Serialize the filesystem replacement with publisher administration and approval changes.
  _UnitOfWork.Query<int>("SELECT Id FROM yTenant WITH(UPDLOCK,HOLDLOCK) WHERE Id=@tenant",new {tenant}).Single();
  var payloads=_UnitOfWork.Query<string>(@"SELECT TOP(1001) o.Payload FROM yOutbox o WITH(HOLDLOCK)
   JOIN PublicacaoDestino d ON d.Id=o.EntityId AND d.TenantID=o.TenantID
   JOIN Aprovacao a WITH(HOLDLOCK) ON a.VersaoId=d.VersaoId AND a.TenantID=d.TenantID AND a.IdentidadeId=d.IdentidadeId
   JOIN ConteudoVersao v WITH(HOLDLOCK) ON v.Id=d.VersaoId AND v.TenantID=d.TenantID AND v.Hash=a.Hash AND v.Estado='Aprovada'
   WHERE o.Type='Presenca.Publicacao.v1' AND o.ProcessingScope=@scope AND o.TenantID=@tenant AND d.IdentidadeId=@identity AND d.CanalId=(SELECT CanalId FROM PublicacaoDestino WHERE Id=@id AND TenantID=@tenant)
    AND (d.Estado='Publicada' OR d.Id=@id)",new {tenant,identity=atual.IdentidadeId,id=atual.Id,scope}).ToList();
  if(payloads.Count>1000)throw new EditorialException("PRESENCA_PORTAL_CAPACITY",409);
  var result=payloads.Select(p=>JsonSerializer.Deserialize(p,IntegracaoJson.Default.EntregaPublica)!).GroupBy(p=>p.PautaId).Select(g=>g.OrderByDescending(p=>p.Numero).First()).ToList();
  if(!result.Any(p=>p.Id==atual.Id))throw new EditorialException("PRESENCA_APPROVAL_REQUIRED",409);
  return result;
 }
 public sealed class CanalRow {public string Plataforma {get;set;}="";public string Destino {get;set;}="";public string Conexao {get;set;}="";}
 public sealed class CallbackRow {public string MovimentoId {get;set;}="";public int Revisao {get;set;} public int UserId {get;set;}}
}
