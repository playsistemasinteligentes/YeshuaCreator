using Dominio.Migration;
using Dominio.Schemas.CQRS;

namespace TestMigration;

[TestClass]
public class CustomCrudExecutionGenerationTests
{
    [TestMethod]
    public void CrudSmokeAndSeedAllowCustomExecutionWithoutOverwritingUserCode()
    {
        var directory = Path.Combine(Path.GetTempPath(), "Yeshua.Engine.Tests", Guid.NewGuid().ToString("N"));
        try
        {
            var migration = new Fixture();
            migration.Up();
            var entity = migration.Entitys.Single();
            Directory.CreateDirectory(directory);
            foreach (var generator in new Migration.Dominio.SourceCodeBase[] {
                new SourceCodeIntegrationApiSmokeCrudTestMigration(entity, 1, "Tests"),
                new SourceCodeIntegrationApiSeedCrudTestMigration(entity, 1, "Tests") })
            {
                var path = Path.Combine(directory, generator.GetType().Name + ".cs");
                var custom = path + ".custom";
                File.WriteAllText(custom, "custom-owned");
                generator.WriteCode(null, path, custom);
                var code = File.ReadAllText(path);
                StringAssert.Contains(code, "partial void CustomizeExecution(HttpClient client, ref Task? execution);");
                StringAssert.Contains(code, "if (customExecution != null) { await customExecution; return; }");
                Assert.IsTrue(code.IndexOf("CustomizeExecution(client", StringComparison.Ordinal)
                    < code.IndexOf("var createPayload", StringComparison.Ordinal));
                Assert.AreEqual("custom-owned", File.ReadAllText(custom));
            }
        }
        finally
        {
            if (Directory.Exists(directory)) Directory.Delete(directory, true);
        }
    }

    private sealed class Fixture : MigrationBase
    {
        public override void Up() => AddEntity("Publication").AddColumn("Id", "ID").Int().Key();
    }
}
