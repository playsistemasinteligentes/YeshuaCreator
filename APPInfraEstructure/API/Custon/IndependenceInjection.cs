using Shered.Services;
using Aplication.Interfaces.Services;
using Shared.InterfacesConcrete.Queue.RabbitMQ;
using Shered.ConcretInterfaces.FileStore;
using Command.Interfaces.Patterns.FileStore;
namespace API.Migrations
{
    public static class IndependenceInjectionCuston
    {
        public static void MapIndependenceInjection(WebApplicationBuilder builder)
        {

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ICurrentUser, CurrentUserHttp>();
            builder.Services.Configure<RabbitMqOptions>(builder.Configuration.GetSection("RabbitMq"));
            builder.Services.AddScoped<Command.Interfaces.Patterns.Queue.IQueuePublisher, RabbitMQQueuePublisher>();
            builder.Services.AddScoped<Command.Interfaces.Patterns.Queue.IQueueListener, RabbitMQQueueListener>();

            builder.Services.Configure<FileSystemOptions>(builder.Configuration.GetSection("FileSystem"));
            builder.Services.AddScoped<IFileStorage, FileSystemStorage>();




        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureAPIIndependenceInjectionMigration