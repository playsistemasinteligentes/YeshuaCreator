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
                receiver.Execute(new TCommand());
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                break;
            }
            catch (Exception)
            {
                // A excecao do Command ja foi registrada pelo ReciverBase.
            }

            await Task.Delay(_interval, stoppingToken);
        }
    }

}