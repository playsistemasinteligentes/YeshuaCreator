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
    public class ySagaQueryWrite : QueryBase, IySagaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ySagaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirySagaQuery(IySagaEntity ySaga)
        {
            this.Query = $@" INSERT INTO [ySaga] ([CorrelationId], [Type], [Status], [KeyCurrentStep], [CreatedAt], [CompletedAt], [EntityType], [EntityId], [NextExecutionAt], [LockedAt], [LockedBy], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@CorrelationId, @Type, @Status, @KeyCurrentStep, @CreatedAt, @CompletedAt, @EntityType, @EntityId, @NextExecutionAt, @LockedAt, @LockedBy, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CorrelationId = ySaga.CorrelationId,
                Type = ySaga.Type,
                Status = ySaga.Status,
                KeyCurrentStep = ySaga.KeyCurrentStep,
                CreatedAt = ySaga.CreatedAt,
                CompletedAt = ySaga.CompletedAt,
                EntityType = ySaga.EntityType,
                EntityId = ySaga.EntityId,
                NextExecutionAt = ySaga.NextExecutionAt,
                LockedAt = ySaga.LockedAt,
                LockedBy = ySaga.LockedBy,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateySagaQuery(IySagaEntity ySaga)
        {
            this.Query = $@" UPDATE [ySaga] SET [CorrelationId] = @CorrelationId, [Type] = @Type, [Status] = @Status, [KeyCurrentStep] = @KeyCurrentStep, [CreatedAt] = @CreatedAt, [CompletedAt] = @CompletedAt, [EntityType] = @EntityType, [EntityId] = @EntityId, [NextExecutionAt] = @NextExecutionAt, [LockedAt] = @LockedAt, [LockedBy] = @LockedBy, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CorrelationId = ySaga.CorrelationId,
                Type = ySaga.Type,
                Status = ySaga.Status,
                KeyCurrentStep = ySaga.KeyCurrentStep,
                CreatedAt = ySaga.CreatedAt,
                CompletedAt = ySaga.CompletedAt,
                EntityType = ySaga.EntityType,
                EntityId = ySaga.EntityId,
                NextExecutionAt = ySaga.NextExecutionAt,
                LockedAt = ySaga.LockedAt,
                LockedBy = ySaga.LockedBy,
                Changed = ySaga.Changed,
                UserId = _executionContext.UserId,
                Id = ySaga.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(int id, string value)
        {
            this.Query = $@" UPDATE [ySaga] SET [CorrelationId] = @CorrelationId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CorrelationId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateType(int id, string value)
        {
            this.Query = $@" UPDATE [ySaga] SET [Type] = @Type WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Type = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE [ySaga] SET [Status] = @Status WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateKeyCurrentStep(int id, string value)
        {
            this.Query = $@" UPDATE [ySaga] SET [KeyCurrentStep] = @KeyCurrentStep WHERE [Id] = @Id ";
            this.Parameters = new
            {
                KeyCurrentStep = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCreatedAt(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ySaga] SET [CreatedAt] = @CreatedAt WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CreatedAt = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCompletedAt(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ySaga] SET [CompletedAt] = @CompletedAt WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CompletedAt = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEntityType(int id, string value)
        {
            this.Query = $@" UPDATE [ySaga] SET [EntityType] = @EntityType WHERE [Id] = @Id ";
            this.Parameters = new
            {
                EntityType = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEntityId(int id, string value)
        {
            this.Query = $@" UPDATE [ySaga] SET [EntityId] = @EntityId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                EntityId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNextExecutionAt(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ySaga] SET [NextExecutionAt] = @NextExecutionAt WHERE [Id] = @Id ";
            this.Parameters = new
            {
                NextExecutionAt = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLockedAt(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ySaga] SET [LockedAt] = @LockedAt WHERE [Id] = @Id ";
            this.Parameters = new
            {
                LockedAt = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLockedBy(int id, string value)
        {
            this.Query = $@" UPDATE [ySaga] SET [LockedBy] = @LockedBy WHERE [Id] = @Id ";
            this.Parameters = new
            {
                LockedBy = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [ySaga] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [ySaga] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ySaga] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [ySaga] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteySagaQuery(IySagaEntity ySaga)
        {
            this.Query = $@" DELETE FROM [ySaga] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = ySaga.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration