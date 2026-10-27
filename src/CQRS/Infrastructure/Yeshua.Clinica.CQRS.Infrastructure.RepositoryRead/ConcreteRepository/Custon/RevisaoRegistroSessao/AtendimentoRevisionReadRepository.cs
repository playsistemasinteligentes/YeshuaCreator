using RepositoryInterfaces.Patterns.Repository;
using Repositorio.Outputs;
namespace Read.Repository;
public partial class RevisaoRegistroSessaoReadRepository
{
    partial void TryGetRevisaoRegistroSessaoCustom(Command.Read.RevisaoRegistroSessaoReadCommand command, ref DataPagination<RevisaoRegistroSessaoDTO> result, ref bool handled)
    {
        var page=Math.Max(1,command.Paginacao?.Page??1);var size=Math.Clamp(command.Paginacao?.PageSize??20,1,100);
        var rows=_unitOfWork.Query<RevisaoRegistroSessaoDTO>(@"SELECT r.* FROM RevisaoRegistroSessao r
            JOIN Sesoes s ON s.Id=r.SessaoId AND s.TenantID=r.TenantID AND s.Deleted=0
            JOIN Profissional f ON f.Id=s.ProfissionalId AND f.TenantID=s.TenantID AND f.Deleted=0
            WHERE r.TenantID=@Tenant AND r.Deleted=0 AND f.UsuarioAcessoId=@Actor
            AND (@Id IS NULL OR r.Id=@Id) AND (@Sessao IS NULL OR r.SessaoId=@Sessao)
            ORDER BY r.Id DESC OFFSET @Offset ROWS FETCH NEXT @Size ROWS ONLY",
            new{Tenant=_executionContext.TenantID,Actor=_executionContext.UserId,Id=command.Id,Sessao=command.SessaoId,Offset=(page-1)*size,Size=size}).ToList();
        result=new(rows,page,size,rows.Count);handled=true;
    }
}
