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
  var result=new ResultadoEditorial {Id=p.RegistroId};
  if(p.Operacao=="ConsultarRedacao")
   result.Versoes=_unitOfWork.Query<VersaoEditorial>(@"SELECT TOP(100) v.Id,v.PautaId,v.Numero,v.Hash,v.Estado,v.Snapshot,v.UserId FROM ConteudoVersao v
    WHERE v.TenantID=@tenant AND v.IdentidadeId=@IdentidadeId AND (@RegistroId='' OR v.PautaId=@RegistroId) AND v.Deleted=0 ORDER BY v.Changed DESC,v.Id",new {tenant,p.IdentidadeId,p.RegistroId}).ToList();
  else if(p.Operacao=="ConsultarOperacao")
   result.Entregas=_unitOfWork.Query<EntregaEditorial>(@"SELECT TOP(100) Id,VersaoId,CanalId,Estado,Tentativas,ReciboExterno,UrlPublica FROM PublicacaoDestino
    WHERE TenantID=@tenant AND IdentidadeId=@IdentidadeId AND Deleted=0 ORDER BY Changed DESC,Id",new {tenant,p.IdentidadeId}).ToList();
  else throw new EditorialException("PRESENCA_OPERATION_INVALID");
  result.Canais=_unitOfWork.Query<CanalEditorial>("SELECT TOP(100) Id,Plataforma,Destino FROM Canal WHERE TenantID=@tenant AND IdentidadeId=@IdentidadeId AND Deleted=0 ORDER BY Plataforma,Destino",new {tenant,p.IdentidadeId}).ToList();
  return result;
 }
}
