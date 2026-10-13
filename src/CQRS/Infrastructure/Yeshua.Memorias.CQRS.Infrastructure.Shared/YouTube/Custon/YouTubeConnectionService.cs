using System.Security.Cryptography;
using System.Text;

namespace Memorias.YouTube;

public sealed class YouTubeConnectionService(
    YouTubeOptions options, IYouTubeAccountRepository repository,
    IYouTubeOAuthClient client, TimeProvider clock) : IYouTubeConnectionService
{
    public const string UploadScope = "https://www.googleapis.com/auth/youtube.upload";
    public const string ReadScope = "https://www.googleapis.com/auth/youtube.readonly";

    public async Task<YouTubeConnectionStatus> BeginAsync(YouTubeOwner owner, string connectionId, CancellationToken cancellationToken)
    {
        owner.Validate();
        RequireConfiguration();
        using var lease = await repository.AcquireAsync(owner, cancellationToken);
        var existing = string.IsNullOrEmpty(connectionId) ? null : lease.ReadAccount(connectionId);
        if (!string.IsNullOrEmpty(connectionId) && existing == null)
            throw new YouTubeConnectionException("Conexao nao encontrada para este usuario.");
        connectionId = existing?.ConnectionId ?? Guid.NewGuid().ToString("N");
        var state = Convert.ToHexString(RandomNumberGenerator.GetBytes(32));
        var request = client.CreateAuthorization(state);
        lease.RemoveExpiredAuthorizations(Now);
        lease.SaveAuthorization(new(state, request.CodeVerifier, options.RedirectUri,
            Now.AddMinutes(10), options.ClientId, connectionId, existing?.ChannelId ?? ""));
        return new(true, false, AuthorizationUrl: request.Url, Mensagem: "Autorizacao iniciada.", ConexaoId: connectionId);
    }

    public async Task<YouTubeConnectionStatus> CompleteAsync(YouTubeOwner owner, string code, string state, CancellationToken cancellationToken)
    {
        owner.Validate();
        RequireConfiguration();
        if (string.IsNullOrWhiteSpace(code) || code.Length > 4096 || state?.Length != 64)
            throw new YouTubeConnectionException("Retorno de autorizacao invalido.");
        using var lease = await repository.AcquireAsync(owner, cancellationToken);
        var pending = lease.ReadAuthorization(state);
        if (pending == null || pending.ExpiresAtUtc <= Now || pending.ClientId != options.ClientId
            || pending.RedirectUri != options.RedirectUri
            || !CryptographicOperations.FixedTimeEquals(Encoding.UTF8.GetBytes(pending.State), Encoding.UTF8.GetBytes(state)))
            throw new YouTubeConnectionException("Autorizacao invalida ou expirada. Conecte novamente.");

        // Consome o state antes da troca: callbacks repetidos nao reutilizam o codigo.
        lease.DeleteAuthorization(state);
        var tokens = await client.ExchangeAsync(owner, code, pending.CodeVerifier, pending.RedirectUri, cancellationToken);
        RequireScopes(tokens.Scope);
        if (string.IsNullOrWhiteSpace(tokens.RefreshToken) || string.IsNullOrWhiteSpace(tokens.AccessToken))
            throw new YouTubeConnectionException("Google nao autorizou o acesso continuado. Conecte novamente.");
        var channel = await client.ReadChannelAsync(tokens.AccessToken, cancellationToken);
        if (!string.IsNullOrEmpty(pending.ExpectedChannelId) && channel.Id != pending.ExpectedChannelId)
            throw new YouTubeConnectionException("Esta conexao pertence a outro canal. Adicione uma nova conexao para o canal escolhido.");
        // Uma nova autorizacao do mesmo canal preserva o ID usado pelas publicacoes.
        var existing = lease.ReadAccounts().FirstOrDefault(account => account.ChannelId == channel.Id);
        var connectionId = existing?.ConnectionId ?? pending.ConnectionId;
        lease.SaveAccount(new(options.ClientId, tokens.AccessToken, tokens.RefreshToken,
            tokens.ExpiresAtUtc, channel.Id, channel.Title, connectionId));
        return new(true, true, channel.Id, channel.Title, Mensagem: "Canal conectado.", ConexaoId: connectionId);
    }

    public async Task<YouTubeConnections> ListAsync(YouTubeOwner owner, CancellationToken cancellationToken)
    {
        owner.Validate();
        if (!options.Configured) return new(false, []);
        using var lease = await repository.AcquireAsync(owner, cancellationToken);
        return new(true, lease.ReadAccounts().Select(Status).OrderBy(account => account.CanalTitulo).ToList());
    }

    public async Task<YouTubeConnectionStatus> StatusAsync(YouTubeOwner owner, string connectionId, CancellationToken cancellationToken)
    {
        owner.Validate();
        if (!options.Configured)
            return new(false, false, Mensagem: "YouTube ainda nao configurado no servidor.");
        using var lease = await repository.AcquireAsync(owner, cancellationToken);
        var account = lease.ReadAccount(connectionId);
        return account != null ? Status(account) : new(true, false, Mensagem: "Conexao nao encontrada.");
    }

    public async Task<YouTubeConnectionStatus> DisconnectAsync(YouTubeOwner owner, string connectionId, CancellationToken cancellationToken)
    {
        owner.Validate();
        RequireConfiguration();
        using var lease = await repository.AcquireAsync(owner, cancellationToken);
        var account = lease.ReadAccount(connectionId);
        if (account?.Connected == true)
        {
            await client.RevokeAsync(account.RefreshToken, cancellationToken);
            lease.SaveAccount(account with { Connected = false, AccessToken = "", RefreshToken = "" });
        }
        lease.CancelAuthorizations(connectionId);
        return new(true, false, account?.ChannelId ?? "", account?.ChannelTitle ?? "",
            Mensagem: "Canal desconectado.", ConexaoId: connectionId);
    }

    public async Task<string?> GetAccessTokenAsync(YouTubeOwner owner, string connectionId, string expectedChannelId, CancellationToken cancellationToken)
    {
        owner.Validate();
        if (!options.Configured) return null;
        using var lease = await repository.AcquireAsync(owner, cancellationToken);
        if (string.IsNullOrWhiteSpace(connectionId) || string.IsNullOrWhiteSpace(expectedChannelId)) return null;
        var account = lease.ReadAccount(connectionId);
        if (account == null || !account.Connected || account.ClientId != options.ClientId
            || account.ChannelId != expectedChannelId) return null;
        if (account.ExpiresAtUtc > Now.AddMinutes(2)) return account.AccessToken;
        YouTubeTokens refreshed;
        try { refreshed = await client.RefreshAsync(owner, account.RefreshToken, cancellationToken); }
        catch (YouTubeConnectionException exception) when (exception.AuthorizationRejected)
        {
            lease.SaveAccount(account with { Connected = false, AccessToken = "", RefreshToken = "" });
            throw;
        }
        if (!string.IsNullOrWhiteSpace(refreshed.Scope)) RequireScopes(refreshed.Scope);
        if (string.IsNullOrWhiteSpace(refreshed.AccessToken))
            throw new YouTubeConnectionException("Google nao renovou a autorizacao. Reconecte sua conta.");
        account = account with {
            AccessToken = refreshed.AccessToken, ExpiresAtUtc = refreshed.ExpiresAtUtc,
            RefreshToken = string.IsNullOrWhiteSpace(refreshed.RefreshToken) ? account.RefreshToken : refreshed.RefreshToken
        };
        lease.SaveAccount(account);
        return account.AccessToken;
    }

    private DateTime Now => clock.GetUtcNow().UtcDateTime;
    private YouTubeConnectionStatus Status(YouTubeAccount account)
    {
        var connected = account.Connected && account.ClientId == options.ClientId;
        return new(true, connected, account.ChannelId, account.ChannelTitle,
            Mensagem: connected ? "Canal conectado." : "Canal desconectado. Reconecte para publicar.",
            ConexaoId: account.ConnectionId);
    }
    private void RequireConfiguration()
    {
        if (!options.Configured)
            throw new YouTubeConnectionException("YouTube ainda nao configurado no servidor.");
    }

    private static void RequireScopes(string scope)
    {
        var scopes = scope.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (!scopes.Contains(UploadScope) || !scopes.Contains(ReadScope))
            throw new YouTubeConnectionException("Autorize o envio de videos e a identificacao do canal.");
    }
}
