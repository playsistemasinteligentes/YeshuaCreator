using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Command.Interfaces.Patterns.Queue;
using Command.Patterns.Queue;
using RepositoryInterfaces.Patterns.Command;

namespace Worker.Custon
{
    public class QueueListenerWorker<TReceiver, TCommand, TResponse> : BackgroundService
        where TReceiver : class, IReceiver<TCommand, TResponse>
        where TCommand : class, ICommand, new()
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IQueueListener _listener;
        private readonly ILogger<QueueListenerWorker<TReceiver, TCommand, TResponse>> _logger;
        private readonly string _queueName;

        public QueueListenerWorker(
            IServiceProvider serviceProvider,
            IQueueListener listener,
            ILogger<QueueListenerWorker<TReceiver, TCommand, TResponse>> logger,
            string queueName)
        {
            _serviceProvider = serviceProvider;
            _listener = listener;
            _logger = logger;
            _queueName = queueName;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var workerName = typeof(TReceiver).Name;

            _logger.LogInformation("QueueListenerWorker {Worker} iniciado.", workerName);

            await _listener.ListenAsync(_queueName, async message =>
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();

                    var receiver = scope.ServiceProvider.GetRequiredService<TReceiver>();

                    var command = new TCommand();

                    var result = receiver.Execute(command);

                    if (result.StatusCode >= 400)
                    {
                        _logger.LogWarning(
                            "QueueListenerWorker {Worker} erro {StatusCode} - {Message}",
                            workerName,
                            result.StatusCode,
                            result.Message);
                    }
                    else
                    {
                        _logger.LogInformation(
                            "QueueListenerWorker {Worker} executado com sucesso.",
                            workerName);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro no QueueListenerWorker {Worker}", workerName);
                    throw;
                }

            }, stoppingToken);
        }
    }
}


