using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.Central.Migrations;

[Migration(000001)]
public sealed class M000001 : MigrationBase
{
    public override void Up()
    {
        AddModule("CENTRAL", "Central de Autenticacao");

        AddCustomPage(
            "CENTRAL",
            "Catalogo de Aplicativos",
            "application-catalog",
            "central.catalogo.visualizar",
            "Plataforma");

        AddMenuGroup("CENTRAL", "Plataforma", "Catalogo de Aplicativos");

        AddUsecaseGroup("Central")
            .AddUseCaseSubGrup("Catalogo")
            .AddCommand(
                "AdicionarAplicativoAoTenant",
                new AdicionarAplicativoAoTenantInput(string.Empty),
                new AdicionarAplicativoAoTenantOutput(false, string.Empty, new List<string>()))
            .Authorization(Authorization.User)
            .AddScope("central.catalogo.adicionar")
            .AddEntity("yTenant")
            .AddEntity("TenantCatalogo");
    }
}

public sealed record AdicionarAplicativoAoTenantInput(string Aplicativo);

public sealed record AdicionarAplicativoAoTenantOutput(
    bool Adicionado,
    string Aplicativo,
    List<string> Catalogos);
