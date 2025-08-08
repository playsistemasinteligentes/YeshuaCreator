using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IServicoQueryWrite 
     {
        public QueryModel InserirServicoQuery(IServicoEntity Servico);
        public QueryModel UpdateServicoQuery(IServicoEntity Servico);
        public QueryModel UpdateGrupoServicoId(IServicoEntity entity);
        public QueryModel UpdateNome(IServicoEntity entity);
        public QueryModel UpdateValor(IServicoEntity entity);
        public QueryModel UpdateTenantID(IServicoEntity entity);
        public QueryModel UpdateDeleted(IServicoEntity entity);
        public QueryModel UpdateChanged(IServicoEntity entity);
        public QueryModel UpdateUserId(IServicoEntity entity);
        public QueryModel DeleteServicoQuery(IServicoEntity Servico);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration