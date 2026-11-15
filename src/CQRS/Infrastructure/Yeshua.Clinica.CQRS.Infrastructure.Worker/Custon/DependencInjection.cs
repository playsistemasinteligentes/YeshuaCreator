namespace Worker.Custon;

using Clinica.Infrastructure.OutboxDelivery;
using Command.Patterns.OutBox;
using Shared.Operational;

public static class CustonDependenceInjection
{
    public static void MapCustonDependenceInjection(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<Command.Receivers.Custon.UseCases.FileUpload.Infra.UploadTokenHelper>(_ =>
            new(builder.Configuration["UploadTokens:SigningKey"] ?? string.Empty));
        if (!Enum.TryParse<TranscriptionDeliveryProvider>(
                builder.Configuration["ClinicaTranscription:Provider"] ?? "OpenAI", true, out var provider)
            || !Enum.IsDefined(provider))
            throw new InvalidOperationException("ClinicaTranscription:Provider deve ser OpenAI, Groq ou Queue.");
        builder.Services.AddSingleton(new ClinicaTranscriptionOptions
        {
            Provider = provider,
            ApiKey = builder.Configuration["ClinicaTranscription:ApiKey"] ?? "",
            Model = builder.Configuration["ClinicaTranscription:Model"] ?? "gpt-transcribe",
            BaseUrl = builder.Configuration["ClinicaTranscription:BaseUrl"] ?? "https://api.openai.com/v1",
            GroqApiKey = builder.Configuration["ClinicaTranscription:Groq:ApiKey"] ?? "",
            GroqModel = builder.Configuration["ClinicaTranscription:Groq:Model"] ?? "whisper-large-v3-turbo",
            GroqBaseUrl = builder.Configuration["ClinicaTranscription:Groq:BaseUrl"] ?? "https://api.groq.com/openai/v1",
            StorageRoot = builder.Configuration["Storage:Providers:Disk:Root"] ?? "/storage",
            FFmpegExecutable = builder.Configuration["ClinicaTranscription:FFmpegExecutable"] ?? "ffmpeg"
        });
        builder.Services.AddTransient<QueueOutboxDeliveryStrategy>();
        builder.Services.AddHttpClient<OpenAITranscriptionDeliveryStrategy>(client =>
            client.Timeout = Timeout.InfiniteTimeSpan)
            .AddHttpMessageHandler<OperationalHttpTelemetryHandler>();
        builder.Services.AddHttpClient<GroqTranscriptionDeliveryStrategy>(client =>
            client.Timeout = Timeout.InfiniteTimeSpan)
            .AddHttpMessageHandler<OperationalHttpTelemetryHandler>();
        builder.Services.AddScoped<IOutboxDeliveryFactory, TranscriptionDeliveryFactory>();
    }
}
