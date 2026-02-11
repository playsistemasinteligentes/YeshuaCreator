using Shered.Services;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.Command;
using Command.Receivers.UseCase;
using Command.UseCase;

namespace Worker.Migration
{
    public class DependencInjection
    {
        public static void MapIndependenceInjection(WebApplicationBuilder builder)
        {
            builder.Services.AddLogging();

            // =============================
            // RECEIVERS (Scoped)
            // =============================

            builder.Services.AddScoped<
                IReceiver<WorkerInboxUseCaseInputCommand, WorkerInboxUseCaseOutputCommand>,
                WorkerInboxUseCaseReceiver>();

            builder.Services.AddScoped<
                IReceiver<WorkerOutBoxUseCaseInputCommand, WorkerOutBoxUseCaseOutputCommand>,
                WorkerOutBoxUseCaseReceiver>();


            // =============================
            // WORKERS (Singleton)
            // =============================

            builder.Services.AddSingleton<
                Worker<WorkerInboxUseCaseInputCommand, WorkerInboxUseCaseOutputCommand>>(sp =>
                {
                    return new Worker<WorkerInboxUseCaseInputCommand, WorkerInboxUseCaseOutputCommand>(
            sp, // IServiceProvider
            () => new WorkerInboxUseCaseInputCommand(), // factory
            sp.GetRequiredService<
                ILogger<Worker<WorkerInboxUseCaseInputCommand, WorkerInboxUseCaseOutputCommand>>>(),
            TimeSpan.FromSeconds(5)
        );
                });

            builder.Services.AddSingleton<
                Worker<WorkerOutBoxUseCaseInputCommand, WorkerOutBoxUseCaseOutputCommand>>(sp =>
                {
                    return new Worker<WorkerOutBoxUseCaseInputCommand, WorkerOutBoxUseCaseOutputCommand>(
            sp,
            () => new WorkerOutBoxUseCaseInputCommand(),
            sp.GetRequiredService<
                ILogger<Worker<WorkerOutBoxUseCaseInputCommand, WorkerOutBoxUseCaseOutputCommand>>>(),
            TimeSpan.FromSeconds(3)
        );
                });


            builder.Services.AddSingleton<WorkerHost>();
        }
    }
}
