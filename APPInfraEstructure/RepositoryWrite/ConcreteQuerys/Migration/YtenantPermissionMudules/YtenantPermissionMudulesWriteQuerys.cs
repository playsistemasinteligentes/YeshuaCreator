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
    public class YtenantPermissionMudulesQueryWrite : QueryBase, IYtenantPermissionMudulesQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public YtenantPermissionMudulesQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InserirYtenantPermissionMudulesQuery(IYtenantPermissionMudulesEntity YtenantPermissionMudules)
        {
            this.Query = $@" INSERT INTO YtenantPermissionMudules (permissionModulesId, TenantID, ValidUntil, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@permissionModulesId, @TenantID, @ValidUntil, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                permissionModulesId = YtenantPermissionMudules.permissionModulesId,
                TenantID = YtenantPermissionMudules.TenantID,
                ValidUntil = YtenantPermissionMudules.ValidUntil,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _correntUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYtenantPermissionMudulesQuery(IYtenantPermissionMudulesEntity YtenantPermissionMudules)
        {
            this.Query = $@" UPDATE YtenantPermissionMudules SET permissionModulesId = @permissionModulesId, TenantID = @TenantID, ValidUntil = @ValidUntil WHERE Id = @Id ";
            this.Parameters = new
            {
                permissionModulesId = YtenantPermissionMudules.permissionModulesId,
                TenantID = YtenantPermissionMudules.TenantID,
                ValidUntil = YtenantPermissionMudules.ValidUntil,
                Id = YtenantPermissionMudules.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatepermissionModulesId(IYtenantPermissionMudulesEntity entity)
        {
            this.Query = $@" UPDATE YtenantPermissionMudules SET permissionModulesId = @permissionModulesId WHERE Id = @Id ";
            this.Parameters = new
            {
                permissionModulesId = entity.permissionModulesId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IYtenantPermissionMudulesEntity entity)
        {
            this.Query = $@" UPDATE YtenantPermissionMudules SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValidUntil(IYtenantPermissionMudulesEntity entity)
        {
            this.Query = $@" UPDATE YtenantPermissionMudules SET ValidUntil = @ValidUntil WHERE Id = @Id ";
            this.Parameters = new
            {
                ValidUntil = entity.ValidUntil,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteYtenantPermissionMudulesQuery(IYtenantPermissionMudulesEntity YtenantPermissionMudules)
        {
            this.Query = $@" DELETE FROM YtenantPermissionMudules WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = YtenantPermissionMudules.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration