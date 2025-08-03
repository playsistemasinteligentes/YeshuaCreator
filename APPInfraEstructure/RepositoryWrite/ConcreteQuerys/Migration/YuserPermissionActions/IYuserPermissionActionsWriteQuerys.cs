using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IYuserPermissionActionsQueryWrite 
     {
        public QueryModel InserirYuserPermissionActionsQuery(IYuserPermissionActionsEntity YuserPermissionActions);
        public QueryModel UpdateYuserPermissionActionsQuery(IYuserPermissionActionsEntity YuserPermissionActions);
        public QueryModel UpdatePerfilId(IYuserPermissionActionsEntity entity);
        public QueryModel UpdatepermissionActionsId(IYuserPermissionActionsEntity entity);
        public QueryModel UpdateGrant(IYuserPermissionActionsEntity entity);
        public QueryModel UpdateCreate(IYuserPermissionActionsEntity entity);
        public QueryModel UpdateRead(IYuserPermissionActionsEntity entity);
        public QueryModel UpdateUpdate(IYuserPermissionActionsEntity entity);
        public QueryModel UpdateDelete(IYuserPermissionActionsEntity entity);
        public QueryModel UpdateValidUntil(IYuserPermissionActionsEntity entity);
        public QueryModel DeleteYuserPermissionActionsQuery(IYuserPermissionActionsEntity YuserPermissionActions);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration