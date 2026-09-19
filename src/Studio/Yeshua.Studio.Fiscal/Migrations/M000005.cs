using Dominio.Migration;

namespace Yeshua.Studio.Fiscal.Migrations;

[Migration(000005)]
public class M000005 : MigrationBase
{
    public override void Up()
    {
        AlterEntity("EntradaFiscalContingencia")
            .AlterColumn("SnapshotJson", "Snapshot")
            .VarcharMax()
            .Group("Snapshot");
    }
}
