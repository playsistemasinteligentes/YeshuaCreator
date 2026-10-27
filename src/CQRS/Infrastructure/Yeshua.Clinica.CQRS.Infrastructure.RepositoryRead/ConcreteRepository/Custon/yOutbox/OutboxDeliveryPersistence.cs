namespace Read.Repository;

public partial class yOutboxReadRepository
{
    public string? BindDeliveryProvider(int id, DateTime claimedAt, string provider, int transportType)
    {
        if (string.IsNullOrWhiteSpace(provider) || provider.Length > 64)
            throw new ArgumentException("Destino de entrega invalido.");
        return _unitOfWork.QueryFirstOrDefault<string>(@"
            UPDATE yOutbox
               SET TransportData = JSON_MODIFY(COALESCE(TransportData, '{}'), '$.DeliveryProvider', @Provider),
                   TransportType = @TransportType,
                   RootOperationId = COALESCE(@RootOperationId, RootOperationId),
                   OperationId = COALESCE(@OperationId, OperationId),
                   ExecutionId = COALESCE(@ExecutionId, ExecutionId),
                   CausationId = COALESCE(@CausationId, CausationId)
            OUTPUT inserted.TransportData
             WHERE Id = @Id AND Status = 9 AND ProcessingAt = @ClaimedAt
               AND ProcessingScope = @Scope AND Deleted = 0
               AND JSON_VALUE(TransportData, '$.DeliveryProvider') IS NULL;",
            DeliveryState(id, claimedAt) with { Provider = provider, TransportType = transportType });
    }

    public bool HasAcceptedDeliveryResult(int id)
        => _unitOfWork.ExecuteScalar<int>(@"
            SELECT COUNT(*) FROM yOutbox o
            WHERE o.Id = @Id AND o.ProcessingScope = @Scope AND o.Deleted = 0
              AND EXISTS (SELECT 1 FROM yInbox i
                   WHERE i.SagaStepId = o.SagaStepId AND i.ProcessingScope = @Scope AND i.Deleted = 0
                     AND JSON_VALUE(i.Payload, '$.requestId') = o.MessageId);",
            new { Id = id, Scope = _executionContext.ProcessingScope }) == 1;

    public bool IsCurrentDelivery(int id)
        => _unitOfWork.ExecuteScalar<int>(@"
            SELECT COUNT(*) FROM yOutbox o
            INNER JOIN ySagaStep st ON st.Id = o.SagaStepId
            INNER JOIN ySaga sg ON sg.Id = st.SagaId AND sg.Id = o.SagaId
            WHERE o.Id = @Id AND o.ProcessingScope = @Scope AND sg.ProcessingScope = @Scope
              AND o.Deleted = 0 AND st.Deleted = 0 AND sg.Deleted = 0
              AND sg.Status = 1 AND st.Status = 3
              AND o.Id = (SELECT MAX(latest.Id) FROM yOutbox latest
                  WHERE latest.SagaStepId = st.Id AND latest.ProcessingScope = @Scope AND latest.Deleted = 0);",
            new { Id = id, Scope = _executionContext.ProcessingScope }) == 1;

    public bool MarkDeliveryDone(int id, DateTime claimedAt, DateTime sentAt)
        => _unitOfWork.Execute(@"
            UPDATE yOutbox SET Status = 1, SentAt = @SentAt, ProcessingAt = NULL,
                   RootOperationId = COALESCE(@RootOperationId, RootOperationId),
                   OperationId = COALESCE(@OperationId, OperationId),
                   ExecutionId = COALESCE(@ExecutionId, ExecutionId),
                   CausationId = COALESCE(@CausationId, CausationId)
            WHERE Id = @Id AND Status = 9 AND ProcessingAt = @ClaimedAt
              AND ProcessingScope = @Scope AND Deleted = 0;",
            DeliveryState(id, claimedAt) with { SentAt = sentAt }) == 1;

    public bool MarkDeliveryRetry(int id, DateTime claimedAt, int retry, DateTime next, string code)
        => _unitOfWork.Execute(@"
            UPDATE yOutbox SET Status = 0, RetryCount = @Retry, NextAttemptAt = @Next,
                   LastError = @Code, ProcessingAt = NULL,
                   RootOperationId = COALESCE(@RootOperationId, RootOperationId),
                   OperationId = COALESCE(@OperationId, OperationId),
                   ExecutionId = COALESCE(@ExecutionId, ExecutionId),
                   CausationId = COALESCE(@CausationId, CausationId)
            WHERE Id = @Id AND Status = 9 AND ProcessingAt = @ClaimedAt
              AND ProcessingScope = @Scope AND Deleted = 0;",
            DeliveryState(id, claimedAt) with { Retry = retry, Next = next, Code = code }) == 1;

    public bool MarkDeliveryDeadLetter(int id, DateTime claimedAt, string code, int retry)
        => _unitOfWork.Execute(@"
            UPDATE yOutbox SET Status = 2, RetryCount = @Retry, LastError = @Code, ProcessingAt = NULL,
                   RootOperationId = COALESCE(@RootOperationId, RootOperationId),
                   OperationId = COALESCE(@OperationId, OperationId),
                   ExecutionId = COALESCE(@ExecutionId, ExecutionId),
                   CausationId = COALESCE(@CausationId, CausationId)
            WHERE Id = @Id AND Status = 9 AND ProcessingAt = @ClaimedAt
              AND ProcessingScope = @Scope AND Deleted = 0;",
            DeliveryState(id, claimedAt) with { Code = code, Retry = retry }) == 1;

    private DeliveryParameters DeliveryState(int id, DateTime claimedAt)
    {
        _executionContext.TryGetOperationalIdentity(out var identity);
        return new(id, claimedAt, _executionContext.ProcessingScope,
            identity.RootOperationId, identity.OperationId, identity.ExecutionId, identity.CausationId);
    }

    private sealed record DeliveryParameters(int Id, DateTime ClaimedAt, string Scope,
        string? RootOperationId, string? OperationId, string? ExecutionId, string? CausationId)
    {
        public string? Provider { get; init; }
        public int TransportType { get; init; }
        public DateTime SentAt { get; init; }
        public int Retry { get; init; }
        public DateTime Next { get; init; }
        public string? Code { get; init; }
    }
}
