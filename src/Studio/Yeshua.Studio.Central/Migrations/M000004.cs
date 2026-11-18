using Dominio.Migration;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.Central.Migrations;

[Migration(000004)]
public sealed class M000004 : MigrationBase
{
    public override void Up()
    {
        AddModule(new Module("COBRANCA", "Carteira de creditos"));
        AddCustomPage("COBRANCA", "Carteira de creditos", "central-financeiro", "central.financeiro", "Minha conta");
        var carteira = AddUsecaseGroup("Central").AddUseCaseSubGrup("Financeiro");
        carteira.AddCommand("AdicionarCreditosCarteira", new FinanceiroInput(), new FinanceiroOutput()).Authorization(Authorization.User);
        carteira.AddCommand("AlocarCreditosCarteira", new FinanceiroInput(), new FinanceiroOutput()).Authorization(Authorization.User);
    }
}
