using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IPlanoContaQueryWrite 
     {
        public QueryModel InserirPlanoContaQuery(IPlanoContaEntity PlanoConta);
        public QueryModel UpdatePlanoContaQuery(IPlanoContaEntity PlanoConta);
        QueryModel UpdateCodigo(int id, string value);
        QueryModel UpdateNome(int id, string value);
        QueryModel UpdateTipo(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeletePlanoContaQuery(IPlanoContaEntity PlanoConta);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration