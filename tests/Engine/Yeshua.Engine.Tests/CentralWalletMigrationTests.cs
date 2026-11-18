using Dominio.Schemas;

namespace TestMigration;

[TestClass]
public sealed class CentralWalletMigrationTests
{
    [TestMethod]
    public void Wallet_evolution_reuses_existing_module_without_another_database_insert()
    {
        var initial = new Yeshua.Studio.Central.Migrations.M000003(); initial.Up();
        var wallet = new Yeshua.Studio.Central.Migrations.M000004(); wallet.Up();
        Assert.IsTrue(initial.Modules.Single(module => module.Key == "COBRANCA").Inserir);
        Assert.IsFalse(wallet.Modules.Single(module => module.Key == "COBRANCA").Inserir);
        Assert.AreEqual(0, new SqlServerSchema(null!, "Central").ApplyMigration(wallet).Count,
            "The wallet evolution must not insert COBRANCA again or change existing tables.");
        var commands = wallet.UseCaseGroup.SelectMany(group => group.UseCaseSubGroup).SelectMany(group => group.UseCaseCommand).ToArray();
        CollectionAssert.AreEquivalent(new[] { "AdicionarCreditosCarteira", "AlocarCreditosCarteira" }, commands.Select(command => command.Name._value).ToArray());
        Assert.IsTrue(commands.All(command => !command.IsInternal));
    }
}
