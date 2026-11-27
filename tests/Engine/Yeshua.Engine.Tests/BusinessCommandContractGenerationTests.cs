using Dominio.Migration;
using Dominio.Schemas.CQRS;

namespace TestMigration;

[TestClass]
public class BusinessCommandContractGenerationTests
{
    [TestMethod]
    public void ExistingEndpointGenerationPublishesStableIdentityAndOutputWithoutExposingInternalCommands()
    {
        var directory = Path.Combine(Path.GetTempPath(), "Yeshua.Engine.Tests", Guid.NewGuid().ToString("N"));
        try
        {
            Directory.CreateDirectory(directory);
            var fixture = new Fixture(); fixture.Up();
            var generator = new SourceCodeInfraestructureAPIEndpointsMigration(fixture, "Sample");
            var path = Path.Combine(directory, "Endpoints.cs");
            var custom = Path.Combine(directory, "Custom.cs");
            File.WriteAllText(custom, "custom-owned");
            generator.WriteCode(null, path, custom);
            var code = File.ReadAllText(path);
            StringAssert.Contains(code, ".WithName(\"Sample.Commands.Actions.Execute\")");
            StringAssert.Contains(code, "ExecuteOutputCommand>(StatusCodes.Status200OK)");
            StringAssert.Contains(code, ".WithDescription(");
            Assert.IsFalse(code.Contains("ActionsHiddenUseCase"));
            Assert.AreEqual("custom-owned", File.ReadAllText(custom));
        }
        finally { if (Directory.Exists(directory)) Directory.Delete(directory, true); }
    }
    private sealed class Fixture : MigrationBase
    {
        public override void Up()
        {
            var group = AddUsecaseGroup("Commands").AddUseCaseSubGrup("Actions");
            group.AddCommand("Execute", new Input(), new Output());
            group.AddCommand("Hidden", new Input(), new Output()).Internal();
        }
    }
    private sealed class Input { public int Quantity { get; set; } }
    private sealed class Output { public bool Ok { get; set; } }
}
