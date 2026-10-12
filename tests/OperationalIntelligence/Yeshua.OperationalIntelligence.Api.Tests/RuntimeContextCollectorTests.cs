using System.Text.Json;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Yeshua.OperationalIntelligence.Api.Application;
using Yeshua.OperationalIntelligence.Api.Collectors;
using Yeshua.OperationalIntelligence.Api.Contracts;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;
using Yeshua.OperationalIntelligence.Api.Repositories;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class RuntimeContextCollectorTests
{
    [TestMethod]
    public void CanCollectRequiresRuntimeSourceOrSelector()
    {
        var collector = CreateCollector(new RecordingProvider());

        Assert.IsFalse(collector.CanCollect(new InvestigationRequest
        {
            Application = "Fiscal",
            Field = "Status"
        }));
        Assert.IsTrue(collector.CanCollect(new InvestigationRequest
        {
            Application = "Fiscal",
            Sources = ["runtime"]
        }));
        Assert.IsTrue(collector.CanCollect(new InvestigationRequest
        {
            Application = "Fiscal",
            OperationId = "operation-1"
        }));
    }

    [TestMethod]
    public async Task CollectLimitsTimeRangeAndVolume()
    {
        var provider = new RecordingProvider();
        var collector = CreateCollector(provider);
        var toUtc = new DateTimeOffset(2026, 10, 11, 12, 0, 0, TimeSpan.Zero);

        var result = await collector.CollectAsync(
            new InvestigationRequest
            {
                Application = "Fiscal",
                Environment = "Production",
                OperationId = "operation-1",
                FromUtc = toUtc.AddHours(-10),
                ToUtc = toUtc,
                MaxResults = 500,
                IncludeKnowledgeReferences = false
            },
            CancellationToken.None);

        Assert.IsNotNull(provider.LastQuery);
        Assert.AreEqual(toUtc.AddHours(-2), provider.LastQuery.FromUtc);
        Assert.AreEqual(toUtc, provider.LastQuery.ToUtc);
        Assert.AreEqual(50, provider.LastQuery.Limit);
        Assert.AreEqual(1, result.Evidence.Count);
        StringAssert.Contains(result.Warnings.Single(), "limited to 2 hours");
    }

    [TestMethod]
    public async Task CollectCorrelatesRuntimeLogWithConfirmedSourceVersion()
    {
        var repository = new CorrelationRepository();
        var resolver = new LogKnowledgeReferenceResolver(
            repository,
            new QuestionContextBuilder(),
            new LogSourceEvidenceExtractor());
        var collector = CreateCollector(new RuntimeLogProvider(), resolver);

        var result = await collector.CollectAsync(
            new InvestigationRequest
            {
                Application = "Fiscal",
                Sources = ["runtime"]
            },
            CancellationToken.None);

        Assert.AreEqual("commit-abc123", repository.RequestedVersion);
        Assert.IsTrue(result.Evidence.Any(item => item.Data is SourceContextResponse));
        var runtime = (RuntimeInvestigationEvidence)result.Evidence
            .Single(item => item.EvidenceType == "RUNTIME_OPERATIONAL_EVIDENCE")
            .Data;
        Assert.AreEqual(1, runtime.Inferences.Count);
        StringAssert.Contains(runtime.Inferences[0], "EmitirReceiver");
    }

    private static RuntimeContextCollector CreateCollector(
        IRuntimeEvidenceProvider provider,
        LogKnowledgeReferenceResolver? resolver = null) =>
        new(
            provider,
            Options.Create(new McpOptions
            {
                DefaultLimit = 25,
                MaxLimit = 50,
                MaxTimeRangeHours = 2
            }),
            resolver!,
            NullLogger<RuntimeContextCollector>.Instance);

    private sealed class RecordingProvider : IRuntimeEvidenceProvider
    {
        public RuntimeEvidenceQuery? LastQuery { get; private set; }

        public Task<RuntimeEvidenceResponse> QueryAsync(
            RuntimeEvidenceQuery query,
            CancellationToken cancellationToken)
        {
            LastQuery = query;
            using var document = JsonDocument.Parse("{\"status\":\"success\"}");
            return Task.FromResult(new RuntimeEvidenceResponse(
                "Loki",
                "{service_name=\"Fiscal\"}",
                query.FromUtc,
                query.ToUtc,
                200,
                1,
                query.Version,
                "commit-1",
                document.RootElement.Clone(),
                []));
        }
    }

    private sealed class RuntimeLogProvider : IRuntimeEvidenceProvider
    {
        public Task<RuntimeEvidenceResponse> QueryAsync(
            RuntimeEvidenceQuery query,
            CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse("""
                {
                  "data": {
                    "result": [
                      {
                        "values": [
                          ["1", "{\"SourceContext\":\"Yeshua.Fiscal.EmitirReceiver\"}"]
                        ]
                      }
                    ]
                  }
                }
                """);
            return Task.FromResult(new RuntimeEvidenceResponse(
                "Loki",
                "query",
                query.FromUtc,
                query.ToUtc,
                200,
                1,
                "commit-abc123",
                "abc123",
                document.RootElement.Clone(),
                []));
        }
    }

    private sealed class CorrelationRepository : ISourceContextRepository
    {
        public string? RequestedVersion { get; private set; }

        public Task<SourceContextResponse> SearchClassAsync(
            ClassSearchRequest request,
            CancellationToken cancellationToken)
        {
            RequestedVersion = request.Version;
            return Task.FromResult(new SourceContextResponse(
                new BuildSummary(
                    Guid.NewGuid(),
                    request.Application,
                    request.Version!,
                    "abc123",
                    "YeshuaCreator.sln",
                    DateTime.UtcNow),
                [
                    new SymbolMatch(
                        Guid.NewGuid(),
                        "EXACT",
                        "CLASS",
                        "Yeshua.Fiscal.EmitirReceiver",
                        "src/Fiscal/EmitirReceiver.cs",
                        10,
                        40)
                ],
                [],
                [],
                [
                    new SourceFileCandidate
                    {
                        File = "src/Fiscal/EmitirReceiver.cs",
                        Reason = "CLASS_DECLARATION"
                    }
                ],
                []));
        }

        public Task<IReadOnlyList<ApplicationSummary>> GetApplicationsAsync(CancellationToken cancellationToken) => throw new NotSupportedException();
        public Task<IReadOnlyList<BuildSummary>> GetBuildsAsync(string application, CancellationToken cancellationToken) => throw new NotSupportedException();
        public Task<SourceContextResponse> SearchFieldAsync(FieldSearchRequest request, CancellationToken cancellationToken) => throw new NotSupportedException();
        public Task<SourceContextResponse> SearchFunctionAsync(FunctionSearchRequest request, CancellationToken cancellationToken) => throw new NotSupportedException();
        public Task<SourceContextResponse> SearchFilesAsync(FileSearchRequest request, CancellationToken cancellationToken) => throw new NotSupportedException();
        public Task<IReadOnlyList<SourceFileContent>> GetSourceContentsAsync(Guid buildId, IReadOnlyList<string> files, CancellationToken cancellationToken) => Task.FromResult<IReadOnlyList<SourceFileContent>>([]);
        public Task<IReadOnlyList<SourceFileHistory>> GetFileHistoryAsync(Guid buildId, IReadOnlyList<string> files, CancellationToken cancellationToken) => Task.FromResult<IReadOnlyList<SourceFileHistory>>([]);
    }
}
