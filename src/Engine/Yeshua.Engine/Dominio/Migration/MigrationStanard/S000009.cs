using Dominio.Migration;

namespace Migration.Dominio.Migration
{
    [Migration(000009)]
    public sealed class S000009 : MigrationBase
    {
        public override void Up()
        {
            AlterEntity("ySagaStep")
                .AddColumn("FailureNature", "Natureza da falha").Varchar(40).DefaultValue("#null").EditFront(false).VisivelFront(false)
                .AddColumn("FailureTransience", "Transitoriedade da falha").Varchar(40).DefaultValue("#null").EditFront(false).VisivelFront(false)
                .AddColumn("FailureOrigin", "Origem da falha").Varchar(40).DefaultValue("#null").EditFront(false).VisivelFront(false)
                .AddColumn("FailureRetryable", "Falha permite retry").Boolean().DefaultValue("#null").EditFront(false).VisivelFront(false)
                .AddColumn("FailureCode", "Codigo estavel da falha").Varchar(200).DefaultValue("#null").EditFront(false).VisivelFront(false);
        }
    }
}
