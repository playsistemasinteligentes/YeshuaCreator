using Dominio;
using Dominio.Migration;
using Dominio.Schemas.CQRS;

namespace TestMigration;

[TestClass]
public sealed class UsageRightGenerationTests
{
    [TestMethod]
    public void Period_access_and_saga_units_are_declared_without_exposing_financial_tables()
    {
        var migration = new UsageMigration(); migration.Up();
        Assert.AreEqual(2, migration.UsageRights.Count);
        Assert.AreEqual(UsagePurchaseModel.Period, migration.UsageRights[0].Models);
        Assert.AreEqual(UsagePurchaseModel.Period | UsagePurchaseModel.Credits, migration.UsageRights[1].Models);
        Assert.AreEqual(2, migration.Entitys.Count);
        Assert.IsTrue(migration.Entitys.All(entity => entity.IsInternal));
        var directory = Path.Combine(Path.GetTempPath(), "yeshua-usage-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        try
        {
            var path = Path.Combine(directory, "Endpoints.cs");
            new SourceCodeInfraestructureAPIEndpointsMigration(migration, "Example").WriteCode(null, path, Path.Combine(directory, "Endpoints.Custon.cs"));
            var output = File.ReadAllText(path);
            Assert.IsFalse(output.Contains("/yUsageRight/"));
            Assert.IsFalse(output.Contains("/yUsageConsumption/"));
            StringAssert.Contains(output, "StaticUsageRights.TokenExpiry");
            StringAssert.Contains(output, "IUsageRightsRepository");
            var modules = Path.Combine(directory, "Modules.cs");
            new SourceCodeInfraestructureModulesMigration(migration).WriteCode(null, modules, Path.Combine(directory, "Modules.Custon.cs"));
            var generated = File.ReadAllText(modules);
            StringAssert.Contains(generated, "usageUntil.example.access");
            Assert.IsFalse(generated.Contains("HttpClient"));
            Assert.IsFalse(generated.Contains("JsonSerializer"));
        }
        finally { Directory.Delete(directory, true); }
    }

    [TestMethod]
    public void Invalid_binding_models_and_keys_are_rejected()
    {
        Assert.ThrowsException<InvalidOperationException>(() => new UsageRightDefinition("invalid/key", "Test", UsagePurchaseModel.Period, Module: "TEST").Validate());
        Assert.ThrowsException<InvalidOperationException>(() => new UsageRightDefinition("test", "Test", UsagePurchaseModel.Credits, Module: "TEST").Validate());
        Assert.ThrowsException<InvalidOperationException>(() => new UsageRightDefinition("test", "Test", UsagePurchaseModel.Period).Validate());
        Assert.ThrowsException<InvalidOperationException>(() => new UsageRightDefinition("test", "Test", UsagePurchaseModel.Credits, Saga: "Test", Step: "Run", Units: 0).Validate());
    }

    private sealed class UsageMigration : MigrationBase
    {
        public override void Up()
        {
            AddModule("TEST", "Example");
            RequirePeriodAccess("TEST", "example.access", "Example");
            ChargeSagaStep("ExampleSaga", "Run", "example.process", "Process", UsagePurchaseModel.Period | UsagePurchaseModel.Credits);
        }
    }
}
