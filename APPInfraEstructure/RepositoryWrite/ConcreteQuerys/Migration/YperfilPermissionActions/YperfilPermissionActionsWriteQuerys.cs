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
    public class YperfilPermissionActionsQueryWrite : QueryBase, IYperfilPermissionActionsQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public YperfilPermissionActionsQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InserirYperfilPermissionActionsQuery(IYperfilPermissionActionsEntity YperfilPermissionActions)
        {
            this.Query = $@" INSERT INTO YperfilPermissionActions (PerfilId, permissionActionsId, Grant, Create, Read, Update, Delete, ValidUntil, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.ID VALUES(@PerfilId, @permissionActionsId, @Grant, @Create, @Read, @Update, @Delete, @ValidUntil, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PerfilId = YperfilPermissionActions.PerfilId,
                permissionActionsId = YperfilPermissionActions.permissionActionsId,
                Grant = YperfilPermissionActions.Grant,
                Create = YperfilPermissionActions.Create,
                Read = YperfilPermissionActions.Read,
                Update = YperfilPermissionActions.Update,
                Delete = YperfilPermissionActions.Delete,
                ValidUntil = YperfilPermissionActions.ValidUntil,
                TenantID = _correntUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _correntUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYperfilPermissionActionsQuery(IYperfilPermissionActionsEntity YperfilPermissionActions)
        {
            this.Query = $@" UPDATE YperfilPermissionActions SET PerfilId = @PerfilId, permissionActionsId = @permissionActionsId, Grant = @Grant, Create = @Create, Read = @Read, Update = @Update, Delete = @Delete, ValidUntil = @ValidUntil WHERE  ";
            this.Parameters = new
            {
                PerfilId = YperfilPermissionActions.PerfilId,
                permissionActionsId = YperfilPermissionActions.permissionActionsId,
                Grant = YperfilPermissionActions.Grant,
                Create = YperfilPermissionActions.Create,
                Read = YperfilPermissionActions.Read,
                Update = YperfilPermissionActions.Update,
                Delete = YperfilPermissionActions.Delete,
                ValidUntil = YperfilPermissionActions.ValidUntil,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePerfilId(IYperfilPermissionActionsEntity entity)
        {
            this.Query = $@" UPDATE YperfilPermissionActions SET PerfilId = @PerfilId WHERE  ";
            this.Parameters = new
            {
                PerfilId = entity.PerfilId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatepermissionActionsId(IYperfilPermissionActionsEntity entity)
        {
            this.Query = $@" UPDATE YperfilPermissionActions SET permissionActionsId = @permissionActionsId WHERE  ";
            this.Parameters = new
            {
                permissionActionsId = entity.permissionActionsId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrant(IYperfilPermissionActionsEntity entity)
        {
            this.Query = $@" UPDATE YperfilPermissionActions SET Grant = @Grant WHERE  ";
            this.Parameters = new
            {
                Grant = entity.Grant,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCreate(IYperfilPermissionActionsEntity entity)
        {
            this.Query = $@" UPDATE YperfilPermissionActions SET Create = @Create WHERE  ";
            this.Parameters = new
            {
                Create = entity.Create,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRead(IYperfilPermissionActionsEntity entity)
        {
            this.Query = $@" UPDATE YperfilPermissionActions SET Read = @Read WHERE  ";
            this.Parameters = new
            {
                Read = entity.Read,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUpdate(IYperfilPermissionActionsEntity entity)
        {
            this.Query = $@" UPDATE YperfilPermissionActions SET Update = @Update WHERE  ";
            this.Parameters = new
            {
                Update = entity.Update,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDelete(IYperfilPermissionActionsEntity entity)
        {
            this.Query = $@" UPDATE YperfilPermissionActions SET Delete = @Delete WHERE  ";
            this.Parameters = new
            {
                Delete = entity.Delete,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValidUntil(IYperfilPermissionActionsEntity entity)
        {
            this.Query = $@" UPDATE YperfilPermissionActions SET ValidUntil = @ValidUntil WHERE  ";
            this.Parameters = new
            {
                ValidUntil = entity.ValidUntil,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteYperfilPermissionActionsQuery(IYperfilPermissionActionsEntity YperfilPermissionActions)
        {
            this.Query = $@" DELETE FROM YperfilPermissionActions WHERE  ";
            this.Parameters = new
            {
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration