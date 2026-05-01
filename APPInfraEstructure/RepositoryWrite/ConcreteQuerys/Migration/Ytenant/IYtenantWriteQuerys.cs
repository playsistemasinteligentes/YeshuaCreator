using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyTenantQueryWrite 
     {
        public QueryModel InseriryTenantQuery(IyTenantEntity yTenant);
        public QueryModel UpdateyTenantQuery(IyTenantEntity yTenant);
        QueryModel UpdateCnpjCpf(int id, string value);
        QueryModel UpdateNome(int id, string value);
        QueryModel UpdateUserId(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        public QueryModel DeleteyTenantQuery(IyTenantEntity yTenant);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration