using Presenca.Editorial;
namespace Read.Repository;
public partial class IdentidadePublicadoraReadRepository
{
 public ResultadoEditorial Consultar(int tenant,int actor,PedidoEditorial p)
 {
  if(p.Operacao=="ConsultarIdentidades")
  {
   if(tenant<=0||actor<=0)throw new EditorialException("PRESENCA_FORBIDDEN",403);
   return new ResultadoEditorial {Identidades=_unitOfWork.Query<IdentidadeEditorial>(@"SELECT TOP(100) i.Id,i.Nome FROM IdentidadePublicadora i WITH(HOLDLOCK)
    JOIN VinculoIdentidadePublicadora v WITH(HOLDLOCK) ON v.IdentidadeId=i.Id AND v.TenantID=i.TenantID AND v.UsuarioId=@actor AND (v.Permissoes & 1)=1 AND v.Deleted=0
    WHERE i.TenantID=@tenant AND i.Ativa=1 AND i.Deleted=0 ORDER BY i.Nome,i.Id",new {tenant,actor}).ToList()};
  }
  RegrasEditoriais.ValidarId(p.IdentidadeId);
  if(tenant<=0||actor<=0)throw new EditorialException("PRESENCA_FORBIDDEN",403);
  var grant=_unitOfWork.ExecuteScalar<int>(@"SELECT v.Permissoes FROM VinculoIdentidadePublicadora v WITH(HOLDLOCK) JOIN IdentidadePublicadora i WITH(HOLDLOCK) ON i.Id=v.IdentidadeId AND i.TenantID=v.TenantID AND i.Ativa=1 AND i.Deleted=0
    WHERE v.IdentidadeId=@IdentidadeId AND v.UsuarioId=@actor AND v.TenantID=@tenant AND v.Deleted=0",new {p.IdentidadeId,actor,tenant});
  RegrasEditoriais.Autorizar(tenant,actor,grant,RegrasEditoriais.Permissao(p.Operacao));
  if(p.Operacao=="ConsultarOperacao"&&string.IsNullOrWhiteSpace(_executionContext.ProcessingScope))throw new EditorialException("PRESENCA_SCOPE_REQUIRED",503);
  var offset=RegrasEditoriais.Dados(string.IsNullOrEmpty(p.Dados)?"{}":p.Dados).Offset;
  if(offset<0||offset>10000)throw new EditorialException("PRESENCA_PAGE_INVALID");
  var result=new ResultadoEditorial {Id=p.RegistroId};
  if(p.Operacao=="ConsultarRedacao")
   result.Versoes=_unitOfWork.Query<VersaoEditorial>(@"SELECT v.Id,v.PautaId,v.Numero,v.Hash,v.Estado,v.Snapshot,v.UserId FROM ConteudoVersao v
    WHERE v.TenantID=@tenant AND v.IdentidadeId=@IdentidadeId AND (@RegistroId='' OR v.PautaId=@RegistroId) AND v.Deleted=0 ORDER BY v.Changed DESC,v.Id OFFSET @offset ROWS FETCH NEXT 51 ROWS ONLY",new {tenant,p.IdentidadeId,p.RegistroId,offset}).ToList();
  else if(p.Operacao=="ConsultarOperacao")
   result.Entregas=_unitOfWork.Query<EntregaEditorial>(@"SELECT TOP(100) d.Id,d.VersaoId,d.CanalId,d.Estado,d.CodigoErro,d.NaturezaFalha,d.Tentativas,d.ReciboExterno,d.UrlPublica FROM PublicacaoDestino d JOIN yOutbox o ON o.EntityId=d.Id AND o.TenantID=d.TenantID AND o.Type='Presenca.Publicacao.v1' AND o.ProcessingScope=@scope
    WHERE d.TenantID=@tenant AND d.IdentidadeId=@IdentidadeId AND d.Deleted=0 ORDER BY d.Changed DESC,d.Id",new {tenant,p.IdentidadeId,scope=_executionContext.ProcessingScope}).ToList();
  else if(p.Operacao=="ConsultarAuditoria")
   result.AuditoriaJson=System.Text.Json.JsonSerializer.Serialize(_unitOfWork.Query<AuditoriaEditorialInfo>("SELECT TOP(100) Operacao,RegistroId,UserId,Changed FROM AuditoriaEditorial WHERE TenantID=@tenant AND IdentidadeId=@IdentidadeId AND Deleted=0 ORDER BY Changed DESC,Id",new {tenant,p.IdentidadeId}).ToList(),IntegracaoJson.Default.ListAuditoriaEditorialInfo);
  else throw new EditorialException("PRESENCA_OPERATION_INVALID");
  if(p.Operacao=="ConsultarOperacao")
   result.RetornosEducacionais=_unitOfWork.Query<RetornoEducacionalEditorial>(@"SELECT TOP(100) SUBSTRING(o.MessageId,8,64) Id,
     CASE o.Status WHEN 0 THEN 'Pendente' WHEN 1 THEN 'Confirmado' WHEN 2 THEN 'Processando' ELSE 'FalhaFinal' END Estado,
     o.RetryCount Tentativas,o.LastError CodigoErro FROM yOutbox o
    WHERE o.Type='PublicacaoEducacionalAtualizada.v1' AND o.TenantID=@tenant AND o.ProcessingScope=@scope AND o.Deleted=0
     AND (EXISTS(SELECT 1 FROM Pauta p WHERE p.Id=o.EntityId AND p.TenantID=o.TenantID AND p.IdentidadeId=@IdentidadeId AND p.Deleted=0)
      OR EXISTS(SELECT 1 FROM PublicacaoDestino d WHERE d.Id=o.EntityId AND d.TenantID=o.TenantID AND d.IdentidadeId=@IdentidadeId AND d.Deleted=0))
    ORDER BY o.CreatedAt DESC,o.Id",new {tenant,p.IdentidadeId,scope=_executionContext.ProcessingScope}).ToList();
  if(p.Operacao=="ConsultarOperacao")
  {
   result.SaudeFilas=SaudeOperacao(tenant,p.IdentidadeId);
   result.SaudeConsultadaEmUtc=DateTimeOffset.UtcNow;
  }
  result.Canais=_unitOfWork.Query<CanalEditorial>("SELECT TOP(100) Id,Plataforma,Destino FROM Canal WHERE TenantID=@tenant AND IdentidadeId=@IdentidadeId AND Deleted=0 ORDER BY Plataforma,Destino",new {tenant,p.IdentidadeId}).ToList();
  result.TemMais=result.Versoes.Count>50;
  if(result.TemMais)result.Versoes.RemoveAt(50);
  return result;
 }
}
