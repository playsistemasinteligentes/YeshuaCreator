using System.Globalization;
using System.Text.Json;
using Presenca.Editorial;
namespace Input.Repository.IdentidadePublicadora;
public partial class IdentidadePublicadoraWriteRepository
{
 // Caller opens a transaction. Lock order is tenant, identity, grant, receipt, aggregate.
 // Tenant lock also serializes explicit administration and concurrent revocation.
 public ResultadoEditorial Executar(int tenant,int actor,PedidoEditorial p,string processingScope="")
 {
  RegrasEditoriais.ValidarPedido(p);
  if(tenant<=0||actor<=0)throw new EditorialException("PRESENCA_FORBIDDEN",403);
  var d=RegrasEditoriais.Dados(p.Dados);
  // A local yTenant.UserId is rewritten on application entry; it is NOT tenant ownership.
  // Bootstrap requires an explicitly provisioned publisher + administrator binding.
  _UnitOfWork.Query<int>("SELECT Id FROM yTenant WITH(UPDLOCK,HOLDLOCK) WHERE Id=@tenant AND Deleted=0",new {tenant}).SingleOrDefault();
  var source=p.IdentidadeId;
  var active=_UnitOfWork.ExecuteScalar<int>("SELECT Ativa FROM IdentidadePublicadora WITH(UPDLOCK,HOLDLOCK) WHERE Id=@source AND TenantID=@tenant AND Deleted=0",new {source,tenant});
  if(active!=1)throw new EditorialException("PRESENCA_FORBIDDEN",403);
  var grant=_UnitOfWork.ExecuteScalar<int>("SELECT Permissoes FROM VinculoIdentidadePublicadora WITH(UPDLOCK,HOLDLOCK) WHERE Id=@id AND TenantID=@tenant AND IdentidadeId=@source AND UsuarioId=@actor AND Deleted=0",new {id=RegrasEditoriais.Id(tenant.ToString(CultureInfo.InvariantCulture),source,actor.ToString(CultureInfo.InvariantCulture)),tenant,source,actor});
  RegrasEditoriais.Autorizar(tenant,actor,grant,RegrasEditoriais.Permissao(p.Operacao));
  var identidade=p.Operacao=="CriarIdentidade"?RegrasEditoriais.Id(tenant.ToString(CultureInfo.InvariantCulture),source,p.Operacao,p.Chave):source;
  var recibo=RegrasEditoriais.Id(tenant.ToString(CultureInfo.InvariantCulture),identidade,p.Operacao,p.Chave);
  var hash=RegrasEditoriais.Hash(RegrasEditoriais.Canonico(p,d));
  var previous=_UnitOfWork.Query<ReciboRow>("SELECT Hash,Resultado,UserId FROM ReciboEntrada WITH(UPDLOCK,HOLDLOCK) WHERE Id=@recibo AND TenantID=@tenant AND IdentidadeId=@identidade",new {recibo,tenant,identidade}).SingleOrDefault();
  if(previous!=null)
  {
   if(previous.UserId!=actor)throw new EditorialException("PRESENCA_FORBIDDEN",403);
   if(previous.Hash!=hash)throw new EditorialException("PRESENCA_IDEMPOTENCY_CONFLICT",409);
   return JsonSerializer.Deserialize(previous.Resultado,EditorialJson.Default.ResultadoEditorial)!;
  }
  var result=new ResultadoEditorial {Id=p.RegistroId};
  switch(p.Operacao)
  {
   case "CriarIdentidade":
    RegrasEditoriais.Texto(d.Nome,120);
    if(d.UsuarioId<=0||(d.Permissoes&~255)!=0||(d.Permissoes&64)!=64)throw new EditorialException("PRESENCA_INITIAL_ADMIN_REQUIRED");
    if(_UnitOfWork.ExecuteScalar<int>("SELECT COUNT(*) FROM yUser WITH(HOLDLOCK) WHERE Id=@UsuarioId AND TenantID=@tenant AND Deleted=0",new {d.UsuarioId,tenant})!=1)throw new EditorialException("PRESENCA_FORBIDDEN",403);
    _UnitOfWork.Execute("INSERT INTO IdentidadePublicadora(Id,Nome,Ativa,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@identidade,@Nome,1,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@identidade,32))",new {identidade,d.Nome,tenant,actor});
    var initialGrant=RegrasEditoriais.Id(tenant.ToString(CultureInfo.InvariantCulture),identidade,d.UsuarioId.ToString(CultureInfo.InvariantCulture));
    _UnitOfWork.Execute("INSERT INTO VinculoIdentidadePublicadora(Id,IdentidadeId,UsuarioId,Permissoes,Versao,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@initialGrant,@identidade,@UsuarioId,@Permissoes,1,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@initialGrant,32))",new {initialGrant,identidade,d.UsuarioId,d.Permissoes,tenant,actor});
    result.Id=identidade;result.Estado="Ativa";break;
   case "DefinirVinculo":
    if(d.UsuarioId<=0||(d.Permissoes&~255)!=0||d.Permissoes<0)throw new EditorialException("PRESENCA_GRANT_INVALID");
    if(_UnitOfWork.ExecuteScalar<int>("SELECT COUNT(*) FROM yUser WITH(HOLDLOCK) WHERE Id=@UsuarioId AND TenantID=@tenant AND Deleted=0",new {d.UsuarioId,tenant})!=1)throw new EditorialException("PRESENCA_FORBIDDEN",403);
    var vinculo=RegrasEditoriais.Id(tenant.ToString(CultureInfo.InvariantCulture),identidade,d.UsuarioId.ToString(CultureInfo.InvariantCulture));
    var grantVersion=_UnitOfWork.Query<int>("SELECT Versao FROM VinculoIdentidadePublicadora WITH(UPDLOCK,HOLDLOCK) WHERE Id=@vinculo AND TenantID=@tenant",new {vinculo,tenant}).SingleOrDefault();
    RegrasEditoriais.Concorrencia(grantVersion,p.VersaoEsperada);
    _UnitOfWork.Execute(@"IF EXISTS(SELECT 1 FROM VinculoIdentidadePublicadora WHERE Id=@vinculo AND TenantID=@tenant)
      UPDATE VinculoIdentidadePublicadora SET Permissoes=@Permissoes,Versao=Versao+1,Changed=SYSUTCDATETIME() WHERE Id=@vinculo AND TenantID=@tenant;
      ELSE INSERT INTO VinculoIdentidadePublicadora(Id,IdentidadeId,UsuarioId,Permissoes,Versao,TenantID,UserId,Deleted,Changed,OperationalEntityId)
      VALUES(@vinculo,@identidade,@UsuarioId,@Permissoes,1,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@vinculo,32))",new {vinculo,identidade,d.UsuarioId,d.Permissoes,tenant,actor});
    result.Id=vinculo;result.Versao=grantVersion+1;result.Estado="Definido";break;
   case "ConfigurarCanal":
    // Account and credential are references only. No network access or secret in the DTO.
    if(d.Plataforma is not ("Portal" or "Telegram" or "GitHubDiscussions"))throw new EditorialException("PRESENCA_PLATFORM_INVALID");
    RegrasEditoriais.Texto(d.Destino,200);RegrasEditoriais.Texto(d.Conexao,120);
    var platformId=RegrasEditoriais.Id(tenant.ToString(CultureInfo.InvariantCulture),d.Plataforma);
    _UnitOfWork.Execute("IF NOT EXISTS(SELECT 1 FROM Plataforma WITH(UPDLOCK,HOLDLOCK) WHERE Id=@platformId AND TenantID=@tenant) INSERT INTO Plataforma(Id,Codigo,Capacidades,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@platformId,@Plataforma,@capabilities,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@platformId,32))",new {platformId,d.Plataforma,capabilities=d.Plataforma=="Portal"?"StaticHtml":d.Plataforma=="Telegram"?"PlainText4096":"Discussion",tenant,actor});
    var canal=RegrasEditoriais.Id(tenant.ToString(CultureInfo.InvariantCulture),identidade,d.Plataforma,d.Destino);
    if(_UnitOfWork.ExecuteScalar<int>("SELECT COUNT(*) FROM Canal WHERE Id=@canal AND TenantID=@tenant",new {canal,tenant})!=0)throw new EditorialException("PRESENCA_CHANNEL_EXISTS",409);
    _UnitOfWork.Execute("INSERT INTO Canal(Id,IdentidadeId,Plataforma,Destino,Conexao,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@canal,@identidade,@Plataforma,@Destino,@Conexao,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@canal,32))",new {canal,identidade,d.Plataforma,d.Destino,d.Conexao,tenant,actor});
    result.Id=canal;result.Estado="Configurado";break;
   case "CriarPautaManual":
    var pauta=RegrasEditoriais.Id(tenant.ToString(CultureInfo.InvariantCulture),identidade,p.Chave);
    _UnitOfWork.Execute("INSERT INTO Pauta(Id,IdentidadeId,VersaoAtual,Origem,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@pauta,@identidade,0,'Manual',@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@pauta,32))",new {pauta,identidade,tenant,actor});
    result=Salvar(tenant,actor,identidade,pauta,0,d);break;
   case "SalvarRascunho":result=Salvar(tenant,actor,identidade,p.RegistroId,p.VersaoEsperada,d);break;
   case "SubmeterRevisao":case "AprovarVersao":case "RejeitarVersao":
    var version=Atual(tenant,identidade,p.RegistroId,p.VersaoEsperada);
    var estado=RegrasEditoriais.Transicao(version.Estado,p.Operacao,version.UserId,actor,d.Publicavel);
    if(p.Operacao=="RejeitarVersao")RegrasEditoriais.Texto(d.Motivo,500);
    if(estado=="Aprovada")
    {
     if(d.Canais is null||d.Canais.Length is <1 or >10||d.Canais.Distinct().Count()!=d.Canais.Length)throw new EditorialException("PRESENCA_CHANNEL_INVALID");
     foreach(var channel in d.Canais)ValidarCanal(tenant,identidade,channel);
     _UnitOfWork.Execute("INSERT INTO Aprovacao(Id,IdentidadeId,VersaoId,Hash,Destinos,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@Id,@identidade,@Id,@Hash,@Destinos,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@Id,32))",new {version.Id,identidade,version.Hash,Destinos=JsonSerializer.Serialize(d.Canais.Order().ToArray(),EditorialJson.Default.StringArray),tenant,actor});
    }
    _UnitOfWork.Execute("UPDATE ConteudoVersao SET Estado=@estado,Changed=SYSUTCDATETIME() WHERE Id=@Id AND TenantID=@tenant AND IdentidadeId=@identidade",new {estado,version.Id,tenant,identidade});
    result=new(){Id=p.RegistroId,Versao=version.Numero,Estado=estado};break;
   case "SolicitarPublicacao":
    var approved=Atual(tenant,identidade,p.RegistroId,p.VersaoEsperada);
    if(approved.Estado!="Aprovada")throw new EditorialException("PRESENCA_APPROVAL_REQUIRED",409);
    var approval=_UnitOfWork.Query<AprovacaoRow>("SELECT Hash,Destinos FROM Aprovacao WITH(HOLDLOCK) WHERE Id=@Id AND TenantID=@tenant AND IdentidadeId=@identidade",new {approved.Id,tenant,identidade}).SingleOrDefault();
    if(approval==null||approval.Hash!=approved.Hash)throw new EditorialException("PRESENCA_APPROVAL_REQUIRED",409);
    _UnitOfWork.Execute("IF NOT EXISTS(SELECT 1 FROM Publicacao WITH(UPDLOCK,HOLDLOCK) WHERE Id=@Id AND TenantID=@tenant) INSERT INTO Publicacao(Id,IdentidadeId,VersaoId,Hash,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@Id,@identidade,@Id,@Hash,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@Id,32))",new {approved.Id,identidade,approved.Hash,tenant,actor});
    var allowed=JsonSerializer.Deserialize(approval.Destinos,EditorialJson.Default.StringArray)!;
    if(d.Canais is null||d.Canais.Length is <1 or >10||d.Canais.Distinct().Count()!=d.Canais.Length||d.Canais.Any(c=>!allowed.Contains(c)))throw new EditorialException("PRESENCA_CHANNEL_INVALID");
    foreach(var channel in d.Canais)
    {
     ValidarCanal(tenant,identidade,channel);
     var delivery=RegrasEditoriais.Id(tenant.ToString(CultureInfo.InvariantCulture),identidade,approved.Id,channel);
     _UnitOfWork.Execute(@"IF NOT EXISTS(SELECT 1 FROM PublicacaoDestino WITH(UPDLOCK,HOLDLOCK) WHERE Id=@delivery AND TenantID=@tenant)
       INSERT INTO PublicacaoDestino(Id,IdentidadeId,VersaoId,CanalId,Estado,Tentativas,TenantID,UserId,Deleted,Changed,OperationalEntityId)
       VALUES(@delivery,@identidade,@Id,@channel,'Pendente',0,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@delivery,32))",new {delivery,identidade,approved.Id,channel,tenant,actor});
    }
    foreach(var channel in d.Canais)EnfileirarPublicacao(tenant,actor,identidade,approved,channel,processingScope,d.AgendadaParaUtc);
    result=new(){Id=p.RegistroId,Versao=approved.Numero,Estado="Pendente"};break;
   case "ReprocessarEntrega":
    RegrasEditoriais.Texto(d.Motivo,500);
    var affected=_UnitOfWork.Execute("UPDATE d SET Estado='Pendente',CodigoErro='',Changed=SYSUTCDATETIME() FROM PublicacaoDestino d JOIN yOutbox o ON o.EntityId=d.Id AND o.TenantID=d.TenantID AND o.Type='Presenca.Publicacao.v1' AND o.ProcessingScope=@processingScope WHERE d.Id=@Id AND d.TenantID=@tenant AND d.IdentidadeId=@identidade AND d.Estado='FalhaFinal' AND d.Tentativas=@expected",new {Id=p.RegistroId,tenant,identidade,processingScope,expected=p.VersaoEsperada});
    if(affected!=1)throw new EditorialException("PRESENCA_RETRY_DENIED",409);
    _UnitOfWork.Execute("UPDATE yOutbox SET Status=0,NextAttemptAt=SYSUTCDATETIME(),LastError=NULL,TransportData=JSON_MODIFY(COALESCE(TransportData,'{}'),'$.ManualRetryBase',RetryCount) WHERE EntityId=@Id AND TenantID=@tenant AND ProcessingScope=@processingScope AND Type='Presenca.Publicacao.v1' AND Status=3",new {Id=p.RegistroId,tenant,processingScope});
    result.Estado="Pendente";break;
   case "ReconciliarEntrega":
    RegrasEditoriais.Texto(d.Motivo,500);RegrasEditoriais.Texto(d.ReciboExterno,200);
    if(d.UrlPublica.Length>0&&!RegrasEditoriais.UrlSegura(d.UrlPublica))throw new EditorialException("PRESENCA_URL_INVALID");
    var changed=_UnitOfWork.Execute("UPDATE d SET Estado='Publicada',ReciboExterno=@ReciboExterno,UrlPublica=@UrlPublica,Changed=SYSUTCDATETIME() FROM PublicacaoDestino d JOIN yOutbox o ON o.EntityId=d.Id AND o.TenantID=d.TenantID AND o.Type='Presenca.Publicacao.v1' AND o.ProcessingScope=@processingScope WHERE d.Id=@Id AND d.TenantID=@tenant AND d.IdentidadeId=@identidade AND d.Estado='ResultadoIncerto' AND d.Tentativas=@expected",new {d.ReciboExterno,d.UrlPublica,Id=p.RegistroId,tenant,identidade,processingScope,expected=p.VersaoEsperada});
    if(changed!=1)throw new EditorialException("PRESENCA_RECONCILIATION_DENIED",409);
    _UnitOfWork.Execute("UPDATE yOutbox SET Status=1,SentAt=SYSUTCDATETIME(),LastError=NULL WHERE EntityId=@Id AND TenantID=@tenant AND ProcessingScope=@processingScope AND Type='Presenca.Publicacao.v1' AND Status=3",new {Id=p.RegistroId,tenant,processingScope});
    Callback(tenant,p.RegistroId,processingScope,"Publicada",d.UrlPublica,"");
    result.Estado="Publicada";break;
   default:throw new EditorialException("PRESENCA_OPERATION_INVALID");
  }
  _UnitOfWork.Execute("INSERT INTO AuditoriaEditorial(Id,IdentidadeId,Operacao,RegistroId,Motivo,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@recibo,@identidade,@Operacao,@Id,@Motivo,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@recibo,32))",new {recibo,identidade,p.Operacao,result.Id,d.Motivo,tenant,actor});
  _UnitOfWork.Execute("INSERT INTO ReciboEntrada(Id,IdentidadeId,Operacao,Hash,Resultado,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@recibo,@identidade,@Operacao,@hash,@Resultado,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@recibo,32))",new {recibo,identidade,p.Operacao,hash,Resultado=JsonSerializer.Serialize(result,EditorialJson.Default.ResultadoEditorial),tenant,actor});
  return result;
 }
 private ResultadoEditorial Salvar(int tenant,int actor,string identidade,string pauta,int expected,DadosEditorial d)
 {
  var conteudo=RegrasEditoriais.Conteudo(d);
  var current=_UnitOfWork.Query<int>("SELECT VersaoAtual FROM Pauta WITH(UPDLOCK,HOLDLOCK) WHERE Id=@pauta AND TenantID=@tenant AND IdentidadeId=@identidade AND Deleted=0",new {pauta,tenant,identidade}).SingleOrDefault(-1);
  RegrasEditoriais.Concorrencia(current,expected);
  var number=current+1;
  var id=RegrasEditoriais.Id(tenant.ToString(CultureInfo.InvariantCulture),identidade,pauta,number.ToString(CultureInfo.InvariantCulture));
  var snapshot=JsonSerializer.Serialize(conteudo,EditorialJson.Default.ConteudoPublico);
  _UnitOfWork.Execute("INSERT INTO ConteudoVersao(Id,IdentidadeId,PautaId,Numero,Hash,Estado,Snapshot,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@id,@identidade,@pauta,@number,@hash,'Rascunho',@snapshot,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@id,32))",new {id,identidade,pauta,number,hash=RegrasEditoriais.Hash(snapshot),snapshot,tenant,actor});
  _UnitOfWork.Execute("IF NOT EXISTS(SELECT 1 FROM Conteudo WITH(UPDLOCK,HOLDLOCK) WHERE Id=@pauta AND TenantID=@tenant) INSERT INTO Conteudo(Id,IdentidadeId,PautaId,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@pauta,@identidade,@pauta,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@pauta,32))",new {pauta,identidade,tenant,actor});
  foreach(var material in conteudo.Materiais.DistinctBy(m=>m.StorageKey))
  {
   var materialId=RegrasEditoriais.Id(id,material.StorageKey);
   _UnitOfWork.Execute("INSERT INTO Material(Id,IdentidadeId,VersaoId,StorageKey,Hash,Licenca,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@materialId,@identidade,@id,@StorageKey,@Hash,@Licenca,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@materialId,32))",new {materialId,identidade,id,material.StorageKey,material.Hash,material.Licenca,tenant,actor});
  }
  _UnitOfWork.Execute("UPDATE Pauta SET VersaoAtual=@number,Changed=SYSUTCDATETIME() WHERE Id=@pauta AND TenantID=@tenant AND IdentidadeId=@identidade",new {number,pauta,tenant,identidade});
  return new(){Id=pauta,Versao=number,Estado="Rascunho"};
 }
 private VersaoEditorial Atual(int tenant,string identidade,string pauta,int expected)
 {
  var version=_UnitOfWork.Query<VersaoEditorial>(@"SELECT v.Id,v.PautaId,v.Numero,v.Hash,v.Estado,v.Snapshot,v.UserId FROM Pauta p WITH(UPDLOCK,HOLDLOCK)
    JOIN ConteudoVersao v WITH(UPDLOCK,HOLDLOCK) ON v.PautaId=p.Id AND v.Numero=p.VersaoAtual AND v.TenantID=p.TenantID AND v.IdentidadeId=p.IdentidadeId
    WHERE p.Id=@pauta AND p.TenantID=@tenant AND p.IdentidadeId=@identidade AND p.Deleted=0",new {pauta,tenant,identidade}).SingleOrDefault()??throw new EditorialException("PRESENCA_VERSION_CONFLICT",409);
  RegrasEditoriais.Concorrencia(version.Numero,expected);return version;
 }
 private void ValidarCanal(int tenant,string identidade,string channel)
 {
  RegrasEditoriais.ValidarId(channel);
  if(_UnitOfWork.ExecuteScalar<int>("SELECT COUNT(*) FROM Canal WITH(HOLDLOCK) WHERE Id=@channel AND TenantID=@tenant AND IdentidadeId=@identidade AND Deleted=0",new {channel,tenant,identidade})!=1)throw new EditorialException("PRESENCA_CHANNEL_INVALID");
 }
 public sealed class ReciboRow {public string Hash {get;set;}="";public string Resultado {get;set;}="";public int UserId {get;set;}}
 public sealed class AprovacaoRow {public string Hash {get;set;}="";public string Destinos {get;set;}="";}
}
