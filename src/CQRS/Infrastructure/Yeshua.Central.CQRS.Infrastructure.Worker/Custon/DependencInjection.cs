namespace Worker.Custon;

using Central.Infrastructure.OutboxDelivery;
using Command.Patterns.OutBox;
using Shared.Operational;

public static class CustonDependenceInjection
{
    public static void MapCustonDependenceInjection(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<Command.Patterns.FileUpload.UploadTokenHelper>(_ =>
            new(builder.Configuration["UploadTokens:SigningKey"] ?? string.Empty));
        if (!Enum.TryParse<TranscriptionDeliveryProvider>(
                builder.Configuration["CentralTranscription:Provider"] ?? "OpenAI", true, out var provider)
            || !Enum.IsDefined(provider))
            throw new InvalidOperationException("CentralTranscription:Provider deve ser OpenAI, Queue ou Groq.");
        builder.Services.AddSingleton(new CentralTranscriptionOptions
        {
            Provider = provider,
            ApiKey = builder.Configuration["CentralTranscription:ApiKey"] ?? "",
            Model = builder.Configuration["CentralTranscription:Model"] ?? "gpt-transcribe",
            BaseUrl = builder.Configuration["CentralTranscription:BaseUrl"] ?? "https://api.openai.com/v1",
            Groq = new GroqTranscriptionOptions
            {
                ApiKey = builder.Configuration["CentralTranscription:Groq:ApiKey"] ?? "",
                Model = builder.Configuration["CentralTranscription:Groq:Model"] ?? "whisper-large-v3-turbo",
                BaseUrl = builder.Configuration["CentralTranscription:Groq:BaseUrl"] ?? "https://api.groq.com/openai/v1"
            },
            StorageRoot = builder.Configuration["Storage:Providers:Disk:Root"] ?? "/storage",
            FFmpegExecutable = builder.Configuration["CentralTranscription:FFmpegExecutable"] ?? "ffmpeg"
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
