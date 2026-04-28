using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Patterns.Saga
{
    public abstract class SagaStepBase
    {
        // 🔥 persistência
        public int Id { get; set; }
        public int SagaId { get; set; }
        public string Key { get; protected set; }
        public int Order { get; protected set; }
        public SagaStepStatus Status { get; protected set; }
        public DateTime? CompletedAt { get; protected set; }
        public string ErrorMessage { get; protected set; }
        public string Payload { get; protected set; }

        public int ExecutionCount { get; protected set; }
        public DateTime? LastExecutionAt { get; protected set; }
        public DateTime? NextExecutionAt { get; protected set; }
        public int RetryCount { get; protected set; } = 0;
        public int MaxRetries { get; protected set; } = 3;

        public string CorrelationId { get; protected set; } = Guid.NewGuid().ToString();
        public bool IsNew { get; private set; } = true;
        public bool IsDirty { get; private set; } = false;



        protected SagaStepBase(string key)
        {
            Key = key;
            Status = SagaStepStatus.Created;
            IsDirty = true; // novo já nasce dirty
        }

        public void SetOrder(int order)
        {
            Order = order;
        }
        private void MarkDirty()
        {
            IsDirty = true;
        }

        public void SetInProgress()
        {
            Status = SagaStepStatus.InProgress;
            LastExecutionAt = DateTime.UtcNow;
            ExecutionCount++;
            MarkDirty();
        }
        // 🔥 async flow
        public void SetWaiting()
        {
            Status = SagaStepStatus.WaitingResponse;
            MarkDirty();
        }
        public void SetPayload(string payload)
        {
            Payload = payload;
            MarkDirty();
        }

        public void SetCompleted()
        {
            Status = SagaStepStatus.Completed;
            CompletedAt = DateTime.UtcNow;
            MarkDirty();
        }

        public void SetPendingApply()
        {
            Status = SagaStepStatus.PendingApply;
            MarkDirty();
        }

        public void SetFailed(string menssage)
        {
            Status = SagaStepStatus.Failed;
            MarkDirty();
        }

        public void ClearDirty()
        {
            IsDirty = false;
        }
        public void MarkPersisted()
        {
            IsNew = false;
            IsDirty = false;
        }
        public void SetPending(DateTime? nextExecution = null)
        {
            Status = SagaStepStatus.Pending;
            NextExecutionAt = nextExecution;
            MarkDirty();
        }
        public void IncrementRetry()
        {
            RetryCount++;
        }
        public void Hydrate(int id,int status,string correlationId,DateTime? completedAt,int retryCount)
        {
            Id = id;
            Status = (SagaStepStatus)status;
            CorrelationId = correlationId;
            CompletedAt = completedAt;
            RetryCount = retryCount;
            //NextExecutionAt = nextExecutionAt;

            IsNew = false;
            IsDirty = false;
        }
        public bool CanRetry() => RetryCount < MaxRetries;
    }
}