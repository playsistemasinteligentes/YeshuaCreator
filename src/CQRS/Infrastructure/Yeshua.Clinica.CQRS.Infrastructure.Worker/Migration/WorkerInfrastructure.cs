using Aplication.Interfaces.Services;
using Command.Interfaces.Patterns.FileStore;
using Command.Interfaces.Patterns.Queue;
using Command.Patterns.OutBox;
using Microsoft.Extensions.Logging;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shared.InterfacesConcrete.Queue.RabbitMQ;
using Shered.ConcretInterfaces.Queue.RabbitMQ;
using Shered.DB.Connection;
using Shered.Patterns.FileStore;
using Worker.Custon;

namespace Migrations;

public static class WorkerInfrastructure
{
    public static void MapWorkerInfrastructure(WebApplicationBuilder builder)
    {
        builder.Services.AddLogging();
        builder.Services.AddScoped<IExecutionContext, WorkerExecutionContext>();

        builder.Services.Configure<RabbitMqOptions>(builder.Configuration.GetSection("RabbitMq"));
        builder.Services.AddSingleton<RabbitMqConnectionManager>();
        builder.Services.AddSingleton<IQueueTopologyInitializer, RabbitMqTopologyInitializer>();
        builder.Services.AddSingleton<IQueuePublisher, RabbitMQQueuePublisher>();
        builder.Services.AddSingleton<IQueueListener, RabbitMQQueueListener>();

        builder.Services.Configure<StorageSettings>(builder.Configuration.GetSection("Storage"));
        builder.Services.AddScoped<IFileStorage, StorageService>();
        builder.Services.AddScoped<IStorageProvider, DiskStorageProvider>();
        builder.Services.AddScoped<StorageResolver>();

        builder.Services.AddScoped<ISqlFactory>(_ =>
            new SqlFactory(EnumSqlConections.SqlServer, GS.I.MYC.ReadConectionString));

        builder.Services.AddScoped<yOutBoxWorkerHandler>();
        builder.Services.AddHostedService(serviceProvider =>
            new PollingWorker<yOutBoxWorkerHandler, yOutboxInputCommand, yOutboxOutputCommand>(
                serviceProvider,
                serviceProvider.GetRequiredService<ILogger<
                    PollingWorker<yOutBoxWorkerHandler, yOutboxInputCommand, yOutboxOutputCommand>>>(),
                TimeSpan.FromSeconds(5)));

        // pendencia: registrar SagaWorkerCommandHandler e SagaInboxWorkerCommandHandler
        // somente quando as sagas do aplicativo estiverem habilitadas pela DSL.
        // observacao: ambos ja retornam IWorkerCycleResult; o ReciverBase
        // incorpora os contadores na telemetria do Command.
    }
}