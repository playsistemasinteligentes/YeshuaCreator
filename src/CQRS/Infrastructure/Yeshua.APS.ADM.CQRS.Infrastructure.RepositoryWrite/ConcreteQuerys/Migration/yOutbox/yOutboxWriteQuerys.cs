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
    public class yOutboxQueryWrite : QueryBase, IyOutboxQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public yOutboxQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InseriryOutboxQuery(IyOutboxEntity yOutbox)
        {
            this.Query = $@" INSERT INTO yOutbox (MessageId, Type, EntityType, EntityId, CorrelationId, Payload, Status, TransportType, TransportData, CreatedAt, SentAt, RetryCount, LastError, ProcessingAt, NextAttemptAt, SagaId, SagaStepId, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@MessageId, @Type, @EntityType, @EntityId, @CorrelationId, @Payload, @Status, @TransportType, @TransportData, @CreatedAt, @SentAt, @RetryCount, @LastError, @ProcessingAt, @NextAttemptAt, @SagaId, @SagaStepId, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MessageId = yOutbox.MessageId,
                Type = yOutbox.Type,
                EntityType = yOutbox.EntityType,
                EntityId = yOutbox.EntityId,
                CorrelationId = yOutbox.CorrelationId,
                Payload = yOutbox.Payload,
                Status = yOutbox.Status,
                TransportType = yOutbox.TransportType,
                TransportData = yOutbox.TransportData,
                CreatedAt = yOutbox.CreatedAt,
                SentAt = yOutbox.SentAt,
                RetryCount = yOutbox.RetryCount,
                LastError = yOutbox.LastError,
                ProcessingAt = yOutbox.ProcessingAt,
                NextAttemptAt = yOutbox.NextAttemptAt,
                SagaId = yOutbox.SagaId,
                SagaStepId = yOutbox.SagaStepId,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyOutboxQuery(IyOutboxEntity yOutbox)
        {
            this.Query = $@" UPDATE yOutbox SET MessageId = @MessageId, Type = @Type, EntityType = @EntityType, EntityId = @EntityId, CorrelationId = @CorrelationId, Payload = @Payload, Status = @Status, TransportType = @TransportType, TransportData = @TransportData, CreatedAt = @CreatedAt, SentAt = @SentAt, RetryCount = @RetryCount, LastError = @LastError, ProcessingAt = @ProcessingAt, NextAttemptAt = @NextAttemptAt, SagaId = @SagaId, SagaStepId = @SagaStepId, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                MessageId = yOutbox.MessageId,
                Type = yOutbox.Type,
                EntityType = yOutbox.EntityType,
                EntityId = yOutbox.EntityId,
                CorrelationId = yOutbox.CorrelationId,
                Payload = yOutbox.Payload,
                Status = yOutbox.Status,
                TransportType = yOutbox.TransportType,
                TransportData = yOutbox.TransportData,
                CreatedAt = yOutbox.CreatedAt,
                SentAt = yOutbox.SentAt,
                RetryCount = yOutbox.RetryCount,
                LastError = yOutbox.LastError,
                ProcessingAt = yOutbox.ProcessingAt,
                NextAttemptAt = yOutbox.NextAttemptAt,
                SagaId = yOutbox.SagaId,
                SagaStepId = yOutbox.SagaStepId,
                Changed = yOutbox.Changed,
                UserId = _executionContext.UserId,
                Id = yOutbox.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMessageId(int id, string value)
        {
            this.Query = $@" UPDATE yOutbox SET MessageId = @MessageId WHERE Id = @Id ";
            this.Parameters = new
            {
                MessageId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateType(int id, string value)
        {
            this.Query = $@" UPDATE yOutbox SET Type = @Type WHERE Id = @Id ";
            this.Parameters = new
            {
                Type = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEntityType(int id, string value)
        {
            this.Query = $@" UPDATE yOutbox SET EntityType = @EntityType WHERE Id = @Id ";
            this.Parameters = new
            {
                EntityType = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEntityId(int id, string value)
        {
            this.Query = $@" UPDATE yOutbox SET EntityId = @EntityId WHERE Id = @Id ";
            this.Parameters = new
            {
                EntityId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(int id, string value)
        {
            this.Query = $@" UPDATE yOutbox SET CorrelationId = @CorrelationId WHERE Id = @Id ";
            this.Parameters = new
            {
                CorrelationId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePayload(int id, string value)
        {
            this.Query = $@" UPDATE yOutbox SET Payload = @Payload WHERE Id = @Id ";
            this.Parameters = new
            {
                Payload = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE yOutbox SET Status = @Status WHERE Id = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTransportType(int id, int value)
        {
            this.Query = $@" UPDATE yOutbox SET TransportType = @TransportType WHERE Id = @Id ";
            this.Parameters = new
            {
                TransportType = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTransportData(int id, string value)
        {
            this.Query = $@" UPDATE yOutbox SET TransportData = @TransportData WHERE Id = @Id ";
            this.Parameters = new
            {
                TransportData = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCreatedAt(int id, DateTime value)
        {
            this.Query = $@" UPDATE yOutbox SET CreatedAt = @CreatedAt WHERE Id = @Id ";
            this.Parameters = new
            {
                CreatedAt = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSentAt(int id, DateTime value)
        {
            this.Query = $@" UPDATE yOutbox SET SentAt = @SentAt WHERE Id = @Id ";
            this.Parameters = new
            {
                SentAt = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRetryCount(int id, int value)
        {
            this.Query = $@" UPDATE yOutbox SET RetryCount = @RetryCount WHERE Id = @Id ";
            this.Parameters = new
            {
                RetryCount = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLastError(int id, string value)
        {
            this.Query = $@" UPDATE yOutbox SET LastError = @LastError WHERE Id = @Id ";
            this.Parameters = new
            {
                LastError = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProcessingAt(int id, DateTime value)
        {
            this.Query = $@" UPDATE yOutbox SET ProcessingAt = @ProcessingAt WHERE Id = @Id ";
            this.Parameters = new
            {
                ProcessingAt = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNextAttemptAt(int id, DateTime value)
        {
            this.Query = $@" UPDATE yOutbox SET NextAttemptAt = @NextAttemptAt WHERE Id = @Id ";
            this.Parameters = new
            {
                NextAttemptAt = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSagaId(int id, int value)
        {
            this.Query = $@" UPDATE yOutbox SET SagaId = @SagaId WHERE Id = @Id ";
            this.Parameters = new
            {
                SagaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSagaStepId(int id, int value)
        {
            this.Query = $@" UPDATE yOutbox SET SagaStepId = @SagaStepId WHERE Id = @Id ";
            this.Parameters = new
            {
                SagaStepId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE yOutbox SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE yOutbox SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE yOutbox SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE yOutbox SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteyOutboxQuery(IyOutboxEntity yOutbox)
        {
            this.Query = $@" DELETE FROM yOutbox WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = yOutbox.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration