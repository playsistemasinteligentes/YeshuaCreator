using System.Net.Http.Headers;
using System.Text.Json;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Http;
using Shared.Operational;

namespace Memorias.YouTube;

public sealed class GoogleYouTubeOAuthClient : IYouTubeOAuthClient, IDisposable
{
    private readonly PkceGoogleAuthorizationCodeFlow _flow;
    private readonly YouTubeOptions _options;
    private readonly TimeProvider _clock;

    public GoogleYouTubeOAuthClient(YouTubeOptions options, Dominio.Interfaces.ILogger logger, TimeProvider clock)
    {
        _options = options;
        _clock = clock;
        _flow = new(new GoogleAuthorizationCodeFlow.Initializer
        {
            ClientSecrets = new ClientSecrets { ClientId = options.ClientId, ClientSecret = options.ClientSecret },
            Scopes = [YouTubeConnectionService.UploadScope, YouTubeConnectionService.ReadScope],
            Prompt = "consent select_account", IncludeGrantedScopes = true,
            HttpClientFactory = new TelemetryHttpClientFactory(logger)
        });
        _flow.HttpClient.Timeout = TimeSpan.FromSeconds(60);
    }

    public YouTubeAuthorizationRequest CreateAuthorization(string state)
    {
        var request = _flow.CreateAuthorizationCodeRequest(_options.RedirectUri, out var verifier);
        request.State = state;
        return new(request.Build().ToString(), verifier);
    }

    public async Task<YouTubeTokens> ExchangeAsync(YouTubeOwner owner, string code, string verifier, string redirectUri, CancellationToken cancellationToken)
    {
        try { return Map(await _flow.ExchangeCodeForTokenAsync(Identity(owner), code, verifier, redirectUri, cancellationToken)); }
        catch (TokenResponseException) { throw new YouTubeConnectionException("Google recusou a autorizacao. Conecte novamente."); }
        catch (Exception exception) when (exception is HttpRequestException or TaskCanceledException)
        { throw new YouTubeConnectionException("Comunicacao com Google indisponivel. Reinicie a conexao."); }
    }

    public async Task<YouTubeTokens> RefreshAsync(YouTubeOwner owner, string refreshToken, CancellationToken cancellationToken)
    {
        try { return Map(await _flow.RefreshTokenAsync(Identity(owner), refreshToken, cancellationToken)); }
        catch (TokenResponseException exception)
        {
            throw new YouTubeConnectionException("Google nao renovou a autorizacao. Reconecte sua conta.",
                authorizationRejected: exception.Error?.Error == "invalid_grant");
        }
        catch (Exception exception) when (exception is HttpRequestException or TaskCanceledException)
        { throw new YouTubeConnectionException("Comunicacao com Google indisponivel. Tente novamente mais tarde."); }
    }

    public async Task<YouTubeChannel> ReadChannelAsync(string accessToken, CancellationToken cancellationToken)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "https://www.googleapis.com/youtube/v3/channels?part=snippet&mine=true");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        using var response = await _flow.HttpClient.SendAsync(request, cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new YouTubeConnectionException("Nao foi possivel identificar o canal autorizado.");
        using var body = await response.Content.ReadAsStreamAsync(cancellationToken);
        using var document = await JsonDocument.ParseAsync(body, cancellationToken: cancellationToken);
        if (!document.RootElement.TryGetProperty("items", out var items) || items.GetArrayLength() != 1)
            throw new YouTubeConnectionException("Selecione uma conta Google com um canal YouTube.");
        var channel = items[0];
        var id = channel.GetProperty("id").GetString();
        var title = channel.GetProperty("snippet").GetProperty("title").GetString();
        if (string.IsNullOrWhiteSpace(id)) throw new YouTubeConnectionException("Canal autorizado sem identificacao valida.");
        return new(id, title ?? "");
    }

    public async Task RevokeAsync(string token, CancellationToken cancellationToken)
    {
        try { await _flow.RevokeTokenAsync("Memorias", token, cancellationToken); }
        catch (TokenResponseException exception) when (exception.Error?.Error == "invalid_token") { }
        catch (TokenResponseException) { throw new YouTubeConnectionException("Nao foi possivel revogar o acesso no Google. Tente novamente."); }
        catch (Exception exception) when (exception is HttpRequestException or TaskCanceledException)
        { throw new YouTubeConnectionException("Comunicacao com Google indisponivel. Tente desconectar novamente."); }
    }

    private YouTubeTokens Map(TokenResponse token)
    {
        if (token.ExpiresInSeconds is not > 0)
            throw new YouTubeConnectionException("Google retornou uma autorizacao sem prazo valido.");
        return new(token.AccessToken ?? "", token.RefreshToken ?? "",
            _clock.GetUtcNow().UtcDateTime.AddSeconds(token.ExpiresInSeconds.Value), token.Scope ?? "");
    }

    private static string Identity(YouTubeOwner owner) => $"{owner.TenantId}:{owner.UserId}";
    public void Dispose() => _flow.Dispose();

    private sealed class TelemetryHttpClientFactory(Dominio.Interfaces.ILogger logger) : Google.Apis.Http.HttpClientFactory
    {
        protected override HttpMessageHandler CreateHandler(CreateHttpClientArgs args) =>
            new OperationalHttpTelemetryHandler(logger) { InnerHandler = base.CreateHandler(args) };
    }
}
