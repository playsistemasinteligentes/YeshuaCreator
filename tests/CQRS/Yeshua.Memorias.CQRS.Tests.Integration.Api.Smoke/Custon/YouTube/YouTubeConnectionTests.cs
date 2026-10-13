using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Command.Receivers.UseCase;
using Command.UseCase;
using Memorias.YouTube;
using Microsoft.AspNetCore.WebUtilities;
using static Yeshua.Memorias.Tests.PhotoUploadTests;

namespace Yeshua.Memorias.Tests;

[Trait("Category", "BusinessSmoke")]
public class YouTubeConnectionTests
{
    private static readonly YouTubeOwner Owner = new(7, 9);

    [Fact]
    public async Task OneUserCanConnectMultipleChannelsAndListOnlySafeMetadata()
    {
        using var rig = new Rig();
        var first = await rig.Connect("channel-a");
        var second = await rig.Connect("channel-b");
        var list = await rig.Service.ListAsync(Owner, default);
        Assert.Equal(2, list.Conexoes.Count);
        Assert.NotEqual(first.ConexaoId, second.ConexaoId);
        Assert.Equal("access-channel-a", await rig.Service.GetAccessTokenAsync(Owner, first.ConexaoId, "channel-a", default));
        Assert.Equal("access-channel-b", await rig.Service.GetAccessTokenAsync(Owner, second.ConexaoId, "channel-b", default));
        var json = JsonSerializer.Serialize(list);
        Assert.DoesNotContain("access-channel", json);
        Assert.DoesNotContain("refresh-channel", json);
        Assert.DoesNotContain("CodeVerifier", json);
    }

    [Theory]
    [InlineData(7, 99)]
    [InlineData(99, 9)]
    public async Task AnotherUserOrTenantCannotUseConnectionOrCallback(int tenantId, int userId)
    {
        using var rig = new Rig();
        var connection = await rig.Connect("channel-a");
        var other = new YouTubeOwner(tenantId, userId);
        Assert.Empty((await rig.Service.ListAsync(other, default)).Conexoes);
        Assert.Null(await rig.Service.GetAccessTokenAsync(other, connection.ConexaoId, "channel-a", default));
        await Assert.ThrowsAsync<YouTubeConnectionException>(() => rig.Service.BeginAsync(other, connection.ConexaoId, default));
        await rig.Service.BeginAsync(Owner, "", default);
        await Assert.ThrowsAsync<YouTubeConnectionException>(() => rig.Service.CompleteAsync(other, "code", rig.Google.LastState, default));
    }

    [Fact]
    public async Task CallbackCannotBeReplayed()
    {
        using var rig = new Rig();
        await rig.Service.BeginAsync(Owner, "", default);
        var state = rig.Google.LastState;
        await rig.Service.CompleteAsync(Owner, "code", state, default);
        await Assert.ThrowsAsync<YouTubeConnectionException>(() => rig.Service.CompleteAsync(Owner, "code", state, default));
        Assert.Equal(1, rig.Google.Exchanges);
    }

    [Fact]
    public async Task ExpiredAuthorizationDoesNotExchangeCode()
    {
        using var rig = new Rig();
        await rig.Service.BeginAsync(Owner, "", default);
        rig.Clock.Advance(TimeSpan.FromMinutes(11));
        await Assert.ThrowsAsync<YouTubeConnectionException>(() => rig.Service.CompleteAsync(Owner, "code", rig.Google.LastState, default));
        Assert.Equal(0, rig.Google.Exchanges);
    }

    [Fact]
    public async Task WrongStateDoesNotConsumeValidAuthorization()
    {
        using var rig = new Rig();
        await rig.Service.BeginAsync(Owner, "", default);
        await Assert.ThrowsAsync<YouTubeConnectionException>(() => rig.Service.CompleteAsync(Owner, "code", new string('A', 64), default));
        Assert.True((await rig.Service.CompleteAsync(Owner, "code", rig.Google.LastState, default)).Conectado);
    }

