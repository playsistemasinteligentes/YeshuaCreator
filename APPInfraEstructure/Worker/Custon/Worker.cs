using RepositoryInterfaces.Patterns.Command;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public class Worker<TCommand, TResponse>
    where TCommand : ICommand
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<Worker<TCommand, TResponse>> _logger;
    private readonly TimeSpan _interval;
    private readonly Func<TCommand> _commandFactory;

    public Worker(
        IServiceProvider serviceProvider,
        Func<TCommand> commandFactory,
        ILogger<Worker<TCommand, TResponse>> logger,
        TimeSpan interval)
    {
        _serviceProvider = serviceProvider;
        _commandFactory = commandFactory;
        _logger = logger;
        _interval = interval;
    }

    public async Task RunAsync(CancellationToken token)
    {
        _logger.LogInformation("Worker {Worker} iniciado.", typeof(TCommand).Name);

        while (!token.IsCancellationRequested)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var receiver = scope.ServiceProvider
                        .GetRequiredService<IReceiver<TCommand, TResponse>>();

                    var command = _commandFactory();

                    var result = receiver.Execute(command);

                    if (result.StatusCode >= 400)
                    {
                        _logger.LogWarning("Erro no worker {Worker}: {Message}",
                            typeof(TCommand).Name,
                            result.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado no worker {Worker}",
                    typeof(TCommand).Name);
            }

            await Task.Delay(_interval, token);
        }

        _logger.LogInformation("Worker {Worker} finalizado.",
            typeof(TCommand).Name);
    }
}
