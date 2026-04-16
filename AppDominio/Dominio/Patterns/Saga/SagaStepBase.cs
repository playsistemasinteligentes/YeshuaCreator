using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Patterns.Saga
{
    public abstract class SagaStepBase
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public SagaStepStatus Status { get; private set; } = SagaStepStatus.Created;

        protected SagaBase Saga { get; private set; }

        internal void SetSaga(SagaBase saga)
        {
            Saga = saga;
        }

        public void Start()
        {
            if (Status != SagaStepStatus.Pending)
                throw new Exception("Step inválido para iniciar.");

            Status = SagaStepStatus.InProgress;

            OnStart();
        }

        public void Complete()
        {
            if (Status != SagaStepStatus.InProgress)
                throw new Exception("Step inválido para completar.");

            Status = SagaStepStatus.Completed;

            OnComplete();

            Saga.NotifyStepCompleted(this);
        }

        public void Fail()
        {
            Status = SagaStepStatus.Failed;

            OnFail();

            Saga.NotifyStepFailed(this);
        }

        protected abstract void OnStart();
        
        protected abstract void OnComplete();
        
        protected abstract void OnFail();
    }
}
