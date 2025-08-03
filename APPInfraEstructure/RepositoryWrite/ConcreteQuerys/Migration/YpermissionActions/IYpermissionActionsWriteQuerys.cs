using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IYpermissionActionsQueryWrite 
     {
        public QueryModel InserirYpermissionActionsQuery(IYpermissionActionsEntity YpermissionActions);
        public QueryModel UpdateYpermissionActionsQuery(IYpermissionActionsEntity YpermissionActions);
        public QueryModel UpdateDescription(IYpermissionActionsEntity entity);
        public QueryModel DeleteYpermissionActionsQuery(IYpermissionActionsEntity YpermissionActions);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration