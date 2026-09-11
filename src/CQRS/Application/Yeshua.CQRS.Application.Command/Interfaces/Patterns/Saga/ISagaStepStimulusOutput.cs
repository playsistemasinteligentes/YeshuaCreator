namespace Command.Interfaces
{
    public interface ISagaStepStimulusOutput
    {
        bool Accepted { get; }
        int SagaId { get; }
        int SagaStepId { get; }
        int InboxId { get; }
        string CorrelationId { get; }
        string StepKey { get; }
    }
}
