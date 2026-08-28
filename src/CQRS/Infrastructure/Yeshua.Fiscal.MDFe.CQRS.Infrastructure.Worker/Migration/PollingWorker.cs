using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RepositoryInterfaces.Patterns.Command;

namespace Worker.Custon;

public sealed class PollingWorker<TReceiver, TCommand, TResponse> : BackgroundService
    where TReceiver : class, IReceiver<TCommand, TResponse>
    where TCommand : class, ICommand, new()
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<PollingWorker<TReceiver, TCommand, TResponse>> _logger;
    private readonly TimeSpan _interval;

    public PollingWorker(
        IServiceProvider serviceProvider,
        ILogger<PollingWorker<TReceiver, TCommand, TResponse>> logger,
        TimeSpan interval)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _interval = interval;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var workerName = typeof(TReceiver).Name;
        _logger.LogInformation("Worker {Worker} iniciado.", workerName);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var receiver = scope.ServiceProvider.GetRequiredService<TReceiver>();
                var result = await receiver.ExecuteAsync(new TCommand(), stoppingToken);

                if (result.StatusCode >= 400)
                    _logger.LogWarning("Worker {Worker}: {StatusCode} - {Message}", workerName, result.StatusCode, result.Message);
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                break;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Erro inesperado no Worker {Worker}.", workerName);
            }

            await Task.Delay(_interval, stoppingToken);
        }
    }
}