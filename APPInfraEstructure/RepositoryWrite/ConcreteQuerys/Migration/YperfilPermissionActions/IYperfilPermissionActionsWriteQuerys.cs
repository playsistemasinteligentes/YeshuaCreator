using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IYperfilPermissionActionsQueryWrite 
     {
        public QueryModel InserirYperfilPermissionActionsQuery(IYperfilPermissionActionsEntity YperfilPermissionActions);
        public QueryModel UpdateYperfilPermissionActionsQuery(IYperfilPermissionActionsEntity YperfilPermissionActions);
        public QueryModel UpdatePerfilId(IYperfilPermissionActionsEntity entity);
        public QueryModel UpdatepermissionActionsId(IYperfilPermissionActionsEntity entity);
        public QueryModel UpdateGrant(IYperfilPermissionActionsEntity entity);
        public QueryModel UpdateCreate(IYperfilPermissionActionsEntity entity);
        public QueryModel UpdateRead(IYperfilPermissionActionsEntity entity);
        public QueryModel UpdateUpdate(IYperfilPermissionActionsEntity entity);
        public QueryModel UpdateDelete(IYperfilPermissionActionsEntity entity);
        public QueryModel UpdateValidUntil(IYperfilPermissionActionsEntity entity);
        public QueryModel DeleteYperfilPermissionActionsQuery(IYperfilPermissionActionsEntity YperfilPermissionActions);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration