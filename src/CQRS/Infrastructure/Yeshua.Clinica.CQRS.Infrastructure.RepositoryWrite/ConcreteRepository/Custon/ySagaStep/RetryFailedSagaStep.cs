namespace Input.Repository.ySagaStep;
public partial class ySagaStepWriteRepository
{
    public string? RetryFailedStep(int sagaId, int stepId, int tenantId, int userId, string processingScope)
        => _UnitOfWork.Query<string>(@"
            DECLARE @reopened TABLE (StepKey nvarchar(100));
            UPDATE st WITH (UPDLOCK)
               SET Status = 1, RetryCount = 0, ErrorMessage = NULL
               OUTPUT inserted.StepKey INTO @reopened
              FROM ySagaStep st INNER JOIN ySaga sg WITH (UPDLOCK) ON sg.Id = st.SagaId
             WHERE st.Id = @StepId AND sg.Id = @SagaId AND st.Status = 6 AND sg.Status = 3 AND sg.KeyCurrentStep = st.StepKey
               AND sg.TenantID = @TenantId AND sg.UserId = @UserId AND sg.ProcessingScope = @Scope
               AND sg.Deleted = 0 AND st.Deleted = 0
               AND (sg.LockedBy IS NULL OR sg.LockedAt < DATEADD(MINUTE,-1,SYSUTCDATETIME()));
            UPDATE ySaga SET Status = 1, NextExecutionAt = SYSUTCDATETIME(), LockedBy = NULL, LockedAt = NULL
              WHERE Id = @SagaId AND EXISTS(SELECT 1 FROM @reopened);
            SELECT StepKey FROM @reopened;", new
            { SagaId = sagaId, StepId = stepId, TenantId = tenantId, UserId = userId, Scope = processingScope }).SingleOrDefault();
}
