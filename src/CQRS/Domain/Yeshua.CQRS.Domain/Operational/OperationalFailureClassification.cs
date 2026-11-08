namespace Dominio.Operational;

public enum OperationalFailureNature
{
    Technical,
    Business,
    ExternalRejection,
    Cancellation
}

public enum OperationalFailureTransience
{
    Unknown,
    Transient,
    Permanent
}

public enum OperationalFailureOrigin
{
    Unknown,
    Application,
    Database,
    Http,
    Queue,
    ExternalProvider,
    Configuration
}

public readonly record struct OperationalFailureClassification(
    OperationalFailureNature Nature,
    OperationalFailureTransience Transience,
    OperationalFailureOrigin Origin,
    bool Retryable,
    string StableCode)
{
    public static OperationalFailureClassification Technical(
        Exception exception,
        bool retryable,
        OperationalFailureOrigin origin = OperationalFailureOrigin.Unknown,
        string? stableCode = null) =>
        new(
            OperationalFailureNature.Technical,
            retryable
                ? OperationalFailureTransience.Transient
                : OperationalFailureTransience.Permanent,
            origin,
            retryable,
            stableCode ?? exception.GetType().Name);
}
