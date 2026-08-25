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
    public class yInboxQueryWrite : QueryBase, IyInboxQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public yInboxQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
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
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
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
                UserId = _executionContext.UserId,
                Id = yInbox.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMessageId(int id, string value)
        {
            this.Query = $@" UPDATE yInbox SET MessageId = @MessageId WHERE Id = @Id ";
            this.Parameters = new
            {
                MessageId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateType(int id, string value)
        {
            this.Query = $@" UPDATE yInbox SET Type = @Type WHERE Id = @Id ";
            this.Parameters = new
            {
                Type = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEntityType(int id, string value)
        {
            this.Query = $@" UPDATE yInbox SET EntityType = @EntityType WHERE Id = @Id ";
            this.Parameters = new
            {
                EntityType = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEntityId(int id, string value)
        {
            this.Query = $@" UPDATE yInbox SET EntityId = @EntityId WHERE Id = @Id ";
            this.Parameters = new
            {
                EntityId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(int id, string value)
        {
            this.Query = $@" UPDATE yInbox SET CorrelationId = @CorrelationId WHERE Id = @Id ";
            this.Parameters = new
            {
                CorrelationId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePayload(int id, string value)
        {
            this.Query = $@" UPDATE yInbox SET Payload = @Payload WHERE Id = @Id ";
            this.Parameters = new
            {
                Payload = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE yInbox SET Status = @Status WHERE Id = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCreatedAt(int id, DateTime value)
        {
            this.Query = $@" UPDATE yInbox SET CreatedAt = @CreatedAt WHERE Id = @Id ";
            this.Parameters = new
            {
                CreatedAt = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRetryCount(int id, int value)
        {
            this.Query = $@" UPDATE yInbox SET RetryCount = @RetryCount WHERE Id = @Id ";
            this.Parameters = new
            {
                RetryCount = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLastError(int id, string value)
        {
            this.Query = $@" UPDATE yInbox SET LastError = @LastError WHERE Id = @Id ";
            this.Parameters = new
            {
                LastError = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProcessingAt(int id, DateTime value)
        {
            this.Query = $@" UPDATE yInbox SET ProcessingAt = @ProcessingAt WHERE Id = @Id ";
            this.Parameters = new
            {
                ProcessingAt = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNextAttemptAt(int id, DateTime value)
        {
            this.Query = $@" UPDATE yInbox SET NextAttemptAt = @NextAttemptAt WHERE Id = @Id ";
            this.Parameters = new
            {
                NextAttemptAt = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSagaId(int id, int value)
        {
            this.Query = $@" UPDATE yInbox SET SagaId = @SagaId WHERE Id = @Id ";
            this.Parameters = new
            {
                SagaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSagaStepId(int id, int value)
        {
            this.Query = $@" UPDATE yInbox SET SagaStepId = @SagaStepId WHERE Id = @Id ";
            this.Parameters = new
            {
                SagaStepId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE yInbox SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE yInbox SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE yInbox SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE yInbox SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
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