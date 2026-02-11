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
        protected readonly ICurrentUser _currentUser;
        public yOutboxQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InseriryOutboxQuery(IyOutboxEntity yOutbox)
        {
            this.Query = $@" INSERT INTO yOutbox (MessageId, JobId, CorrelationId, Type, Payload, Status, CreatedAt, SentAt, RetryCount, LastError, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@MessageId, @JobId, @CorrelationId, @Type, @Payload, @Status, @CreatedAt, @SentAt, @RetryCount, @LastError, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MessageId = Guid.NewGuid(),
                JobId = Guid.NewGuid(),
                CorrelationId = yOutbox.CorrelationId,
                Type = yOutbox.Type,
                Payload = yOutbox.Payload,
                Status = yOutbox.Status,
                CreatedAt = yOutbox.CreatedAt,
                SentAt = yOutbox.SentAt,
                RetryCount = yOutbox.RetryCount,
                LastError = yOutbox.LastError,
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateyOutboxQuery(IyOutboxEntity yOutbox)
        {
            this.Query = $@" UPDATE yOutbox SET MessageId = @MessageId, JobId = @JobId, CorrelationId = @CorrelationId, Type = @Type, Payload = @Payload, Status = @Status, CreatedAt = @CreatedAt, SentAt = @SentAt, RetryCount = @RetryCount, LastError = @LastError, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                MessageId = yOutbox.MessageId,
                JobId = yOutbox.JobId,
                CorrelationId = yOutbox.CorrelationId,
                Type = yOutbox.Type,
                Payload = yOutbox.Payload,
                Status = yOutbox.Status,
                CreatedAt = yOutbox.CreatedAt,
                SentAt = yOutbox.SentAt,
                RetryCount = yOutbox.RetryCount,
                LastError = yOutbox.LastError,
                Changed = yOutbox.Changed,
                UserId = _currentUser.UserId,
                Id = yOutbox.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMessageId(IyOutboxEntity entity)
        {
            this.Query = $@" UPDATE yOutbox SET MessageId = @MessageId WHERE Id = @Id ";
            this.Parameters = new
            {
                MessageId = entity.MessageId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateJobId(IyOutboxEntity entity)
        {
            this.Query = $@" UPDATE yOutbox SET JobId = @JobId WHERE Id = @Id ";
            this.Parameters = new
            {
                JobId = entity.JobId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(IyOutboxEntity entity)
        {
            this.Query = $@" UPDATE yOutbox SET CorrelationId = @CorrelationId WHERE Id = @Id ";
            this.Parameters = new
            {
                CorrelationId = entity.CorrelationId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateType(IyOutboxEntity entity)
        {
            this.Query = $@" UPDATE yOutbox SET Type = @Type WHERE Id = @Id ";
            this.Parameters = new
            {
                Type = entity.Type,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePayload(IyOutboxEntity entity)
        {
            this.Query = $@" UPDATE yOutbox SET Payload = @Payload WHERE Id = @Id ";
            this.Parameters = new
            {
                Payload = entity.Payload,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(IyOutboxEntity entity)
        {
            this.Query = $@" UPDATE yOutbox SET Status = @Status WHERE Id = @Id ";
            this.Parameters = new
            {
                Status = entity.Status,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCreatedAt(IyOutboxEntity entity)
        {
            this.Query = $@" UPDATE yOutbox SET CreatedAt = @CreatedAt WHERE Id = @Id ";
            this.Parameters = new
            {
                CreatedAt = entity.CreatedAt,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSentAt(IyOutboxEntity entity)
        {
            this.Query = $@" UPDATE yOutbox SET SentAt = @SentAt WHERE Id = @Id ";
            this.Parameters = new
            {
                SentAt = entity.SentAt,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRetryCount(IyOutboxEntity entity)
        {
            this.Query = $@" UPDATE yOutbox SET RetryCount = @RetryCount WHERE Id = @Id ";
            this.Parameters = new
            {
                RetryCount = entity.RetryCount,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLastError(IyOutboxEntity entity)
        {
            this.Query = $@" UPDATE yOutbox SET LastError = @LastError WHERE Id = @Id ";
            this.Parameters = new
            {
                LastError = entity.LastError,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IyOutboxEntity entity)
        {
            this.Query = $@" UPDATE yOutbox SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IyOutboxEntity entity)
        {
            this.Query = $@" UPDATE yOutbox SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IyOutboxEntity entity)
        {
            this.Query = $@" UPDATE yOutbox SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IyOutboxEntity entity)
        {
            this.Query = $@" UPDATE yOutbox SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
                Id = entity.Id,
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