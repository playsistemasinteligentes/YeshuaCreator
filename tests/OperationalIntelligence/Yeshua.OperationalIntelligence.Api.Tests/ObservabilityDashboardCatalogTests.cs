using System.Text.Json;
using Microsoft.Extensions.Options;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class ObservabilityDashboardCatalogTests
{
    [TestMethod]
    public async Task CatalogDiscoversNewPanelsAndNormalizesSemanticAndTechnicalMetadata()
    {
        var directory = Path.Combine(Path.GetTempPath(), "yeshua-dashboard-catalog-" + Guid.NewGuid());
        Directory.CreateDirectory(directory);
        try
        {
            var path = Path.Combine(directory, "test.json");
            await File.WriteAllTextAsync(path, Fixture(includeSecondPanel: false));
            var options = Options.Create(new McpOptions { DashboardCatalogPath = directory });
            var catalog = new ObservabilityDashboardCatalog(options);
            var arguments = new McpToolArgumentReader(options);
            var listTool = new ObservabilityDashboardsListTool(catalog);
            var getTool = new ObservabilityDashboardGetTool(catalog, arguments);

            var listed = await listTool.CallAsync(JsonSerializer.Deserialize<JsonElement>("{}"), default);
            Assert.IsFalse(listed.IsError);
            McpOutputContractTests.Validate(McpOutputSchemas.For(listTool.Name),
                JsonSerializer.SerializeToElement(listed.StructuredContent, new JsonSerializerOptions(JsonSerializerDefaults.Web)));
            var list = (ObservabilityDashboardCatalogResult)listed.StructuredContent!;
            Assert.AreEqual(1, list.Dashboards.Count);
            Assert.AreEqual(1, list.Dashboards[0].PanelCount);

            var input = JsonSerializer.Deserialize<JsonElement>("""{"uid":"test-dashboard"}""");
            var loaded = await getTool.CallAsync(input, default);
            Assert.IsFalse(loaded.IsError);
            McpOutputContractTests.Validate(McpOutputSchemas.For(getTool.Name),
                JsonSerializer.SerializeToElement(loaded.StructuredContent, new JsonSerializerOptions(JsonSerializerDefaults.Web)));
            var contract = (ObservabilityDashboardContract)loaded.StructuredContent!;
            Assert.AreEqual("CPU atual.", contract.Panels[0].SemanticSections["whatItMeasures"]);
            Assert.AreEqual("PromQL", contract.Panels[0].Technical.Targets[0].QueryLanguage);
            Assert.AreEqual("range", contract.Panels[0].Technical.Targets[0].QueryMode);
            Assert.IsTrue(contract.Panels[0].ReviewHints.Any(hint => hint.Contains("range query resolution")));
            Assert.IsNull(contract.Panels[0].RawConfiguration);

            await File.WriteAllTextAsync(path, Fixture(includeSecondPanel: true));
            var updated = await catalog.GetAsync("test-dashboard", includeRaw: true, default);
            Assert.IsNotNull(updated);
            Assert.AreEqual(2, updated.Panels.Count);
            Assert.AreEqual(JsonValueKind.Object, updated.Panels[0].RawConfiguration!.Value.ValueKind);
        }
        finally
        {
            Directory.Delete(directory, recursive: true);
        }
    }

    private static string Fixture(bool includeSecondPanel)
    {
        var second = includeSecondPanel
            ? """,{"id":2,"title":"Backlog","type":"timeseries","description":"**O que mede:** itens aguardando.\n\n**Como interpretar:** zero significa fila vazia.\n\n**Fonte:** Prometheus.","gridPos":{"x":6,"y":0,"w":6,"h":6},"fieldConfig":{"defaults":{"unit":"short"},"overrides":[]},"options":{},"targets":[{"refId":"A","datasource":{"type":"prometheus"},"expr":"queue_backlog","range":true}]}"""
            : string.Empty;
        return """
        {
          "uid":"test-dashboard",
          "title":"Test dashboard",
          "description":"Fixture",
          "version":1,
          "schemaVersion":41,
          "tags":["yeshua"],
          "templating":{"list":[{"name":"service","label":"Servico","type":"query","query":{"query":"label_values(up, service)"},"includeAll":true,"multi":true}]},
          "panels":[
            {"id":1,"title":"CPU","type":"stat","description":"**O que mede:** CPU atual.\n\n**Como interpretar:** percentual ocupado.\n\n**Fonte:** hostmetrics.","gridPos":{"x":0,"y":0,"w":6,"h":6},"fieldConfig":{"defaults":{"unit":"percent","min":0,"max":100,"thresholds":{"steps":[{"color":"green","value":null},{"color":"red","value":85}]}},"overrides":[]},"options":{"reduceOptions":{"calcs":["lastNotNull"]}},"targets":[{"refId":"A","datasource":{"type":"prometheus"},"expr":"cpu_percent","range":true}]}
            __SECOND_PANEL__
          ]
        }
        """.Replace("__SECOND_PANEL__", second, StringComparison.Ordinal);
    }
}
