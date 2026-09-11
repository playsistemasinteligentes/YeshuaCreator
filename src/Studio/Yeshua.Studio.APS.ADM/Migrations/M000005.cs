using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.APS.ADM.Migrations;

[Migration(000005)]
public class M000005 : MigrationBase
{
    public override void Up()
    {
        AlterEntity("PontosMapa")
            .AddColumn("MUN_ID", "Municipio")
                .FK("Municipio", "MUN_ID")
                .RelationTab("PontosMapa", "PontosMapa")
                .Varchar(50)
                .LegacyColumn("MUN_ID", "varchar(50)");
    }
}
