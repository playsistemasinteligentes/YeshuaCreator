using Aplication.Interfaces.Services;
using Dominio.Operational;
using System.Diagnostics;

namespace Shared.Operational;

public static class OperationalHttpRequestOptions
{
    public static readonly HttpRequestOptionsKey<string> Operation =
        new("Yeshua.Operational.Operation");
    public static readonly HttpRequestOptionsKey<string> Entity =
        new("Yeshua.Operational.Entity");
    public static readonly HttpRequestOptionsKey<string> RecordId =
        new("Yeshua.Operational.RecordId");
    public static readonly HttpRequestOptionsKey<string> OperationalEntityId =
        new("Yeshua.Operational.OperationalEntityId");
    public static readonly HttpRequestOptionsKey<string> CorrelationId =
        new("Yeshua.Operational.CorrelationId");
    public static readonly HttpRequestOptionsKey<string> MessageId =
        new("Yeshua.Operational.MessageId");
}

public sealed class OperationalHttpTelemetryHandler : DelegatingHandler
{
    private const string Component = "ExternalDependency";
    private readonly Dominio.Interfaces.ILogger _logger;

    public OperationalHttpTelemetryHandler(Dominio.Interfaces.ILogger logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var operation = GetOperation(request);
        var entity = GetOption(request, OperationalHttpRequestOptions.Entity);
        var recordId = GetOption(request, OperationalHttpRequestOptions.RecordId);
        var identity = ReadIdentity(request);
        Dominio.Interfaces.OperationalTelemetryDecision telemetry;
        try
        {
            telemetry = _logger.Evaluate(
                Component,
                operation,
                entity,
                recordId,
                identity.OperationId);
        }
        catch
        {
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        if (!telemetry.Enabled)
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

        var startedTimestamp = Stopwatch.GetTimestamp();
        var dependency = request.RequestUri?.Host;

        try
        {
            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            var succeeded = response.IsSuccessStatusCode;
            Publish(
                request,
                operation,
                entity,
                recordId,
                dependency,
                identity,
                telemetry,
                startedTimestamp,
                succeeded ? "Completed" : "Failed",
                succeeded
                    ? OperationalTechnicalOutcome.Succeeded
                    : OperationalTechnicalOutcome.Failed,
                (int)response.StatusCode,
                succeeded ? null : $"HTTP_{(int)response.StatusCode}",
                succeeded ? null : "External HTTP dependency returned a non-success status.");
            return response;
        }
        catch (Exception exception)
        {
            var timedOut = exception is TaskCanceledException && !cancellationToken.IsCancellationRequested;
            Publish(
                request,
                operation,
                entity,
                recordId,
                dependency,
                identity,
                telemetry,
                startedTimestamp,
                timedOut ? "TimedOut" : "Failed",
                timedOut
                    ? OperationalTechnicalOutcome.TimedOut
                    : OperationalTechnicalOutcome.Unavailable,
                null,
                exception.GetType().Name,
                timedOut
                    ? "External HTTP dependency timed out."
                    : $"External HTTP dependency failed with {exception.GetType().Name}.");
            throw;
        }
    }

    private void Publish(
        HttpRequestMessage request,
        string operation,
        string? entity,
        string? recordId,
        string? dependency,
        OperationalExecutionIdentity identity,
        Dominio.Interfaces.OperationalTelemetryDecision telemetry,
        long startedTimestamp,
        string phase,
        OperationalTechnicalOutcome technicalOutcome,
        int? statusCode,
        string? errorCode,
        string? errorSummary)
    {
        _logger.Transition(
            new OperationalEvidenceTransition(
                Component,
                operation,
                phase,
                (long)Stopwatch.GetElapsedTime(startedTimestamp).TotalMilliseconds,
                technicalOutcome,
                OperationalBusinessOutcome.NotEvaluated,
                identity,
                entity,
                recordId,
                GetOption(request, OperationalHttpRequestOptions.OperationalEntityId),
                GetOption(request, OperationalHttpRequestOptions.CorrelationId),
                GetOption(request, OperationalHttpRequestOptions.MessageId),
                dependency,
                ErrorCode: errorCode,
                ErrorSummary: errorSummary,
                StatusCode: statusCode),
            telemetry);
    }

    private static string GetOperation(HttpRequestMessage request)
    {
        if (request.Options.TryGetValue(OperationalHttpRequestOptions.Operation, out var operation) &&
            !string.IsNullOrWhiteSpace(operation))
        {
            return operation;
        }

        if (request.Method == HttpMethod.Get)
            return "HTTP.GET";
        if (request.Method == HttpMethod.Post)
            return "HTTP.POST";
        if (request.Method == HttpMethod.Put)
            return "HTTP.PUT";
        if (request.Method == HttpMethod.Delete)
            return "HTTP.DELETE";
        if (request.Method == HttpMethod.Patch)
            return "HTTP.PATCH";

        return "HTTP";
    }

    private static string? GetOption(
        HttpRequestMessage request,
        HttpRequestOptionsKey<string> key) =>
        request.Options.TryGetValue(key, out var value) && !string.IsNullOrWhiteSpace(value)
            ? value
            : null;

    private static OperationalExecutionIdentity ReadIdentity(HttpRequestMessage request) =>
        new(
            ReadHeader(request, OperationalExecutionHeaders.RootOperationId),
            ReadHeader(request, OperationalExecutionHeaders.OperationId),
            ReadHeader(request, OperationalExecutionHeaders.ExecutionId),
            ReadHeader(request, OperationalExecutionHeaders.CausationId));

    private static string? ReadHeader(HttpRequestMessage request, string name) =>
        request.Headers.TryGetValues(name, out var values)
            ? OperationalExecutionIdentityState.NormalizeExternalId(values.FirstOrDefault())
            : null;
}
