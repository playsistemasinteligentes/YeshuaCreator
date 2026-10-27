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

        public SourceCodeInfraestructureWorker(Migration.MigrationBase migration, WorkerType WorkerType) : base()
        {
            _migration = migration;
            _WorkerType = WorkerType;
        }
        public SourceCodeInfraestructureWorker(Migration.MigrationBase migration) : base()
        {
            _migration = migration;
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
