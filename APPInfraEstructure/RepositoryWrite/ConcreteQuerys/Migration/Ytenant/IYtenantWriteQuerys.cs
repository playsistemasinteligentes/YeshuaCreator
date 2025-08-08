using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyTenantQueryWrite 
     {
        public QueryModel InseriryTenantQuery(IyTenantEntity yTenant);
        public QueryModel UpdateyTenantQuery(IyTenantEntity yTenant);
        public QueryModel UpdateCnpjCpf(IyTenantEntity entity);
        public QueryModel UpdateNome(IyTenantEntity entity);
        public QueryModel UpdateUserId(IyTenantEntity entity);
        public QueryModel UpdateDeleted(IyTenantEntity entity);
        public QueryModel UpdateChanged(IyTenantEntity entity);
        public QueryModel DeleteyTenantQuery(IyTenantEntity yTenant);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration