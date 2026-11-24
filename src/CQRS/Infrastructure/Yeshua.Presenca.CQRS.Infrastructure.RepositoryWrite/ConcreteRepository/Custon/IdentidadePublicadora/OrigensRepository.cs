using System.Globalization;
using System.Text.Json;
using Presenca.Editorial;
namespace Input.Repository.IdentidadePublicadora;
public partial class IdentidadePublicadoraWriteRepository
{
 public ResultadoEditorial RegistrarOrigem(int tenant,int actor,string contrato,string payload,string scope)
 {
  Escopo(scope);var input=ContratosEditoriais.Validar(contrato,payload);
  _UnitOfWork.Query<int>("SELECT Id FROM yTenant WITH(UPDLOCK,HOLDLOCK) WHERE Id=@tenant AND Deleted=0",new {tenant}).Single();
  var grant=_UnitOfWork.ExecuteScalar<int>(@"SELECT v.Permissoes FROM VinculoIdentidadePublicadora v WITH(UPDLOCK,HOLDLOCK) JOIN IdentidadePublicadora i ON i.Id=v.IdentidadeId AND i.TenantID=v.TenantID AND i.Ativa=1 AND i.Deleted=0
   WHERE v.TenantID=@tenant AND v.IdentidadeId=@IdentidadeId AND v.UsuarioId=@actor AND v.Deleted=0",new {tenant,input.IdentidadeId,actor});
  RegrasEditoriais.Autorizar(tenant,actor,grant,PermissaoEditorial.Integrar);
  var id=RegrasEditoriais.Id(tenant.ToString(CultureInfo.InvariantCulture),input.IdentidadeId,input.Produtor,input.MovimentoId);
  var previous=_UnitOfWork.Query<OrigemRow>("SELECT PautaId,Revisao,Hash,Contrato FROM OrigemPauta WITH(UPDLOCK,HOLDLOCK) WHERE Id=@id AND TenantID=@tenant AND IdentidadeId=@IdentidadeId",new {id,tenant,input.IdentidadeId}).SingleOrDefault();
  if(previous!=null)
  {
   if(previous.Contrato!=contrato)throw new EditorialException("PRESENCA_ORIGIN_CONFLICT",409);
   if(input.Revisao<previous.Revisao)return new(){Id=previous.PautaId,Estado="Obsoleta"};
   if(input.Revisao==previous.Revisao)
   {if(input.Hash!=previous.Hash)throw new EditorialException("PRESENCA_ORIGIN_HASH_CONFLICT",409);return new(){Id=previous.PautaId,Estado="Recebida"};}
  }
  var pauta=previous?.PautaId??id;
  if(previous==null)
  {
   _UnitOfWork.Execute("INSERT INTO Pauta(Id,IdentidadeId,VersaoAtual,Origem,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@pauta,@IdentidadeId,0,@contrato,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@pauta,32))",new {pauta,input.IdentidadeId,contrato,tenant,actor});
   _UnitOfWork.Execute("INSERT INTO OrigemPauta(Id,IdentidadeId,PautaId,Produtor,MovimentoId,Referencia,Revisao,Hash,Contrato,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@id,@IdentidadeId,@pauta,@Produtor,@MovimentoId,@Referencia,0,'',@contrato,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@id,32))",new {id,input.IdentidadeId,pauta,input.Produtor,input.MovimentoId,input.Referencia,contrato,tenant,actor});
  }
  var current=_UnitOfWork.ExecuteScalar<int>("SELECT VersaoAtual FROM Pauta WITH(UPDLOCK,HOLDLOCK) WHERE Id=@pauta AND TenantID=@tenant AND IdentidadeId=@IdentidadeId",new {pauta,tenant,input.IdentidadeId});
  var c=input.Conteudo;var data=new DadosEditorial{Manchete=c.Manchete,Corpo=c.Corpo,AutorPublico=c.AutorPublico,ClassificacaoPrincipal=c.ClassificacaoPrincipal,ClassificacoesSecundarias=c.ClassificacoesSecundarias,Fontes=c.Fontes,Tags=c.Tags,Materiais=c.Materiais};
  var result=Salvar(tenant,actor,input.IdentidadeId,pauta,current,data);
  _UnitOfWork.Execute("UPDATE OrigemPauta SET Revisao=@Revisao,Hash=@Hash,Referencia=@Referencia,Changed=SYSUTCDATETIME() WHERE Id=@id AND TenantID=@tenant AND IdentidadeId=@IdentidadeId",new {input.Revisao,input.Hash,input.Referencia,id,tenant,input.IdentidadeId});
  _UnitOfWork.Execute("UPDATE ConteudoVersao SET OrigemRevisao=@Revisao WHERE PautaId=@pauta AND Numero=@Versao AND TenantID=@tenant AND IdentidadeId=@IdentidadeId",new {input.Revisao,pauta,result.Versao,tenant,input.IdentidadeId});
  var audit=RegrasEditoriais.Id(id,input.Revisao.ToString(CultureInfo.InvariantCulture));
  _UnitOfWork.Execute("INSERT INTO AuditoriaEditorial(Id,IdentidadeId,Operacao,RegistroId,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@audit,@IdentidadeId,@contrato,@pauta,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@audit,32))",new {audit,input.IdentidadeId,contrato,pauta,tenant,actor});
  if(contrato=="SolicitacaoPublicacaoEducacional.v1")Saida(tenant,actor,"status:"+audit,"PublicacaoEducacionalAtualizada.v1",pauta,JsonSerializer.Serialize(new StatusEducacionalV1(input.MovimentoId,input.Revisao,"Rascunho","",""),IntegracaoJson.Default.StatusEducacionalV1),scope);
  return result;
 }
 public void ProvisionarInicial(int tenant,int actor,string identidade,string nome)
 {
  RegrasEditoriais.ValidarId(identidade);RegrasEditoriais.Texto(nome,120);
  if(tenant<=0||actor<=0||_UnitOfWork.ExecuteScalar<int>("SELECT COUNT(*) FROM yUser WITH(UPDLOCK,HOLDLOCK) WHERE Id=@actor AND TenantID=@tenant AND Deleted=0",new {tenant,actor})!=1)throw new EditorialException("PRESENCA_BOOTSTRAP_IDENTITY_REQUIRED",403);
  if(_UnitOfWork.ExecuteScalar<int>("SELECT COUNT(*) FROM IdentidadePublicadora WITH(UPDLOCK,HOLDLOCK) WHERE TenantID=@tenant",new {tenant})!=0)throw new EditorialException("PRESENCA_BOOTSTRAP_ALREADY_DONE",409);
  var id=RegrasEditoriais.Id(tenant.ToString(CultureInfo.InvariantCulture),identidade,actor.ToString(CultureInfo.InvariantCulture));
  _UnitOfWork.Execute(@"INSERT INTO IdentidadePublicadora(Id,Nome,Ativa,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@identidade,@nome,1,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@identidade,32));
   INSERT INTO VinculoIdentidadePublicadora(Id,IdentidadeId,UsuarioId,Permissoes,Versao,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@id,@identidade,@actor,127,1,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@id,32));
   INSERT INTO AuditoriaEditorial(Id,IdentidadeId,Operacao,RegistroId,TenantID,UserId,Deleted,Changed,OperationalEntityId) VALUES(@id,@identidade,'ProvisionamentoExplicito',@identidade,@tenant,@actor,0,SYSUTCDATETIME(),LEFT(@id,32));",new {identidade,nome,tenant,actor,id});
 }
 public sealed class OrigemRow {public string PautaId {get;set;}="";public int Revisao {get;set;}public string Hash {get;set;}="";public string Contrato {get;set;}="";}
}
