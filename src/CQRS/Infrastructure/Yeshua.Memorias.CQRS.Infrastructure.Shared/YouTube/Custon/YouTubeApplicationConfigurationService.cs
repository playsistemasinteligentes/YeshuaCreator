namespace Memorias.YouTube;

public sealed class YouTubeApplicationConfigurationService(
    YouTubeOptions baseline, IYouTubeApplicationConfigurationRepository repository) : IYouTubeApplicationConfigurationService
{
    private bool CanConfigure(YouTubeOwner owner) => baseline.ConfigurationAdminTenantId > 0
        && baseline.ConfigurationAdminUserId > 0 && owner.TenantId == baseline.ConfigurationAdminTenantId
        && owner.UserId == baseline.ConfigurationAdminUserId;

    public YouTubeApplicationConfigurationStatus Read(YouTubeOwner owner)
    {
        owner.Validate();
        if (!CanConfigure(owner)) return new(false, false);
        var configuration = repository.Read();
        return Status(configuration);
    }

    public async Task<YouTubeApplicationConfigurationStatus> SaveAsync(
        YouTubeOwner owner, string clientId, string clientSecret, CancellationToken cancellationToken)
    {
        owner.Validate();
        if (!CanConfigure(owner)) throw new YouTubeConfigurationAccessException();
        clientId = (clientId ?? "").Trim();
        clientSecret = (clientSecret ?? "").Trim();
        if (clientId.Length is < 25 or > 256 || !clientId.EndsWith(".apps.googleusercontent.com", StringComparison.Ordinal)
            || clientId.Any(character => !(char.IsAsciiLetterOrDigit(character) || character is '-' or '.')))
            throw new YouTubeConnectionException("Client ID OAuth Web invalido.");
        var current = repository.Read();
        var existingId = current?.ClientId ?? baseline.ClientId;
        if (!string.IsNullOrWhiteSpace(existingId) && clientId != existingId)
            throw new YouTubeConnectionException("O Client ID ja esta vinculado ao aplicativo. A troca exige revisao das conexoes existentes.");
        var effectiveSecret = string.IsNullOrEmpty(clientSecret) ? current?.ClientSecret ?? baseline.ClientSecret : clientSecret;
        if (effectiveSecret.Length is < 8 or > 512 || effectiveSecret.Any(character => character < '!' || character > '~'))
            throw new YouTubeConnectionException("Informe um Client Secret OAuth valido.");
        if (!baseline.InfrastructureConfigured) throw new YouTubeConnectionException("Infraestrutura privada ou endereco de retorno YouTube nao configurado.");
        return Status(await repository.SaveAsync(clientId, clientSecret, cancellationToken));
    }

    private YouTubeApplicationConfigurationStatus Status(YouTubeApplicationConfiguration? configuration)
    {
        var options = baseline.Snapshot(configuration);
        return new(true, options.Configured, options.ClientId, options.RedirectUri,
            !string.IsNullOrEmpty(options.ClientSecret), configuration?.UpdatedAtUtc.ToString("O") ?? "");
    }
}
