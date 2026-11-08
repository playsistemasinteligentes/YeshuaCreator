using Dominio.Migration;
using Dominio.Schemas.CQRS.Abstraction;
using Interfaces.Schemas;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Net.Http;
using System.Text;
using static Dapper.SqlMapper;
using static Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers;
using static System.Net.Mime.MediaTypeNames;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeInfraestructureWorker : SourceCodeBase
    {
        private readonly Migration.MigrationBase _migration;
        private readonly WorkerType _WorkerType;
        private readonly string _applicationName;

        public SourceCodeInfraestructureWorker(Migration.MigrationBase migration, WorkerType WorkerType, string applicationName = "Application") : base()
        {
            _migration = migration;
            _WorkerType = WorkerType;
            _applicationName = applicationName;
        }
        public SourceCodeInfraestructureWorker(Migration.MigrationBase migration, string applicationName = "Application") : base()
        {
            _migration = migration;
            _applicationName = applicationName;
        }

        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();

            sb.AppendLine("using Shered.Services;");
            sb.AppendLine("using Command.Interfaces.Patterns.Queue;");
            sb.AppendLine("using Microsoft.Extensions.DependencyInjection;");
            sb.AppendLine("using Microsoft.Extensions.Logging;");
            sb.AppendLine("using Worker.Custon;");


            sb.AppendLine("namespace Migrations");
            sb.AppendLine("{");
            sb.AppendLine("public static class WorkersBuilder");
            sb.AppendLine("{");
            sb.AppendLine("public static void MapWorkersBuilder(WebApplicationBuilder builder)");
            sb.AppendLine("{");


            if (_migration.GenerateSagaQueueWorkers)
                AppendStandardQueueWorkers(sb);

            if (HasSagas())
                AppendSagaPollingWorkers(sb);


            sb.AppendLine("}");
            sb.AppendLine("}");

            if (HasSagas())
                AppendSagaQueueHealthProbe(sb);

            sb.AppendLine("}");

            return sb;
        }
        protected override StringBuilder GenerateCustonCode()
        {
            return new StringBuilder();
        }

        private bool HasSagas()
        {
            return _migration.UseCaseGroup
                .SelectMany(group => group.UseCaseSubGroup)
                .Any(subGroup => subGroup.Saga.Any());
        }

        private void AppendSagaPollingWorkers(StringBuilder sb)
        {
            var loopMilliseconds = _migration.SagaWorkerLoopMilliseconds ?? 2000;
            sb.AppendLine($@"
builder.Services.AddTransient<Command.Patterns.SagaWorkerCommandHandler>();
builder.Services.AddTransient<Command.Patterns.SagaInboxWorkerCommandHandler>();
builder.Services.AddScoped<RepositoryInterfaces.Patterns.Worker.IWorkerQueueHealthProbe<
    Command.Patterns.SagaWorkerCommandHandler,
    Command.Patterns.InputCommand>, SagaQueueHealthProbe>();

builder.Services.AddHostedService(sp =>
    new PollingWorker<Command.Patterns.SagaWorkerCommandHandler, Command.Patterns.InputCommand, Command.Patterns.OutputCommand>(
        sp,
        sp.GetRequiredService<ILogger<PollingWorker<Command.Patterns.SagaWorkerCommandHandler, Command.Patterns.InputCommand, Command.Patterns.OutputCommand>>>(),
        TimeSpan.FromMilliseconds({loopMilliseconds})));

builder.Services.AddHostedService(sp =>
    new PollingWorker<Command.Patterns.SagaInboxWorkerCommandHandler, Command.Patterns.InputCommand, Command.Patterns.InboxOutputCommand>(
        sp,
        sp.GetRequiredService<ILogger<PollingWorker<Command.Patterns.SagaInboxWorkerCommandHandler, Command.Patterns.InputCommand, Command.Patterns.InboxOutputCommand>>>(),
        TimeSpan.FromMilliseconds({loopMilliseconds})));
");
        }

        private void AppendSagaQueueHealthProbe(StringBuilder sb)
        {
            var queueName = System.Text.Json.JsonSerializer.Serialize($"{_applicationName}.Saga");
            sb.AppendLine($$"""

internal sealed class SagaQueueHealthProbe
    : RepositoryInterfaces.Patterns.Worker.IWorkerQueueHealthProbe<
        Command.Patterns.SagaWorkerCommandHandler,
        Command.Patterns.InputCommand>
{
    private readonly IRepository.Read.IySagaReadRepository _repository;
    private readonly RepositoryInterfaces.Patterns.Worker.WorkerQueueItemHealthThresholds _thresholds;

    public SagaQueueHealthProbe(
        IRepository.Read.IySagaReadRepository repository,
        Microsoft.Extensions.Configuration.IConfiguration configuration)
    {
        _repository = repository;
        _thresholds = new RepositoryInterfaces.Patterns.Worker.WorkerQueueItemHealthThresholds(
            ExcessiveWaitSeconds: Math.Clamp(
                configuration.GetValue<long?>("YeshuaQueueHealth:Item:ExcessiveWaitSeconds") ?? 900,
                60,
                86_400),
            ProcessingStuckSeconds: Math.Clamp(
                configuration.GetValue<long?>("YeshuaQueueHealth:Item:ProcessingStuckSeconds") ?? 120,
                60,
                3_600),
            RecurrentExecutionCount: Math.Clamp(
                configuration.GetValue<int?>("YeshuaQueueHealth:Item:RecurrentExecutionCount") ?? 3,
                2,
                100),
            RepeatedFailureCount: Math.Clamp(
                configuration.GetValue<int?>("YeshuaQueueHealth:Item:RepeatedFailureCount") ?? 2,
                1,
                100));
    }

    public string QueueName => {{queueName}};

    public RepositoryInterfaces.Patterns.Worker.WorkerQueueHealthSnapshot Capture() =>
        _repository.GetRunnableSagaHealth(_thresholds);

    public IReadOnlyList<RepositoryInterfaces.Patterns.Worker.WorkerQueueSickItem> CaptureSickItems(int limit) =>
        _repository.GetSickSagaItems(_thresholds, limit);
}
""");
        }

        private void AppendStandardQueueWorkers(StringBuilder sb)
        {
            var steps = _migration.UseCaseGroup.SelectMany(g => g.UseCaseSubGroup)
                .SelectMany(g => g.Saga).SelectMany(s => s.SagaStepGroup).SelectMany(g => g.Steps).ToList();
            if (steps.Any(s => s.OutboxQueueTopology != null))
                sb.AppendLine(@"
builder.Services.AddTransient<Command.Patterns.OutBox.yOutBoxWorkerHandler>();
builder.Services.AddHostedService(sp =>
    new PollingWorker<Command.Patterns.OutBox.yOutBoxWorkerHandler, Command.Patterns.OutBox.yOutboxInputCommand, Command.Patterns.OutBox.yOutboxOutputCommand>(
        sp, sp.GetRequiredService<ILogger<PollingWorker<Command.Patterns.OutBox.yOutBoxWorkerHandler, Command.Patterns.OutBox.yOutboxInputCommand, Command.Patterns.OutBox.yOutboxOutputCommand>>>(),
        TimeSpan.FromMilliseconds(2000)));");
            var queues = steps.Where(s => s.InboxQueueTopology != null)
                .SelectMany(s => s.InboxQueueTopology!.Exchanges).SelectMany(e => e.Bindings)
                .Select(b => b.QueueName).Distinct().ToList();
            if (queues.Count == 0) return;
            sb.AppendLine(@"
builder.Services.AddTransient<Command.Patterns.OutBox.InboxListenerHandler>();
builder.Services.AddHostedService(sp =>
    new QueueListenerWorker<Command.Patterns.OutBox.InboxListenerHandler, Command.Patterns.OutBox.InboxInputCommand, Command.Patterns.OutBox.InboxOutputCommand>(
        sp, sp.GetRequiredService<IQueueListener>(),
        sp.GetRequiredService<ILogger<QueueListenerWorker<Command.Patterns.OutBox.InboxListenerHandler, Command.Patterns.OutBox.InboxInputCommand, Command.Patterns.OutBox.InboxOutputCommand>>>(),");
            sb.AppendLine("        new string[] { " + string.Join(", ", queues.Select(q => System.Text.Json.JsonSerializer.Serialize(q))) + " }));");
        }
    }
}
