// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

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
        protected readonly IExecutionContext _executionContext;
        public yUserModuleQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InseriryUserModuleQuery(IyUserModuleEntity yUserModule)
        {
            this.Query = $@" INSERT INTO yUserModule (ModuleId, UserId, ValidUntil, TenantID, Deleted, Changed) OUTPUT INSERTED.Id VALUES(@ModuleId, @UserId, @ValidUntil, @TenantID, @Deleted, @Changed) ";
            this.Parameters = new
            {
                ModuleId = yUserModule.ModuleId,
                UserId = yUserModule.UserId,
                ValidUntil = yUserModule.ValidUntil,
                TenantID = _executionContext.TenantID,
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
                UserId = _executionContext.UserId,
                ValidUntil = yUserModule.ValidUntil,
                Changed = yUserModule.Changed,
                Id = yUserModule.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateModuleId(int id, string value)
        {
            this.Query = $@" UPDATE yUserModule SET ModuleId = @ModuleId WHERE Id = @Id ";
            this.Parameters = new
            {
                ModuleId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE yUserModule SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValidUntil(int id, DateTime value)
        {
            this.Query = $@" UPDATE yUserModule SET ValidUntil = @ValidUntil WHERE Id = @Id ";
            this.Parameters = new
            {
                ValidUntil = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE yUserModule SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE yUserModule SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE yUserModule SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
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