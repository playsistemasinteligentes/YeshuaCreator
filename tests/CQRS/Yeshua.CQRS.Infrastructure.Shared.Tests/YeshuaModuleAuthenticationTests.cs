using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.ModuleTransport;
using System.Net;
using System.Text;

namespace Yeshua.CQRS.Infrastructure.Shared.Tests;

[TestClass]
public sealed class YeshuaModuleAuthenticationTests
{
    private static readonly DateTimeOffset Now = new(2026, 10, 10, 12, 0, 0, TimeSpan.Zero);

    [TestMethod]
    public async Task HandlerAndAuthenticatorAcceptTheSameSignedBody()
    {
        var settings = CreateSettings();
        var clock = new FixedTimeProvider(Now);
        var capture = new CapturingHandler();
        var signingHandler = new YeshuaModuleAuthenticationHandler(settings, clock)
        {
            InnerHandler = capture
        };
        using var client = new HttpClient(signingHandler);
        using var request = CreateRequest("message-1", "{\"tenantId\":17}");

        await client.SendAsync(request);

        var authenticator = new YeshuaModuleRequestAuthenticator(settings, clock);
        var result = Authenticate(authenticator, capture);

        Assert.IsTrue(result.Succeeded, result.ErrorCode);
        Assert.AreEqual("APS.ADM", result.SourceModule);
    }

    [TestMethod]
    public async Task AuthenticatorRejectsTamperedBody()
    {
        var settings = CreateSettings();
        var clock = new FixedTimeProvider(Now);
        var capture = new CapturingHandler();
        var signingHandler = new YeshuaModuleAuthenticationHandler(settings, clock)
        {
            InnerHandler = capture
        };
        using var client = new HttpClient(signingHandler);
        using var request = CreateRequest("message-2", "{\"tenantId\":17}");
        await client.SendAsync(request);

        capture.Body = "{\"tenantId\":18}";
        var result = Authenticate(new YeshuaModuleRequestAuthenticator(settings, clock), capture);

        Assert.IsFalse(result.Succeeded);
        Assert.AreEqual("InvalidSignature", result.ErrorCode);
    }

    [TestMethod]
    public async Task AuthenticatorRejectsExpiredSignature()
    {
        var settings = CreateSettings();
        var capture = new CapturingHandler();
        var signingHandler = new YeshuaModuleAuthenticationHandler(settings, new FixedTimeProvider(Now))
        {
            InnerHandler = capture
        };
        using var client = new HttpClient(signingHandler);
        using var request = CreateRequest("message-3", "{\"tenantId\":17}");
        await client.SendAsync(request);

        var later = new FixedTimeProvider(Now.AddMinutes(6));
        var result = Authenticate(new YeshuaModuleRequestAuthenticator(settings, later), capture);

        Assert.IsFalse(result.Succeeded);
        Assert.AreEqual("ExpiredSignature", result.ErrorCode);
    }

    private static YeshuaModuleAuthenticationSettings CreateSettings() =>
        new(
            "APS.ADM",
            "this-is-a-test-key-with-at-least-32-characters",
            300,
            1);

    private static HttpRequestMessage CreateRequest(string messageId, string body)
    {
        var request = new HttpRequestMessage(
            HttpMethod.Post,
            "https://fiscal.test/yapi/Fiscal/Inbox/YeshuaModuleEvent");
        request.Content = new StringContent(body, Encoding.UTF8, "application/json");
        request.Headers.TryAddWithoutValidation(YeshuaModuleAuthenticationHeaders.MessageId, messageId);
        return request;
    }

    private static YeshuaModuleAuthenticationResult Authenticate(
        YeshuaModuleRequestAuthenticator authenticator,
        CapturingHandler capture) =>
        authenticator.Authenticate(
            capture.Method,
            capture.PathAndQuery,
            capture.SourceModule,
            capture.MessageId,
            capture.Timestamp,
            capture.Signature,
            capture.Body);

    private sealed class FixedTimeProvider(DateTimeOffset now) : TimeProvider
    {
        public override DateTimeOffset GetUtcNow() => now;
    }

    private sealed class CapturingHandler : HttpMessageHandler
    {
        public string Method { get; private set; } = string.Empty;
        public string PathAndQuery { get; private set; } = string.Empty;
        public string SourceModule { get; private set; } = string.Empty;
        public string MessageId { get; private set; } = string.Empty;
        public string Timestamp { get; private set; } = string.Empty;
        public string Signature { get; private set; } = string.Empty;
        public string Body { get; set; } = string.Empty;

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            Method = request.Method.Method;
            PathAndQuery = request.RequestUri!.PathAndQuery;
            SourceModule = Header(request, YeshuaModuleAuthenticationHeaders.SourceModule);
            MessageId = Header(request, YeshuaModuleAuthenticationHeaders.MessageId);
            Timestamp = Header(request, YeshuaModuleAuthenticationHeaders.Timestamp);
            Signature = Header(request, YeshuaModuleAuthenticationHeaders.Signature);
            Body = await request.Content!.ReadAsStringAsync(cancellationToken);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        private static string Header(HttpRequestMessage request, string name) =>
            request.Headers.GetValues(name).Single();
    }
}
