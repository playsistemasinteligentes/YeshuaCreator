using Dominio.Interfaces;
using Dominio.Operational;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Authentication;

namespace Command.Patterns.Operational;

public readonly record struct OperationalExternalCallDescriptor(
    string Operation,
    string Entity,
    string Dependency,
    string Endpoint,
    string Environment,
    string Region);

public readonly record struct OperationalExternalCallContext(
    OperationalExecutionIdentity ExecutionIdentity,
    string? RecordId,
    string? OperationalEntityId,
    string? CorrelationId,
    int Attempt);

public sealed class OperationalExternalCallScope
{
    public const string Component = "ExternalCallEvents";

    private readonly ILogger _logger;
    private readonly OperationalExternalCallDescriptor _descriptor;
    private readonly OperationalExternalCallContext _context;
    private readonly OperationalTelemetryDecision _telemetry;
    private readonly long _startedTimestamp;
    private readonly string? _dependencyEndpoint;
    private bool _completed;

    private OperationalExternalCallScope(
        ILogger logger,
        OperationalExternalCallDescriptor descriptor,
        OperationalExternalCallContext context,
        OperationalTelemetryDecision telemetry)
    {
        _logger = logger;
        _descriptor = descriptor;
        _context = context;
        _telemetry = telemetry;
        _startedTimestamp = Stopwatch.GetTimestamp();
        _dependencyEndpoint = ResolveEndpoint(descriptor.Endpoint);

        Publish(
            "Started",
            OperationalTechnicalOutcome.NotEvaluated,
            OperationalBusinessOutcome.NotEvaluated,
            null,
            null,
            null);
    }

    public static OperationalExternalCallScope? Begin(
        ILogger logger,
        OperationalExternalCallDescriptor descriptor,
        OperationalExternalCallContext context)
    {
        OperationalTelemetryDecision telemetry;
        try
        {
            telemetry = logger.Evaluate(
                Component,
                descriptor.Operation,
                descriptor.Entity,
                context.RecordId,
                context.ExecutionIdentity.OperationId);
        }
        catch
        {
            return null;
        }

        return telemetry.Enabled
            ? new OperationalExternalCallScope(logger, descriptor, context, telemetry)
            : null;
    }

    public void Complete(
        int statusCode,
        int resultCode,
        bool accepted,
        bool structuredResponse)
    {
        if (!TryComplete())
            return;

        var technicalOutcome = accepted || structuredResponse
            ? OperationalTechnicalOutcome.Succeeded
            : OperationalTechnicalOutcome.Failed;
        var businessOutcome = accepted
            ? OperationalBusinessOutcome.Accepted
            : structuredResponse
                ? OperationalBusinessOutcome.Rejected
                : OperationalBusinessOutcome.NotEvaluated;
        var phase = accepted
            ? "Accepted"
            : structuredResponse
                ? "Rejected"
                : "Failed";

        Publish(
            phase,
            technicalOutcome,
            businessOutcome,
            statusCode,
            resultCode > 0 ? resultCode.ToString() : null,
            structuredResponse || accepted ? null : "External dependency returned no structured result.");
    }

    public void FailHttp(int statusCode)
    {
        if (!TryComplete())
            return;

        Publish(
            "Failed",
            OperationalTechnicalOutcome.Failed,
            OperationalBusinessOutcome.NotEvaluated,
            statusCode,
            null,
            "External dependency returned a non-success HTTP status.",
            $"HTTP_{statusCode}");
    }

    public void Fail(Exception exception)
    {
        if (!TryComplete())
            return;

        var relevantException = FindRelevantException(exception);
        var timedOut = relevantException is TaskCanceledException;
        var cancelled = relevantException is OperationCanceledException;
        var unavailable = relevantException is HttpRequestException
            or AuthenticationException
            or IOException;
        var technicalOutcome = timedOut
            ? OperationalTechnicalOutcome.TimedOut
            : cancelled
                ? OperationalTechnicalOutcome.Cancelled
                : unavailable
                    ? OperationalTechnicalOutcome.Unavailable
                    : OperationalTechnicalOutcome.Failed;
        var phase = technicalOutcome switch
        {
            OperationalTechnicalOutcome.TimedOut => "TimedOut",
            OperationalTechnicalOutcome.Cancelled => "Cancelled",
            OperationalTechnicalOutcome.Unavailable => "Unavailable",
            _ => "Failed"
        };

        Publish(
            phase,
            technicalOutcome,
            OperationalBusinessOutcome.NotEvaluated,
            null,
            null,
            $"External dependency failed with {relevantException.GetType().Name}.",
            relevantException.GetType().Name);
    }

    private bool TryComplete()
    {
        if (_completed)
            return false;

        _completed = true;
        return true;
    }

    private void Publish(
        string phase,
        OperationalTechnicalOutcome technicalOutcome,
        OperationalBusinessOutcome businessOutcome,
        int? statusCode,
        string? resultCode,
        string? errorSummary,
        string? errorCode = null)
    {
        try
        {
            _logger.Transition(
                new OperationalEvidenceTransition(
                    Component,
                    _descriptor.Operation,
                    phase,
                    phase == "Started"
                        ? 0
                        : (long)Stopwatch.GetElapsedTime(_startedTimestamp).TotalMilliseconds,
                    technicalOutcome,
                    businessOutcome,
                    _context.ExecutionIdentity,
                    _descriptor.Entity,
                    _context.RecordId,
                    _context.OperationalEntityId,
                    _context.CorrelationId,
                    Dependency: _descriptor.Dependency,
                    Attempt: _context.Attempt,
                    ErrorCode: errorCode,
                    ErrorSummary: errorSummary,
                    StatusCode: statusCode,
                    DependencyEndpoint: _dependencyEndpoint,
                    DependencyEnvironment: _descriptor.Environment,
                    DependencyRegion: _descriptor.Region,
                    ResultCode: resultCode),
                _telemetry);
        }
        catch
        {
            // A telemetria nunca altera o resultado da chamada externa.
        }
    }

    private static Exception FindRelevantException(Exception exception)
    {
        for (Exception? current = exception; current is not null; current = current.InnerException)
        {
            if (current is TaskCanceledException
                or OperationCanceledException
                or HttpRequestException
                or AuthenticationException
                or IOException)
            {
                return current;
            }
        }

        return exception;
    }

    private static string? ResolveEndpoint(string endpoint) =>
        Uri.TryCreate(endpoint, UriKind.Absolute, out var uri)
            ? uri.Host
            : null;
}
