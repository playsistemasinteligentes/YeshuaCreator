using Dominio.Migration;

namespace Migration.Dominio.Migration
{
    [Migration(000008)]
    public sealed class S000008 : MigrationBase
    {
        public override void Up()
        {
            AddEntity("yTenantApplication", "Aplicativos autorizados do tenant")
                .AddColumn("Id", "ID").Int().Incremento().Key()
                .AddColumn("ApplicationKey", "Aplicativo").Varchar(100).NotNull()
                .AddColumn("TenantID", "TenantID").Int().FK("yTenant", "Id")
                    .DefaultValue("#_executionContext.TenantID")
                .AddColumn("ValidUntil", "Valido ate").DateTime().NotNull();
        }
    }
}
