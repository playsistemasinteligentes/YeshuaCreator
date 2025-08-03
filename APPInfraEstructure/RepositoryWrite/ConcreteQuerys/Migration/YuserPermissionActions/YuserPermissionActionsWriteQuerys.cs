using Dominio.Entitys;
using Shered.DB;
using Command.Write;
using IQuery.Write;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Write
{
    public class YuserPermissionActionsQueryWrite : QueryBase, IYuserPermissionActionsQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public YuserPermissionActionsQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InserirYuserPermissionActionsQuery(IYuserPermissionActionsEntity YuserPermissionActions)
        {
            this.Query = $@" INSERT INTO YuserPermissionActions (PerfilId, permissionActionsId, Grant, Create, Read, Update, Delete, ValidUntil, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.ID VALUES(@PerfilId, @permissionActionsId, @Grant, @Create, @Read, @Update, @Delete, @ValidUntil, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PerfilId = YuserPermissionActions.PerfilId,
                permissionActionsId = YuserPermissionActions.permissionActionsId,
                Grant = YuserPermissionActions.Grant,
                Create = YuserPermissionActions.Create,
                Read = YuserPermissionActions.Read,
                Update = YuserPermissionActions.Update,
                Delete = YuserPermissionActions.Delete,
                ValidUntil = YuserPermissionActions.ValidUntil,
                TenantID = _correntUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _correntUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYuserPermissionActionsQuery(IYuserPermissionActionsEntity YuserPermissionActions)
        {
            this.Query = $@" UPDATE YuserPermissionActions SET PerfilId = @PerfilId, permissionActionsId = @permissionActionsId, Grant = @Grant, Create = @Create, Read = @Read, Update = @Update, Delete = @Delete, ValidUntil = @ValidUntil WHERE  ";
            this.Parameters = new
            {
                PerfilId = YuserPermissionActions.PerfilId,
                permissionActionsId = YuserPermissionActions.permissionActionsId,
                Grant = YuserPermissionActions.Grant,
                Create = YuserPermissionActions.Create,
                Read = YuserPermissionActions.Read,
                Update = YuserPermissionActions.Update,
                Delete = YuserPermissionActions.Delete,
                ValidUntil = YuserPermissionActions.ValidUntil,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePerfilId(IYuserPermissionActionsEntity entity)
        {
            this.Query = $@" UPDATE YuserPermissionActions SET PerfilId = @PerfilId WHERE  ";
            this.Parameters = new
            {
                PerfilId = entity.PerfilId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatepermissionActionsId(IYuserPermissionActionsEntity entity)
        {
            this.Query = $@" UPDATE YuserPermissionActions SET permissionActionsId = @permissionActionsId WHERE  ";
            this.Parameters = new
            {
                permissionActionsId = entity.permissionActionsId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrant(IYuserPermissionActionsEntity entity)
        {
            this.Query = $@" UPDATE YuserPermissionActions SET Grant = @Grant WHERE  ";
            this.Parameters = new
            {
                Grant = entity.Grant,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCreate(IYuserPermissionActionsEntity entity)
        {
            this.Query = $@" UPDATE YuserPermissionActions SET Create = @Create WHERE  ";
            this.Parameters = new
            {
                Create = entity.Create,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRead(IYuserPermissionActionsEntity entity)
        {
            this.Query = $@" UPDATE YuserPermissionActions SET Read = @Read WHERE  ";
            this.Parameters = new
            {
                Read = entity.Read,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUpdate(IYuserPermissionActionsEntity entity)
        {
            this.Query = $@" UPDATE YuserPermissionActions SET Update = @Update WHERE  ";
            this.Parameters = new
            {
                Update = entity.Update,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDelete(IYuserPermissionActionsEntity entity)
        {
            this.Query = $@" UPDATE YuserPermissionActions SET Delete = @Delete WHERE  ";
            this.Parameters = new
            {
                Delete = entity.Delete,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValidUntil(IYuserPermissionActionsEntity entity)
        {
            this.Query = $@" UPDATE YuserPermissionActions SET ValidUntil = @ValidUntil WHERE  ";
            this.Parameters = new
            {
                ValidUntil = entity.ValidUntil,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteYuserPermissionActionsQuery(IYuserPermissionActionsEntity YuserPermissionActions)
        {
            this.Query = $@" DELETE FROM YuserPermissionActions WHERE  ";
            this.Parameters = new
            {
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration