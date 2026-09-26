using Dominio.Migration;

namespace Migration.Dominio.Migration
{
    [Migration(000006)]
    public sealed class S000006 : MigrationBase, IStandardFieldUpgradeMigration
    {
        public IReadOnlyCollection<string> FieldNames { get; } = ["OperationalEntityId"];

        public override void Up()
        {
            AddEntity("yStandardFields")
                .AddColumn("OperationalEntityId", "Identificador operacional")
                .Varchar(32)
                .NotNull()
                .DefaultValue("#Guid.NewGuid().ToString(\"N\")")
                .Immutable()
                .EditFront(false)
                .VisivelFront(false)
                .NotEntity("yModule");
        }
    }
}
