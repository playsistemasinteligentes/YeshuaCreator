using Yeshua.OperationalIntelligence.Api.Application;
using Yeshua.OperationalIntelligence.Api.Contracts;
using Yeshua.OperationalIntelligence.Api.Repositories;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class SourceBundleBuilderTests
{
    [TestMethod]
    public async Task BundleSeparatesRuntimeFactsInferencesAndGaps()
    {
        var runtime = new RuntimeInvestigationEvidence(
            new RuntimeEvidenceResponse(
                "Loki",
                "query",
                DateTimeOffset.UtcNow.AddHours(-1),
                DateTimeOffset.UtcNow,
                200,
                3,
                "commit-abc123",
                "abc123",
                null,
                []),
            null,
            ["Runtime version: commit-abc123."],
            ["Class 'EmitirReceiver' inferred from a stack frame."],
            ["One symbol was not resolved."]);
        var investigation = new InvestigationResponse(
            "Fiscal",
            "commit-abc123",
            DateTimeOffset.UtcNow,
            TimeSpan.Zero,
            [],
            [
                new ContextEvidence(
                    "runtime",
                    "RUNTIME_OPERATIONAL_EVIDENCE",
                    "runtime",
                    "Fiscal",
                    "commit-abc123",
                    DateTimeOffset.UtcNow,
                    1,
                    runtime)
            ],
            []);
        var context = new QuestionContextResponse(
            Guid.Empty,
            "Fiscal",
            "commit-abc123",
            "Where did the failure originate?",
            "BUG_DIAGNOSIS",
            "Use the supplied evidence.",
            string.Empty,
            DateTime.UtcNow,
            new QuestionContextSummary(0, 0, 0, 0, 0, 0),
            [],
            []);
        var builder = new SourceBundleBuilder(new UnusedRepository());

        var bundle = await builder.BuildAsync(context, investigation, CancellationToken.None);

        StringAssert.Contains(bundle, "RUNTIME FACTS:");
        StringAssert.Contains(bundle, "Runtime version: commit-abc123.");
        StringAssert.Contains(bundle, "SOURCE INFERENCES:");
        StringAssert.Contains(bundle, "Class 'EmitirReceiver' inferred from a stack frame.");
        StringAssert.Contains(bundle, "EVIDENCE GAPS:");
        StringAssert.Contains(bundle, "One symbol was not resolved.");
    }

    private sealed class UnusedRepository : ISourceContextRepository
    {
        public Task<SourceContextResponse> DiscoverFilesAsync(SourceDiscoveryRequest request, CancellationToken cancellationToken) => throw new NotSupportedException();
        public Task<IReadOnlyList<ApplicationSummary>> GetApplicationsAsync(CancellationToken cancellationToken) => throw new NotSupportedException();
        public Task<IReadOnlyList<BuildSummary>> GetBuildsAsync(string application, CancellationToken cancellationToken) => throw new NotSupportedException();
        public Task<SourceContextResponse> SearchFieldAsync(FieldSearchRequest request, CancellationToken cancellationToken) => throw new NotSupportedException();
        public Task<SourceContextResponse> SearchClassAsync(ClassSearchRequest request, CancellationToken cancellationToken) => throw new NotSupportedException();
        public Task<SourceContextResponse> SearchFunctionAsync(FunctionSearchRequest request, CancellationToken cancellationToken) => throw new NotSupportedException();
        public Task<SourceContextResponse> SearchFilesAsync(FileSearchRequest request, CancellationToken cancellationToken) => throw new NotSupportedException();
        public Task<IReadOnlyList<SourceFileContent>> GetSourceContentsAsync(Guid buildId, IReadOnlyList<string> files, CancellationToken cancellationToken) => throw new NotSupportedException();
        public Task<IReadOnlyList<SourceFileHistory>> GetFileHistoryAsync(Guid buildId, IReadOnlyList<string> files, CancellationToken cancellationToken) => throw new NotSupportedException();
    }
}
