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
    public class yConfigArctetureQueryWrite : QueryBase, IyConfigArctetureQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public yConfigArctetureQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InseriryConfigArctetureQuery(IyConfigArctetureEntity yConfigArcteture)
        {
            this.Query = $@" INSERT INTO [yConfigArcteture] ([Id], [AuditTrackerActived], [AuditCRUDActived], [TenantID], [Deleted], [Changed], [UserId]) VALUES(@Id, @AuditTrackerActived, @AuditCRUDActived, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Id = yConfigArcteture.Id,
                AuditTrackerActived = yConfigArcteture.AuditTrackerActived,
                AuditCRUDActived = yConfigArcteture.AuditCRUDActived,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyConfigArctetureQuery(IyConfigArctetureEntity yConfigArcteture)
        {
            this.Query = $@" UPDATE [yConfigArcteture] SET [AuditTrackerActived] = @AuditTrackerActived, [AuditCRUDActived] = @AuditCRUDActived, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                AuditTrackerActived = yConfigArcteture.AuditTrackerActived,
                AuditCRUDActived = yConfigArcteture.AuditCRUDActived,
                Changed = yConfigArcteture.Changed,
                UserId = _executionContext.UserId,
                Id = yConfigArcteture.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAuditTrackerActived(int id, int value)
        {
            this.Query = $@" UPDATE [yConfigArcteture] SET [AuditTrackerActived] = @AuditTrackerActived WHERE [Id] = @Id ";
            this.Parameters = new
            {
                AuditTrackerActived = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAuditCRUDActived(int id, int value)
        {
            this.Query = $@" UPDATE [yConfigArcteture] SET [AuditCRUDActived] = @AuditCRUDActived WHERE [Id] = @Id ";
            this.Parameters = new
            {
                AuditCRUDActived = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [yConfigArcteture] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [yConfigArcteture] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [yConfigArcteture] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [yConfigArcteture] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyConfigArctetureQuery(IyConfigArctetureEntity yConfigArcteture)
        {
            this.Query = $@" DELETE FROM [yConfigArcteture] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = yConfigArcteture.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration