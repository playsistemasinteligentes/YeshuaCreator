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
    public class ySagaStepQueryWrite : QueryBase, IySagaStepQueryWrite
    {
        protected readonly ICurrentUser _currentUser;
        public ySagaStepQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InserirySagaStepQuery(IySagaStepEntity ySagaStep)
        {
            this.Query = $@" INSERT INTO ySagaStep (SagaId, StepKey, IndexOrder, CorrelationId, Status, ExecutionCount, LastExecutionAt, CompletedAt, ErrorMessage, Payload, RetryCount, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@SagaId, @StepKey, @IndexOrder, @CorrelationId, @Status, @ExecutionCount, @LastExecutionAt, @CompletedAt, @ErrorMessage, @Payload, @RetryCount, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                SagaId = ySagaStep.SagaId,
                StepKey = ySagaStep.StepKey,
                IndexOrder = ySagaStep.IndexOrder,
                CorrelationId = ySagaStep.CorrelationId,
                Status = ySagaStep.Status,
                ExecutionCount = ySagaStep.ExecutionCount,
                LastExecutionAt = ySagaStep.LastExecutionAt,
                CompletedAt = ySagaStep.CompletedAt,
                ErrorMessage = ySagaStep.ErrorMessage,
                Payload = ySagaStep.Payload,
                RetryCount = ySagaStep.RetryCount,
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateySagaStepQuery(IySagaStepEntity ySagaStep)
        {
            this.Query = $@" UPDATE ySagaStep SET SagaId = @SagaId, StepKey = @StepKey, IndexOrder = @IndexOrder, CorrelationId = @CorrelationId, Status = @Status, ExecutionCount = @ExecutionCount, LastExecutionAt = @LastExecutionAt, CompletedAt = @CompletedAt, ErrorMessage = @ErrorMessage, Payload = @Payload, RetryCount = @RetryCount, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                SagaId = ySagaStep.SagaId,
                StepKey = ySagaStep.StepKey,
                IndexOrder = ySagaStep.IndexOrder,
                CorrelationId = ySagaStep.CorrelationId,
                Status = ySagaStep.Status,
                ExecutionCount = ySagaStep.ExecutionCount,
                LastExecutionAt = ySagaStep.LastExecutionAt,
                CompletedAt = ySagaStep.CompletedAt,
                ErrorMessage = ySagaStep.ErrorMessage,
                Payload = ySagaStep.Payload,
                RetryCount = ySagaStep.RetryCount,
                Changed = ySagaStep.Changed,
                UserId = _currentUser.UserId,
                Id = ySagaStep.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSagaId(IySagaStepEntity entity)
        {
            this.Query = $@" UPDATE ySagaStep SET SagaId = @SagaId WHERE Id = @Id ";
            this.Parameters = new
            {
                SagaId = entity.SagaId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStepKey(IySagaStepEntity entity)
        {
            this.Query = $@" UPDATE ySagaStep SET StepKey = @StepKey WHERE Id = @Id ";
            this.Parameters = new
            {
                StepKey = entity.StepKey,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIndexOrder(IySagaStepEntity entity)
        {
            this.Query = $@" UPDATE ySagaStep SET IndexOrder = @IndexOrder WHERE Id = @Id ";
            this.Parameters = new
            {
                IndexOrder = entity.IndexOrder,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(IySagaStepEntity entity)
        {
            this.Query = $@" UPDATE ySagaStep SET CorrelationId = @CorrelationId WHERE Id = @Id ";
            this.Parameters = new
            {
                CorrelationId = entity.CorrelationId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(IySagaStepEntity entity)
        {
            this.Query = $@" UPDATE ySagaStep SET Status = @Status WHERE Id = @Id ";
            this.Parameters = new
            {
                Status = entity.Status,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateExecutionCount(IySagaStepEntity entity)
        {
            this.Query = $@" UPDATE ySagaStep SET ExecutionCount = @ExecutionCount WHERE Id = @Id ";
            this.Parameters = new
            {
                ExecutionCount = entity.ExecutionCount,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLastExecutionAt(IySagaStepEntity entity)
        {
            this.Query = $@" UPDATE ySagaStep SET LastExecutionAt = @LastExecutionAt WHERE Id = @Id ";
            this.Parameters = new
            {
                LastExecutionAt = entity.LastExecutionAt,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCompletedAt(IySagaStepEntity entity)
        {
            this.Query = $@" UPDATE ySagaStep SET CompletedAt = @CompletedAt WHERE Id = @Id ";
            this.Parameters = new
            {
                CompletedAt = entity.CompletedAt,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateErrorMessage(IySagaStepEntity entity)
        {
            this.Query = $@" UPDATE ySagaStep SET ErrorMessage = @ErrorMessage WHERE Id = @Id ";
            this.Parameters = new
            {
                ErrorMessage = entity.ErrorMessage,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePayload(IySagaStepEntity entity)
        {
            this.Query = $@" UPDATE ySagaStep SET Payload = @Payload WHERE Id = @Id ";
            this.Parameters = new
            {
                Payload = entity.Payload,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRetryCount(IySagaStepEntity entity)
        {
            this.Query = $@" UPDATE ySagaStep SET RetryCount = @RetryCount WHERE Id = @Id ";
            this.Parameters = new
            {
                RetryCount = entity.RetryCount,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IySagaStepEntity entity)
        {
            this.Query = $@" UPDATE ySagaStep SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IySagaStepEntity entity)
        {
            this.Query = $@" UPDATE ySagaStep SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IySagaStepEntity entity)
        {
            this.Query = $@" UPDATE ySagaStep SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IySagaStepEntity entity)
        {
            this.Query = $@" UPDATE ySagaStep SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteySagaStepQuery(IySagaStepEntity ySagaStep)
        {
            this.Query = $@" DELETE FROM ySagaStep WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = ySagaStep.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration