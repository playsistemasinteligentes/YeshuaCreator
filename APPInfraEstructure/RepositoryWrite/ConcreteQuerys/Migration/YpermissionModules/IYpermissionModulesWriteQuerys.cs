using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IYpermissionModulesQueryWrite 
     {
        public QueryModel InserirYpermissionModulesQuery(IYpermissionModulesEntity YpermissionModules);
        public QueryModel UpdateYpermissionModulesQuery(IYpermissionModulesEntity YpermissionModules);
        public QueryModel UpdateDescription(IYpermissionModulesEntity entity);
        public QueryModel DeleteYpermissionModulesQuery(IYpermissionModulesEntity YpermissionModules);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration