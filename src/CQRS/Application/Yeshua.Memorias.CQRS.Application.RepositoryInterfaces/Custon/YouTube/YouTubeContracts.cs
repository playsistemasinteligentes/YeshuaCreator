namespace Memorias.YouTube;

public readonly record struct YouTubeOwner(int TenantId, int UserId)
{
    public void Validate()
    {
        if (TenantId <= 0 || UserId <= 0)
            throw new YouTubeConnectionException("Usuario e tenant devem estar autenticados.");
    }
}

public sealed record YouTubeConnectionStatus(
    bool Configurado, bool Conectado, string CanalId = "", string CanalTitulo = "",
    string AuthorizationUrl = "", string Mensagem = "", string ConexaoId = "");

public sealed record YouTubeConnections(bool Configurado, IReadOnlyList<YouTubeConnectionStatus> Conexoes);

public interface IYouTubeConnectionService
{
    Task<YouTubeConnectionStatus> BeginAsync(YouTubeOwner owner, string connectionId, CancellationToken cancellationToken);
    Task<YouTubeConnectionStatus> CompleteAsync(YouTubeOwner owner, string code, string state, CancellationToken cancellationToken);
    Task<YouTubeConnections> ListAsync(YouTubeOwner owner, CancellationToken cancellationToken);
    Task<YouTubeConnectionStatus> StatusAsync(YouTubeOwner owner, string connectionId, CancellationToken cancellationToken);
    Task<YouTubeConnectionStatus> DisconnectAsync(YouTubeOwner owner, string connectionId, CancellationToken cancellationToken);
    Task<string?> GetAccessTokenAsync(YouTubeOwner owner, string connectionId, string expectedChannelId, CancellationToken cancellationToken);
}

public sealed class YouTubeConnectionException(string message, bool authorizationRejected = false) : Exception(message)
{
    public bool AuthorizationRejected { get; } = authorizationRejected;
}

public sealed record YouTubeApplicationConfiguration(string ClientId, string ClientSecret, string EncryptionKey, DateTime UpdatedAtUtc);
public sealed record YouTubeApplicationConfigurationStatus(
    bool PodeConfigurar, bool Configurado, string ClientId = "", string RedirectUri = "",
    bool SegredoSalvo = false, string AtualizadoEmUtc = "");

public interface IYouTubeApplicationConfigurationRepository
{
    YouTubeApplicationConfiguration? Read();
    Task<YouTubeApplicationConfiguration> SaveAsync(string clientId, string clientSecret, CancellationToken cancellationToken);
}

public interface IYouTubeApplicationConfigurationService
{
    YouTubeApplicationConfigurationStatus Read(YouTubeOwner owner);
    Task<YouTubeApplicationConfigurationStatus> SaveAsync(YouTubeOwner owner, string clientId, string clientSecret, CancellationToken cancellationToken);
}

public sealed class YouTubeConfigurationAccessException : Exception
{
    public YouTubeConfigurationAccessException() : base("Configuracao YouTube restrita ao administrador do aplicativo.") { }
}

public sealed record YouTubeAccount(
    string ClientId, string AccessToken, string RefreshToken, DateTime ExpiresAtUtc,
    string ChannelId, string ChannelTitle, string ConnectionId, bool Connected = true);

public sealed record YouTubeAuthorization(
    string State, string CodeVerifier, string RedirectUri, DateTime ExpiresAtUtc, string ClientId,
    string ConnectionId, string ExpectedChannelId);

public interface IYouTubeAccountRepository
{
    Task<IYouTubeAccountLease> AcquireAsync(YouTubeOwner owner, CancellationToken cancellationToken);
    Task<IYouTubeAccountLease> AcquireUploadAsync(YouTubeOwner owner, int publicationId, CancellationToken cancellationToken);
}

public interface IYouTubeAccountLease : IDisposable
{
    IReadOnlyList<YouTubeAccount> ReadAccounts();
    YouTubeAccount? ReadAccount(string connectionId);
    YouTubeAuthorization? ReadAuthorization(string state);
    void SaveAccount(YouTubeAccount account);
    void SaveAuthorization(YouTubeAuthorization authorization);
    void DeleteAuthorization(string state);
    void RemoveExpiredAuthorizations(DateTime now);
    void CancelAuthorizations(string connectionId);
    YouTubeUploadState? ReadUpload(int publicationId);
    void SaveUpload(YouTubeUploadState state);
}

public sealed record YouTubeUploadState(
    int PublicationId, string ConnectionId, string ChannelId, string StorageKey,
    long Length, string Sha256, string SessionUri, string VideoId = "");

public sealed record YouTubeVideoUpload(
    YouTubeOwner Owner, int PublicationId, string ConnectionId, string ChannelId,
    string StorageKey, string Title, string Description, string Privacy);

public interface IYouTubeVideoUploader
{
    Task<string> UploadAsync(YouTubeVideoUpload upload, Stream video, CancellationToken cancellationToken);
}

public sealed class YouTubeUploadReviewException(string message) : Exception(message);

public sealed record YouTubeAuthorizationRequest(string Url, string CodeVerifier);
public sealed record YouTubeTokens(string AccessToken, string RefreshToken, DateTime ExpiresAtUtc, string Scope);
public sealed record YouTubeChannel(string Id, string Title);

public interface IYouTubeOAuthClient
{
    YouTubeAuthorizationRequest CreateAuthorization(string state);
    Task<YouTubeTokens> ExchangeAsync(YouTubeOwner owner, string code, string verifier, string redirectUri, CancellationToken cancellationToken);
    Task<YouTubeTokens> RefreshAsync(YouTubeOwner owner, string refreshToken, CancellationToken cancellationToken);
    Task<YouTubeChannel> ReadChannelAsync(string accessToken, CancellationToken cancellationToken);
    Task RevokeAsync(string token, CancellationToken cancellationToken);
}
