using Dominio.Migration;

namespace Yeshua.Studio.Central.Migrations;

[Migration(000003)]
public sealed class M000003 : MigrationBase
{
    public override void Up()
    {
        AddEntity("TenantCatalogo", "Catalogo do Tenant")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("Catalogo", "Catalogo").Varchar(100).NotNull()
            .AddColumn("TenantID", "TenantID").Int().FK("yTenant", "Id")
                .DefaultValue("#_executionContext.TenantID")
            .AddColumn("ValidUntil", "Valido ate").DateTime().NotNull();
    }
}
