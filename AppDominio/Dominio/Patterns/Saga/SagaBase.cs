using Dominio.Patterns.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 1. Define o fluxo
Step1 → Step2 → Step3 → Step4
2. Controla estado
Pending → InProgress → Completed → Failed
3. Emite intenção (eventos)
👉 isso é o que está faltando no teu código hoje
 */

namespace Dominio.Patterns.Saga
{
    public abstract class SagaBase
    {
        public int Id { get; set; }
        public Guid CorrelationId { get; protected set; } = Guid.NewGuid();
        public string Type { get; set; }
        public SagaStatus Status { get; protected set; } = SagaStatus.NotStarted;
        public string KeyCurrentStep { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public string EntityType { get; set; }
        public string EntityId { get; set; }
        public DateTime NextExecutionAt { get; set; }
        public DateTime LockedAt { get; set; }
        public string LockedBy { get; set; }

        protected readonly List<SagaStepBase> _steps = new();
        public IReadOnlyCollection<SagaStepBase> Steps => _steps;
        // 🔥 NOVO: controle de persistência
        public bool IsDirty { get; private set; } = false;

        public void SetCorrelationId(string guid)
        {
            this.CorrelationId = Guid.Parse(guid);
        }
        public void SetStatus(int status)
        {
            this.Status = (SagaStatus)(status);
        }
        protected void MarkDirty()
        {
            IsDirty = true;
        }

        public void MarkPersisted()
        {
            IsDirty = false;
            foreach (var s in _steps)
                s.MarkPersisted();
        }

        protected void AddStep(SagaStepBase step)
        {
            _steps.Add(step);
            MarkDirty();
        }

        public void Start(string entityId)
        {
            EntityId = entityId;

            Type = this.GetType().Name;

            if (Status != SagaStatus.NotStarted)
                throw new Exception("Saga já iniciada");

            Status = SagaStatus.InProgress;
            _steps.FirstOrDefault()?.SetPending();

            MarkDirty();
            UpdateCurrentStepKey();
        }

        private void NextStep()
        {
            var current = GetCurrent();

            if (current == null)
                return;

            current.SetPending();

            if (_steps.All(s => s.Status == SagaStepStatus.Completed))
                Status = SagaStatus.Completed;

            MarkDirty();
            UpdateCurrentStepKey();
        }

        public SagaStepBase GetCurrent()
        {
            var lastCompleted = _steps
                .Where(s => s.Status == SagaStepStatus.Completed)
                .OrderByDescending(s => s.Order)
                .FirstOrDefault();

            if (lastCompleted == null)
            {
                // nenhum completado → primeiro step
                return _steps.OrderBy(s => s.Order).FirstOrDefault();
            }

            return _steps
                .Where(s => s.Order > lastCompleted.Order)
                .OrderBy(s => s.Order)
                .FirstOrDefault();
        }

        public void MarkInProgress()
        {
            GetCurrent()?.SetInProgress();
            MarkDirty();
        }

        public void MarkWaiting()
        {
            GetCurrent()?.SetWaiting();
            MarkDirty();
        }

        public void MarkCompleted()
        {
            NextStep();
        }

        public void MarkFailed(string menssage) // pendencia propagar menssagem para banco e pra outros 
        {
            Status = SagaStatus.Failed;
            MarkDirty();
            UpdateCurrentStepKey();
        }
        
        private void UpdateCurrentStepKey()
        {
            KeyCurrentStep = GetCurrent()?.Key;
        }

        public SagaStepBase GetWaitingStep(int stepId)
        {
            return _steps.FirstOrDefault(s =>
                s.Status == SagaStepStatus.WaitingResponse &&
                s.Id == stepId);
        }


        public void CompleteCurrentStep()
        {
            var current = GetCurrent();

            if (current == null)
                return;

            current.SetCompleted();
            NextStep();
        }

        public SagaStepBase GetWaitingStep(string correlationId)
        {
            return _steps.FirstOrDefault(s =>
                s.Status == SagaStepStatus.WaitingResponse &&
                s.CorrelationId == correlationId);
        }

    }
}