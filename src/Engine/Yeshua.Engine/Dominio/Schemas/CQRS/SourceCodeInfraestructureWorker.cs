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
            sb.AppendLine("using Worker.Custon;");


            sb.AppendLine("namespace Migrations");
            sb.AppendLine("{");
            sb.AppendLine("public static class WorkersBuilder");
            sb.AppendLine("{");
            sb.AppendLine("public static void MapWorkersBuilder(WebApplicationBuilder builder)");
            sb.AppendLine("{");


            foreach (var group in _migration.UseCaseGroup)
            {
                foreach (var subGroup in group.UseCaseSubGroup)
                {
                    foreach (var saga in subGroup.Saga)
                    {
                        foreach (var stepGroup in saga.SagaStepGroup)
                        {
                            foreach (var step in stepGroup.Steps)
                            {
                                //avaliar pois o outbox pode ser mais padronizado sem necessidade de um por step ou por saga podendo eventualmente ser um apenas 
                                //padronizar o outbox ou seja um outbox por sistema  eventualmente por saga mas tem que ter codigo padrao  

                                //if (step.SagaStepUseCaseCommand != null)
                                //    AppendPollingWorker(sb, step.SagaStepUseCaseCommand);
                                //
                                //if (step.OutBoxPollingWorker != null)
                                //    AppendPollingWorker(sb, step.OutBoxPollingWorker);
                                //
                                //if (step.InBoxPollingWorker != null)
                                //    AppendPollingWorker(sb, step.InBoxPollingWorker);
                                //
                                //if (step.QueueListenerWorker != null)
                                //{
                                //    foreach (var exchange in step.queueTopology.Exchanges)
                                //    {
                                //        foreach (var binding in exchange.Bindings)
                                //        {
                                //            var queueName = binding.QueueName;
                                //            AppendQueueListenerWorker(sb, queueName, step.QueueListenerWorker);
                                //        }
                                //    }
                                //}
                            }
                        }
                    }
                }
            }


            sb.AppendLine("}");
            sb.AppendLine("}");
            sb.AppendLine("}");

            return sb;
        }
        protected override StringBuilder GenerateCustonCode()
        {
            return new StringBuilder();
        }

        private void AppendPollingWorker(StringBuilder sb, UseCaseCommand handler)
        {
            sb.AppendLine($@"
                builder.Services.AddHostedService(sp =>
                    new PollingWorker<{CQRSParam.I.NameSpaceCommandCommandsSaga}.{handler.HandlerName},
                        {CQRSParam.I.NameSpaceCommandCommandsSaga}.{handler.InputCommandName},
                        {CQRSParam.I.NameSpaceCommandCommandsSaga}.{handler.OutputCommandName}>(
                        sp,
                        sp.GetRequiredService<
                            ILogger<PollingWorker<
                                {CQRSParam.I.NameSpaceCommandCommandsSaga}.{handler.HandlerName},
                                {CQRSParam.I.NameSpaceCommandCommandsSaga}.{handler.InputCommandName},
                                {CQRSParam.I.NameSpaceCommandCommandsSaga}.{handler.OutputCommandName}>>>(),
                        TimeSpan.FromSeconds(5)
                    ));
                ");
        }
        private void AppendQueueListenerWorker(StringBuilder sb,string queueName, UseCaseCommand handler)
        {
            sb.AppendLine($@"
                builder.Services.AddHostedService(sp =>
                {{
                    var listener = sp.GetRequiredService<IQueueListener>();
                    var logger = sp.GetRequiredService<ILogger<QueueListenerWorker<
                        {CQRSParam.I.NameSpaceCommandCommandsSaga}.{handler.HandlerName},
                        {CQRSParam.I.NameSpaceCommandCommandsSaga}.{handler.InputCommandName},
                        {CQRSParam.I.NameSpaceCommandCommandsSaga}.{handler.OutputCommandName}>>>();

                    return new QueueListenerWorker<
                        {CQRSParam.I.NameSpaceCommandCommandsSaga}.{handler.HandlerName},
                        {CQRSParam.I.NameSpaceCommandCommandsSaga}.{handler.InputCommandName},
                        {CQRSParam.I.NameSpaceCommandCommandsSaga}.{handler.OutputCommandName}>(
                            sp,
                            listener,
                            logger,
                            queueName: ""{queueName}""
                    );
                }});
                ");
        }
    }
}