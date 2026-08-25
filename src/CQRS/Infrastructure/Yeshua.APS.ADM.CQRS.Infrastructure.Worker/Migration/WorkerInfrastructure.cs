using Aplication.Interfaces.Services;
using Command.Interfaces.Patterns.FileStore;
using Command.Interfaces.Patterns.Queue;
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

        // pendencia: registrar workers de polling, fila, saga, inbox ou outbox
        // somente quando a DSL do aplicativo declarar essas politicas.
        // observacao: handlers que implementam IWorkerCycleResult alimentam
        // a telemetria do Command pelo ReciverBase.
    }
}