    [Fact]
    public async Task ReauthorizationOfSameChannelPreservesConnectionId()
    {
        using var rig = new Rig();
        var first = await rig.Connect("channel-a");
        var again = await rig.Connect("channel-a");
        Assert.Equal(first.ConexaoId, again.ConexaoId);
        Assert.Single((await rig.Service.ListAsync(Owner, default)).Conexoes);
    }

    [Fact]
    public async Task ReconnectingConnectionCannotChangeItsChannel()
    {
        using var rig = new Rig();
        var first = await rig.Connect("channel-a");
        rig.Google.NextChannel = "channel-b";
        await rig.Service.BeginAsync(Owner, first.ConexaoId, default);
        await Assert.ThrowsAsync<YouTubeConnectionException>(() => rig.Service.CompleteAsync(Owner, "code", rig.Google.LastState, default));
        Assert.Equal("channel-a", (await rig.Service.StatusAsync(Owner, first.ConexaoId, default)).CanalId);
        Assert.Null(await rig.Service.GetAccessTokenAsync(Owner, first.ConexaoId, "channel-b", default));
    }

    [Fact]
    public async Task DisconnectKeepsDestinationIdentityButRemovesSecretsAndPendingConsent()
    {
        using var rig = new Rig();
        var first = await rig.Connect("channel-a");
        var second = await rig.Connect("channel-b");
        await rig.Service.BeginAsync(Owner, first.ConexaoId, default);
        var state = rig.Google.LastState;
        await rig.Service.DisconnectAsync(Owner, first.ConexaoId, default);
        Assert.Equal("refresh-channel-a", rig.Google.LastRevoked);
        Assert.False((await rig.Service.StatusAsync(Owner, first.ConexaoId, default)).Conectado);
        Assert.Null(await rig.Service.GetAccessTokenAsync(Owner, first.ConexaoId, "channel-a", default));
        Assert.Equal("access-channel-b", await rig.Service.GetAccessTokenAsync(Owner, second.ConexaoId, "channel-b", default));
        await Assert.ThrowsAsync<YouTubeConnectionException>(() => rig.Service.CompleteAsync(Owner, "code", state, default));
        rig.Google.NextChannel = "channel-a";
        await rig.Service.BeginAsync(Owner, first.ConexaoId, default);
        Assert.Equal(first.ConexaoId, (await rig.Service.CompleteAsync(Owner, "code", rig.Google.LastState, default)).ConexaoId);
    }

    [Fact]
    public async Task RefreshIsSerializedAndPreservesExistingRefreshToken()
    {
        using var rig = new Rig();
        var connection = await rig.Connect("channel-a");
        rig.Clock.Advance(TimeSpan.FromHours(2));
        var tokens = await Task.WhenAll(
            rig.Service.GetAccessTokenAsync(Owner, connection.ConexaoId, "channel-a", default),
            rig.Service.GetAccessTokenAsync(Owner, connection.ConexaoId, "channel-a", default));
        Assert.All(tokens, token => Assert.Equal("renewed-access", token));
        Assert.Equal(1, rig.Google.Refreshes);
        using var lease = await rig.Repository.AcquireAsync(Owner, default);
        Assert.Equal("refresh-channel-a", lease.ReadAccount(connection.ConexaoId)!.RefreshToken);
    }

    [Fact]
    public async Task RevokedGrantMarksOnlyThatConnectionDisconnected()
    {
        using var rig = new Rig();
        var first = await rig.Connect("channel-a");
        var second = await rig.Connect("channel-b");
        rig.Clock.Advance(TimeSpan.FromHours(2));
        rig.Google.RejectRefresh = true;
        await Assert.ThrowsAsync<YouTubeConnectionException>(() => rig.Service.GetAccessTokenAsync(Owner, first.ConexaoId, "channel-a", default));
        Assert.False((await rig.Service.StatusAsync(Owner, first.ConexaoId, default)).Conectado);
        Assert.True((await rig.Service.StatusAsync(Owner, second.ConexaoId, default)).Conectado);
        using var lease = await rig.Repository.AcquireAsync(Owner, default);
        Assert.Empty(lease.ReadAccount(first.ConexaoId)!.RefreshToken);
    }

