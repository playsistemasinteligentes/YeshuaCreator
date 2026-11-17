namespace Read.Repository;
public partial class ySagaStepReadRepository
{
    // Called inside the inbox transaction. Serializes competing deliveries for the same step.
    public bool CanReceiveResult(int stepId, string messageId, string? requestId)
        => _unitOfWork.ExecuteScalar<int>(@"
            SELECT COUNT(*) FROM ySagaStep st WITH (UPDLOCK, HOLDLOCK)
            INNER JOIN ySaga sg ON sg.Id = st.SagaId
            CROSS APPLY (SELECT TOP 1 o.MessageId FROM yOutbox o
                WHERE o.SagaStepId = st.Id AND o.ProcessingScope = @Scope AND o.Deleted = 0 ORDER BY o.Id DESC) request
            WHERE st.Id = @Id AND st.Status = 3 AND sg.Status = 1 AND st.Deleted = 0 AND sg.Deleted = 0
              AND sg.ProcessingScope = @Scope
              AND ((@RequestId IS NOT NULL AND request.MessageId = @RequestId)
                  OR (@RequestId IS NULL AND
                      (SELECT COUNT(*) FROM yOutbox legacy WHERE legacy.SagaStepId = st.Id
                       AND legacy.ProcessingScope = @Scope AND legacy.Deleted = 0) = 1))
              AND NOT EXISTS (SELECT 1 FROM yInbox i WHERE i.ProcessingScope = @Scope
                  AND (i.MessageId = @MessageId OR
                       (i.SagaStepId = st.Id AND (@RequestId IS NULL OR JSON_VALUE(i.Payload, '$.requestId') = @RequestId))));",
            new { Id = stepId, MessageId = messageId, RequestId = requestId, Scope = _executionContext.ProcessingScope }) == 1;
}
