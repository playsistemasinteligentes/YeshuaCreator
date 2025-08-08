using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IGrupoServicoQueryWrite 
     {
        public QueryModel InserirGrupoServicoQuery(IGrupoServicoEntity GrupoServico);
        public QueryModel UpdateGrupoServicoQuery(IGrupoServicoEntity GrupoServico);
        public QueryModel UpdateDescricao(IGrupoServicoEntity entity);
        public QueryModel UpdateTenantID(IGrupoServicoEntity entity);
        public QueryModel UpdateDeleted(IGrupoServicoEntity entity);
        public QueryModel UpdateChanged(IGrupoServicoEntity entity);
        public QueryModel UpdateUserId(IGrupoServicoEntity entity);
        public QueryModel DeleteGrupoServicoQuery(IGrupoServicoEntity GrupoServico);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration