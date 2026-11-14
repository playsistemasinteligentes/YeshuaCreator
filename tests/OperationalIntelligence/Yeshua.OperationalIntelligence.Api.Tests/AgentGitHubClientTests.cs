using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class AgentGitHubClientTests
{
    private const string FixtureToken = "fixture-token-not-a-credential";

    [TestMethod]
    public async Task AuthenticatesTheDedicatedUserAndChecksRepositoryAccess()
    {
        using var transport = new GitHubFixture(
            "{\"login\":\"agpsi0001-lgtm\"}", "{\"permissions\":{\"push\":true}}");
        var identity = await Create(transport).AuthenticateAsync(default);
        Assert.AreEqual("agpsi0001-lgtm", identity.Name);
        Assert.AreEqual("agpsi0001@gmail.com", identity.Email);
        Assert.AreEqual(FixtureToken, identity.Token);
        Assert.IsFalse(identity.ToString()!.Contains(FixtureToken));
        CollectionAssert.AreEqual(new[] { "/user", "/repos/playsistemasinteligentes/YeshuaCreator" },
            transport.Calls.Select(call => call.Path).ToArray());
        Assert.IsTrue(transport.Calls.All(call => call.Method == HttpMethod.Get));
    }

    [TestMethod]
    public async Task AnotherAccountsTokenCannotBeUsedAsTheAgent()
    {
        using var transport = new GitHubFixture("{\"login\":\"another-user\"}");
        var error = await Assert.ThrowsExceptionAsync<ArgumentException>(() => Create(transport).AuthenticateAsync(default));
        StringAssert.Contains(error.Message, "nao pertence");
        Assert.AreEqual(1, transport.Calls.Count);
    }

    [TestMethod]
    public async Task ReadOnlyRepositoryAccessIsInsufficientForPublishing()
    {
        using var transport = new GitHubFixture(
            "{\"login\":\"agpsi0001-lgtm\"}", "{\"permissions\":{\"push\":false}}");
        var error = await Assert.ThrowsExceptionAsync<ArgumentException>(() => Create(transport).AuthenticateAsync(default));
        StringAssert.Contains(error.Message, "nao possui escrita");
    }

    [TestMethod]
    public async Task MissingCredentialsFailBeforeAnyRequestAndApiErrorsDoNotExposeBodies()
    {
        using var transport = new GitHubFixture(FixtureToken);
        using var http = new HttpClient(transport);
        var unconfigured = new AgentGitHubClient(http, Options.Create(new AgentTaskOptions()));
        Assert.IsFalse(unconfigured.Configured);
        await Assert.ThrowsExceptionAsync<ArgumentException>(() => unconfigured.AuthenticateAsync(default));
        Assert.AreEqual(0, transport.Calls.Count);
        transport.StatusCode = HttpStatusCode.Unauthorized;
        var error = await Assert.ThrowsExceptionAsync<ArgumentException>(() => Create(transport).AuthenticateAsync(default));
        StringAssert.Contains(error.Message, "HTTP 401");
        Assert.IsFalse(error.Message.Contains(FixtureToken));
    }

    [TestMethod]
    public async Task CreatesOnlyADraftPullRequestToTheConfiguredBase()
    {
        using var transport = new GitHubFixture("[]", "{\"html_url\":\"https://github.com/playsistemasinteligentes/YeshuaCreator/pull/123\"}");
        var branch = AgentGitWorkspace.Branch(Guid.NewGuid());
        var identity = new AgentGitIdentity(FixtureToken, "agpsi0001-lgtm", "agpsi0001@gmail.com");
        var url = await Create(transport).OpenDraftPullRequestAsync(identity, branch, "Ajuste", "Verificacao executada.", default);
        StringAssert.EndsWith(url, "/pull/123");
        Assert.AreEqual(2, transport.Calls.Count);
        StringAssert.Contains(Uri.UnescapeDataString(transport.Calls[0].Path), "head=playsistemasinteligentes:" + branch);
        Assert.AreEqual(HttpMethod.Post, transport.Calls[1].Method);
        Assert.AreEqual("/repos/playsistemasinteligentes/YeshuaCreator/pulls", transport.Calls[1].Path);
        using var body = JsonDocument.Parse(transport.Calls[1].Body!);
        Assert.IsTrue(body.RootElement.GetProperty("draft").GetBoolean());
        Assert.AreEqual("main", body.RootElement.GetProperty("base").GetString());
        Assert.AreEqual(branch, body.RootElement.GetProperty("head").GetString());
        Assert.IsFalse(transport.Calls[1].Body!.Contains(FixtureToken));
    }

    [TestMethod]
    public async Task ReusesExistingPullRequestAndDoesNotReopenAClosedOne()
    {
        var identity = new AgentGitIdentity(FixtureToken, "agpsi0001-lgtm", "agpsi0001@gmail.com");
        using var open = new GitHubFixture("[{\"state\":\"open\",\"html_url\":\"https://github.com/owner/repo/pull/1\"}]");
        var url = await Create(open).OpenDraftPullRequestAsync(identity, "codex/task-fixture", "Ajuste", "Resumo", default);
        StringAssert.EndsWith(url, "/pull/1");
        Assert.AreEqual(1, open.Calls.Count);
        using var closed = new GitHubFixture("[{\"state\":\"closed\"}]");
        await Assert.ThrowsExceptionAsync<ArgumentException>(() => Create(closed)
            .OpenDraftPullRequestAsync(identity, "codex/task-fixture", "Ajuste", "Resumo", default));
        Assert.AreEqual(1, closed.Calls.Count);
    }

    private static AgentGitHubClient Create(GitHubFixture transport) => new(new HttpClient(transport), Options.Create(new AgentTaskOptions
    {
        Git = new() { UserName = "agpsi0001-lgtm", Email = "agpsi0001@gmail.com", Token = FixtureToken }
    }));

    private sealed class GitHubFixture(params string[] responses) : HttpMessageHandler
    {
        private readonly Queue<string> responses = new(responses);
        public List<(HttpMethod Method, string Path, string? Body)> Calls { get; } = [];
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token)
        {
            Assert.AreEqual("https://api.github.com", request.RequestUri!.GetLeftPart(UriPartial.Authority));
            Assert.AreEqual("Bearer", request.Headers.Authorization!.Scheme);
            Assert.AreEqual(FixtureToken, request.Headers.Authorization.Parameter);
            Calls.Add((request.Method, request.RequestUri.PathAndQuery,
                request.Content is null ? null : await request.Content.ReadAsStringAsync(token)));
            return new(StatusCode) { Content = new StringContent(responses.Dequeue()) };
        }
    }
}
