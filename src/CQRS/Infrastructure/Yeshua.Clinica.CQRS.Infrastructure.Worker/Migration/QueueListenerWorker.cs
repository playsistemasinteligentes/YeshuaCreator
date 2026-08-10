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
    private readonly IServiceProvider _serviceProvider;
    private readonly IQueueListener _listener;
    private readonly ILogger<QueueListenerWorker<TReceiver, TCommand, TResponse>> _logger;
    private readonly string[] _queues;

    public QueueListenerWorker(
        IServiceProvider serviceProvider,
        IQueueListener listener,
        ILogger<QueueListenerWorker<TReceiver, TCommand, TResponse>> logger,
        params string[] queues)
    {
        _serviceProvider = serviceProvider;
        _listener = listener;
        _logger = logger;
        _queues = queues;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        foreach (var queue in _queues)
        {
            _ = Task.Run(() => _listener.ListenAsync<TCommand>(queue, async message =>
            {
                using var scope = _serviceProvider.CreateScope();
                var receiver = scope.ServiceProvider.GetRequiredService<TReceiver>();
                var result = receiver.Execute(message);

                if (result.StatusCode >= 400)
                    _logger.LogWarning("Fila {Queue}: {StatusCode} - {Message}", queue, result.StatusCode, result.Message);

                await Task.CompletedTask;
            }, stoppingToken), stoppingToken);
        }

        return Task.CompletedTask;
    }
}