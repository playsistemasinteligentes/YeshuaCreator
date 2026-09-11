using Aplication.Interfaces.Services;
using Command.Interfaces.Patterns.FileStore;
using Command.Interfaces.Patterns.Queue;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shared.InterfacesConcrete.Queue.RabbitMQ;
using Shered.ConcretInterfaces.Queue.RabbitMQ;
using Shered.DB.Connection;
using Shered.Patterns.FileStore;
using Shered.Services;

namespace Migrations;

public static class DependenceInjectionCuston
{
    public static void MapDependenceInjection(WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<IExecutionContext, executionContextHttp>();

        builder.Services.Configure<RabbitMqOptions>(builder.Configuration.GetSection("RabbitMq"));
        builder.Services.AddSingleton<RabbitMqConnectionManager>();
        builder.Services.AddSingleton<IQueueTopologyInitializer, RabbitMqTopologyInitializer>();
        builder.Services.AddSingleton<IQueuePublisher, RabbitMQQueuePublisher>();
        builder.Services.AddSingleton<IQueueListener, RabbitMQQueueListener>();

        builder.Services.Configure<StorageSettings>(builder.Configuration.GetSection("Storage"));
        builder.Services.AddScoped<IFileStorage, StorageService>();
        builder.Services.AddScoped<IStorageProvider, DiskStorageProvider>();
        builder.Services.AddScoped<StorageResolver>();
        builder.Services.AddTransient<Command.Receivers.UseCase.ContingenciaFiscalStepStimulusService>();
        builder.Services.AddTransient<Command.Receivers.UseCase.InformarNotasFiscaisContingenciaHandler>();
        builder.Services.AddTransient<Command.Receivers.UseCase.EscolherModeloAgrupamentoCTeContingenciaHandler>();
        builder.Services.AddTransient<Command.Receivers.UseCase.InformarFreteERateioContingenciaHandler>();
        builder.Services.AddTransient<Command.Receivers.UseCase.InformarDadosTransporteContingenciaHandler>();
        builder.Services.AddTransient<Command.Receivers.UseCase.ConfirmarPlanoEmissaoFiscalContingenciaHandler>();
        builder.Services.AddTransient<Command.Receivers.UseCase.InformarResultadoEmissaoFiscalContingenciaHandler>();

        builder.Services.AddScoped<ISqlFactory>(_ =>
            new SqlFactory(EnumSqlConections.SqlServer, GS.I.MYC.ReadConectionString));
    }
}
