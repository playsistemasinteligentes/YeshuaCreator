using System.Text.Json;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp;
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
            {"TimestampUtc":"2026-11-10T10:00:00Z","Data":{"EventName":"QueueItem.HealthChanged","Queue":"Clinica.Saga","ItemType":"ExampleSaga","ItemReference":"item-42","Disease":"TerminalFailure","Severity":"critical","EligibleAgeSeconds":4,"ProcessingAgeSeconds":0,"ExecutionCount":3,"RetryCount":2,"LastOutcome":"Failed","OperationalEntityId":"entity-1","RootOperationId":"root-1","ExecutionId":"execution-1","ErrorSignature":"abc123"}}
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
}
