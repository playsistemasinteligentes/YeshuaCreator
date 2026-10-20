using Dominio.Schemas.CQRS;
using System.Reflection;
using System.Text.Json.Nodes;

namespace TestMigration;

[TestClass]
public class PrivateConfigurationGenerationTests
{
    [TestMethod]
    public void GeneratedHostDoesNotCopyStudioCredentials()
    {
        var baseDirectory = Path.GetFullPath(Path.Combine(Path.GetTempPath(), "Yeshua.Engine.Tests"));
        var directory = Path.Combine(baseDirectory, Guid.NewGuid().ToString("N"));
        try
        {
            var studio = Path.Combine(directory, "src", "Studio", "StudioFixture");
            Directory.CreateDirectory(studio);
            File.WriteAllText(Path.Combine(studio, "appsettings.json"),
                "{\"MyConfig\":{\"ReadConectionString\":\"fixture-private-read\",\"WriteConectionString\":\"fixture-private-write\"}}");
            var schema = new CSharpCQRS("Fixture", directory, "StudioFixture");
            var method = typeof(CSharpCQRS).GetMethod("EnsureApplicationHostMyConfig", BindingFlags.Instance | BindingFlags.NonPublic)!;
            var host = Path.Combine(directory, "host");
            method.Invoke(schema, [host]);
            var output = File.ReadAllText(Path.Combine(host, "appsettings.json"));
            var configuration = JsonNode.Parse(output)!;
            Assert.AreEqual(string.Empty, configuration["MyConfig"]!["ReadConectionString"]!.GetValue<string>());
            Assert.AreEqual(string.Empty, configuration["MyConfig"]!["WriteConectionString"]!.GetValue<string>());
            Assert.IsFalse(output.Contains("fixture-private", StringComparison.Ordinal));
        }
        finally
        {
            if (Path.GetFullPath(directory).StartsWith(baseDirectory + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase)
                && Directory.Exists(directory))
                Directory.Delete(directory, true);
        }
    }
}
