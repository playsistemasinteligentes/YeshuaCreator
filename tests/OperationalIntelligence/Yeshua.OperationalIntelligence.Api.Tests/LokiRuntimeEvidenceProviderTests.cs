using System.Net;
using System.Text;
using Yeshua.OperationalIntelligence.Api.Collectors;
using Yeshua.OperationalIntelligence.Api.Contracts;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Clients;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class LokiRuntimeEvidenceProviderTests
{
    [TestMethod]
    public async Task QueryResolvesVersionCommitAndRecordCountFromLokiLabels()
    {
        const string payload = """
            {
              "status": "success",
              "data": {
                "result": [
                  {
                    "stream": {
                      "service_version": "commit-abc123",
                      "service_commit_sha": "abc123"
                    },
                    "values": [["1", "first"], ["2", "second"]]
                  }
                ]
              }
            }
            """;
        using var httpClient = new HttpClient(new JsonHandler(payload))
        {
            BaseAddress = new Uri("http://loki")
        };
        var provider = new LokiRuntimeEvidenceProvider(new LokiClient(httpClient));
        var toUtc = new DateTimeOffset(2026, 10, 11, 12, 0, 0, TimeSpan.Zero);

        var result = await provider.QueryAsync(
            new RuntimeEvidenceQuery(
                "Fiscal",
                null,
                "Production",
                null,
                "operation-1",
                null,
                null,
                toUtc.AddHours(-1),
                toUtc,
                100),
            CancellationToken.None);

        Assert.AreEqual(2, result.RecordCount);
        Assert.AreEqual("commit-abc123", result.ResolvedVersion);
        Assert.AreEqual("abc123", result.ResolvedCommitSha);
    }

    private sealed class JsonHandler : HttpMessageHandler
    {
        private readonly string _payload;

        public JsonHandler(string payload)
        {
            _payload = payload;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken) =>
            Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(_payload, Encoding.UTF8, "application/json")
            });
    }
}
