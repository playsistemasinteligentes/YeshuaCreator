using Microsoft.AspNetCore.Mvc;

namespace API.Migrations;

public static class EndpointsCuston
{
    public sealed record YeshuaModuleEventIngress(
        string MessageId,
        string Type,
        string EntityType,
        string EntityId,
        string CorrelationId,
        string Payload,
        string Source,
        string Transport);

    public static void MapEndpoints(this WebApplication app)
    {
        app.MapPost("/yapi/Fiscal/Inbox/YeshuaModuleEvent", async (
            [FromServices] Command.Receivers.Write.InsertyInboxReceiver receiver,
            [FromBody] YeshuaModuleEventIngress envelope) =>
        {
            var command = new Command.Write.yInboxCrudCommand
            {
                MessageId = string.IsNullOrWhiteSpace(envelope.MessageId) ? Guid.NewGuid().ToString() : envelope.MessageId,
                Type = envelope.Type,
                EntityType = envelope.EntityType,
                EntityId = envelope.EntityId,
                CorrelationId = envelope.CorrelationId,
                Payload = envelope.Payload,
                Status = 0,
                CreatedAt = DateTime.UtcNow,
                RetryCount = 0,
                LastError = null,
                ProcessingAt = null,
                NextAttemptAt = null,
                SagaId = null,
                SagaStepId = null
            };

            var result = await receiver.ExecuteAsync(command);
            return result.StatusCode is >= 200 and < 300
                ? Results.Accepted($"/yapi/Fiscal/Inbox/YeshuaModuleEvent/{command.MessageId}", new { command.MessageId, command.Type, Accepted = true })
                : Results.BadRequest(result);
        });
    }
}
