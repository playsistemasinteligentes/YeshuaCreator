using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Patterns.Saga
{
    public abstract class SagaBase
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public SagaStatus Status { get; protected set; } = SagaStatus.NotStarted;

        protected readonly List<SagaStepBase> _steps = new();
        private readonly List<string> _events = new();

        public IReadOnlyCollection<SagaStepBase> Steps => _steps;
        public IReadOnlyCollection<string> Events => _events;

        protected void AddStep(SagaStepBase step)
        {
            step.SetSaga(this);
            _steps.Add(step);
        }

        protected void RaiseEvent(string evt)
        {
            _events.Add(evt);
        }

        public void ClearEvents()
        {
            _events.Clear();
        }

        public void Start()
        {
            if (Status != SagaStatus.NotStarted)
                throw new Exception("Saga já iniciada.");

            Status = SagaStatus.InProgress;

            OnStart();
        }

        protected abstract void OnStart();

        internal void NotifyStepCompleted(SagaStepBase step)
        {
            if (_steps.All(s => s.Status == SagaStepStatus.Completed))
            {
                Status = SagaStatus.Completed;
                RaiseEvent("SagaCompleted");
            }
        }

        internal void NotifyStepFailed(SagaStepBase step)
        {
            Status = SagaStatus.Failed;
            RaiseEvent("SagaFailed");
        }

        public SagaStepBase GetNextPendingStep()
        {
            return _steps.FirstOrDefault(s => s.Status == SagaStepStatus.Pending);
        }
    }

}
