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
    public class yTenantModuleQueryWrite : QueryBase, IyTenantModuleQueryWrite
    {
        protected readonly ICurrentUser _currentUser;
        public yTenantModuleQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InseriryTenantModuleQuery(IyTenantModuleEntity yTenantModule)
        {
            this.Query = $@" INSERT INTO yTenantModule (ModuleId, TenantID, ValidUntil, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@ModuleId, @TenantID, @ValidUntil, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ModuleId = yTenantModule.ModuleId,
                TenantID = _currentUser.TenantID,
                ValidUntil = yTenantModule.ValidUntil,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyTenantModuleQuery(IyTenantModuleEntity yTenantModule)
        {
            this.Query = $@" UPDATE yTenantModule SET ModuleId = @ModuleId, ValidUntil = @ValidUntil, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                ModuleId = yTenantModule.ModuleId,
                ValidUntil = yTenantModule.ValidUntil,
                Changed = yTenantModule.Changed,
                UserId = _currentUser.UserId,
                Id = yTenantModule.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateModuleId(IyTenantModuleEntity entity)
        {
            this.Query = $@" UPDATE yTenantModule SET ModuleId = @ModuleId WHERE Id = @Id ";
            this.Parameters = new
            {
                ModuleId = entity.ModuleId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IyTenantModuleEntity entity)
        {
            this.Query = $@" UPDATE yTenantModule SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValidUntil(IyTenantModuleEntity entity)
        {
            this.Query = $@" UPDATE yTenantModule SET ValidUntil = @ValidUntil WHERE Id = @Id ";
            this.Parameters = new
            {
                ValidUntil = entity.ValidUntil,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IyTenantModuleEntity entity)
        {
            this.Query = $@" UPDATE yTenantModule SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IyTenantModuleEntity entity)
        {
            this.Query = $@" UPDATE yTenantModule SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IyTenantModuleEntity entity)
        {
            this.Query = $@" UPDATE yTenantModule SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyTenantModuleQuery(IyTenantModuleEntity yTenantModule)
        {
            this.Query = $@" DELETE FROM yTenantModule WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = yTenantModule.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration