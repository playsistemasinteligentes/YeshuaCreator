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
    public class yTenantApplicationQueryWrite : QueryBase, IyTenantApplicationQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public yTenantApplicationQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InseriryTenantApplicationQuery(IyTenantApplicationEntity yTenantApplication)
        {
            this.Query = $@" INSERT INTO [yTenantApplication] ([ApplicationKey], [TenantID], [ValidUntil], [OperationalEntityId], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@ApplicationKey, @TenantID, @ValidUntil, @OperationalEntityId, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ApplicationKey = yTenantApplication.ApplicationKey,
                TenantID = _executionContext.TenantID,
                ValidUntil = yTenantApplication.ValidUntil,
                OperationalEntityId = yTenantApplication.OperationalEntityId,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyTenantApplicationQuery(IyTenantApplicationEntity yTenantApplication)
        {
            this.Query = $@" UPDATE [yTenantApplication] SET [ApplicationKey] = @ApplicationKey, [ValidUntil] = @ValidUntil, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ApplicationKey = yTenantApplication.ApplicationKey,
                ValidUntil = yTenantApplication.ValidUntil,
                Changed = yTenantApplication.Changed,
                UserId = _executionContext.UserId,
                Id = yTenantApplication.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateApplicationKey(int id, string value)
        {
            this.Query = $@" UPDATE [yTenantApplication] SET [ApplicationKey] = @ApplicationKey WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ApplicationKey = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [yTenantApplication] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValidUntil(int id, DateTime value)
        {
            this.Query = $@" UPDATE [yTenantApplication] SET [ValidUntil] = @ValidUntil WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ValidUntil = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOperationalEntityId(int id, string value)
        {
            this.Query = $@" UPDATE [yTenantApplication] SET [OperationalEntityId] = @OperationalEntityId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                OperationalEntityId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [yTenantApplication] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [yTenantApplication] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [yTenantApplication] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyTenantApplicationQuery(IyTenantApplicationEntity yTenantApplication)
        {
            this.Query = $@" DELETE FROM [yTenantApplication] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = yTenantApplication.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration