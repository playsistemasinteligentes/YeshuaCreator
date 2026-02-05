using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IPlanoContaQueryWrite 
     {
        public QueryModel InserirPlanoContaQuery(IPlanoContaEntity PlanoConta);
        public QueryModel UpdatePlanoContaQuery(IPlanoContaEntity PlanoConta);
        public QueryModel UpdateCodigo(IPlanoContaEntity entity);
        public QueryModel UpdateNome(IPlanoContaEntity entity);
        public QueryModel UpdateTipo(IPlanoContaEntity entity);
        public QueryModel UpdateContaPaiId(IPlanoContaEntity entity);
        public QueryModel UpdateTenantID(IPlanoContaEntity entity);
        public QueryModel UpdateDeleted(IPlanoContaEntity entity);
        public QueryModel UpdateChanged(IPlanoContaEntity entity);
        public QueryModel UpdateUserId(IPlanoContaEntity entity);
        public QueryModel DeletePlanoContaQuery(IPlanoContaEntity PlanoConta);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration