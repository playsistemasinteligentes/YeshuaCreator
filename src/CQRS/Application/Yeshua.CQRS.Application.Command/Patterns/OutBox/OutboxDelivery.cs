using Command.Interfaces.Patterns.Queue;
using Command.Patterns.Queue;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Command.Patterns.OutBox;

// One delivery boundary for durable Outbox requests. Providers never apply saga state.
public interface IOutboxDeliveryStrategy
{
    int TransportType { get; }
    Task<ExternalExecutionResult?> DeliverAsync(OutboxDeliveryRequest request, CancellationToken cancellationToken);
}

public interface IOutboxDeliveryFactory
{
    string SelectProvider(OutboxDeliveryRequest request);
    IOutboxDeliveryStrategy GetType(string provider);
}

public sealed record OutboxDeliveryRequest(
    QueueMessage Message, string TransportData, int TransportType, int TenantId, string ResultContract);

public sealed record ExternalExecutionError(string code, string message, bool retryable);

public sealed record ExternalExecutionResult(
    string messageId, string requestId, string correlationId, string status,
    JsonElement result, JsonElement error)
{
    public static ExternalExecutionResult Create(OutboxDeliveryRequest request, string status, JsonElement result,
        ExternalExecutionError? error = null)
    {
        var requestId = request.Message.MenssageId
            ?? throw new OutboxDeliveryException("request_missing", "Pedido sem identidade.", false);
        return new("outbox-result-" + Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(requestId))),
            requestId, request.Message.CorrelationId ?? "", status, result,
            JsonSerializer.SerializeToElement(error, OutboxDeliveryJson.Default.ExternalExecutionError));
    }

    public static ExternalExecutionResult DeliveryFailed(OutboxDeliveryRequest request, string code)
        => Create(request, "external.delivery.failed",
            JsonSerializer.SerializeToElement<object?>(null, OutboxDeliveryJson.Default.Object),
            new(code, "Nao foi possivel entregar o pedido ao executor externo.", false));
}

public sealed class OutboxDeliveryException : Exception
{
    public string Code { get; }
    public bool Retryable { get; }
    public TimeSpan? RetryAfter { get; }
    public OutboxDeliveryException(string code, string message, bool retryable, TimeSpan? retryAfter = null)
        : base(message) => (Code, Retryable, RetryAfter) = (code, retryable, retryAfter);
}

public sealed class QueueOutboxDeliveryStrategy(IQueuePublisher publisher) : IOutboxDeliveryStrategy
{
    public int TransportType => 1;
    public async Task<ExternalExecutionResult?> DeliverAsync(OutboxDeliveryRequest request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        QueueDeliverySettings settings;
        try
        {
            settings = JsonSerializer.Deserialize(request.TransportData, OutboxDeliveryJson.Default.QueueDeliverySettings)
                ?? throw new JsonException();
        }
        catch (JsonException)
        {
            throw new OutboxDeliveryException("queue_settings_invalid", "Entrega de fila invalida.", false);
        }
        if (request.TransportType != 1 || string.IsNullOrWhiteSpace(settings.Queue)
            || string.IsNullOrWhiteSpace(settings.Exchange) || string.IsNullOrWhiteSpace(settings.RoutingKey)
            || string.IsNullOrWhiteSpace(settings.TaskName))
            throw new OutboxDeliveryException("queue_settings_invalid", "Entrega de fila invalida.", false);
        if (!await publisher.PublishCeleryAsync(settings.Queue, settings.Exchange, settings.RoutingKey,
                settings.TaskName, request.Message).ConfigureAwait(false))
            throw new OutboxDeliveryException("queue_publish_failed", "Entrega de fila indisponivel.", true);
        return null; // The external executor returns the same result contract through Inbox.
    }
}

public sealed class QueueOutboxDeliveryFactory(IQueuePublisher publisher) : IOutboxDeliveryFactory
{
    private readonly QueueOutboxDeliveryStrategy _queue = new(publisher);
    public string SelectProvider(OutboxDeliveryRequest request) => "Queue";
    public IOutboxDeliveryStrategy GetType(string provider) => provider == "Queue" ? _queue
        : throw new OutboxDeliveryException("provider_invalid", "Destino de entrega invalido.", false);
}

public sealed class QueueDeliverySettings
{
    public string Queue { get; set; } = "";
    public string Exchange { get; set; } = "";
    public string RoutingKey { get; set; } = "";
    public string TaskName { get; set; } = "";
    public string? DeliveryProvider { get; set; }
}

[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
[JsonSerializable(typeof(QueueDeliverySettings))]
[JsonSerializable(typeof(ExternalExecutionError))]
[JsonSerializable(typeof(object))]
internal partial class OutboxDeliveryJson : JsonSerializerContext;
