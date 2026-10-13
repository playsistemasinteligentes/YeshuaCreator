using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shared.Operational;

namespace Memorias.YouTube;

public static class YouTubeRegistration
{
    public const string UploadClient = "Memorias.YouTube.Upload";

    public static IServiceCollection AddMemoriasYouTube(this IServiceCollection services, IConfiguration configuration)
    {
        var options = new YouTubeOptions();
        configuration.GetSection("MemoriasYouTube").Bind(options);
        options.ProcessingScope = configuration["YeshuaProcessing:Scope"] ?? "";
        services.AddSingleton(options);
        services.TryAddSingleton(TimeProvider.System);
        services.AddSingleton<IYouTubeAccountRepository, EncryptedYouTubeAccountRepository>();
        services.AddScoped<IYouTubeOAuthClient, GoogleYouTubeOAuthClient>();
        services.AddScoped<IYouTubeConnectionService, YouTubeConnectionService>();
        services.AddScoped<IYouTubeVideoUploader, ResumableYouTubeVideoUploader>();
        services.AddHttpClient(UploadClient, client => client.Timeout = TimeSpan.FromMinutes(30))
            .RemoveAllLoggers()
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { AllowAutoRedirect = false })
            .AddHttpMessageHandler<OperationalHttpTelemetryHandler>();
        return services;
    }
}
