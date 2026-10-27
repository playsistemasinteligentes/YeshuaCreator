namespace IRepository.Read;

public partial interface IyOutboxReadRepository
{
    string? BindDeliveryProvider(int id, DateTime claimedAt, string provider, int transportType);
    bool HasAcceptedDeliveryResult(int id);
    bool IsCurrentDelivery(int id);
    bool MarkDeliveryDone(int id, DateTime claimedAt, DateTime sentAt);
    bool MarkDeliveryRetry(int id, DateTime claimedAt, int retry, DateTime next, string code);
    bool MarkDeliveryDeadLetter(int id, DateTime claimedAt, string code, int retry);
}
