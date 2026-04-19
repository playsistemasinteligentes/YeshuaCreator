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
            this.Query = $@" INSERT INTO ySaga (SagaId, Type, Status, KeyCurrentStep, CreatedAt, CompletedAt, EntityType, EntityId, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@SagaId, @Type, @Status, @KeyCurrentStep, @CreatedAt, @CompletedAt, @EntityType, @EntityId, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                SagaId = ySaga.SagaId,
                Type = ySaga.Type,
                Status = ySaga.Status,
                KeyCurrentStep = ySaga.KeyCurrentStep,
                CreatedAt = ySaga.CreatedAt,
                CompletedAt = ySaga.CompletedAt,
                EntityType = ySaga.EntityType,
                EntityId = ySaga.EntityId,
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateySagaQuery(IySagaEntity ySaga)
        {
            this.Query = $@" UPDATE ySaga SET SagaId = @SagaId, Type = @Type, Status = @Status, KeyCurrentStep = @KeyCurrentStep, CreatedAt = @CreatedAt, CompletedAt = @CompletedAt, EntityType = @EntityType, EntityId = @EntityId, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                SagaId = ySaga.SagaId,
                Type = ySaga.Type,
                Status = ySaga.Status,
                KeyCurrentStep = ySaga.KeyCurrentStep,
                CreatedAt = ySaga.CreatedAt,
                CompletedAt = ySaga.CompletedAt,
                EntityType = ySaga.EntityType,
                EntityId = ySaga.EntityId,
                Changed = ySaga.Changed,
                UserId = _currentUser.UserId,
                Id = ySaga.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSagaId(IySagaEntity entity)
        {
            this.Query = $@" UPDATE ySaga SET SagaId = @SagaId WHERE Id = @Id ";
            this.Parameters = new
            {
                SagaId = entity.SagaId,
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