    [Fact]
    public async Task TokensAreEncryptedAndCannotBeMovedToAnotherOwner()
    {
        using var rig = new Rig();
        var connection = await rig.Connect("channel-a");
        var source = Directory.GetFiles(rig.Root, "connection-*.bin", SearchOption.AllDirectories).Single();
        Assert.DoesNotContain("access-channel-a", Encoding.UTF8.GetString(File.ReadAllBytes(source)));
        var other = new YouTubeOwner(7, 99);
        using (await rig.Repository.AcquireAsync(other, default)) { }
        var target = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(source))!, "99", Path.GetFileName(source));
        File.Copy(source, target);
        await Assert.ThrowsAsync<YouTubeConnectionException>(() => rig.Service.StatusAsync(other, connection.ConexaoId, default));
    }

    [Theory]
    [InlineData("../escape")]
    [InlineData("00000000000000000000000000000000")]
    [InlineData("invalid")]
    public async Task InvalidConnectionIdsCannotAddressFiles(string id)
    {
        using var rig = new Rig();
        await Assert.ThrowsAsync<YouTubeConnectionException>(() => rig.Service.StatusAsync(Owner, id, default));
    }

    [Theory]
    [InlineData("https://www.googleapis.com/auth/youtube.readonly", "refresh")]
    [InlineData("https://www.googleapis.com/auth/youtube.upload", "refresh")]
    [InlineData("https://www.googleapis.com/auth/youtube.upload https://www.googleapis.com/auth/youtube.readonly", "")]
    public async Task MissingPermissionsOrRefreshTokenDoNotCreateConnection(string scope, string refresh)
    {
        using var rig = new Rig();
        rig.Google.Scope = scope;
        rig.Google.RefreshTokenOverride = refresh;
        await rig.Service.BeginAsync(Owner, "", default);
        await Assert.ThrowsAsync<YouTubeConnectionException>(() => rig.Service.CompleteAsync(Owner, "code", rig.Google.LastState, default));
        Assert.Empty((await rig.Service.ListAsync(Owner, default)).Conexoes);
    }

    [Fact]
    public void OfficialLibraryRequestsOfflineAccessAndPkceS256()
    {
        using var rig = new Rig();
        using var client = new GoogleYouTubeOAuthClient(rig.Options, TestProxy.For<Dominio.Interfaces.ILogger>(), rig.Clock);
        var request = client.CreateAuthorization("state");
        var query = QueryHelpers.ParseQuery(new Uri(request.Url).Query);
        Assert.Equal("offline", query["access_type"]);
        Assert.Equal("S256", query["code_challenge_method"]);
        Assert.Equal("state", query["state"]);
        Assert.Contains(YouTubeConnectionService.UploadScope, query["scope"].ToString());
        Assert.Contains(YouTubeConnectionService.ReadScope, query["scope"].ToString());
        Assert.DoesNotContain(rig.Options.ClientSecret, request.Url);
        Assert.InRange(request.CodeVerifier.Length, 43, 128);
    }

    [Fact]
    public async Task MissingConfigurationReturnsStatusWithoutTouchingCredentials()
    {
        using var rig = new Rig();
        rig.Options.ClientId = "";
        var list = await rig.Service.ListAsync(Owner, default);
        Assert.False(list.Configurado);
        Assert.Empty(list.Conexoes);
        Assert.Null(await rig.Service.GetAccessTokenAsync(Owner, "", "", default));
        Assert.Empty(Directory.GetFileSystemEntries(rig.Root));
        using var google = new GoogleYouTubeOAuthClient(rig.Options, TestProxy.For<Dominio.Interfaces.ILogger>(), rig.Clock);
    }

    internal sealed class Rig : IDisposable
    {
        public string Root { get; } = Path.Combine(Path.GetTempPath(), "yeshua-memorias-youtube-tests", Guid.NewGuid().ToString("N"));
        public YouTubeOptions Options { get; }
        public Clock Clock { get; } = new();
        public FakeGoogle Google { get; }
        public EncryptedYouTubeAccountRepository Repository { get; }
        public YouTubeConnectionService Service { get; }

        public Rig()
        {
            Directory.CreateDirectory(Root);
            Options = new()
            {
                ClientId = "test.apps.googleusercontent.com", ClientSecret = "test-client-secret",
                RedirectUri = "https://playsis.com.br/spa/youtube-callback.html",
                EncryptionKey = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32)),
                CredentialsDirectory = Root, ProcessingScope = "tests"
            };
            Google = new(Clock);
            Repository = new(Options);
            Service = new(Options, Repository, Google, Clock);
        }

        public async Task<YouTubeConnectionStatus> Connect(string channel)
        {
            Google.NextChannel = channel;
            await Service.BeginAsync(Owner, "", default);
            return await Service.CompleteAsync(Owner, "code", Google.LastState, default);
        }

        public void Dispose()
        {
            var expected = Path.GetFullPath(Path.Combine(Path.GetTempPath(), "yeshua-memorias-youtube-tests")) + Path.DirectorySeparatorChar;
            Assert.StartsWith(expected, Path.GetFullPath(Root));
            Directory.Delete(Root, true);
        }
    }

    internal sealed class Clock : TimeProvider
    {
        private DateTimeOffset _now = new(2026, 10, 13, 12, 0, 0, TimeSpan.Zero);
        public override DateTimeOffset GetUtcNow() => _now;
        public void Advance(TimeSpan time) => _now += time;
    }

    internal sealed class FakeGoogle(Clock clock) : IYouTubeOAuthClient
    {
        public string NextChannel = "channel-a";
        public string LastState = "";
        public string LastRevoked = "";
        public string Scope = YouTubeConnectionService.UploadScope + " " + YouTubeConnectionService.ReadScope;
        public string? RefreshTokenOverride;
        public int Exchanges;
        public int Refreshes;
        public bool RejectRefresh;
        public YouTubeAuthorizationRequest CreateAuthorization(string state)
        {
            LastState = state;
            return new("https://accounts.google.com/o/oauth2/v2/auth?state=" + state, "test-verifier");
        }
        public Task<YouTubeTokens> ExchangeAsync(YouTubeOwner owner, string code, string verifier, string redirectUri, CancellationToken cancellationToken)
        {
            ++Exchanges;
            return Task.FromResult(new YouTubeTokens("access-" + NextChannel,
                RefreshTokenOverride ?? "refresh-" + NextChannel, clock.GetUtcNow().UtcDateTime.AddHours(1), Scope));
        }
        public async Task<YouTubeTokens> RefreshAsync(YouTubeOwner owner, string refreshToken, CancellationToken cancellationToken)
        {
            ++Refreshes;
            if (RejectRefresh) throw new YouTubeConnectionException("Revoked", authorizationRejected: true);
            await Task.Delay(50, cancellationToken);
            return new("renewed-access", "", clock.GetUtcNow().UtcDateTime.AddHours(1), Scope);
        }
        public Task<YouTubeChannel> ReadChannelAsync(string token, CancellationToken cancellationToken) =>
            Task.FromResult(new YouTubeChannel(NextChannel, NextChannel));
        public Task RevokeAsync(string token, CancellationToken cancellationToken)
        {
            LastRevoked = token;
            return Task.CompletedTask;
        }
    }
}
