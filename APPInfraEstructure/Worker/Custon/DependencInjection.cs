using Shered.Services;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.Command;
using Command.Receivers.UseCase;
using Command.UseCase;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Aplication.Interfaces.Services;
using System.Security.Claims;
using Microsoft.Data.SqlClient;
using System.Data;
using Shered.DB.Connection;
using Command.Interfaces.Patterns.Queue;
using Worker.Custon;
using Shared.InterfacesConcrete.Queue.RabbitMQ;
using Shered.ConcretInterfaces.Queue.RabbitMQ;
using Command.Interfaces.Patterns.FileStore;
using Shered.ConcretInterfaces.FileStore;
using RepositoryInterfaces.Patterns.UnitOfWork;

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

            builder.Services.Configure<FileSystemOptions>(builder.Configuration.GetSection("FileSystem"));
            builder.Services.AddScoped<IFileStorage, FileSystemStorage>();





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
                IReceiver<WorkerPollingInboxUseCaseInputCommand, WorkerPollingInboxUseCaseOutputCommand>,
                WorkerPollingInboxUseCaseReceiver>();

            builder.Services.AddScoped<
                IReceiver<WorkerPollingOutBoxUseCaseInputCommand, WorkerPollingOutBoxUseCaseOutputCommand>,
                WorkerPollingOutBoxUseCaseReceiver>();


            // =============================
            // WORKERS (Hosted Services)
            // =============================

            builder.Services.AddScoped<
       WorkerPollingInboxUseCaseReceiver>();

            builder.Services.AddHostedService(sp =>
                new PollingWorker<
                    WorkerPollingInboxUseCaseReceiver,
                    WorkerPollingInboxUseCaseInputCommand,
                    WorkerPollingInboxUseCaseOutputCommand>(
                    sp,
                    sp.GetRequiredService<
                        ILogger<PollingWorker<
                            WorkerPollingInboxUseCaseReceiver,
                            WorkerPollingInboxUseCaseInputCommand,
                            WorkerPollingInboxUseCaseOutputCommand>>>(),
                        TimeSpan.FromSeconds(5)
                    ));



            builder.Services.AddScoped<WorkerPollingOutBoxUseCaseReceiver>();

            builder.Services.AddHostedService(sp =>
                new PollingWorker<
                    WorkerPollingOutBoxUseCaseReceiver,
                    WorkerPollingOutBoxUseCaseInputCommand,
                    WorkerPollingOutBoxUseCaseOutputCommand>(
                    sp,
                    sp.GetRequiredService<
                        ILogger<PollingWorker<WorkerPollingOutBoxUseCaseReceiver, WorkerPollingOutBoxUseCaseInputCommand
                        , WorkerPollingOutBoxUseCaseOutputCommand>>>(),
                    TimeSpan.FromSeconds(5)
                ));


            builder.Services.AddScoped<WorkerListenerInBoxUseCaseInputCommand>();

            // HostedService do Listener
            builder.Services.AddHostedService(sp =>
            {
                var listener = sp.GetRequiredService<IQueueListener>();
                var logger = sp.GetRequiredService<ILogger<QueueListenerWorker<
                    WorkerListenerInBoxUseCaseReceiver,
                    WorkerListenerInBoxUseCaseInputCommand,
                    WorkerListenerInBoxUseCaseOutputCommand>>>();

                return new QueueListenerWorker<
                    WorkerListenerInBoxUseCaseReceiver,
                    WorkerListenerInBoxUseCaseInputCommand,
                    WorkerListenerInBoxUseCaseOutputCommand>(
                        sp,
                        listener,
                        logger,
                        queueName: "audio.transcribed.inbox"
                );
            });






        }
    }
}
