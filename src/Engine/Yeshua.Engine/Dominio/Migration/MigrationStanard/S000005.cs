using Dominio.Migration;
using MyApp.Domain.Entities;

namespace Migration.Dominio.Migration
{
    [Migration(000005)]
    public class S000005 : MigrationBase
    {
        public override void Up()
        {
            AlterEntity("ySagaStep")
                .AlterColumn("Payload", "Payload")
                .VarcharMax()
                .Group("Saga");

            AlterEntity("yInbox")
                .AlterColumn("Payload", "Payload")
                .VarcharMax()
                .NotNull()
                .Group("Mensagem");

            AlterEntity("yOutbox")
                .AlterColumn("Payload", "Payload")
                .VarcharMax()
                .NotNull()
                .Group("Mensagem");

            AddUsecaseGroup("Saga")
                .AddUseCaseSubGrup("Operacao")
                .AddCommand(
                    "RetrySagaStep",
                    new RetrySagaStepInput(0, 0),
                    new RetrySagaStepOutput(0, 0, string.Empty, string.Empty))
                .AddEntity<ySagaStep>();
        }

        public sealed record RetrySagaStepInput(int SagaId, int SagaStepId);
        public sealed record RetrySagaStepOutput(int SagaId, int SagaStepId, string StepKey, string Status);
    }
}
