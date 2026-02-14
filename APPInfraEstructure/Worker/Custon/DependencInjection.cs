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
            builder.Services.AddScoped<Command.Interfaces.Patterns.Queue.IQueuePublisher, RabbitMQQueuePublisher>();
            builder.Services.AddScoped<Command.Interfaces.Patterns.Queue.IQueueListener, RabbitMQQueueListener>();
            /*
             pendencia Você está declarando a fila toda vez: await channel.QueueDeclareAsync(...)
             fabrica criada a toda ora          await using var connection = await factory.CreateConnectionAsync(cancellationToken);
             */
        }
    }
}
