using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IYtenantPermissionMudulesQueryWrite 
     {
        public QueryModel InserirYtenantPermissionMudulesQuery(IYtenantPermissionMudulesEntity YtenantPermissionMudules);
        public QueryModel UpdateYtenantPermissionMudulesQuery(IYtenantPermissionMudulesEntity YtenantPermissionMudules);
        public QueryModel UpdatepermissionModulesId(IYtenantPermissionMudulesEntity entity);
        public QueryModel UpdateTenantID(IYtenantPermissionMudulesEntity entity);
        public QueryModel UpdateValidUntil(IYtenantPermissionMudulesEntity entity);
        public QueryModel DeleteYtenantPermissionMudulesQuery(IYtenantPermissionMudulesEntity YtenantPermissionMudules);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration