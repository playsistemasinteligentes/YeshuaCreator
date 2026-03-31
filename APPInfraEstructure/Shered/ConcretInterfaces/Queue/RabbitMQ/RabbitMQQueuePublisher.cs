using Command.Interfaces.Patterns.Queue;
using Command.Patterns.Queue;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shered.ConcretInterfaces.Queue.RabbitMQ;
using System.Text;
using System.Text.Json;

namespace Shared.InterfacesConcrete.Queue.RabbitMQ;

public class RabbitMQQueuePublisher : IQueuePublisher
{
    private readonly RabbitMqConnectionManager _manager;

    public RabbitMQQueuePublisher(RabbitMqConnectionManager manager)
    {
        _manager = manager;
    }

    public async Task<bool> PublishAsync(string channelId, string exchange, string routingKey, QueueMessage message, CancellationToken ct = default)
    {
        try
        {
            var channel = await _manager.GetChannelAsync(channelId, ct);

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            var props = new BasicProperties
            {
                Persistent = true,
                ContentType = "application/json"
            };

            await channel.BasicPublishAsync(
                exchange: exchange,
                routingKey: routingKey,
                mandatory: false,
                basicProperties: props,
                body: body,
                cancellationToken: ct);

            return true;
        }
        catch
        {
            return false;
        }
    }
    public async Task<bool> PublishCeleryAsync(string channelId, string exchange, string routingKey, QueueMessage message, CancellationToken ct = default)
    {
        try
        {
            var channel = await _manager.GetChannelAsync(channelId, ct);

            object[] args;

            if (message.Payload is object[] arr)
            {
                args = arr;
            }
            else if (message.Payload is string str && str.TrimStart().StartsWith("{"))
            {
                using var doc = JsonDocument.Parse(str);

                var list = new List<object>();

                foreach (var prop in doc.RootElement.EnumerateObject())
                {
                    list.Add(prop.Name);                 // chave -> "1"
                    list.Add(prop.Value.GetString());    // valor -> URL
                }

                args = list.ToArray();
            }
            else if (message.Payload != null)
            {
                args = new object[] { message.Payload.ToString() };
            }
            else
            {
                args = Array.Empty<object>();
            }

            // 🔥 GARANTE nome correto da task (caso venha errado)
            var taskName = "app.tasks.transcribe_audio";
            var taskId = message.CorrelationId ?? message.Id.ToString();

            var celeryBody = new
            {
                id = taskId,
                task = taskName,
                args = args,
                kwargs = new { },
                retries = 0,
                eta = (string)null
            };

            var json = JsonSerializer.Serialize(celeryBody);

            Console.WriteLine("CELERY JSON:");
            Console.WriteLine(json);

            var body = Encoding.UTF8.GetBytes(json);

            var props = new BasicProperties
            {
                Persistent = true,
                ContentType = "application/json",
                ContentEncoding = "utf-8",
                Headers = new Dictionary<string, object>
            {
                { "task", taskName },
                { "id", taskId },
                { "lang", "py" },
                { "retries", 0 },
                { "eta", null }
            }
            };

            await channel.BasicPublishAsync(
                exchange: exchange,
                routingKey: routingKey,
                mandatory: false,
                basicProperties: props,
                body: body,
                cancellationToken: ct);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao publicar Celery: {ex.Message}");
            return false;
        }
    }
}