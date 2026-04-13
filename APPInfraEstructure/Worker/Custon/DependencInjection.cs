using Aplication.Interfaces.Services;
using Command.Interfaces.Patterns.FileStore;
using Command.Interfaces.Patterns.Queue;
using Command.Receivers.UseCase;
using Command.UseCase;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using RepositoryInterfaces.Services;
using Shared.InterfacesConcrete.Queue.RabbitMQ;
using Shered.ConcretInterfaces.Queue.RabbitMQ;
using Shered.DB.Connection;
using Shered.Patterns.FileStore;
using Shered.Services;
using System.Data;
using System.Security.Claims;
using Worker.Custon;

namespace Worker.Migration
{
    public static class CustonIndependenceInjection
    {
        public static void MapCustonIndependenceInjection(WebApplicationBuilder builder)
        {
            builder.Services.AddLogging();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ICurrentUser, CurrentUser>();
            builder.Services.Configure<RabbitMqOptions>(builder.Configuration.GetSection("RabbitMq"));
            builder.Services.AddSingleton<RabbitMqConnectionManager>();
            builder.Services.AddSingleton<IQueueTopologyInitializer, RabbitMqTopologyInitializer>();
            builder.Services.AddSingleton<Command.Interfaces.Patterns.Queue.IQueuePublisher, RabbitMQQueuePublisher>();
            builder.Services.AddSingleton<Command.Interfaces.Patterns.Queue.IQueueListener, RabbitMQQueueListener>();

            //builder.Services.Configure<FileSystemOptions>(builder.Configuration.GetSection("FileSystem"));
            //builder.Services.AddScoped<IFileStorage, FileSystemStorage>();

            builder.Services.Configure<StorageSettings>(builder.Configuration.GetSection("Storage"));
            builder.Services.AddScoped<IFileStorage, StorageService>();
            builder.Services.AddScoped<IStorageProvider, DiskStorageProvider>();
            builder.Services.AddScoped<StorageResolver>();


            /*
             pendencia Você está declarando a fila toda vez: await channel.QueueDeclareAsync(...)
             fabrica criada a toda ora          await using var connection = await factory.CreateConnectionAsync(cancellationToken);
             */



            // pendencia retirar e aotomatizar 
            builder.Services.AddScoped<ISqlFactory>(provader => new SqlFactory(EnumSqlConections.SqlServer, GS.I.MYC.ReadConectionString));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            

            //builder.Services.AddScoped<ISqlFactory>(_ =>new SqlFactoryMokSqlite("Data Source=app.db"));
            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            // =============================
            // RECEIVERS (Scoped)
            // =============================

            builder.Services.AddScoped<
                IReceiver<InboxInputCommand, InboxOutputCommand>,
                InboxHandler>();

            builder.Services.AddScoped<
                IReceiver<OutBoxInputCommand, OutBoxOutputCommand>,
                OutBoxHandler>();


            // =============================
            // WORKERS (Hosted Services)
            // =============================

            builder.Services.AddScoped<
       InboxHandler>();

            builder.Services.AddHostedService(sp =>
                new PollingWorker<
                    InboxHandler,
                    InboxInputCommand,
                    InboxOutputCommand>(
                    sp,
                    sp.GetRequiredService<
                        ILogger<PollingWorker<
                            InboxHandler,
                            InboxInputCommand,
                            InboxOutputCommand>>>(),
                        TimeSpan.FromSeconds(5)
                    ));



            builder.Services.AddScoped<OutBoxHandler>();

            builder.Services.AddHostedService(sp =>
                new PollingWorker<
                    OutBoxHandler,
                    OutBoxInputCommand,
                    OutBoxOutputCommand>(
                    sp,
                    sp.GetRequiredService<
                        ILogger<PollingWorker<OutBoxHandler, OutBoxInputCommand
                        , OutBoxOutputCommand>>>(),
                    TimeSpan.FromSeconds(5)
                ));


            builder.Services.AddScoped<InBoxInputCommand>();

            // HostedService do Listener
            builder.Services.AddHostedService(sp =>
            {
                var listener = sp.GetRequiredService<IQueueListener>();
                var logger = sp.GetRequiredService<ILogger<QueueListenerWorker<
                    InBoxHandler,
                    InBoxInputCommand,
                    InBoxOutputCommand>>>();

                return new QueueListenerWorker<
                    InBoxHandler,
                    InBoxInputCommand,
                    InBoxOutputCommand>(
                        sp,
                        listener,
                        logger,
                        queueName: "audio.transcribed.inbox"
                );
            });
        }
    }
}
