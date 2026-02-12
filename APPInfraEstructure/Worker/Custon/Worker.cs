using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RepositoryInterfaces.Patterns.Command;

public class Worker<TReceiver, TCommand, TResponse> : BackgroundService
    where TReceiver : class, IReceiver<TCommand, TResponse>
    where TCommand : class, ICommand, new()
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<Worker<TReceiver, TCommand, TResponse>> _logger;
    private readonly TimeSpan _interval;

    public Worker(
        IServiceProvider serviceProvider,
        ILogger<Worker<TReceiver, TCommand, TResponse>> logger,
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

                var receiver = scope.ServiceProvider
                    .GetRequiredService<TReceiver>();

                var command = new TCommand();

                var result = receiver.Execute(command);

                if (result.StatusCode >= 400)
                {
                    _logger.LogWarning(
                        "Worker {Worker} erro {StatusCode} - {Message}",
                        workerName,
                        result.StatusCode,
                        result.Message);
                }
                else
                {
                    _logger.LogInformation(
                        "Worker {Worker} executado com sucesso.",
                        workerName);
                }
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Erro inesperado no Worker {Worker}",
                    workerName);
            }

            try
            {
                await Task.Delay(_interval, stoppingToken);
            }
            catch (TaskCanceledException)
            {
                break;
            }
        }

        _logger.LogInformation("Worker {Worker} finalizado.", workerName);
    }
}
