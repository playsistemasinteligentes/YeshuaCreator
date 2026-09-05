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
    public class yTenantModuleQueryWrite : QueryBase, IyTenantModuleQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public yTenantModuleQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InseriryTenantModuleQuery(IyTenantModuleEntity yTenantModule)
        {
            this.Query = $@" INSERT INTO [yTenantModule] ([ModuleId], [TenantID], [ValidUntil], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@ModuleId, @TenantID, @ValidUntil, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ModuleId = yTenantModule.ModuleId,
                TenantID = _executionContext.TenantID,
                ValidUntil = yTenantModule.ValidUntil,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyTenantModuleQuery(IyTenantModuleEntity yTenantModule)
        {
            this.Query = $@" UPDATE [yTenantModule] SET [ModuleId] = @ModuleId, [ValidUntil] = @ValidUntil, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ModuleId = yTenantModule.ModuleId,
                ValidUntil = yTenantModule.ValidUntil,
                Changed = yTenantModule.Changed,
                UserId = _executionContext.UserId,
                Id = yTenantModule.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateModuleId(int id, string value)
        {
            this.Query = $@" UPDATE [yTenantModule] SET [ModuleId] = @ModuleId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ModuleId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [yTenantModule] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValidUntil(int id, DateTime value)
        {
            this.Query = $@" UPDATE [yTenantModule] SET [ValidUntil] = @ValidUntil WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ValidUntil = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [yTenantModule] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [yTenantModule] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [yTenantModule] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyTenantModuleQuery(IyTenantModuleEntity yTenantModule)
        {
            this.Query = $@" DELETE FROM [yTenantModule] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = yTenantModule.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration