using Dominio.Migration;

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
        }
    }
}
