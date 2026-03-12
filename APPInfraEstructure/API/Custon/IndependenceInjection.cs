using Shered.Services;
using Aplication.Interfaces.Services;
using Shared.InterfacesConcrete.Queue.RabbitMQ;
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


        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureAPIIndependenceInjectionMigration