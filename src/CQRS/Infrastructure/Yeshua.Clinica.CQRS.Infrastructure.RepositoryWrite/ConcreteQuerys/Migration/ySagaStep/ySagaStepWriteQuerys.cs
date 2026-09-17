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
    public class ySagaStepQueryWrite : QueryBase, IySagaStepQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ySagaStepQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirySagaStepQuery(IySagaStepEntity ySagaStep)
        {
            this.Query = $@" INSERT INTO [ySagaStep] ([SagaId], [StepKey], [IndexOrder], [CorrelationId], [Status], [ExecutionCount], [LastExecutionAt], [CompletedAt], [ErrorMessage], [Payload], [RetryCount], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@SagaId, @StepKey, @IndexOrder, @CorrelationId, @Status, @ExecutionCount, @LastExecutionAt, @CompletedAt, @ErrorMessage, @Payload, @RetryCount, @TenantID, @Deleted, @Changed, @UserId) ";
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
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateySagaStepQuery(IySagaStepEntity ySagaStep)
        {
            this.Query = $@" UPDATE [ySagaStep] SET [SagaId] = @SagaId, [StepKey] = @StepKey, [IndexOrder] = @IndexOrder, [CorrelationId] = @CorrelationId, [Status] = @Status, [ExecutionCount] = @ExecutionCount, [LastExecutionAt] = @LastExecutionAt, [CompletedAt] = @CompletedAt, [ErrorMessage] = @ErrorMessage, [Payload] = @Payload, [RetryCount] = @RetryCount, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
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
                UserId = _executionContext.UserId,
                Id = ySagaStep.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSagaId(int id, int value)
        {
            this.Query = $@" UPDATE [ySagaStep] SET [SagaId] = @SagaId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SagaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStepKey(int id, string value)
        {
            this.Query = $@" UPDATE [ySagaStep] SET [StepKey] = @StepKey WHERE [Id] = @Id ";
            this.Parameters = new
            {
                StepKey = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIndexOrder(int id, int value)
        {
            this.Query = $@" UPDATE [ySagaStep] SET [IndexOrder] = @IndexOrder WHERE [Id] = @Id ";
            this.Parameters = new
            {
                IndexOrder = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(int id, string value)
        {
            this.Query = $@" UPDATE [ySagaStep] SET [CorrelationId] = @CorrelationId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CorrelationId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE [ySagaStep] SET [Status] = @Status WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateExecutionCount(int id, int value)
        {
            this.Query = $@" UPDATE [ySagaStep] SET [ExecutionCount] = @ExecutionCount WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ExecutionCount = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLastExecutionAt(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ySagaStep] SET [LastExecutionAt] = @LastExecutionAt WHERE [Id] = @Id ";
            this.Parameters = new
            {
                LastExecutionAt = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCompletedAt(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ySagaStep] SET [CompletedAt] = @CompletedAt WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CompletedAt = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateErrorMessage(int id, string value)
        {
            this.Query = $@" UPDATE [ySagaStep] SET [ErrorMessage] = @ErrorMessage WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ErrorMessage = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePayload(int id, string value)
        {
            this.Query = $@" UPDATE [ySagaStep] SET [Payload] = @Payload WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Payload = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRetryCount(int id, int value)
        {
            this.Query = $@" UPDATE [ySagaStep] SET [RetryCount] = @RetryCount WHERE [Id] = @Id ";
            this.Parameters = new
            {
                RetryCount = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [ySagaStep] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [ySagaStep] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ySagaStep] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [ySagaStep] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteySagaStepQuery(IySagaStepEntity ySagaStep)
        {
            this.Query = $@" DELETE FROM [ySagaStep] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = ySagaStep.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration