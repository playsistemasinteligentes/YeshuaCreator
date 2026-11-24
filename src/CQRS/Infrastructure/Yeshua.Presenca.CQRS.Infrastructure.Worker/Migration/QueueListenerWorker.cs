using Command.Interfaces.Patterns.Queue;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RepositoryInterfaces.Patterns.Command;
namespace Worker.Custon;

public sealed class QueueListenerWorker<TReceiver, TCommand, TResponse> : BackgroundService
    where TReceiver : class, IReceiver<TCommand, TResponse>
    where TCommand : class, ICommand, new()
{
    private readonly IServiceProvider _services;
    private readonly IQueueListener _listener;
    private readonly ILogger<QueueListenerWorker<TReceiver, TCommand, TResponse>> _logger;
    private readonly string[] _queues;
    public QueueListenerWorker(IServiceProvider services, IQueueListener listener,
        ILogger<QueueListenerWorker<TReceiver, TCommand, TResponse>> logger, params string[] queues)
        { _services = services; _listener = listener; _logger = logger; _queues = queues; }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
        => Task.WhenAll(_queues.Select(queue => Listen(queue, stoppingToken)));

    private async Task Listen(string queue, CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            try
            {
                await _listener.ListenAsync<TCommand>(queue, async message =>
                {
                    if (message is IQueueReceivedCommand received) received.QueueName = queue;
                    using var scope = _services.CreateScope();
                    var receiver = scope.ServiceProvider.GetRequiredService<TReceiver>();
                    var result = await receiver.ExecuteAsync(message, token);
                    if (result.StatusCode >= 400)
                        throw new InvalidOperationException("Receiver recusou a entrega da fila.");
                }, token);
            }
            catch (OperationCanceledException) when (token.IsCancellationRequested) { return; }
            catch (Exception exception)
            {
                _logger.LogWarning("Consumidor indisponivel: {ErrorType}", exception.GetType().Name);
                await Task.Delay(TimeSpan.FromSeconds(5), token);
            }
        }
    }
}
