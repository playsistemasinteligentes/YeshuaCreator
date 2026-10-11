namespace Dominio.Operational;

public enum OperationalSeverity
{
    Trace,
    Debug,
    Information,
    Warning,
    Error,
    Critical
}

public enum OperationalDepth
{
    D0,
    D1,
    D2,
    D3,
    D4
}

public enum OperationalTechnicalOutcome
{
    NotEvaluated,
    Succeeded,
    Failed,
    TimedOut,
    Cancelled,
    Unavailable
}

public enum OperationalBusinessOutcome
{
    NotEvaluated,
    Accepted,
    Rejected,
    PartiallyAccepted
}

public enum OperationalDataClassification
{
    Public,
    Internal,
    Confidential,
    Restricted,
    NeverCapture
}

public readonly record struct OperationalExecutionIdentity(
    string? RootOperationId,
    string? OperationId,
    string? ExecutionId,
    string? CausationId)
{
    public static OperationalExecutionIdentity FromTrace(string? traceId) =>
        string.IsNullOrWhiteSpace(traceId)
            ? default
            : new OperationalExecutionIdentity(traceId, traceId, traceId, null);
}

public readonly record struct OperationalEvidenceEnvelope(
    string Component,
    string Operation,
    OperationalSeverity Severity,
    OperationalDepth Depth,
    OperationalTechnicalOutcome TechnicalOutcome,
    OperationalBusinessOutcome BusinessOutcome,
    string? TraceId = null,
    string? RootOperationId = null,
    string? OperationId = null,
    string? ExecutionId = null,
    string? CausationId = null,
    string? OperationalEntityId = null,
    string? ErrorCode = null);

public readonly record struct OperationalEvidenceTransition(
    string Component,
    string Operation,
    string Phase,
    long DurationMs,
    OperationalTechnicalOutcome TechnicalOutcome,
    OperationalBusinessOutcome BusinessOutcome,
    OperationalExecutionIdentity ExecutionIdentity,
    string? Entity = null,
    string? RecordId = null,
    string? OperationalEntityId = null,
    string? CorrelationId = null,
    string? MessageId = null,
    string? Dependency = null,
    int Attempt = 0,
    string? ErrorCode = null,
    string? ErrorSummary = null,
    int? StatusCode = null);

public readonly record struct OperationalEvidenceField(
    string Name,
    object? Value,
    OperationalDataClassification Classification = OperationalDataClassification.Internal);

public static class OperationalEvidenceAxes
{
    public static OperationalSeverity ParseSeverity(string? value)
    {
        if (Enum.TryParse<OperationalSeverity>(value, true, out var severity))
            return severity;

        return OperationalSeverity.Information;
    }

    public static OperationalDepth ParseDepth(string? value)
    {
        if (Enum.TryParse<OperationalDepth>(value, true, out var depth))
            return depth;

        return OperationalDepth.D0;
    }

}
