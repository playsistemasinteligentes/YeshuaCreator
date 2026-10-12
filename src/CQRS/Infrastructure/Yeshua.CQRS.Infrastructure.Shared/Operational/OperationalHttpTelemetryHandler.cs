using Aplication.Interfaces.Services;
using Dominio.Operational;
using Shared.ModuleTransport;
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
    public static readonly HttpRequestOptionsKey<int> Attempt =
        new("Yeshua.Operational.Attempt");
}

public sealed class OperationalHttpTelemetryHandler : DelegatingHandler
{
    private const string Component = "ExternalCallEvents";
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
        var telemetry = Evaluate(Component, operation, entity, recordId, identity.OperationId);
        var moduleDelivery = IsYeshuaModuleDelivery(request);
        var messageId = moduleDelivery ? GetMessageId(request) : null;
        var deliveryTelemetry = moduleDelivery
            ? Evaluate("Outbox", operation, "yOutbox", messageId, identity.OperationId)
            : default;

        if (!telemetry.Enabled && !deliveryTelemetry.Enabled)
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

        var startedTimestamp = Stopwatch.GetTimestamp();
        var dependency = request.RequestUri?.Host;
        if (deliveryTelemetry.Enabled)
        {
            Publish(
                request,
                "Outbox",
                operation,
                "yOutbox",
                messageId,
                dependency,
                identity,
                deliveryTelemetry,
                startedTimestamp,
                "DeliveryStarted",
                OperationalTechnicalOutcome.NotEvaluated,
                null,
                null,
                null);
        }

        try
        {
            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            var succeeded = response.IsSuccessStatusCode;
            if (telemetry.Enabled)
            {
                Publish(
                    request,
                    Component,
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
            }
            if (deliveryTelemetry.Enabled)
            {
                Publish(
                    request,
                    "Outbox",
                    operation,
                    "yOutbox",
                    messageId,
                    dependency,
                    identity,
                    deliveryTelemetry,
                    startedTimestamp,
                    succeeded ? "Delivered" : "DeliveryFailed",
                    succeeded
                        ? OperationalTechnicalOutcome.Succeeded
                        : OperationalTechnicalOutcome.Failed,
                    (int)response.StatusCode,
                    succeeded ? null : $"HTTP_{(int)response.StatusCode}",
                    succeeded ? null : "Outbox delivery returned a non-success status.");
            }
            return response;
        }
        catch (Exception exception)
        {
            var timedOut = exception is TaskCanceledException && !cancellationToken.IsCancellationRequested;
            if (telemetry.Enabled)
            {
                Publish(
                    request,
                    Component,
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
            }
            if (deliveryTelemetry.Enabled)
            {
                Publish(
                    request,
                    "Outbox",
                    operation,
                    "yOutbox",
                    messageId,
                    dependency,
                    identity,
                    deliveryTelemetry,
                    startedTimestamp,
                    "DeliveryFailed",
                    timedOut
                        ? OperationalTechnicalOutcome.TimedOut
                        : OperationalTechnicalOutcome.Unavailable,
                    null,
                    exception.GetType().Name,
                    timedOut
                        ? "Outbox delivery timed out."
                        : $"Outbox delivery failed with {exception.GetType().Name}.");
            }
            throw;
        }
    }

    private void Publish(
        HttpRequestMessage request,
        string component,
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
                component,
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
                GetMessageId(request),
                dependency,
                GetAttempt(request),
                ErrorCode: errorCode,
                ErrorSummary: errorSummary,
                StatusCode: statusCode),
            telemetry);
    }

    private Dominio.Interfaces.OperationalTelemetryDecision Evaluate(
        string component,
        string operation,
        string? entity,
        string? recordId,
        string? operationId)
    {
        try
        {
            return _logger.Evaluate(component, operation, entity, recordId, operationId);
        }
        catch
        {
            return default;
        }
    }

    private static bool IsYeshuaModuleDelivery(HttpRequestMessage request) =>
        !string.IsNullOrWhiteSpace(GetMessageId(request)) &&
        request.RequestUri?.AbsolutePath.EndsWith(
            "/Inbox/YeshuaModuleEvent",
            StringComparison.OrdinalIgnoreCase) == true;

    private static string? GetMessageId(HttpRequestMessage request) =>
        GetOption(request, OperationalHttpRequestOptions.MessageId)
        ?? ReadHeader(request, YeshuaModuleAuthenticationHeaders.MessageId);

    private static int GetAttempt(HttpRequestMessage request) =>
        request.Options.TryGetValue(OperationalHttpRequestOptions.Attempt, out var attempt)
            ? attempt
            : 0;

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
