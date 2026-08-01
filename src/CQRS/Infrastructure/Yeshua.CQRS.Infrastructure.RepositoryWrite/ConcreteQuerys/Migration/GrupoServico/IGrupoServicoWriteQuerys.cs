using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IGrupoServicoQueryWrite 
     {
        public QueryModel InserirGrupoServicoQuery(IGrupoServicoEntity GrupoServico);
        public QueryModel UpdateGrupoServicoQuery(IGrupoServicoEntity GrupoServico);
        QueryModel UpdateDescricao(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteGrupoServicoQuery(IGrupoServicoEntity GrupoServico);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration