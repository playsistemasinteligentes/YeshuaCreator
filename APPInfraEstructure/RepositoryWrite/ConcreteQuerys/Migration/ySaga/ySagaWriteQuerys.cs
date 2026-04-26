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
        protected readonly ICurrentUser _currentUser;
        public ySagaQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InserirySagaQuery(IySagaEntity ySaga)
        {
            this.Query = $@" INSERT INTO ySaga (CorrelationId, Type, Status, KeyCurrentStep, CreatedAt, CompletedAt, EntityType, EntityId, NextExecutionAt, LockedAt, LockedBy, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@CorrelationId, @Type, @Status, @KeyCurrentStep, @CreatedAt, @CompletedAt, @EntityType, @EntityId, @NextExecutionAt, @LockedAt, @LockedBy, @TenantID, @Deleted, @Changed, @UserId) ";
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
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateySagaQuery(IySagaEntity ySaga)
        {
            this.Query = $@" UPDATE ySaga SET CorrelationId = @CorrelationId, Type = @Type, Status = @Status, KeyCurrentStep = @KeyCurrentStep, CreatedAt = @CreatedAt, CompletedAt = @CompletedAt, EntityType = @EntityType, EntityId = @EntityId, NextExecutionAt = @NextExecutionAt, LockedAt = @LockedAt, LockedBy = @LockedBy, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
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
                UserId = _currentUser.UserId,
                Id = ySaga.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(IySagaEntity entity)
        {
            this.Query = $@" UPDATE ySaga SET CorrelationId = @CorrelationId WHERE Id = @Id ";
            this.Parameters = new
            {
                CorrelationId = entity.CorrelationId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateType(IySagaEntity entity)
        {
            this.Query = $@" UPDATE ySaga SET Type = @Type WHERE Id = @Id ";
            this.Parameters = new
            {
                Type = entity.Type,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(IySagaEntity entity)
        {
            this.Query = $@" UPDATE ySaga SET Status = @Status WHERE Id = @Id ";
            this.Parameters = new
            {
                Status = entity.Status,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateKeyCurrentStep(IySagaEntity entity)
        {
            this.Query = $@" UPDATE ySaga SET KeyCurrentStep = @KeyCurrentStep WHERE Id = @Id ";
            this.Parameters = new
            {
                KeyCurrentStep = entity.KeyCurrentStep,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCreatedAt(IySagaEntity entity)
        {
            this.Query = $@" UPDATE ySaga SET CreatedAt = @CreatedAt WHERE Id = @Id ";
            this.Parameters = new
            {
                CreatedAt = entity.CreatedAt,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCompletedAt(IySagaEntity entity)
        {
            this.Query = $@" UPDATE ySaga SET CompletedAt = @CompletedAt WHERE Id = @Id ";
            this.Parameters = new
            {
                CompletedAt = entity.CompletedAt,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEntityType(IySagaEntity entity)
        {
            this.Query = $@" UPDATE ySaga SET EntityType = @EntityType WHERE Id = @Id ";
            this.Parameters = new
            {
                EntityType = entity.EntityType,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEntityId(IySagaEntity entity)
        {
            this.Query = $@" UPDATE ySaga SET EntityId = @EntityId WHERE Id = @Id ";
            this.Parameters = new
            {
                EntityId = entity.EntityId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNextExecutionAt(IySagaEntity entity)
        {
            this.Query = $@" UPDATE ySaga SET NextExecutionAt = @NextExecutionAt WHERE Id = @Id ";
            this.Parameters = new
            {
                NextExecutionAt = entity.NextExecutionAt,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLockedAt(IySagaEntity entity)
        {
            this.Query = $@" UPDATE ySaga SET LockedAt = @LockedAt WHERE Id = @Id ";
            this.Parameters = new
            {
                LockedAt = entity.LockedAt,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLockedBy(IySagaEntity entity)
        {
            this.Query = $@" UPDATE ySaga SET LockedBy = @LockedBy WHERE Id = @Id ";
            this.Parameters = new
            {
                LockedBy = entity.LockedBy,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IySagaEntity entity)
        {
            this.Query = $@" UPDATE ySaga SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IySagaEntity entity)
        {
            this.Query = $@" UPDATE ySaga SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IySagaEntity entity)
        {
            this.Query = $@" UPDATE ySaga SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IySagaEntity entity)
        {
            this.Query = $@" UPDATE ySaga SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteySagaQuery(IySagaEntity ySaga)
        {
            this.Query = $@" DELETE FROM ySaga WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = ySaga.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration