using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Clients;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class QueueHealthProjectionTests
{
    [TestMethod]
    public void HealthyQueueCanContainCriticalSickItemsWithoutBecomingBlocked()
    {
        var result = QueueHealthClassifier.Classify(Signals(
            backlog: 0,
            processed: 0,
            diseases: new(2, 0, 0, 0, 0, 2)));

        Assert.AreEqual("healthy", result.QueueStatus);
        Assert.AreEqual("sick", result.ItemStatus);
        Assert.AreEqual("sick", result.OverallStatus);
        StringAssert.Contains(result.Reason, "fila pode continuar operando", StringComparison.OrdinalIgnoreCase);
    }

    [TestMethod]
    public void BacklogWithoutProgressIsAQueueDisease()
    {
        var result = QueueHealthClassifier.Classify(Signals(
            backlog: 10,
            oldest: 300,
            processed: 0,
            diseases: new(0, 0, 0, 0, 0, 0)));

        Assert.AreEqual("sick", result.QueueStatus);
        Assert.AreEqual("healthy", result.ItemStatus);
        Assert.AreEqual("sick", result.OverallStatus);
        StringAssert.Contains(result.Reason, "sem vazao", StringComparison.OrdinalIgnoreCase);
    }

    [TestMethod]
    public void RecentProgressKeepsQueueHealthy()
    {
        var result = QueueHealthClassifier.Classify(Signals(
            backlog: 10,
            oldest: 30,
            processed: 8,
            diseases: new(0, 0, 0, 0, 0, 0)));

        Assert.AreEqual("healthy", result.QueueStatus);
        Assert.AreEqual("healthy", result.OverallStatus);
    }

    [TestMethod]
    public void StaleSnapshotDoesNotPretendQueueIsHealthy()
    {
        var result = QueueHealthClassifier.Classify(Signals(
            backlog: 0,
            sampleAge: 600,
            processed: 0,
            diseases: new(0, 0, 0, 0, 0, 0)));

        Assert.AreEqual("unavailable", result.QueueStatus);
        Assert.AreEqual("unavailable", result.OverallStatus);
    }

    [TestMethod]
    public void ParserFindsNestedSanitizedItemEvidence()
    {
        const string line = """
            {"TimestampUtc":"2026-11-10T10:00:00Z","Data":{"EventName":"QueueItem.HealthChanged","TenantId":1,"Queue":"Clinica.Saga","ItemType":"ExampleSaga","ItemReference":"item-42","Disease":"TerminalFailure","Severity":"critical","EligibleAgeSeconds":4,"ProcessingAgeSeconds":0,"ExecutionCount":3,"RetryCount":2,"LastOutcome":"Failed","OperationalEntityId":"entity-1","RootOperationId":"root-1","ExecutionId":"execution-1","ErrorSignature":"abc123"}}
            """;
        var response = JsonSerializer.SerializeToElement(new
        {
            data = new
            {
                result = new[]
                {
                    new { values = new[] { new[] { "1", line } } }
                }
            }
        });

        var evidence = QueueItemEvidenceParser.Latest(response, "Clinica.Saga", "item-42");

        Assert.IsNotNull(evidence);
        Assert.AreEqual(1, evidence.TenantId);
        Assert.AreEqual("TerminalFailure", evidence.Disease);
        Assert.AreEqual(DateTimeOffset.Parse("2026-11-10T10:00:00Z"), evidence.ObservedAtUtc);
        Assert.AreEqual("execution-1", evidence.ExecutionId);
        Assert.AreEqual("abc123", evidence.ErrorSignature);
    }

    [TestMethod]
    public void ParserListsOneLatestEvidencePerSickItem()
    {
        const string first = """{"Data":{"Queue":"Clinica.Saga","ItemReference":"item-1","Disease":"TerminalFailure"}}""";
        const string repeated = """{"Data":{"Queue":"Clinica.Saga","ItemReference":"item-1","Disease":"RepeatedFailure"}}""";
        const string second = """{"Data":{"Queue":"Clinica.Saga","ItemReference":"item-2","Disease":"ExcessiveWait"}}""";
        var response = JsonSerializer.SerializeToElement(new
        {
            data = new
            {
                result = new[]
                {
                    new { values = new[] { new[] { "3", first }, new[] { "2", repeated }, new[] { "1", second } } }
                }
            }
        });

        var items = QueueItemEvidenceParser.List(response, "Clinica.Saga", 25);

        Assert.AreEqual(2, items.Count);
        Assert.AreEqual("TerminalFailure", items[0].Disease);
        Assert.AreEqual("item-2", items[1].ItemReference);
    }

    [TestMethod]
    public async Task ItemDiagnosisCorrelatesRetriesByStableRootOperationIdAndTenant()
    {
        using var handler = new QueueDiagnosisHttp();
        using var http = new HttpClient(handler) { BaseAddress = new Uri("https://test.example/") };
        var tool = new QueueItemDiagnoseTool(
            new LokiClient(http),
            new TempoClient(http),
            new McpToolArgumentReader(Options.Create(new McpOptions())));

        var result = await tool.CallAsync(
            JsonSerializer.Deserialize<JsonElement>(
                """{"queue":"Clinica.Saga","itemReference":"item-42","tenantId":1}"""),
            default);

        Assert.IsFalse(result.IsError);
        StringAssert.Contains(handler.LokiQuery, "\\\"TenantId\\\":1");
        StringAssert.Contains(handler.TempoQuery, "yeshua.root_operation_id");
        StringAssert.Contains(handler.TempoQuery, "root-stable");
        Assert.IsFalse(handler.TempoQuery.Contains("execution-old", StringComparison.Ordinal));
    }

    private static QueueHealthSignals Signals(
        long backlog,
        double processed,
        QueueDiseaseCounts diseases,
        long oldest = 0,
        long sampleAge = 10) =>
        new(
            "Production",
            "Yeshua.Test",
            "SagaWorker",
            "Test.Saga",
            backlog,
            oldest,
            sampleAge,
            false,
            5,
            processed,
            diseases);

    private sealed class QueueDiagnosisHttp : HttpMessageHandler
    {
        public string LokiQuery { get; private set; } = string.Empty;
        public string TempoQuery { get; private set; } = string.Empty;

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var uri = request.RequestUri!;
            if (uri.AbsolutePath.Contains("query_range", StringComparison.Ordinal))
            {
                LokiQuery = Uri.UnescapeDataString(uri.Query);
                const string line = """
                    {"TimestampUtc":"2026-11-10T10:00:00Z","Data":{"EventName":"QueueItem.HealthChanged","TenantId":1,"Queue":"Clinica.Saga","ItemType":"ExampleSaga","ItemReference":"item-42","Disease":"TerminalFailure","Severity":"critical","EligibleAgeSeconds":4,"ProcessingAgeSeconds":0,"ExecutionCount":3,"RetryCount":2,"LastOutcome":"terminal_failed","OperationalEntityId":"entity-1","RootOperationId":"root-stable","ExecutionId":"execution-old","ErrorSignature":"abc123"}}
                    """;
                var body = JsonSerializer.Serialize(new
                {
                    status = "success",
                    data = new
                    {
                        result = new[] { new { values = new[] { new[] { "1", line } } } }
                    }
                });
                return Response(body);
            }

            TempoQuery = Uri.UnescapeDataString(uri.Query);
            return Response("""{"traces":[{"traceID":"trace-1"}]}""");
        }

        private static Task<HttpResponseMessage> Response(string body) =>
            Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(body, Encoding.UTF8, "application/json")
            });
    }
}
