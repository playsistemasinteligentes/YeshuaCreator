using Aplication.Interfaces.Services;
using Command.Interfaces.Patterns.FileStore;
using Command.Interfaces.Patterns.Queue;
using Shared.InterfacesConcrete.Queue.RabbitMQ;
using Shered.ConcretInterfaces.FileStore;
using Shered.ConcretInterfaces.Queue.RabbitMQ;
using Shered.DB.Connection;
using Shered.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
namespace API.Migrations
{
    public static class IndependenceInjectionCuston
    {
        public static void MapIndependenceInjection(WebApplicationBuilder builder)
        {

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ICurrentUser, CurrentUserHttp>();
            builder.Services.Configure<RabbitMqOptions>(builder.Configuration.GetSection("RabbitMq"));
            builder.Services.AddSingleton<RabbitMqConnectionManager>();
            builder.Services.AddSingleton<IQueueTopologyInitializer, RabbitMqTopologyInitializer>();
            builder.Services.AddSingleton<Command.Interfaces.Patterns.Queue.IQueuePublisher, RabbitMQQueuePublisher>();
            builder.Services.AddSingleton<Command.Interfaces.Patterns.Queue.IQueueListener, RabbitMQQueueListener>();

            builder.Services.Configure<FileSystemOptions>(builder.Configuration.GetSection("FileSystem"));
            builder.Services.AddScoped<IFileStorage, FileSystemStorage>();


            builder.Services.AddScoped<ISqlFactory>(provader => new SqlFactory(EnumSqlConections.SqlServer, GS.I.MYC.ReadConectionString));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureAPIIndependenceInjectionMigration