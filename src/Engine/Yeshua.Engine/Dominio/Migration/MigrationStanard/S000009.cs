using Dominio.Migration;

namespace Migration.Dominio.Migration
{
    [Migration(000009)]
    public sealed class S000009 : MigrationBase
    {
        public override void Up()
        {
            AddOperationalIdentity("ySaga");
            AddOperationalIdentity("ySagaStep");
            AddOperationalIdentity("yOutbox");
            AddOperationalIdentity("yInbox");
        }

        private void AddOperationalIdentity(string entityName)
        {
            AlterEntity(entityName)
                .AddColumn("RootOperationId", "Operacao raiz").Varchar(128).DefaultValue("#null").EditFront(false).VisivelFront(false)
                .AddColumn("OperationId", "Operacao logica").Varchar(128).DefaultValue("#null").EditFront(false).VisivelFront(false)
                .AddColumn("ExecutionId", "Tentativa de execucao").Varchar(128).DefaultValue("#null").EditFront(false).VisivelFront(false)
                .AddColumn("CausationId", "Execucao causadora").Varchar(128).DefaultValue("#null").EditFront(false).VisivelFront(false);
        }
    }
}
