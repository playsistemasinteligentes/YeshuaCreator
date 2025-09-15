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
    public class yUserModuleQueryWrite : QueryBase, IyUserModuleQueryWrite
    {
        protected readonly ICurrentUser _currentUser;
        public yUserModuleQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InseriryUserModuleQuery(IyUserModuleEntity yUserModule)
        {
            this.Query = $@" INSERT INTO yUserModule (ModuleId, UserId, ValidUntil, TenantID, Deleted, Changed) OUTPUT INSERTED.Id VALUES(@ModuleId, @UserId, @ValidUntil, @TenantID, @Deleted, @Changed) ";
            this.Parameters = new
            {
                ModuleId = yUserModule.ModuleId,
                UserId = yUserModule.UserId,
                ValidUntil = yUserModule.ValidUntil,
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyUserModuleQuery(IyUserModuleEntity yUserModule)
        {
            this.Query = $@" UPDATE yUserModule SET ModuleId = @ModuleId, UserId = @UserId, ValidUntil = @ValidUntil, Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                ModuleId = yUserModule.ModuleId,
                UserId = _currentUser.UserId,
                ValidUntil = yUserModule.ValidUntil,
                Changed = yUserModule.Changed,
                Id = yUserModule.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateModuleId(IyUserModuleEntity entity)
        {
            this.Query = $@" UPDATE yUserModule SET ModuleId = @ModuleId WHERE Id = @Id ";
            this.Parameters = new
            {
                ModuleId = entity.ModuleId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IyUserModuleEntity entity)
        {
            this.Query = $@" UPDATE yUserModule SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValidUntil(IyUserModuleEntity entity)
        {
            this.Query = $@" UPDATE yUserModule SET ValidUntil = @ValidUntil WHERE Id = @Id ";
            this.Parameters = new
            {
                ValidUntil = entity.ValidUntil,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IyUserModuleEntity entity)
        {
            this.Query = $@" UPDATE yUserModule SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IyUserModuleEntity entity)
        {
            this.Query = $@" UPDATE yUserModule SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IyUserModuleEntity entity)
        {
            this.Query = $@" UPDATE yUserModule SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyUserModuleQuery(IyUserModuleEntity yUserModule)
        {
            this.Query = $@" DELETE FROM yUserModule WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = yUserModule.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration