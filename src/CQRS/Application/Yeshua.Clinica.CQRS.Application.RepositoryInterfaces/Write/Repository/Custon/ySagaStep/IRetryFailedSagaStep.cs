namespace IRepository.Write;
public partial interface IySagaStepWriteRepository
{
    string? RetryFailedStep(int sagaId, int stepId, int tenantId, int userId, string processingScope);
}
