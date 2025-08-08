using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyModuleQueryWrite 
     {
        public QueryModel InseriryModuleQuery(IyModuleEntity yModule);
        public QueryModel UpdateyModuleQuery(IyModuleEntity yModule);
        public QueryModel UpdateDescription(IyModuleEntity entity);
        public QueryModel DeleteyModuleQuery(IyModuleEntity yModule);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration