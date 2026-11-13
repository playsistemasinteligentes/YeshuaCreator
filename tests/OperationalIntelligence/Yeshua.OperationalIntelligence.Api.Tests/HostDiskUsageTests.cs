using System.Text.Json;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class HostDiskUsageTests
{
    [TestMethod]
    public async Task ReadOnlyPrivateToolReturnsPartialAndStaleEvidenceWithoutChangingReport()
    {
        var path = Path.GetTempFileName();
        try
        {
            var content = JsonSerializer.Serialize(new
            {
                collectedAtUtc = DateTimeOffset.UtcNow.AddHours(-1), status = "partial",
                filesystem = new { usedPercent = 85 }, sections = Array.Empty<object>(),
                docker = new { categories = new[] { new { Type = "Build Cache", Size = "97.74GB" } } }
            });
            await File.WriteAllTextAsync(path, content);
            IMcpTool tool = new HostDiskUsageTool(new HostDiskUsageReader(path));
            var result = await tool.CallAsync(JsonSerializer.Deserialize<JsonElement>("{}"), default);
            Assert.IsFalse(result.IsError);
            Assert.IsFalse(tool.IsPublic);
            Assert.IsTrue(tool.IsReadOnly);
            var output = (HostDiskUsageResult)result.StructuredContent!;
            Assert.IsTrue(output.IsStale);
            Assert.AreEqual(2, output.Warnings.Count);
            Assert.AreEqual("97.74GB", output.Report.GetProperty("docker").GetProperty("categories")[0].GetProperty("Size").GetString());
            McpOutputContractTests.Validate(McpOutputSchemas.For(tool.Name),
                JsonSerializer.SerializeToElement(output, new JsonSerializerOptions(JsonSerializerDefaults.Web)));
            Assert.AreEqual(content, await File.ReadAllTextAsync(path));
        }
        finally { File.Delete(path); }
    }

    [DataTestMethod]
    [DataRow("missing")]
    [DataRow("invalid-json")]
    [DataRow("invalid-report")]
    [DataRow("too-large")]
    public async Task UnavailableOrInvalidReportProducesExplicitErrorWithoutDisclosingContents(string scenario)
    {
        var path = Path.Combine(Path.GetTempPath(), "yeshua-disk-" + Guid.NewGuid() + ".json");
        try
        {
            if (scenario != "missing")
                await File.WriteAllTextAsync(path, scenario switch
                {
                    "invalid-json" => "not-json-secret-marker",
                    "invalid-report" => "{}",
                    _ => new string('x', 256 * 1024 + 1)
                });
            var tool = new HostDiskUsageTool(new HostDiskUsageReader(path));
            var result = await tool.CallAsync(JsonSerializer.Deserialize<JsonElement>("{}"), default);
            Assert.IsTrue(result.IsError);
            Assert.IsNull(result.StructuredContent);
            Assert.IsFalse(result.Content[0].Text.Contains("secret-marker"));
        }
        finally { File.Delete(path); }
    }
}
