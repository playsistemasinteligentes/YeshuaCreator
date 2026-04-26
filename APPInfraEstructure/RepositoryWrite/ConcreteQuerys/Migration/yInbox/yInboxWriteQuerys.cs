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
    public class yInboxQueryWrite : QueryBase, IyInboxQueryWrite
    {
        protected readonly ICurrentUser _currentUser;
        public yInboxQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InseriryInboxQuery(IyInboxEntity yInbox)
        {
            this.Query = $@" INSERT INTO yInbox (MessageId, Type, EntityType, EntityId, CorrelationId, Payload, Status, CreatedAt, RetryCount, LastError, ProcessingAt, NextAttemptAt, SagaId, SagaStepId, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@MessageId, @Type, @EntityType, @EntityId, @CorrelationId, @Payload, @Status, @CreatedAt, @RetryCount, @LastError, @ProcessingAt, @NextAttemptAt, @SagaId, @SagaStepId, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MessageId = yInbox.MessageId,
                Type = yInbox.Type,
                EntityType = yInbox.EntityType,
                EntityId = yInbox.EntityId,
                CorrelationId = yInbox.CorrelationId,
                Payload = yInbox.Payload,
                Status = yInbox.Status,
                CreatedAt = yInbox.CreatedAt,
                RetryCount = yInbox.RetryCount,
                LastError = yInbox.LastError,
                ProcessingAt = yInbox.ProcessingAt,
                NextAttemptAt = yInbox.NextAttemptAt,
                SagaId = yInbox.SagaId,
                SagaStepId = yInbox.SagaStepId,
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyInboxQuery(IyInboxEntity yInbox)
        {
            this.Query = $@" UPDATE yInbox SET MessageId = @MessageId, Type = @Type, EntityType = @EntityType, EntityId = @EntityId, CorrelationId = @CorrelationId, Payload = @Payload, Status = @Status, CreatedAt = @CreatedAt, RetryCount = @RetryCount, LastError = @LastError, ProcessingAt = @ProcessingAt, NextAttemptAt = @NextAttemptAt, SagaId = @SagaId, SagaStepId = @SagaStepId, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                MessageId = yInbox.MessageId,
                Type = yInbox.Type,
                EntityType = yInbox.EntityType,
                EntityId = yInbox.EntityId,
                CorrelationId = yInbox.CorrelationId,
                Payload = yInbox.Payload,
                Status = yInbox.Status,
                CreatedAt = yInbox.CreatedAt,
                RetryCount = yInbox.RetryCount,
                LastError = yInbox.LastError,
                ProcessingAt = yInbox.ProcessingAt,
                NextAttemptAt = yInbox.NextAttemptAt,
                SagaId = yInbox.SagaId,
                SagaStepId = yInbox.SagaStepId,
                Changed = yInbox.Changed,
                UserId = _currentUser.UserId,
                Id = yInbox.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMessageId(IyInboxEntity entity)
        {
            this.Query = $@" UPDATE yInbox SET MessageId = @MessageId WHERE Id = @Id ";
            this.Parameters = new
            {
                MessageId = entity.MessageId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateType(IyInboxEntity entity)
        {
            this.Query = $@" UPDATE yInbox SET Type = @Type WHERE Id = @Id ";
            this.Parameters = new
            {
                Type = entity.Type,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEntityType(IyInboxEntity entity)
        {
            this.Query = $@" UPDATE yInbox SET EntityType = @EntityType WHERE Id = @Id ";
            this.Parameters = new
            {
                EntityType = entity.EntityType,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEntityId(IyInboxEntity entity)
        {
            this.Query = $@" UPDATE yInbox SET EntityId = @EntityId WHERE Id = @Id ";
            this.Parameters = new
            {
                EntityId = entity.EntityId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(IyInboxEntity entity)
        {
            this.Query = $@" UPDATE yInbox SET CorrelationId = @CorrelationId WHERE Id = @Id ";
            this.Parameters = new
            {
                CorrelationId = entity.CorrelationId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePayload(IyInboxEntity entity)
        {
            this.Query = $@" UPDATE yInbox SET Payload = @Payload WHERE Id = @Id ";
            this.Parameters = new
            {
                Payload = entity.Payload,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(IyInboxEntity entity)
        {
            this.Query = $@" UPDATE yInbox SET Status = @Status WHERE Id = @Id ";
            this.Parameters = new
            {
                Status = entity.Status,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCreatedAt(IyInboxEntity entity)
        {
            this.Query = $@" UPDATE yInbox SET CreatedAt = @CreatedAt WHERE Id = @Id ";
            this.Parameters = new
            {
                CreatedAt = entity.CreatedAt,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRetryCount(IyInboxEntity entity)
        {
            this.Query = $@" UPDATE yInbox SET RetryCount = @RetryCount WHERE Id = @Id ";
            this.Parameters = new
            {
                RetryCount = entity.RetryCount,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLastError(IyInboxEntity entity)
        {
            this.Query = $@" UPDATE yInbox SET LastError = @LastError WHERE Id = @Id ";
            this.Parameters = new
            {
                LastError = entity.LastError,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProcessingAt(IyInboxEntity entity)
        {
            this.Query = $@" UPDATE yInbox SET ProcessingAt = @ProcessingAt WHERE Id = @Id ";
            this.Parameters = new
            {
                ProcessingAt = entity.ProcessingAt,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNextAttemptAt(IyInboxEntity entity)
        {
            this.Query = $@" UPDATE yInbox SET NextAttemptAt = @NextAttemptAt WHERE Id = @Id ";
            this.Parameters = new
            {
                NextAttemptAt = entity.NextAttemptAt,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSagaId(IyInboxEntity entity)
        {
            this.Query = $@" UPDATE yInbox SET SagaId = @SagaId WHERE Id = @Id ";
            this.Parameters = new
            {
                SagaId = entity.SagaId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSagaStepId(IyInboxEntity entity)
        {
            this.Query = $@" UPDATE yInbox SET SagaStepId = @SagaStepId WHERE Id = @Id ";
            this.Parameters = new
            {
                SagaStepId = entity.SagaStepId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IyInboxEntity entity)
        {
            this.Query = $@" UPDATE yInbox SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IyInboxEntity entity)
        {
            this.Query = $@" UPDATE yInbox SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IyInboxEntity entity)
        {
            this.Query = $@" UPDATE yInbox SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IyInboxEntity entity)
        {
            this.Query = $@" UPDATE yInbox SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyInboxQuery(IyInboxEntity yInbox)
        {
            this.Query = $@" DELETE FROM yInbox WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = yInbox.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration