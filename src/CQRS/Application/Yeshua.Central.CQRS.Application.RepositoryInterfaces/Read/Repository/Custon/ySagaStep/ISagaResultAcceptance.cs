namespace IRepository.Read;
public partial interface IySagaStepReadRepository
{
    bool CanReceiveResult(int stepId, string messageId, string? requestId);
}
