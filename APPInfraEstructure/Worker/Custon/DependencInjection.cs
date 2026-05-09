using Aplication.Interfaces.Services;
using Command.Interfaces.Patterns.FileStore;
using Command.Interfaces.Patterns.Queue;
using Command.Patterns;
using Command.Patterns.Command;
using Command.Patterns.OutBox;
using Command.Receivers;
using Command.Receivers.UseCase;
using Command.UseCase;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyApp.Domain.Entities;
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

namespace Migration
{
    public static class CustonDependenceInjection
    {
        public static void MapCustonDependenceInjection(WebApplicationBuilder builder)
        {
            builder.Services.AddLogging();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IExecutionContext, WorkerExecutionContext>();
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

            //   pendencia mok sql lite       builder.Services.AddScoped<ISqlFactory>(_ =>new SqlFactoryMokSqlite("Data Source=app.db"));
            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            builder.Services.AddScoped<IReceiver<InputCommand, OutputCommand>, SagaWorkerCommandHandler>();
            builder.Services.AddScoped<SagaWorkerCommandHandler>();
            builder.Services.AddHostedService(sp =>
                 new PollingWorker<
                     SagaWorkerCommandHandler,
                     InputCommand,
                     OutputCommand>(
                     sp,
                     sp.GetRequiredService<
                         ILogger<PollingWorker<SagaWorkerCommandHandler, InputCommand, OutputCommand>>>(),
                     TimeSpan.FromMilliseconds(5000)
                 ));



            //builder.Services.AddScoped<IReceiver<InputCommand, OutputCommand>, SagaWorkerCommandHandler>();
            builder.Services.AddScoped<yOutBoxWorkerHandler>();
            builder.Services.AddHostedService(sp =>
                 new PollingWorker< yOutBoxWorkerHandler, yOutboxInputCommand, yOutboxOutputCommand>(
                     sp,
                     sp.GetRequiredService<
                         ILogger<PollingWorker<yOutBoxWorkerHandler, yOutboxInputCommand, yOutboxOutputCommand>>>(),
                     TimeSpan.FromMilliseconds(5000)
                 ));


            //builder.Services.AddScoped<IReceiver<InboxInputCommand, OutputCommand>, SagaInboxWorkerCommandHandler>();
            builder.Services.AddScoped<SagaInboxWorkerCommandHandler>();
            builder.Services.AddHostedService(sp =>
                 new PollingWorker<
                     SagaInboxWorkerCommandHandler,
                     InputCommand,
                     OutputCommand>(
                     sp,
                     sp.GetRequiredService<
                         ILogger<PollingWorker<SagaInboxWorkerCommandHandler, InputCommand, OutputCommand>>>(),
                     TimeSpan.FromMilliseconds(5000)
                 ));



            // pendecia colocar no motor baseado nas filas inbox  acho que os serviços de cimo podem ficar o oque caracteriza algo fora do motor mas este em especifico a quantidade de filas pode variar 
            builder.Services.AddScoped<InboxListenerHandler>();

            builder.Services.AddHostedService(sp =>
            {
                var listener = sp.GetRequiredService<IQueueListener>();
                var logger = sp.GetRequiredService<ILogger<QueueListenerWorker<InboxListenerHandler, InboxInputCommand, InboxOutputCommand>>>();
                return new QueueListenerWorker<InboxListenerHandler, InboxInputCommand, InboxOutputCommand>(
                    sp, listener, logger,
                    "text.summarized.inbox",
                    "audio.transcribed.inbox"
                );
            });

            /*
             * 
             * 
             */

            /*
            builder.Services.AddScoped<SagaResumeCommandHandler>();
             // HostedService do Listener
             builder.Services.AddHostedService(sp =>
             {
                 var listener = sp.GetRequiredService<IQueueListener>();
                 var logger = sp.GetRequiredService<ILogger<QueueListenerWorker<
                     SagaResumeCommandHandler,
                     InputSagaResumeCommand,
                     OutputCommand>>>();

                 return new QueueListenerWorker<
                     SagaResumeCommandHandler,
                     InputSagaResumeCommand,
                     OutputCommand>(
                         sp,
                         listener,
                         logger,
                         queueName: "audio.transcribed.inbox"
                 );
             });

            */

            // =============================
            // RECEIVERS (Scoped)
            // =============================

            // builder.Services.AddScoped<
            //     IReceiver<InboxInputCommand, InboxOutputCommand>,
            //     InboxHandler>();

            // builder.Services.AddScoped<
            //     IReceiver<OutBoxInputCommand, OutBoxOutputCommand>,
            //     OutBoxHandler>();


            // // =============================
            // // WORKERS (Hosted Services)
            // // =============================

            //// builder.Services.AddScoped<InboxHandler>();

            // builder.Services.AddHostedService(sp =>
            //     new PollingWorker<InboxHandler,
            //         InboxInputCommand,
            //         InboxOutputCommand>(
            //         sp,
            //         sp.GetRequiredService<
            //             ILogger<PollingWorker<
            //                 InboxHandler,
            //                 InboxInputCommand,
            //                 InboxOutputCommand>>>(),
            //             TimeSpan.FromSeconds(5)
            //         ));



            // builder.Services.AddScoped<OutBoxHandler>();

            // builder.Services.AddHostedService(sp =>
            //     new PollingWorker<
            //         OutBoxHandler,
            //         OutBoxInputCommand,
            //         OutBoxOutputCommand>(
            //         sp,
            //         sp.GetRequiredService<
            //             ILogger<PollingWorker<OutBoxHandler, OutBoxInputCommand
            //             , OutBoxOutputCommand>>>(),
            //         TimeSpan.FromSeconds(5)
            //     ));


            // builder.Services.AddScoped<InBoxInputCommand>();

            // // HostedService do Listener
            // builder.Services.AddHostedService(sp =>
            // {
            //     var listener = sp.GetRequiredService<IQueueListener>();
            //     var logger = sp.GetRequiredService<ILogger<QueueListenerWorker<
            //         InBoxHandler,
            //         InBoxInputCommand,
            //         InBoxOutputCommand>>>();

            //     return new QueueListenerWorker<
            //         InBoxHandler,
            //         InBoxInputCommand,
            //         InBoxOutputCommand>(
            //             sp,
            //             listener,
            //             logger,
            //             queueName: "audio.transcribed.inbox"
            //     );
            // });
        }
    }
}
